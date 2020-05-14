using System;
using System.Collections.Generic;
using System.Text;

namespace GCart.PromotionEngine.Service.Contracts
{
    public interface IPromotionEngine
    {
        void AddPromotionRule(Func<char[], AfterPromotionResult> action);
        AfterPromotionResult ApplyPromotion(char[] products);
    }
}
