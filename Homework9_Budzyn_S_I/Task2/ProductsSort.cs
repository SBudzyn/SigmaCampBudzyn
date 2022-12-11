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
        
        public static void QuickSort(List<Product> products, int low, int high, Pivot pivot)
        {
            if (low < high)
            {

                int pi = Partition(products, low, high, pivot);

                QuickSort(products, low, pi - 1, pivot);
                QuickSort(products, pi + 1, high, pivot);
            }
        }

        private static int Partition(List<Product> products, int low, int high, Pivot pivott)
        {

            Product pivot;

            if (pivott == Pivot.First)
            {
                pivot = products[low];
            }
            else if (pivott == Pivot.Last)
            {
                pivot = products[high];
            }
            else
            {
                Random rand = new Random();
                pivot = products[rand.Next(low, high)];
            }


            int i;

            if (pivott == Pivot.Last)
            {
                i = low - 1;
                for (int j = low; j <= high - 1; j++)
                {

                    if (products[j].Price < pivot.Price)
                    {

                        i++;
                        Swap(products, i, j);
                    }
                }
                Swap(products, i + 1, high);
            }
            else if (pivott == Pivot.First)
            {
                i = high;
                for (int j = high; j > low; j--)
                {
                    if (products[j].Price > pivot.Price)
                        Swap(products, j, i--);
                }
                Swap(products, i, low);
            }
            else
            {
                i = low - 1;
                for (int j = low; j < high; j++)
                {

                    
                    if (products[j].Price < pivot.Price)
                    {
                        i++;
                        Product tempp = products[i];
                        products[i] = products[j];
                        products[j] = tempp;
                    }
                } 
                Swap(products, i + 1, high);
            }
            return i + 1;
        }
        private static void Swap(List<Product> products, int i, int j)
        {
            Product temp = products[i];
            products[i] = products[j];
            products[j] = temp;
        }
    }
}
