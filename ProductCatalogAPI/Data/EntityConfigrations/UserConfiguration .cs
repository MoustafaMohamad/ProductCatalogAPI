using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductCatalogAPI.Data.EntityConfigrations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
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



            builder.HasIndex(u => u.Username)
                   .IsUnique();

            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
