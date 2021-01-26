using PromotionEngine.ActivePromotion;
using SCM_PromotionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionStrategy : IPromotionStrategy
    {
        List<Promotion> availablePromotions = null;
        public PromotionStrategy()
        {
            // for now hard coding..Later should come from service 
            ActivePromotions activePromotions = new ActivePromotions();
            availablePromotions = activePromotions.GetActivePromotions();
        }

        public ActivePromotion.Promotion GetApplicablePromotion(CartSKU cartSKU)
        {
            
            return null;
        }
    }
}
