namespace HW3T2
{
    class Program
    {
        public static void Main(string[] args)
        {
            RandomArray randomArray = new RandomArray(20, 0, 10);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(randomArray[i]);
            }
            Console.WriteLine(new String('_', 50));
            randomArray.PrintFrequenciesTable();
            Console.WriteLine(new String('_', 50));
            foreach (var item in randomArray.FindPrimeSubsequence())
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                    
                }
                Console.WriteLine(new String('_', 50));
            }

        }
    }
}