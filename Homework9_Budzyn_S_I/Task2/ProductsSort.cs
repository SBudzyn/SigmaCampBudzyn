using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    enum Pivot
    {
        First, 
        Last,
        Random
    }
    internal static class ProductsSort
    {
        public static void QuickSort(List<Product> array, int startIndex, int endIndex, Pivot pivot)
        {
            if (startIndex < endIndex)
            {
                int partitionPivot = 0;

                switch (pivot)
                {
                    case Pivot.Last:
                        partitionPivot = PartitionLastPivot(array, startIndex, endIndex);
                        break;
                    case Pivot.First:
                        partitionPivot = PartitionFirstPivot(array, startIndex, endIndex);
                        break;
                    case Pivot.Random:
                        partitionPivot = PartitionRandomPivot(array, startIndex, endIndex);
                        break;
                }

                QuickSort(array, startIndex, partitionPivot - 1, pivot);
                QuickSort(array, partitionPivot + 1, endIndex, pivot);
            }
        }
        private static int PartitionLastPivot(List<Product> array, int startIndex, int endIndex)
        {
            Product pivot = array[endIndex];
            int pivotNewPlaceIndex = startIndex - 1;

            for (int i = startIndex; i <= endIndex - 1; i++)
            {
                if (pivot.Price > array[i].Price)
                {
                    pivotNewPlaceIndex++;
                    Swap(array, pivotNewPlaceIndex, i);
                }
            }
            Swap(array, pivotNewPlaceIndex + 1, endIndex);
            return pivotNewPlaceIndex + 1;
        }

        private static int PartitionFirstPivot(List<Product> array, int startIndex, int endIndex)
        {
            Product pivot = array[startIndex];
            int pivotNewPlaceIndex = endIndex + 1;

            for (int i = endIndex; i > startIndex; i--)
            {
                if (array[i].Price > pivot.Price)
                {
                    pivotNewPlaceIndex--;
                    Swap(array, pivotNewPlaceIndex, i);
                }
            }
            Swap(array, pivotNewPlaceIndex - 1, startIndex);
            return pivotNewPlaceIndex - 1;
        }
        private static int PartitionRandomPivot(List<Product> array, int startIndex, int endIndex)
        {
            var rand = new Random();
            int pivotIndex = rand.Next(startIndex, endIndex - 1);
            Swap(array, pivotIndex, endIndex);
            return PartitionLastPivot(array, startIndex, endIndex);
        }
        private static void Swap(List<Product> array, int i, int j)
        {
            Product temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
