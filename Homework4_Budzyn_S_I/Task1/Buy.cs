using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal class Buy : ICloneable, IComparable
    {
        private Product _product = null!;
        public Buy(Product product, int amount = 1)
        {
            _product = product;
            Amount = amount;
        }

        public string ProductName
        {
            get { return _product.Name; }
        }
        public decimal ProductPrice
        {
            get { return _product.Price; }
        }
        public float ProductWeight
        {
            get { return _product.Weight; }
        }
        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The amount can`t be less than 1");
                }
                _amount = value;
            }
        }
        public decimal CalculatePrice()
        {
            return Amount * ProductPrice;
        }

        public object Clone()
        {
            Buy buy = (Buy)this.MemberwiseClone();
            Product productToCopy = this._product;
            buy._product = new Product(productToCopy.Name, productToCopy.Price, productToCopy.Weight);
            return buy;
        }

        public override string ToString()
        {
            return $"You are to buy {ProductName}";
        }

        public int CompareTo(object? obj)
        {
            Buy? buy = obj as Buy;
            if (buy == null)
                throw new ArgumentException("Wrong parameter");
            if (buy.CalculatePrice() < this.CalculatePrice())
            {
                return 1;
            }
            else if (buy.CalculatePrice() == this.CalculatePrice())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
