using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Classes;
using System.Collections.Generic;

namespace Tests.PromotionEngine.Shared
{
    public class MockProductAndPromotions
    {
        public MockProductAndPromotions()
        {
            AddProducts();
            AddPromotions();
        }

        public void AddProducts()
        {
            BaseProducts.Products = new List<Product>
            {
                new Product {Id = 1, Name = "A", UnitPrice = 50},
                new Product {Id = 2, Name = "B", UnitPrice = 30},
                new Product {Id = 3, Name = "C", UnitPrice = 20},
                new Product {Id = 4, Name = "D", UnitPrice = 15}
            };
        }

        public void AddPromotions()
        {
            BasePromotions.ActivePromotions = new List<ActivePromotion>
            {
                new ActivePromotion {SkuId = 1, Quantity = 3, FinalPrice = 130},
                new ActivePromotion {SkuId = 2, Quantity = 2, FinalPrice = 45},
                new ActivePromotion {SkuId = 3, Quantity = 1, FinalPrice = 20},
                new ActivePromotion {SkuId = 4 , Quantity = 1, FinalPrice = 30}
            };
        }
    }
}
