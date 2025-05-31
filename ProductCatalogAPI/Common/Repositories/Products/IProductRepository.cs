namespace ProductCatalogAPI.Common.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> ProductNameIsExistAsync(string name);
        Task<bool> IsProductExistAsync(Guid id);
        IQueryable<Product> GetProductsByCategory(Guid categoryId);
    }
}
