

namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class AutomapperConfigration
    {
        public static IServiceCollection AddAutomapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
            return services;
        }
    }
}
