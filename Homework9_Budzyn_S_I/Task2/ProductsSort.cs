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
        public static void QuickSort(List<Product> products, int start, int end, Pivot pivot)
        {
            if (start < end)
            {
                int partitionPivot = 0;

                switch (pivot)
                {
                    case Pivot.Last:
                        partitionPivot = PartitionLastPivot(products, start, end);
                        break;
                    case Pivot.First:
                        partitionPivot = PartitionFirstPivot(products, start, end);
                        break;
                    case Pivot.Random:
                        partitionPivot = PartitionRandomPivot(products, start, end);
                        break;
                }

                QuickSort(products, start, partitionPivot - 1, pivot);
                QuickSort(products, partitionPivot + 1, end, pivot);
            }
        }
        private static int PartitionLastPivot(List<Product> products, int start, int end)
        {
            Product pivot = products[end];
            int pivotNewPlaceIndex = start - 1;

            for (int i = start; i <= end - 1; i++)
            {
                if (pivot.Price > products[i].Price)
                {
                    pivotNewPlaceIndex++;
                    Swap(products, pivotNewPlaceIndex, i);
                }
            }
            Swap(products, pivotNewPlaceIndex + 1, end);
            return pivotNewPlaceIndex + 1;
        }

        private static int PartitionFirstPivot(List<Product> products, int start, int end)
        {
            Product pivot = products[start];
            int pivotNewPlaceIndex = end + 1;

            for (int i = end; i > start; i--)
            {
                if (products[i].Price > pivot.Price)
                {
                    pivotNewPlaceIndex--;
                    Swap(products, pivotNewPlaceIndex, i);
                }
            }
            Swap(products, pivotNewPlaceIndex - 1, start);
            return pivotNewPlaceIndex - 1;
        }
        private static int PartitionRandomPivot(List<Product> products, int start, int end)
        {
            var rand = new Random();
            int pivotIndex = rand.Next(start, end - 1);
            Swap(products, pivotIndex, end);
            return PartitionLastPivot(products, start, end);
        }
        private static void Swap(List<Product> products, int i, int j)
        {
            Product temp = products[i];
            products[i] = products[j];
            products[j] = temp;
        }
    }
}
