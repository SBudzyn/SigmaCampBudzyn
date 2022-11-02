using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Cart
    {
        private List<Buy> _purchases = new List<Buy>();
        public Cart()
        {

        }
        public Cart(params Buy[] purchases)
        {
            foreach (var purchase in purchases)
            {
                var buy = purchase.Clone() as Buy;
                if (buy != null)
                {
                    _purchases.Add(buy);
                }
                
            }
        }
        public Cart(Product product, int amount)
        {
            if (product.Clone() is Product clonedProduct)
            {
                Buy purchase = new Buy(clonedProduct, amount);
                _purchases.Add(purchase);
            }
        }
        public decimal CalculatePrice()
        {
            decimal sum = 0;
            foreach (var purchase in _purchases)
            {
                sum += purchase.CalculatePrice();
            }
            return sum;
        }
        public void AddPurchase(Buy buy)
        {
            if (buy.Clone() is Buy clonedBuy)
            {
                _purchases.Add(clonedBuy);
            }
        }
        public void AddPurchases(params Buy[] purchases)
        {
            foreach (var purchase in purchases)
            {
                if (purchase.Clone() is Buy clonedPurchase)
                {
                    _purchases.Add(clonedPurchase);
                }
            }
        }
        public override string ToString()
        {
            return $"Storage with purchases ({_purchases.Count()} items)";
        }
        
    }
}
