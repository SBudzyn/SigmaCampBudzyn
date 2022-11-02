using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
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
        public override string ToString()
        {
            return $"Product {Name}, Price - {Price}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
