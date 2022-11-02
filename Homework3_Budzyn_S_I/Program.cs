namespace Homework3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Product product = new Product("Apple", 50m, 1.5f);
            Product product1 = new Product("Orange", 30m, 2.2f);

            DairyProduct diary = new DairyProduct("Milk", 20m, 0.9f, new DateOnly(2022, 11, 11));
            DairyProduct diary1 = new DairyProduct("Yogurt", 10m, 0.3f, new DateOnly(2022, 11, 8));

            Meat meat = new Meat("Sliced beef", 150m, 0.6f, Category.FirstSort, Type.Beef);
            Meat meat1 = new Meat("Chicken", 80m, 0.4f, Category.SecondSort, Type.Chicken);
            Meat meat2 = new Meat("Cut mutton", 90m, 0.8f, Category.HighestSort, Type.Mutton);

            Storage storage = new Storage(product, product1, diary, diary1, meat, meat1, meat2);
            storage.DialogInitialization();
            foreach (var meatF in storage.FindMeatProducts())
            {
                Console.WriteLine($"Name - {meatF.Name}, Price - {meatF.Price}, Weight - {meatF.Weight}, Type - {meatF.Type}");
            }

            storage.AddProduct(ProductType.Meat, "Beef qwe", 32m, 0.46f, type: Type.Pork, category: Category.FirstSort);
            storage.PrintEverything();

            Console.WriteLine(new String('_', 50));

            storage.ChangePriceForAll(50);
            storage.PrintEverything();

            Product product11 = storage[2];
            Console.WriteLine(product11.ToString());
        }
    }
}
