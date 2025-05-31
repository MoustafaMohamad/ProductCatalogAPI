
namespace ProductCatalogAPI.Common.Repositories.Categories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly CancellationToken cancellationToken;
        private readonly Context _context;
        public CategoryRepository(Context context, CancellationTokenAccessor cancellationTokenAccessor) : base(context, cancellationTokenAccessor)
        {
            cancellationToken = cancellationTokenAccessor.Token;
            _context = context;
        }

        public async Task<bool> IsCategoryExistsAsync(Guid id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id, cancellationToken);
        }
    }
}
