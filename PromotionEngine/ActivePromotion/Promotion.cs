using SCM_PromotionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.ActivePromotion
{
    public abstract class Promotion
    {
        public PromotionType PromotionType { get; set; }

        public abstract double CalculatePrice(List<CartSKU> cartSKUs, Dictionary<SKU, double> priceList);
    }

    public class BulkPromotion : Promotion
    {
        public SKU SKU { get; set; }

        public int MinQuantity { get; set; }

        public double ApplicablePrice { get; set; }

        public override double CalculatePrice(List<CartSKU> cartSKUs, Dictionary<SKU, double> priceList)
        {
            double calcPrice = 0;
            //Assuming only one Type of SKU and Promotion can be onlty 1
            CartSKU cartSKU = cartSKUs.FirstOrDefault(x => x.Id == SKU.Id && x.Quantity >= MinQuantity && x.IsPromotionApplied==false);

            if (cartSKU!=null)
            {
                //Promotion Appplicable
                double unitPrice = priceList[priceList.Keys.FirstOrDefault(x => x.Id == cartSKU.Id)];
                cartSKU.IsPromotionApplied = true;
                calcPrice = ((cartSKU.Quantity / MinQuantity) * ApplicablePrice) + ((cartSKU.Quantity % MinQuantity) * unitPrice);
            }

            return calcPrice;
        }
    }

    public class ComboPromotion : Promotion
    {
        //For Simplicity Just Allowing 2 Combo and assuming quantiry=1 , Can be done using  Key pair values also
        public SKU SKU1 { get; set; }

        public SKU SKU2 { get; set; }

        public double ApplicablePrice { get; set; }

        public override double CalculatePrice(List<CartSKU> cartSKUs, Dictionary<SKU, double> priceList)
        {
            double calcPrice = 0;

            CartSKU cartSKU1 = cartSKUs.FirstOrDefault(x => x.Id == SKU1.Id && x.IsPromotionApplied == false);
            CartSKU cartSKU2 = cartSKUs.FirstOrDefault(x => x.Id == SKU2.Id && x.IsPromotionApplied == false);


            if (cartSKU1 != null && cartSKU2 !=null)
            {
                //Promotion Appplicable
                double unitPriceSKU1 = priceList[priceList.Keys.FirstOrDefault(x => x.Id == cartSKU1.Id)];
                double unitPriceSKU2 = priceList[priceList.Keys.FirstOrDefault(x => x.Id == cartSKU2.Id)];
                cartSKU1.IsPromotionApplied = true;
                cartSKU2.IsPromotionApplied = true;

                int min = Math.Min(cartSKU1.Quantity, cartSKU2.Quantity);

                calcPrice = min* ApplicablePrice + ((cartSKU1.Quantity-min)* unitPriceSKU1) + ((cartSKU2.Quantity - min) * unitPriceSKU2);
            }

            return calcPrice;
        }
    }
}
