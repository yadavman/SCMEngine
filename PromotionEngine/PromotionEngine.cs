using PromotionEngine;
using PromotionEngine.ActivePromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_PromotionEngine
{
    public class PromotionEngine : IPromotionEngine
    {
        private Dictionary<SKU, double> _priceList { get; set; }
        private IPromotionStrategy _promotionStrategy = null;
        public PromotionEngine(Dictionary<SKU, double> priceList, IPromotionStrategy promotionStrategy)
        {
            _priceList = priceList;
            this._promotionStrategy = promotionStrategy;
        }

        public double ApplyPromotion(Cart cart)
        {

            //Get Which Promotion to Apply Based on the Cart and the Available promotions
            ActivePromotions activePromotions = new ActivePromotions();
            List<Promotion> availablePromotions = activePromotions.GetActivePromotions();
            double total = 0;
            foreach (var availablePromotion in availablePromotions)
            {
                total = total + availablePromotion.CalculatePrice(cart.CartSKUs,_priceList);
            }

            //calculate Price For Items which Did not fall in any Promotion Category

            foreach (CartSKU cartSKU in cart.CartSKUs.Where(x=>x.IsPromotionApplied==false))
            {
                total = total + GetPrice(cartSKU, _priceList);
            }


            //foreach (CartSKU cartSKU in cart.CartSKUs)
            //{
            //    cartSKU.ApplicablePromotion = _promotionStrategy.GetApplicablePromotion(cartSKU);
            //    cartSKU.DiscountedPrice = Utility.GetDiscountedPrice(cartSKU, _priceList);
            //}

            //Actual Calculation of Total once we know which Promotion to apply

            return total;
        }

        private double GetPrice(CartSKU cartSKU, Dictionary<SKU, double> priceList)
        {
            double unitPrice = priceList[priceList.Keys.FirstOrDefault(x => x.Id == cartSKU.Id)];
            return cartSKU.Quantity * unitPrice;
        }
    }
}
