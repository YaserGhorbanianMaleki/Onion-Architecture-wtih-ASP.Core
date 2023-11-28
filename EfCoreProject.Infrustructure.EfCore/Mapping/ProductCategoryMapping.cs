using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreProject.Domain.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreProject.Infrustructure.EfCore
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Name).IsRequired(true).HasMaxLength(200);

            builder.HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);
        }
    }
}
