using PromotionEngine.ActivePromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_PromotionEngine
{
    public class SKU
    {
        public string Id { get; set; }

    }

    public class CartSKU : SKU
    {
        public int Quantity { get; set; }

        public Promotion ApplicablePromotion { get; set; } //Assuming only 1 promotion can be Applied for now

        public double DiscountedPrice { get; set; }

        public bool IsPromotionApplied { get; set; }
    }
}
