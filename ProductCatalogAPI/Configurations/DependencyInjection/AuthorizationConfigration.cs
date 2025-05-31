namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class AuthorizationConfigration
    {
        public static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization();
            return services;
        }
    }
}
