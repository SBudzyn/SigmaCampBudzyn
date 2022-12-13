using Homework8;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    internal class OrderAnalyzer : IAnalyzer
    {
        public event Action<string, Order> OrderFailed;

        public string Analyze(string fileName, Storage storage)
        {
            string response = string.Empty;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] currStr = reader.ReadLine()!.Split(',', StringSplitOptions.TrimEntries);
                    Order order;
                    if (currStr[0] != null && currStr[1] != null && currStr[2] != null)
                    {
                        uint.TryParse(currStr[2], out uint quant);
                        order = new Order(currStr[0], currStr[1], quant);
                    }
                    else
                    {
                        response += "Order failed\n";
                        continue;
                    }

                    if (storage.GetNumberOfProducts(order.ProductName) >= order.Quantity)
                    {
                        response += $"Order from company {order.CompanyName} ({order.ProductName} {order.Quantity}) can be resolved\n";
                    }
                    else
                    {
                        response += $"Order from company {order.CompanyName} ({order.ProductName} {order.Quantity}) can`t be resolved (more info in result.txt\n)";
                        OrderFailed?.Invoke(fileName, order);
                    }
                   
                }
                return response;
            }
        }
        
    }
}
