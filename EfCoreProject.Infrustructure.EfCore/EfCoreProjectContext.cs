using System;
using Microsoft.EntityFrameworkCore;
using EfCoreProject.Domain.ProductCategoryAgg;
using EfCoreProject.Domain.ProductAgg;
namespace EfCoreProject.Infrustructure.EfCore
{
    public class EfCoreProjectContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public EfCoreProjectContext(DbContextOptions options):base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(ProductCategoryMapping));
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
