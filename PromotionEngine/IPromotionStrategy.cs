using PromotionEngine.ActivePromotion;
using SCM_PromotionEngine;

namespace PromotionEngine
{
    public interface IPromotionStrategy
    {
        Promotion GetApplicablePromotion(CartSKU cartSKU);
    }
}