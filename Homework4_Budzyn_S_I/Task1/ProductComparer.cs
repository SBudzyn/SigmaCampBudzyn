using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal class ProductComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Argument can`t be equal to null");
            }

            return x.CompareTo(y);
        }
    }
}
