using Microsoft.EntityFrameworkCore;
using EfCoreProject.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreProject.Infrustructure.EfCore
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ProductId");
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(200);

            builder.HasOne(p => p.ProductCategory).WithMany(pc => pc.Products).HasForeignKey(p => p.ProductCategoryId);
        }
    }
}
