using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class Order
    {
        public Order(string companyName, string productName, uint quantity)
        {
            CompanyName = companyName;
            ProductName = productName;
            Quantity = quantity;
        }
       
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public uint Quantity { get; set; }
    }
}
