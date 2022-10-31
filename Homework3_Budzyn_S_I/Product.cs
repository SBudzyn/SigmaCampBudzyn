using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Product
    {
        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }
        public float Weight { get; }
        public Product(string name, decimal price, float weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }
        public virtual void ChangePrice(decimal changePercent)
        {
            Price += Price * (changePercent / 100);
        }
        public override string ToString()
        {
            return $"Product {Name}, Price - {Price}";
        }
        public override bool Equals(object? obj)
        {
            Product? product = obj as Product;
            if (product == null)
            {
                return false;
            }
            if (product.Name == this.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
