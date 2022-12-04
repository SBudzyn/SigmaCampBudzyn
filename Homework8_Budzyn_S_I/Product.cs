using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    enum Currencies
    {
        UAH,
        USD,
        EUR,
        GBP
    }
    enum WeightUnits
    {
        Gram,
        Kilogram
    }
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
        public Product(string name, decimal price, float weight, Currencies currency = Currencies.UAH, WeightUnits unit = WeightUnits.Kilogram)
        {
            if (currency == Currencies.USD)
            {
                price *= Constants.USD;
            }
            else if (currency == Currencies.EUR)
            {
                price *= Constants.EUR;
            }
            else if (currency == Currencies.GBP)
            {
                price *= Constants.GBP;
            }

            if (unit == WeightUnits.Gram)
            {
                weight *= Constants.Gram;
            }
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
