using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductCatalogAPI.Data.EntityConfigrations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(
           new Category { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Electronics", IsDeleted = false },
           new Category { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Books", IsDeleted = false },
           new Category { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Clothing", IsDeleted = false },
           new Category { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Home Appliances", IsDeleted = false },
           new Category { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Toys", IsDeleted = false },
           new Category { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Sports", IsDeleted = false }
       );
        }
    }
}
