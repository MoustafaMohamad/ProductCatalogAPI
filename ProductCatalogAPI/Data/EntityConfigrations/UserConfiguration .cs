using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductCatalogAPI.Data.EntityConfigrations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IPasswordHasher _passwordHasher = new PasswordHasher();
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();
            var adminUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            builder.HasData(
                new User
                {
                    Id = adminUserId,
                    Username = "admin",
                    Name = "Administrator",
                    Email = "admin@example.com",
                    PasswordHash = _passwordHasher.Hash("Admin@123"),
                    Role = Role.Admin,
                    IsDeleted = false
                });

            builder.HasIndex(u => u.Username)
                   .IsUnique();

            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
