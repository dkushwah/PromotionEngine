using GCart.PromotionEngine.Service.Impl;
using System;

namespace GCart.PromotionEngine.Service
{
    class Program
    {
        private readonly static IProductCatalog _productCatalog = new ProductCatalogService();
        static void Main(string[] args)
        {
            _productCatalog.AddProduct('A', 30);
            _productCatalog.AddProduct('B', 50);
            _productCatalog.AddProduct('C', 20);
            _productCatalog.AddProduct('D', 15);

        }
    }
}
