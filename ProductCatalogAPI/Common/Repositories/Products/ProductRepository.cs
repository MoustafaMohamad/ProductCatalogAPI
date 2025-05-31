
namespace ProductCatalogAPI.Common.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private CancellationToken cancellationToken;
        private readonly Context _context;
        public ProductRepository(Context context, CancellationTokenAccessor cancellationTokenAccessor) : base(context, cancellationTokenAccessor)
        {
            _context = context;
            cancellationToken = cancellationTokenAccessor.Token;
        }
        public async Task<bool> ProductNameIsExistAsync(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name, cancellationToken);
        }

        public async Task<bool> IsProductExistAsync(Guid id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id, cancellationToken);
        }

        public IQueryable<Product> GetProductsByCategory(Guid categoryId)
        {
            return GetAll().Where(p => p.CategoryId == categoryId);
        }

    }
}
