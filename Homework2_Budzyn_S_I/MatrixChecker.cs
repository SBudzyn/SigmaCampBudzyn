using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    internal class MatrixChecker
    {
        public void CheckLongestLine(int[,] arr, out int color, out int length, out int lineIndex, out int startIndex, out int endIndex)
        {
            color = 0;
            length = 0;
            startIndex = 0;
            endIndex = 0;
            lineIndex = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int currLength = 1;
                int currColor = arr[i, 0];
                int currStartIndex = 0;
                int currEndIndex = 0;
                lineIndex = i;
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    if (arr[i, j + 1] == currColor)
                    {
                        currLength++;
                        currEndIndex = j + 1;
                    }
                    else
                    {
                        if (currLength > length)
                        {
                            color = currColor;
                            length = currLength;
                            startIndex = currStartIndex;
                            endIndex = currEndIndex;
                        }
                        currColor = arr[i, j + 1];
                        currLength = 1;
                        currStartIndex = j + 1;
                        currEndIndex = j + 1;
                    }

                    
                }
                if (currLength > length)
                {
                    color = currColor;
                    length = currLength;
                    startIndex = currStartIndex;
                    endIndex = currEndIndex;
                }

            }
            
        }
    }
}
