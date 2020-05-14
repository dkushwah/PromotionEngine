using GCart.PromotionEngine.Service;
using GCart.PromotionEngine.Service.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCart.PrmotionEngine.Service.Tests
{
    [TestClass]
    public class ProductCatalogTests
    {
        [TestMethod]
        [ExpectedException(typeof(DuplicateProductException))]
        public void ProductCatalog_ShouldThrow_DuplicateProductException_WhenAdding_DuplicateProduct()
        {
            //IProductCatalog productCatalog = new ProductCatalogService();
            //productCatalog.AddProduct('A', 30);
            //productCatalog.AddProduct('A', 30);
        }
    }
}
