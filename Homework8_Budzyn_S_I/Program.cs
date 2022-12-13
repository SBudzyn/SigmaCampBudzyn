using Homework5;
using Microsoft.Extensions.Configuration;

namespace Homework8
{
    class Program
    {
        public static void Main(string[] args)
        {
            Storage storage1 = new Storage();

            Product product1 = new("apples first sort", 12, 12);
            Product product2 = new("pineapples second sort", 13, 13);
            Product product3 = new("goat milk", 10, 10);
            Product product4 = new("pork", 12, 12);
            Product product5 = new("bread", 13, 13);
            Product product6 = new("beef", 10, 10);

            storage1.AddProducts(product1, product1, product1, product2, product2, product2, product3, product4, product5, product6);

            IAnalyzer analyzer = new OrderAnalyzer();
            analyzer.OrderFailed += FailedOrderHandler;
            analyzer.Analyze(@"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework8_Budzyn_S_I\orders.txt", storage1);

           

           
        }
        public static void FailedOrderHandler(string path, Order order)
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
