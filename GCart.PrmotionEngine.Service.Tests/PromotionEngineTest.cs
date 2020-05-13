using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCart.PrmotionEngine.Service.Tests
{
    [TestClass]
    public class PromotionEngineTest
    {
        public PromotionEngineTest()
        {

        }
        [TestMethod]
        public void PromotionEngine_ApplyPromotion_when_AtLeastOne_Active()
        {
            PromotionEngine promotionEngine = new PromotionEngine();
            var t = promotionEngine.FindActivePromotions();
            Assert.IsTrue(t.Count > 1);
        }
    }
}
