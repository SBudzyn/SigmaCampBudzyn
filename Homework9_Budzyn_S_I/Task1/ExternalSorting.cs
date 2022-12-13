using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal static class ExternalSorting
    {
        private const int CHUNK_SIZE = 5000;
        private const string PATH_TO_FILE = @"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework9_Budzyn_S_I\Task1\files\";
        private const string RESULT_PATH = @"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework9_Budzyn_S_I\Task1\RESULT.txt";
        private const string CHUNK_PATTERN = "chunk*.txt";
        public static void Sort(string inputFile)
        {
            using (var reader = new StreamReader(inputFile))
            {
                int i = 1;
                while (!reader.EndOfStream)
                {
                    
                    List<int> chunk = new List<int>();
                    while (chunk.Count < CHUNK_SIZE && !reader.EndOfStream)
                    {
                        var number = ReadOneNumber(reader);
                        if (number != null)
                        {
                            chunk.Add((int)number);
                        }
                    }
                    MergeSort(chunk, 0, chunk.Count - 1);
                    using (StreamWriter writer = new StreamWriter(PATH_TO_FILE + $"chunk{i}.txt"))
                    {
                        foreach (var num in chunk)
                        {
                            writer.WriteLine(num);
                        }
                    }
                    i++;
                }
                MergeTheChunks();
            }
        }
       
        private static void MergeSort(List<int> arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        private static void Merge(List<int> arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];
            i = 0;

            j = 0;

            k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                    arr[k++] = L[i++];
                else
                    arr[k++] = R[j++];
            }

            while (i < n1)
                arr[k++] = L[i++];

            while (j < n2)
                arr[k++] = R[j++];
        }

        private static void MergeTheChunks()
        {
            string[] paths = Directory.GetFiles(PATH_TO_FILE, CHUNK_PATTERN);
            
            StreamReader[] readers = new StreamReader[paths.Length];

            for (int i = 0; i < paths.Length; i++)
            {
                readers[i] = new StreamReader(paths[i]);
            }

            int?[] minFromEachFile = new int?[paths.Length];

            for (int i = 0; i < readers.Length; i++)
            {
                minFromEachFile[i] = ReadOneNumber(readers[i]);
            }
            using (StreamWriter writer = new StreamWriter(RESULT_PATH))
            {
                while (readers.Any(r => r.EndOfStream != true))
                {
                    var minIndex = 0;
                    for (int i = 1; i < minFromEachFile.Length; i++)
                    {
                        if (minFromEachFile[minIndex] == null || minFromEachFile[i] < minFromEachFile[minIndex])
                        {
                            minIndex = i;
                        }                      
                    }
                    writer.Write(minFromEachFile[minIndex] + " ");
                    minFromEachFile[minIndex] = ReadOneNumber(readers[minIndex]);
                }
            }
            
        }
        private static int? ReadOneNumber(StreamReader reader)
        {
            List<int> buff = new List<int>();
            bool isCont = true;
            while (isCont)
            {
                var currChar = (char)reader.Read();
                if (Char.IsDigit(currChar))
                {
                    int.TryParse(currChar.ToString(), out int res);
                    buff.Add(res);
                }
                else
                {
                    int finalScore = 0;
                    
                    if (buff.Count != 0)
                    {
                        for (int i = 0; i < buff.Count; i++)
                        {
                            finalScore += buff[i] * Convert.ToInt32(Math.Pow(10, buff.Count - i - 1));

                        }
                        return finalScore;
                    }

                    if (reader.EndOfStream)
                    {
                        isCont = false;
                    }

                }
                
            }
            return null;
        }
        
    }
}
