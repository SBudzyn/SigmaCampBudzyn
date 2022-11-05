using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3T2
{
    internal class RandomArray
    {
        private int[] _arr;

        public int this[int index]
        {
            get => _arr[index];
            set => _arr[index] = value;
        }

        public RandomArray(int size, int lowerBound, int upperBound)
        {
            if (size < 0)
                throw new ArgumentException("Size can`t be less than 0");
            
            if (lowerBound > upperBound)
                throw new ArgumentException("Lower bound can`t be less than upper bound");

            _arr = new int[size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                _arr[i] = random.Next(lowerBound, upperBound);
            }
        }

        public void PrintFrequenciesTable()
        { 
            Dictionary<int, int> frequencies = new Dictionary<int, int>();
            foreach (var num in _arr)
            {
                if (frequencies.ContainsKey(num) == false)
                {
                    frequencies.Add(num, 1);
                }
                else
                {
                    frequencies[num]++;
                }
            }
            foreach (var pair in frequencies)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
        public int[][] FindPrimeSubsequence()
        {
            List<int> longestSubsequence = new List<int>();
            List<int> secondLongestSequence = new List<int>();
            List<int> currentSubsequence = new List<int>();

            for (int i = 0; i < _arr.Length; i++)
            {
                if (CheckPrimes(_arr[i]) == true)
                {
                    currentSubsequence.Add(_arr[i]);
                }
                else
                {
                    if (currentSubsequence.Count() > longestSubsequence.Count())
                    {
                        secondLongestSequence.Clear();
                        secondLongestSequence.AddRange(longestSubsequence);
                        longestSubsequence.Clear();
                        longestSubsequence.AddRange(currentSubsequence);
                    }
                    currentSubsequence.Clear();
                }
            }
            if (currentSubsequence.Count() > longestSubsequence.Count())
            {
                secondLongestSequence.Clear();
                secondLongestSequence.AddRange(longestSubsequence);
                longestSubsequence.Clear();
                longestSubsequence.AddRange(currentSubsequence);
            }

            return new int[][] { longestSubsequence.ToArray(), secondLongestSequence.ToArray() };

            bool CheckPrimes(int number)
            {
                if (number < 0)
                {
                    return false;
                }
                int divs = 0;
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        divs++;
                    }
                }
                if (divs == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
