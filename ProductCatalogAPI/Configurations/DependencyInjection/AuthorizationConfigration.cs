namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class AuthorizationConfigration
    {
        public static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(c =>
            {
                c.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireRole("Admin");
                });


            });
            return services;
        }
    }
}
