using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Product : ICloneable
    {
        public string Name { get; private set; }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be more than 0");
                }
                else
                    _price = value;
            }
        }
        private float _weight;
        public float Weight
        {
            get => _weight;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight must be more than 0");
                }
                else
                    _weight = value;
            }
        }
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

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
