using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Product
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public Product(string name, decimal price, float weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return $"Product {Name}, Price - {Price}";
        }
    }
}
