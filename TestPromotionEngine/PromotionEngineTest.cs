using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using SCM_PromotionEngine;

namespace TestPromotionEngine
{
    [TestClass]
    public class PromotionEngineTest
    {
        Dictionary<SKU, double> priceList = null;
        //Test
        [TestInitialize]
        public void Init()
        {
            priceList = new Dictionary<SKU, double>();
            priceList.Add(new SKU() { Id = "A" }, 50);
            priceList.Add(new SKU() { Id = "B" }, 30);
            priceList.Add(new SKU() { Id = "C" }, 20);
            priceList.Add(new SKU() { Id = "D" }, 15);
        }
        [TestCleanup]
        public void TestClean()
        {
            
        }

        [TestMethod]
        public void Scenario1_ApplyPromotion_ReturnTotal()
        {
            //Prepare
            Cart cart = new Cart()
            {
                CartSKUs = new List<CartSKU>()
                {
                    new CartSKU()
                    {
                        Id="A",
                        Quantity=1
                    },
                     new CartSKU()
                    {
                        Id="B",
                        Quantity=1
                    },
                      new CartSKU()
                    {
                        Id="C",
                        Quantity=1
                    },
                }
            };



            //Act

            IPromotionEngine promotionEngine = new SCM_PromotionEngine.PromotionEngine(priceList,new PromotionStrategy());
            double result = promotionEngine.ApplyPromotion(cart);

            //Assert
            Assert.AreEqual(100, result);
        }
        [TestMethod]
        public void Scenario2_ApplyPromotion_ReturnTotal()
        {
            //Prepare
            Cart cart = new Cart()
            {
                CartSKUs = new List<CartSKU>()
                {
                    new CartSKU()
                    {
                        Id="A",
                        Quantity=5
                    },
                     new CartSKU()
                    {
                        Id="B",
                        Quantity=5
                    },
                      new CartSKU()
                    {
                        Id="C",
                        Quantity=1
                    },
                }
            };



            //Act

            IPromotionEngine promotionEngine = new SCM_PromotionEngine.PromotionEngine(priceList, new PromotionStrategy());
            double result = promotionEngine.ApplyPromotion(cart);

            //Assert
            Assert.AreEqual(370, result);
        }

        [TestMethod]
        public void Scenario3_ApplyPromotion_ReturnTotal()
        {
            //Prepare
            Cart cart = new Cart()
            {
                CartSKUs = new List<CartSKU>()
                {
                    new CartSKU()
                    {
                        Id="A",
                        Quantity=3
                    },
                     new CartSKU()
                    {
                        Id="B",
                        Quantity=5
                    },
                      new CartSKU()
                    {
                        Id="C",
                        Quantity=1
                    },
                        new CartSKU()
                    {
                        Id="D",
                        Quantity=1
                    },
                }
            };



            //Act

            IPromotionEngine promotionEngine = new SCM_PromotionEngine.PromotionEngine(priceList, new PromotionStrategy());
            double result = promotionEngine.ApplyPromotion(cart);

            //Assert
            Assert.AreEqual(280, result);
        }
    }
}
