using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BusinessObjects
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "Seafood" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, ProductName = "coca", UnitsInStock = 1000, UnitPrice = 10_000m },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "pepsi", UnitsInStock = 1000, UnitPrice = 10_000m },
                new Product { ProductId = 3, CategoryId = 8, ProductName = "crab", UnitsInStock = 1000, UnitPrice = 1_000_000m },
                new Product { ProductId = 4, CategoryId = 6, ProductName = "beef", UnitsInStock = 1000, UnitPrice = 200_000m }
                );
        }
    }
}