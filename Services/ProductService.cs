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
                .FirstOrDefault(p=>p.Guid==id);
        }

        public void Add(Product product)
        {
            Product product1 = CheckAddFails(product);
            if (product1==null) return;
            Db.Products.Add(product1);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = Get(id);
            if (product.Guid != id) return;
            Db.Products.Remove(product);
            Db.SaveChanges();
        }

        private Product CheckAddFails(Product product)
        {
            Product product1 = product;
            if (product1.Name == null) return null;
            else if (product1.Price < 0) return null;
            else
            {
                product1.Offset = DateTime.Now;
                return product1;
            }
        }
    }
}
