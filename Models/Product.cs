using System;

namespace ProductShop.Models
{
    public class Product
    {
        public int Guid { get; set; }
        public string Name { get; set; }
        public string Descripion { get; set; }
        public decimal Price { get; set; }
        public DateTime Offset { get; set; }
    }
}
