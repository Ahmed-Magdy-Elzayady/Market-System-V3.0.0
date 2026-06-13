using MarketSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Data.ApplicationContext
{
    public class MarketSystemContext : IdentityDbContext<ApplicationUser, IdentityRole,string>
    {
        public MarketSystemContext(DbContextOptions<MarketSystemContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(MarketSystemContext).Assembly);
            List<ProductModel> _products = new List<ProductModel>()
            {
                new ProductModel { Id = 1, Title = "iPhone 15 Pro", Description = "Apple iPhone 15 Pro 256GB Titanium", Price = 1200.00, UnitOFStock = 15, CategoryModelId = 1 },
                new ProductModel { Id = 2, Title = "Samsung Galaxy S24 Ultra", Description = "Samsung Galaxy S24 Ultra 512GB Titanium Gray", Price = 1300.50, UnitOFStock = 8, CategoryModelId = 1 },
                new ProductModel { Id = 3, Title = "Dell XPS 15", Description = "Dell XPS 15 Laptop Intel Core i9 32GB RAM 1TB SSD", Price = 2100.00, UnitOFStock = 5, CategoryModelId = 2 },
                new ProductModel { Id = 4, Title = "MacBook Air M3", Description = "Apple MacBook Air 13-inch M3 Chip 16GB RAM", Price = 1400.00, UnitOFStock = 12, CategoryModelId = 2 },
                new ProductModel { Id = 5, Title = "LG OLED TV 55", Description = "LG OLED C3 Series 55-Inch 4K Smart TV", Price = 1500.00, UnitOFStock = 4, CategoryModelId = 3 },
                new ProductModel { Id = 6, Title = "Sony PlayStation 5", Description = "Sony PlayStation 5 Console Digital Edition", Price = 500.00, UnitOFStock = 20, CategoryModelId = 3 },
                new ProductModel { Id = 7, Title = "AirPods Pro 2", Description = "Apple AirPods Pro (2nd Generation) Wireless Earbuds", Price = 250.00, UnitOFStock = 35, CategoryModelId = 4 },
                new ProductModel { Id = 8, Title = "Samsung T7 SSD", Description = "Samsung T7 Shield 2TB Portable External SSD", Price = 180.75, UnitOFStock = 50, CategoryModelId = 4 },
                new ProductModel { Id = 9, Title = "Logitech MX Master 3S", Description = "Logitech MX Master 3S Wireless Performance Mouse", Price = 100.00, UnitOFStock = 25, CategoryModelId = 4 },
                new ProductModel { Id = 10, Title = "Asus ROG Swift", Description = "Asus ROG Swift 27-Inch 1440p Gaming Monitor", Price = 650.00, UnitOFStock = 6, CategoryModelId = 3 }
        };

            List<CategoryModel> _categories = new List<CategoryModel>()
                {
                new CategoryModel { Id = 1, Name = "Smartphones" },
                new CategoryModel { Id = 2, Name = "Laptops" },
                new CategoryModel { Id = 3, Name = "Electronics & Gaming" },
                new CategoryModel { Id = 4, Name = "Accessories" }
            };

            builder.Entity<ProductModel>().HasData(_products);
            builder.Entity<CategoryModel>().HasData(_categories);



            base.OnModelCreating(builder);
        }

        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<CategoryModel> Categories { get; set; }

    }


}
