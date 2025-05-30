namespace ProductCatalogAPI.Common.Helpers.PasswordHasherHelper
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
