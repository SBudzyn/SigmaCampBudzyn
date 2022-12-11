using Homework9;
using System.Diagnostics;

namespace Homework8
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Product> productsPivotFirst = new List<Product>();
            List<Product> productsPivotLast = new List<Product>();
            List<Product> productsPivotRandom = new List<Product>();
            Random random = new Random();
            for (int i = 0; i < 5000; i++)
            {
                Product product = new Product($"ProductName {i}", random.Next(1, 100), random.Next(1, 10));
                productsPivotFirst.Add(product);
                productsPivotLast.Add(product);
                productsPivotRandom.Add(product);
                Console.WriteLine($"Product with index {i}. Price - {productsPivotFirst[i].Price}");
            }

            Stopwatch watch = new Stopwatch();

            watch.Start();

            ProductsSort.QuickSort(productsPivotFirst, 0, productsPivotFirst.Count - 1, Pivot.First);
            watch.Stop();
            Console.WriteLine("Pivot first - " + watch.ElapsedMilliseconds);
            watch.Restart();
            ProductsSort.QuickSort(productsPivotLast, 0, productsPivotLast.Count - 1, Pivot.Last);
            watch.Stop();
            Console.WriteLine("Pivot last - " + watch.ElapsedMilliseconds);
            ProductsSort.QuickSort(productsPivotRandom, 0, productsPivotRandom.Count - 1, Pivot.Random);
            watch.Stop();
            Console.WriteLine("Pivot random - " + watch.ElapsedMilliseconds);
            Console.WriteLine(new String('_', 50));

            for (int i = 0; i < productsPivotFirst.Count; i++)
            {
                Console.WriteLine(productsPivotFirst[i].Name + $". Price - {productsPivotFirst[i].Price}");
            }
           
        }
    }
}
