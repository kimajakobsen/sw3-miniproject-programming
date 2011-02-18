using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    /// <summary>
    /// A static class containing search functionality
    /// </summary>
    static class Search
    {
        private static List<Product> currentResult;

        /// <summary>
        /// Depricated
        /// </summary>
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

            //currentResult.Sort(new ProductSorter());

            return currentResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchList"></param>
        /// <param name="code"></param>
        /// <returns>
        /// Returns a list of <code>Products</code> containing the products with the <code>ProductCode</code>
        /// specified in <code>code</code> (should only contain one element).
        /// </returns>
        public static List<Product> SearchProductCode(List<Product> searchList, int code)
        {
            currentResult = searchList.Where(x => x.ProductCode == code).ToList();
            return currentResult;
        }

        public static List<Product> SearchProductCode(int code)
        {
            return SearchProductCode(currentResult,code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchList">The list to search in</param>
        /// <param name="min">Minimum price</param>
        /// <param name="max">Maximum price</param>
        /// <returns>A list containing all <code>Products</code> with a <code>Price</code>
        /// between <code>min</code> and <code>max</code></returns>
        public static List<Product> SearchPriceRange(List<Product> searchList, double min, double max)
        {
            currentResult = searchList.Where(x => x.Price >= min && x.Price <= max).ToList();
            return currentResult;
        }

        public static List<Product> SearchPriceRange(double min, double max)
        {
            return SearchPriceRange(currentResult,min,max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchList">The list to search in</param>
        /// <param name="min">Minimum storage capacity</param>
        /// <param name="max">Maximum storage capacity</param>
        /// <returns>A list containing all <code>Products</code> with a <code>Storage</code>
        /// between <code>min</code> and <code>max</code></returns>
        public static List<Product> SearchStorageRange(List<Product> searchList, int min, int max)
        {
            currentResult = searchList.Where(x => x is StorageUnit && (x as StorageUnit).Storage >= min && (x as StorageUnit).Storage <= max).ToList();
            return currentResult;
        }

        public static List<Product> SearchStorageRange(int min, int max)
        {
            return SearchStorageRange(currentResult, min, max);
        }


        /// <summary>
        /// Function to search for screen for a minimum size or mazimum size. * can be used as wildcard
        /// </summary>
        /// <param name="searchList">The list to search in</param>
        /// <param name="min">minmum size or wildcard</param>
        /// <param name="max">maximum size or wildcard</param>
        /// <returns>A list containing all the products with a size between min and max</returns>
        public static List<Product> SearchSizeRange(List<Product> searchList, int min, int max)
        {
            currentResult = searchList.Where(x => x is Screen && (x as Screen).Size >= min && (x as Screen).Size <= max).ToList();
            return currentResult;
        }

        public static List<Product> SearchSizeRange(int min, int max)
        {
            return SearchSizeRange(currentResult, min, max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchList">The list to search in</param>
        /// <param name="searchString">The string to match</param>
        /// <returns>>A list containing all <code>Products</code> with a <code>Name</code>
        /// or <code>Manufacturer.Name</code> containing <code>searchString</code></returns>
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
