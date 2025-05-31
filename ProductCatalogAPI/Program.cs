using Microsoft.OpenApi.Models;
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer abcdefghijklmnopqrstuvwxyz\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });

            });

            builder.Services
                .AddFluentValidation(Assembly.GetExecutingAssembly())
                .AddMediatR()
                .AddApplicationServices()
                .AddAuthenticationConfiguration(builder.Configuration)
                .AddAuthorizationConfiguration();


            builder.Logging.ClearProviders();

            #region Serilog Configuration 
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
               .WriteTo.MSSqlServer(connectionString: configuration.GetConnectionString("DefaultConnection"), restrictedToMinimumLevel: LogEventLevel.Warning,
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
            //app.UseMiddleware<CancellationTokenCaptureMiddleware>();


            app.UseHttpsRedirection();



            app.MapControllers();

            app.Run();
        }
    }
}
