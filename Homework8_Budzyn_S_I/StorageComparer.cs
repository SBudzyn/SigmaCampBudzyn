using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    enum StorageComparerReturn
    {
        OnlyFirst,
        CommonProducts,
        DistinctCommonProducts
    }
    internal static class StorageComparer
    {
        
        public static Product[] Compare(Storage storage1, Storage storage2, StorageComparerReturn rType)
        {
            List<Product> retProducts = new List<Product>();
            var products1 = storage1.GetAllProducts().ToList();
            var products2 = storage2.GetAllProducts().ToList();
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
