namespace Homework7_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("5555 5555 5555 4444");
            Console.WriteLine(LunaChecker.Check("5555 5555 5555 4444"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("5555-5555-5555-4444");
            Console.WriteLine(LunaChecker.Check("5555-5555-5555-4444"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("378282246310005");
            Console.WriteLine(LunaChecker.Check("378282246310005"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("371449635398431");
            Console.WriteLine(LunaChecker.Check("371449635398431"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("378734493671000");
            Console.WriteLine(LunaChecker.Check("378734493671000"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("5555555555554444");
            Console.WriteLine(LunaChecker.Check("5555555555554444"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("5105105105105100");
            Console.WriteLine(LunaChecker.Check("5105105105105100"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("4111111111111111");
            Console.WriteLine(LunaChecker.Check("4111111111111111"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("4012888888881881");
            Console.WriteLine(LunaChecker.Check("4012888888881881"));
            Console.WriteLine(new String('_', 25));

            Console.WriteLine("4222222222222");
            Console.WriteLine(LunaChecker.Check("4222222222222"));
           
        }
    }
}
