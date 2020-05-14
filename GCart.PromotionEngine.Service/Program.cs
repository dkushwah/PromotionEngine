using GCart.PromotionEngine.Service.Contracts;
using GCart.PromotionEngine.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCart.PromotionEngine.Service
{
  public  class Program
    {
        private static IProductCatalog _productCatalog = new ProductCatalogService();
        private static IPromotionEngine _promotionEngine = new PromotionEngine();
        public static void Main(string[] args)
        {
            _promotionEngine.AddPromotionRule(Apply3APromotion);
            _promotionEngine.AddPromotionRule(ApplyBCPromotion);
            _promotionEngine.AddPromotionRule(ApplyCDPromotion);
            //Feel free to add new logic to be executed for promotion
            //_promotionEngine.AddPromotionRule();

            _productCatalog.AddProduct('A', 50);
            _productCatalog.AddProduct('B', 30);
            _productCatalog.AddProduct('C', 20);
            _productCatalog.AddProduct('D', 15);
            

            Checkout(new[] { 'A','B','C' });
            Checkout(new[] { 'A', 'A', 'A', 'A', 'A','B','B','B','B','B', 'C' });
            Checkout(new[] { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });
        }

        private static void Checkout(char[] v)
        {
            var priceAfterPromotion = _promotionEngine.ApplyPromotion(v);
            foreach (var item in priceAfterPromotion.RemainingProducts)
            {
                priceAfterPromotion.PromotedProductsPrice += _productCatalog.GetPrice(item);
            }

            Console.WriteLine("Total Price: {0}", priceAfterPromotion.PromotedProductsPrice);
        }

        static public AfterPromotionResult Apply3APromotion(IList<char> products)
        {
            products = products.ToList();
            var promotedProducts = new AfterPromotionResult();
            while (true)
            {
                if (products.Count(t => t == 'A')>=3)
                {
                    promotedProducts.PromotedProducts.Add('A');
                    promotedProducts.PromotedProductsPrice += 130;
                    for (int i = 0; i < 3; i++)
                    {
                        products.Remove('A');
                    }
                }
                else
                {
                    break;
                }
            }
            promotedProducts.RemainingProducts = products;
            return promotedProducts;
        }

        static public AfterPromotionResult ApplyBCPromotion(IList<char> products)
        {
            products = products.ToList();
            var promotedProducts = new AfterPromotionResult();
            while (true)
            {
                if (products.Count(t => t == 'B') >= 2)
                {
                    promotedProducts.PromotedProducts.Add('B');
                    promotedProducts.PromotedProductsPrice += 45;
                    for (int i = 0; i < 2; i++)
                    {
                        products.Remove('B');
                    }
                }
                else
                {
                    break;
                }
            }
            promotedProducts.RemainingProducts = products;
            return promotedProducts;
        }

        static public AfterPromotionResult ApplyCDPromotion(IList<char> products)
        {
            var promotedProducts = new AfterPromotionResult();
            products = products.ToList();
            while (true)
            {
                if (products.Any(t => t == 'C') && products.Any(t => t == 'D'))
                {
                    promotedProducts.PromotedProducts.Add('C');
                    promotedProducts.PromotedProducts.Add('D');
                    promotedProducts.PromotedProductsPrice = 30;
                    products.Remove('C');
                    products.Remove('D');
                }
                else
                {
                    break;
                }
            }
            promotedProducts.RemainingProducts = products;
            return promotedProducts;
        }
     
    }
}
