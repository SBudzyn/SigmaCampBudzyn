namespace Homework7
{
    class Program
    {
        public static void Main(string[] args)
        {
            Storage storage1 = new Storage();

            Product product1 = new("Apple", 12, 12);
            Product product2 = new("Orange", 13, 13);
            Product product3 = new("Pineapple", 10, 10);

            storage1.AddProducts(product1, product2, product1, product3, product3);
            
            Storage storage2 = new Storage();

            Product product4 = new("Milk", 9, 9);
            Product product5 = new("Meat", 5, 5);

            storage2.AddProducts(product3, product3, product4, product5);

            var result = StorageComparer.Compare(storage1, storage2, StorageComparerReturn.DistinctCommonProducts);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
