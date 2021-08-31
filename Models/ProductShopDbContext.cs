using System;
using Microsoft.EntityFrameworkCore;

namespace ProductShop.Models
{
    public class ProductShopDbContext : DbContext
    {
        public string DbPath { get; private set; }
        public ProductShopDbContext(DbContextOptions<ProductShopDbContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}ProductDb.db";


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=productshopdb;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
