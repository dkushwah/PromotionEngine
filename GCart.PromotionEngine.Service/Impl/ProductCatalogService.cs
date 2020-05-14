using GCart.PromotionEngine.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCart.PromotionEngine.Service.Impl
{
    public class ProductCatalogService : IProductCatalog
    {
        private  IDictionary<char, double> _productPriceMap = new SortedDictionary<char, double>();
        public ProductCatalogService()
        {

        }
        public void AddProduct(char product, double price)
        {
            _productPriceMap.Add(product, price);
        }

        public KeyValuePair<char, double> FindProduct(char product)
        {
            return new KeyValuePair<char, double>(product, _productPriceMap[product]);
        }

        public IDictionary<char, double> FindProducts()
        {
            return _productPriceMap;
        }

        public double GetPrice(char product)
        {
            if (!_productPriceMap.ContainsKey(product))
            {
                return 0.0;
            }
            return _productPriceMap[product];
        }
    }
}
