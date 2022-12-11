using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
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
        public Product? this[int index]
        {
            get
            {
                if (index >= _products.Count())
                {
                    return null;
                }
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
        public Product[] GetAllProducts()
        {
            List<Product> products = new List<Product>();
            foreach (Product product in _products)
            {
                var clonedProduct = product.Clone() as Product;
                if (clonedProduct != null)
                {
                    products.Add(clonedProduct);
                }
                return products.ToArray();
            }
            return products.ToArray();
        }
        public void AddProducts(params Product[] products)
        {
            foreach (var product in products)
            {
                _products.Add((Product)product.Clone());
            }
        }
        public int GetNumberOfProducts(Product product)
        {
            return _products.FindAll(p => p.Name == product.Name).Count();
        }
        public int GetNumberOfProducts(string product)
        {
            return _products.FindAll(p => p.Name == product).Count();
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
