using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal static class ExternalSorting
    {
        private const int chunkSize = 5000;
        public static void Sort(string inputFile)
        {
            using (var reader = new StreamReader(inputFile))
            {
                while (!reader.EndOfStream)
                {
                    List<int> chunk = new List<int>();
                    while (chunk.Count < chunkSize && !reader.EndOfStream)
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
                                for (int i = 0; i < buff.Count; i++)
                                {
                                    finalScore += buff[i] * Convert.ToInt32(Math.Pow(10, buff.Count - i - 1));

                                }
                                if (buff.Count != 0)
                                {
                                    chunk.Add(finalScore);
                                }
                                buff.Clear();
                                isCont = false;

                            }
                        }
                    }
                    MergeSort(chunk, 0, chunk.Count - 1);
                }
                MergeTheChunks();
            }
        }
        private static string CreateChunkFile(List<int> nums, int num)
        {
            var path = @$"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework9_Budzyn_S_I\Task1\Homework9\files\chunk{num}.txt";
            using (var writer = new StreamWriter(path))
            {
                nums.ForEach(n => writer.WriteLine(n));
            }
            return path;
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
            string[] paths = Directory.GetFiles(@"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework9_Budzyn_S_I\Task1\Homework9\files", "chunk*.txt");
            int chunks = paths.Length;
            int recordsize = 100;
            int maxusage = 500000000;
            int buffersize = maxusage / chunks;
            double recordoverhead = 7.5;
            int bufferlen = (int)(buffersize / recordsize / recordoverhead);

            StreamReader[] readers = new StreamReader[chunks];
            for (int i = 0; i < chunks; i++)
                readers[i] = new StreamReader(paths[i]);

            Queue<string>[] queues = new Queue<string>[chunks];
            for (int i = 0; i < chunks; i++)
                queues[i] = new Queue<string>(bufferlen);

            for (int i = 0; i < chunks; i++)
                LoadQueue(queues[i], readers[i], bufferlen);

            StreamWriter sw = new StreamWriter(@"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework9_Budzyn_S_I\Task1\Homework9\RESULT.txt");
            bool done = false;
            int lowest_index, j;
            string lowest_value;
            while (!done)
            {

                lowest_index = -1;
                lowest_value = "";
                for (j = 0; j < chunks; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 || String.CompareOrdinal(queues[j].Peek(), lowest_value) < 0)
                        {
                            lowest_index = j;
                            lowest_value = queues[j].Peek();
                        }
                    }
                }

                if (lowest_index == -1)
                {
                    done = true;
                    break;
                }

                sw.Write(lowest_value + " ");

                queues[lowest_index].Dequeue();

                if (queues[lowest_index].Count == 0)
                {
                    LoadQueue(queues[lowest_index],
                      readers[lowest_index], bufferlen);

                    if (queues[lowest_index].Count == 0)
                    {
                        queues[lowest_index] = null;
                    }
                }
            }
            sw.Close();


        }

        private static void LoadQueue(Queue<string> queue, StreamReader file, int records)
        {
            for (int i = 0; i < records; i++)
            {
                if (file.Peek() < 0)
                    break;
                queue.Enqueue(file.ReadLine());
            }
        }
    }
}
