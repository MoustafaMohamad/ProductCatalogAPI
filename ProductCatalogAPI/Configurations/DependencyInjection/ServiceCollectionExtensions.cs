

namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<CancellationTokenCaptureMiddleware>();
            services.AddScoped<CancellationTokenAccessor>();
            services.AddScoped<RequestParameters>();
            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped<ValidationExceptionHandlingMiddleware>();

            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            //services.AddScoped<IJwtService, JwtService>();


            // HttpContext

            return services;
        }
    }
}
