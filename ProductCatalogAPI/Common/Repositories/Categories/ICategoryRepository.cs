namespace ProductCatalogAPI.Common.Repositories.Categories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> IsCategoryExistsAsync(Guid id);
    }

}
