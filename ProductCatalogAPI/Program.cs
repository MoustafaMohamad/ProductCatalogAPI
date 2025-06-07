using ProductCatalogAPI.Configurations.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace ProductCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            builder.Services
                .AddFluentValidation(Assembly.GetExecutingAssembly())
                .AddMediatRConfigration()
                .AddAutoMapper(typeof(ProductProfile))
                .AddDBContext(builder.Configuration)
                .AddApplicationServices()
                .AddAuthenticationConfiguration(builder.Configuration)
                .AddAuthorizationConfiguration()
                .AddSwaggerConfiguration();


            builder.Logging.ClearProviders();

            #region Serilog Configuration 
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
               .WriteTo.MSSqlServer(connectionString: configuration.GetConnectionString("DefaultConnection"), restrictedToMinimumLevel: LogEventLevel.Information,
               sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true, AutoCreateSqlDatabase = true })
               .WriteTo.Seq("http://localhost:5341/")
               .CreateLogger();

            builder.Host.UseSerilog();
            #endregion


            var app = builder.Build();
            MapperHelper.Mapper = app.Services.GetService<IMapper>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<UserStateMiddleware>();
            app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
            app.UseMiddleware<CancellationTokenCaptureMiddleware>();


            app.UseHttpsRedirection();



            app.MapControllers();

            app.Run();
        }
    }
}
