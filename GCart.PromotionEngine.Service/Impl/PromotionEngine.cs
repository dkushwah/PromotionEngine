using GCart.PromotionEngine.Service.Contracts;
using GCart.PromotionEngine.Service.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCart.PromotionEngine.Service
{

    public class AfterPromotionResult
    {
        public AfterPromotionResult()
        {
            PromotedProducts = new SortedSet<char>();
            RemainingProducts = new List<char>();
        }
        public IList<char> RemainingProducts { get; set; }
        public SortedSet<char> PromotedProducts { get; set; }
        public double PromotedProductsPrice { get; set; }
    }
    public class PromotionEngine : IPromotionEngine
    {
        private readonly IList<Func<char[], AfterPromotionResult>> _rules = new List<Func<char[], AfterPromotionResult>>();
        
        public void AddPromotionRule(Func<char[], AfterPromotionResult> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            _rules.Add(action);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public AfterPromotionResult ApplyPromotion(char[] products)
        {
            var response = new AfterPromotionResult();
            double price = 0.0;
            if (!_rules.Any())
            {
                throw new PromotionRulesNotFound();
            }
            foreach (var rule in _rules)
            {
                response = rule.Invoke(products);
                products = response.RemainingProducts.ToArray();
                price += response.PromotedProductsPrice;
            }
            response.RemainingProducts = products;
            response.PromotedProductsPrice =price;
            return response;
        }
    }

   
}
