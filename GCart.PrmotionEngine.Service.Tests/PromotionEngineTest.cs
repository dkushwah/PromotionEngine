using GCart.PromotionEngine.Service.CustomException;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GCart.PrmotionEngine.Service.Tests
{
    [TestClass]
    public class PromotionEngineTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PromotionEngine_ShouldThrowException_When_RuleIsNull()
        {
            PromotionEngine.Service.PromotionEngine promotionEngine = new PromotionEngine.Service.PromotionEngine();
            promotionEngine.AddPromotionRule(null);
        }

        [TestMethod]
        [ExpectedException(typeof(PromotionRulesNotFound))]
        public void PromotionEngine_ShouldThrowException_When_NoRulesToApply()
        {
            PromotionEngine.Service.PromotionEngine promotionEngine = new PromotionEngine.Service.PromotionEngine();
            promotionEngine.ApplyPromotion(new[] { 'A' });
        }
    }
}
