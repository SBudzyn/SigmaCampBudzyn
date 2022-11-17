using Homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    
    enum ProductType
    {
        Product,
        Meat,
        Diary
    }
    internal class Storage
    {
        private List<Product> _products = new List<Product>();
        public Storage()
        {
            
        }
        public Storage(params Product[] products)
        {
            _products = new List<Product>(products);
        }
        public Product this[int index]
        {
            get
            {
                if (_products[index] is Meat meat)
                {
                    return (Meat)meat.Clone();
                }
                else if (_products[index] is DairyProduct diary)
                {
                    return (DairyProduct)diary.Clone();
                }
                else
                {
                    return (Product)_products[index].Clone();
                }
                
            }
        }
        // Прив'язка до консолі в модельному класі!!!!
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
                Console.WriteLine("Enter currency (Possible options UAH, USD, EUR, GBP)");
                var currency = Console.ReadLine();  
                if (currency.Equals("USD", StringComparison.OrdinalIgnoreCase))
                {
                    price *= Constants.USD;
                }
                else if (currency.Equals("EUR", StringComparison.OrdinalIgnoreCase))
                {
                    price *= Constants.EUR;
                }
                else if (currency.Equals("GBP", StringComparison.OrdinalIgnoreCase))
                {
                    price *= Constants.GBP;
                }


                if (price <= 0)
                {
                    Console.WriteLine("Wrong price");
                    continue;
                }
                Console.WriteLine("Enter product weight");
                float.TryParse(Console.ReadLine(), out float weight);

                Console.WriteLine("Enter weight unit (kilograms or grams)");
                string unit = Console.ReadLine();

                if (unit.Equals("gram", StringComparison.OrdinalIgnoreCase))
                {
                    weight *= Constants.Gram;
                }

                if (weight <= 0)
                {
                    Console.WriteLine("Wrong weight");
                    continue;
                }

                Console.WriteLine("Enter name of the type you want to create");
                string? productType = Console.ReadLine();

                if (productType.Equals("product", StringComparison.OrdinalIgnoreCase))
                {
                    Product product = new Product(name, price, weight);
                    _products.Add(product);
                }
                else if (productType.Equals("meat", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter meat type");
                    bool isTypeParsed = Enum.TryParse(Console.ReadLine(), out Type type);
                    if (isTypeParsed == false)
                    {
                        Console.WriteLine("Error (wrong meat type)");
                        continue;
                    }
                    
                    Console.WriteLine("Enter meat category");
                    bool isCategoryParsed = Enum.TryParse(Console.ReadLine(), out Category category);
                    if (isCategoryParsed == false)
                    {
                        Console.WriteLine("Error (wrong meat category)");
                        continue;
                    }

                    Meat meat = new Meat(name, price, weight, category, type);
                    _products.Add(meat);
                }
                else if (productType.Equals("diary", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter expiration date (in dd/mm/yyyy format)");
                    if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
                    {
                        Console.WriteLine("Error (wrong date)");
                        continue;
                    }
                    DairyProduct diaryProduct = new DairyProduct(name, price, weight, date);
                    _products.Add(diaryProduct);
                }
                else
                {
                    Console.WriteLine("Wrong product type. Please try again");
                }
                
            }
        }
        public void AddProducts(params Product[] products)
        {
            foreach (var product in products)
            {
                _products.Add((Product)product.Clone());
            }
        }
        public void AddProduct(ProductType productType,string name, decimal price, float weight, DateOnly? date = null, Type? type = null, Category? category = null)
        {
            if (productType == ProductType.Product)
            {
                Product product = new Product(name, price, weight);
                _products.Add(product);
            }
            else if (productType == ProductType.Diary && date != null)
            {
                DairyProduct diary = new DairyProduct(name, price, weight, (DateOnly)date);
                _products.Add(diary);
            }
            else if (productType == ProductType.Meat && type != null && category != null)
            {
                Meat meat = new Meat(name, price, weight, (Category)category, (Type)type);
                _products.Add(meat);
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }
        public void PrintEverything()
        {
            foreach (var product in _products)
            {
                if (product is Meat meat)
                {
                    Console.WriteLine($"Meat | {meat.Name},Weight {meat.Weight},Price {meat.Price}, Type {meat.Type}, Category {meat.Category}");
                }
                else if (product is DairyProduct diary)
                {
                    Console.WriteLine($"Meat | {diary.Name},Weight {diary.Weight},Price {diary.Price}, Expiration date {diary.ExpirationDate}");
                }
                else
                {
                    Console.WriteLine($"Meat | {product.Name},Weight {product.Weight},Price {product.Price}");
                }
            }
        }
        public Meat[] FindMeatProducts()
        {
            List<Meat> meatList = new List<Meat>();
            foreach (var product in _products)
            {
                if (product is Meat meat)
                {
                    if (meat.Clone() is Meat clonedMeat)
                    {
                        meatList.Add(clonedMeat);
                    }
                }
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
