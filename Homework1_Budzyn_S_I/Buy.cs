using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Buy
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
        public int Amount { get; set; }
        public decimal CalculatePrice()
        {
            return Amount * ProductPrice;
        }
        public override string ToString()
        {
            return $"You are to buy {ProductName}";
        }
    }
}
