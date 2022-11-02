namespace Homework2
{
    class Program
    {
        public static void Main(string[] args)
        {
            MatrixClass matr = new MatrixClass(10, 10);
            matr.SpiralInitialization();
            for (int i = 0; i < matr.FirstDimension; i++)
            {
                for (int j = 0; j < matr.SecondDimension; j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
            }
            //MatrixChecker checker = new MatrixChecker();
            //checker.CheckLongestLine(new int[,]
            //    {
            //        { 3, 4, 4, 4, 1 },
            //        { 3, 5, 4, 6, 12 },
            //        { 2, 3, 4, 4, 11 },
            //        { 6, 5, 5, 5, 5 },
            //        { 2, 12, 4, 3, 0 }
            //    }, out int color, out int length, out int lineIndex, out int startIndex, out int endIndex);
            //Console.WriteLine($"{color},{lineIndex} {startIndex}, {endIndex}, {length}");
            //Console.ReadKey();
        }
    }
}
