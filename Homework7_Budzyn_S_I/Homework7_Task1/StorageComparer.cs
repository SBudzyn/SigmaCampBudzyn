using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    enum StorageComparerReturn
    {
        OnlyFirst,
        CommonProducts,
        DistinctCommonProducts
    }
    internal static class StorageComparer
    {
       //хороша ідея окремий клас для порівняння!
        // чому масив, а не список?
        public static Product[] Compare(Storage storage1, Storage storage2, StorageComparerReturn rType)
        {
            List<Product> retProducts = new List<Product>();
            var products1 = storage1.GetAllProducts().ToList();
            var products2 = storage2.GetAllProducts().ToList();
            //чому не використані операції для множин?
            if (rType == StorageComparerReturn.CommonProducts)
            {
                foreach (var product in products1)
                {
                    if (products2.Contains(product))
                    {
                        retProducts.Add(product);
                        products2.Remove(product);
                    }
                }
                return retProducts.ToArray();
            }
            else if (rType == StorageComparerReturn.OnlyFirst)
            {
                foreach (var product in products1)
                {
                    if (!products2.Contains(product))
                    {
                        retProducts.Add(product);
                        
                    }
                }
                return retProducts.ToArray();
            }
            else
            {
                return products1.Intersect(products2).ToArray();
            }
        }
    }
}
