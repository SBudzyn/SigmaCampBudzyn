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
        private event Action<string, Order> OrderFailed;

        public string Analyze(string fileName, Storage storage)
        {
            OrderFailed += FailedOrderHandler;
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
        private void FailedOrderHandler(string path, Order order)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());           
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var pathForSimilar = config.GetSection("pathForSimilarProducts").Value!;
            using (StreamWriter writer = new StreamWriter("C:\\Users\\LapStore\\OneDrive\\Рабочий стол\\Sigma Camp\\Homework8_Budzyn_S_I\\result.txt", true))
            {
                using (StreamReader reader = new StreamReader(pathForSimilar))
                {
                    while (!reader.EndOfStream)
                    {
                        var currItems = reader.ReadLine()!.Split(',', StringSplitOptions.TrimEntries)!;
                        if (currItems[0] == order.ProductName)
                        {
                            writer.WriteLine($"Unable to resolve order from {order.CompanyName} with {order.ProductName} - {order.Quantity} items. You can replace it with: ");
                            foreach (var item in currItems.Skip(1))
                            {
                                writer.Write($"{item}, ");
                            }
                            writer.Write("\n");
                            break;
                        }
                    }
                }
            }
        }
    }
}
