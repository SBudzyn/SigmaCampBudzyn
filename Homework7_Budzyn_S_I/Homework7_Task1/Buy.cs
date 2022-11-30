using Homework7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class Buy : ICloneable
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
        public decimal CalculatePrice(Currencies currency = Currencies.UAH)
        {
            if (currency == Currencies.USD)
            {
                return Amount * ProductPrice / Constants.USD;
            }
            else if (currency == Currencies.EUR)
            {
                return Amount * ProductPrice / Constants.EUR;
            }
            else if (currency == Currencies.GBP)
            {
                return Amount * ProductPrice / Constants.GBP;
            }
            else
            {
                return Amount * ProductPrice;
            }

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
    }
}
