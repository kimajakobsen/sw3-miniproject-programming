using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    static class Search
    {
        private static List<Product> currentResult;
        private class ProductSorter : IComparer<Product>
        {
            public int Compare(Product a, Product b)
            {
                if (a is InternalHarddrive)
                {
                    if (b is InternalHarddrive)
                    {
                        return 0;
                    }
                    return -1;
                }
                if (b is InternalHarddrive)
                {
                    return 1;
                }
                
                if (a is ExternalHarddrive)
                {
                    if (b is ExternalHarddrive)
                    {
                        return 0;
                    }
                    return -1;
                }
                if (b is ExternalHarddrive)
                {
                    return 1;
                }

                if (a is FlashStorage)
                {
                    if (b is FlashStorage)
                    {
                        return 0;
                    }
                    return -1;
                }
                if (b is FlashStorage)
                {
                    return 1;
                }

                return 0;
            }
        }

        public static List<Product> Initiate()
        {
            currentResult = Parser.ProductList;

            currentResult.Sort(new ProductSorter());

            return currentResult;
        }

        public static List<Product> SearchProductCode(List<Product> searchList, int code)
        {
            currentResult = searchList.Where(x => x.ProductCode == code).ToList();
            return currentResult;
        }

        public static List<Product> SearchProductCode(int code)
        {
            return SearchProductCode(currentResult,code);
        }

        public static List<Product> SearchPriceRange(List<Product> searchList, double min, double max)
        {
            currentResult = searchList.Where(x => x.Price >= min && x.Price <= max).ToList();
            return currentResult;
        }

        public static List<Product> SearchPriceRange(double min, double max)
        {
            return SearchPriceRange(currentResult,min,max);
        }

        public static List<Product> SearchStorageRange(List<Product> searchList, int min, int max)
        {
            currentResult = searchList.Where(x => x is StorageUnit && (x as StorageUnit).Storage >= min && (x as StorageUnit).Storage <= max).ToList();
            return currentResult;
        }

        public static List<Product> SearchStorageRange(int min, int max)
        {
            return SearchStorageRange(currentResult, min, max);
        }

        public static List<Product> SearchText(List<Product> searchList, string searchString)
        {
            currentResult = searchList.Where(x => x.Name.ToUpper().Contains(searchString.ToUpper()) ||
                x.Manufacturer.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            return currentResult;
        }

        public static List<Product> SearchText(string searchString)
        {
            return SearchText(currentResult, searchString);
        }
    }
}
