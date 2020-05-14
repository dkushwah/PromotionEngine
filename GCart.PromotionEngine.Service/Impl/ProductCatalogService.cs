using System;
using System.Collections.Generic;
using System.Text;

namespace GCart.PromotionEngine.Service.Impl
{
    public class ProductCatalogService : IProductCatalog
    {
        private readonly IDictionary<Char, double> _productPriceMap = new SortedDictionary<Char, double>();
        public ProductCatalogService()
        {

        }
        public void AddProduct(char product, double price)
        {
            _productPriceMap.Add(product, price);
        }

        public KeyValuePair<Char, double> FindProduct(char product)
        {
            return new KeyValuePair<char, double>(product, _productPriceMap[product]);
        }

        public IDictionary<char, double> FindProducts()
        {
            return _productPriceMap;
        }

     
    }
}
