using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCM_PromotionEngine;

namespace PromotionEngine.ActivePromotion
{
    public class ActivePromotions
    {
        //Will have service Dependency Injected to get actual data from Service
        public ActivePromotions()
        {

        }

        public List<Promotion> GetActivePromotions()
        {
            //Later this should come from Db or Some Service Layer
            //returning Hard Coded for Now
            List<Promotion> promotions = new List<Promotion>();

            //
            Promotion bulkPromotionA = new BulkPromotion()
            {
                PromotionType = PromotionType.Bulk,
                SKU = new SKU()
                {
                    Id = "A"
                },
                ApplicablePrice = 130,
                MinQuantity = 3
            };
            promotions.Add(bulkPromotionA);

            Promotion bulkPromotionB = new BulkPromotion()
            {
                PromotionType = PromotionType.Bulk,
                SKU = new SKU()
                {
                    Id = "B"
                },
                ApplicablePrice = 45,
                MinQuantity = 2
            };
            promotions.Add(bulkPromotionB);

            Promotion comboPromotionCD = new ComboPromotion()
            {
                PromotionType = PromotionType.Combo,
                ApplicablePrice=30,
                SKU1=new SKU()
                    {
                        Id="C"
                    },
                SKU2=
                     new SKU()
                    {
                        Id="D"
                    }

            };
            promotions.Add(comboPromotionCD);

            return promotions;
        }
    }
}
