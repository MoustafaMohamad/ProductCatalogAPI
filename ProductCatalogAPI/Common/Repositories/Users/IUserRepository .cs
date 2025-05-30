namespace ProductCatalogAPI.Common.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> EmailIsExistAsync(string email);
        Task<bool> UsernameIsExistAsync(string username);
    }
}
