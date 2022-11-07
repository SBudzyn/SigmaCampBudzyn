using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    internal class MatrixClass
    {
        private int[,] matrix = null!;
        public int FirstDimension { get; set; }
        public int SecondDimension { get; set; }
        public MatrixClass(int firstDimension, int secondDimension)
        {
            matrix = new int[firstDimension, secondDimension];
            FirstDimension = firstDimension;
            SecondDimension = secondDimension;
        }
        public int this[int index1, int index2]
        {
            get { return matrix[index1, index2]; }
            set { matrix[index1, index2] = value; }
        }
        public void VerticalSnakeInitialization()
        {// можна оптимізувати
            int currNum = 1;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        matrix[j, i] = currNum;
                        currNum++;
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        matrix[j, i] = currNum;
                        currNum++;
                    }
                }
                
            }
        }
        public void DiagonalSnakeInitialization()
        {
            int i = 0;
            int j = 0;
            int currNum = 1;
            int maxValue = matrix.GetLength(0) - 1;
            while (i + j <= maxValue * 2)
            {
                matrix[i, j] = currNum;
                currNum++;
                if ((i + j) % 2 == 0 && (j == maxValue || j == j + i))
                {
                    if (j < maxValue)
                        j++;
                    else
                        i++;
                }
                else if ((i + j) % 2 == 1 && (i == maxValue || i == j + i))
                {
                    if (i < maxValue)
                        i++;
                    else
                        j++;
                }
                else if ((i + j) % 2 == 0)
                {
                    i--;
                    j++;
                }
                else if ((i + j) % 2 == 1)
                {
                    i++;
                    j--;
                }
                
            }
        }
        public void SpiralInitialization()
        {
            if (FirstDimension != SecondDimension)
            {
                return;
            }
            int currNum = 1;
            for (int padd = 0; padd <= Math.Min(FirstDimension, SecondDimension) / 2; padd++)
            {
                for (int j = padd; j < FirstDimension - padd; j++)
                {
                    matrix[j, padd] = currNum;
                    currNum++;
                }
                for (int j = padd + 1; j < SecondDimension - padd; j++)
                {
                    matrix[FirstDimension - padd - 1, j] = currNum;
                    currNum++;
                }
                for (int j = FirstDimension - padd - 2; j > padd - 1; j--)
                {
                    if (padd == SecondDimension / 2)
                    {
                        break;
                    }
                    matrix[j, SecondDimension - padd - 1] = currNum;
                    currNum++;
                }
                for (int j = SecondDimension - padd - 2; j > padd; j--)
                {
                    if (padd == FirstDimension / 2)
                    {
                        break;
                    }
                    matrix[padd, j] = currNum;
                    currNum++;
                }
                
            }
            
        }
    }
}
