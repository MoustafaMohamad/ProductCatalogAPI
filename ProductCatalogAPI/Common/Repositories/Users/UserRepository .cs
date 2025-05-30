
namespace ProductCatalogAPI.Common.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CancellationToken cancellationToken;
        private readonly Context _context;
        public UserRepository(Context context, CancellationTokenAccessor cancellationTokenAccessor) : base(context, cancellationTokenAccessor)
        {
            _context = context;
            cancellationToken = cancellationTokenAccessor.Token;
        }

        public async Task<bool> EmailIsExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> UsernameIsExistAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username, cancellationToken);
        }
    }
}
