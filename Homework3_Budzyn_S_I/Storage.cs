using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Storage
    {
        private List<Product> _products = null!;
        public Storage(params Product[] products)
        {
            _products = new List<Product>(products);
        }
        public Product this[int index]
        {
            get
            {
                return _products[index];
            }
        }
        public void DialogInitialization()
        {
            while (true)
            {
                Console.WriteLine("Press q to quit");
                if (Console.ReadLine() == "q")
                {
                    break;
                }
                Console.WriteLine("Enter product name");
                string? name = Console.ReadLine();
                if (name == null)
                {
                    Console.WriteLine("Empty name");
                    continue;
                }
                Console.WriteLine("Enter product price");
                decimal.TryParse(Console.ReadLine(), out decimal price);
                if (price == 0)
                {
                    Console.WriteLine("Wrong price");
                }
                Console.WriteLine("Enter product weight");
                float.TryParse(Console.ReadLine(), out float weight);
                if (weight == 0)
                {
                    Console.WriteLine("Wrong weight");
                }
                Console.WriteLine("Enter expiration date (in dd/mm/yyyy format) or skip");
                bool isDateParsed = DateOnly.TryParse(Console.ReadLine(), out DateOnly date);
                if (isDateParsed == false)
                {
                    Product product = new Product(name, price, weight);
                    _products.Add(product);
                    continue;
                }
                Console.WriteLine("Enter meat type");
                bool isTypeParsed = Enum.TryParse(Console.ReadLine(), out Type type);
                Console.WriteLine("Enter meat category");
                bool isCategoryParsed = Enum.TryParse(Console.ReadLine(), out Category category);

                if (isTypeParsed == false || isCategoryParsed == false)
                {
                    DiaryProduct product = new DiaryProduct(name, price, weight, date);
                    _products.Add(product);
                    continue;
                }
                else
                {
                    Meat meat = new Meat(name, price, weight, date, category, type);
                    _products.Add(meat);
                }
                
            }
        }
        public void AddProduct(string name, decimal price, float weight, DateOnly? date = null, Type? type = null, Category? category = null)
        {
            Product product;
            
            if (type == null || category == null || date == null )
            {
                if (date == null)
                {
                    product = new Product(name, price, weight);
                }
                else
                {
                    product = new DiaryProduct(name, price, weight, (DateOnly)date);
                }
            }
            else
            {               
                product = new Meat(name, price, weight, (DateOnly)date, (Category)category, (Type)type);
            }
            _products.Add(product);
        }
        public void PrintEverything()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"Name - {product.Name}, Price - {product.Price}, Weight - {product.Weight}");
            }
        }
        public Meat[] FindMeatProducts()
        {
            List<Meat> meatList = new List<Meat>();
            foreach (var product in _products)
            {
                Meat? meat = product as Meat;
                if (meat != null)
                    meatList.Add(meat);
            }
            return meatList.ToArray();
        }
        public void ChangePriceForAll(decimal percent)
        {
            foreach (var product in _products)
            {
                product.ChangePrice(percent);
            }
        }
    }
}
