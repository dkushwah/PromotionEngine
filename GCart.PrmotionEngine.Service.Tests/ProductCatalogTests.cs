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
            ProductCatalogService ProductCatalogService = new ProductCatalogService();
            ProductCatalogService.AddProduct('A', 30);
            ProductCatalogService.AddProduct('A', 30);
        }

        [TestMethod]
        public void ProductCatalog_ShouldReturnZero_When_ProductNotFound()
        {
            ProductCatalogService ProductCatalogService = new ProductCatalogService();
            ProductCatalogService.AddProduct('A', 30);
            var price = ProductCatalogService.GetPrice('B');
            Assert.AreEqual(price, 0);
        }

        [TestMethod]
        public void ProductCatalog_ShouldReturn_ProductPrice_ByPassingProductName()
        {
            ProductCatalogService ProductCatalogService = new ProductCatalogService();
            ProductCatalogService.AddProduct('A', 30);
            var price = ProductCatalogService.GetPrice('A');
            Assert.AreEqual(price, 30);
        }
    }
}
