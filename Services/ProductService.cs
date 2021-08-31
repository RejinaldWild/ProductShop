using System;
using System.Collections.Generic;
using System.Linq;
using ProductShop.Models;

namespace ProductShop.Service
{
    public class ProductService
    {
        private readonly ProductShopDbContext Db;
        public ProductService(ProductShopDbContext db)
        {
            Db = db;
        }

        public ICollection<Product> GetAll()
        {
            return Db.Products
                .ToList();
        }

        public Product Get(int id)
        {
            return Db.Products
                .FirstOrDefault(p => p.Guid == id);
        }

        public void Add(Product product)
        {
            CheckAddFails(product);
            Db.Products.Add(product);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = Get(id);
            if (product.Guid != id) return;
            Db.Products.Remove(product);
            Db.SaveChanges();
        }

        private void CheckAddFails(Product product)
        {
            if (product.Name == null) return;
            else if (product.Price < 0) return;
            else product.Offset = DateTime.Now;
        }
    }
}
