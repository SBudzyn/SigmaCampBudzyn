using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal static class Check
    {
        public static void DisplayProduct(Product product)
        {
            Console.WriteLine($"Product: Name - {product.Name}, Price - {product.Price}, Weight - {product.Weight}");
        }
        public static void DisplayBuy(Buy buy)
        {
            string productName = buy.ProductName;
            if (buy.Amount > 1)
            {
                productName += "s";
            }
            Console.WriteLine($"You are buying {buy.Amount} {productName}. Total price is {buy.CalculatePrice()}");
        }

    }
}
