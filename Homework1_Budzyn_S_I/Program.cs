namespace Homework1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Product product = new Product("Sweater", 25, 1.5f);
            Console.WriteLine(product);

            Buy buy = new Buy(product);
            Console.WriteLine(buy);
            Console.WriteLine(buy.CalculatePrice());

            Buy buy2 = new Buy(product, 5);
            Console.WriteLine(buy2);
            Console.WriteLine(buy2.CalculatePrice());

            
            Check.DisplayBuy(buy);
            Check.DisplayProduct(product); 

        }
    }
}
