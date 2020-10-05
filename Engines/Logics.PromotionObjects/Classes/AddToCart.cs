using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logics.PromotionObjects.Classes
{
    public class AddToCart : BaseCart, IAddToCart
    {
        public bool AddProductToCart(CartRequest request)
        {
            var response = false;
            if (request != null)
            {
                if (!string.IsNullOrEmpty(request.ProductName) && request.Quantity > 0)
                {
                    var products = BaseProducts.Products;
                    if (products.Count > 0)
                    {
                        var activePromotions = BasePromotions.ActivePromotions;
                        if (activePromotions.Count > 0)
                        {
                            foreach (var product in products)
                            {
                                if (request.ProductName.Equals(product.Name, StringComparison.InvariantCulture))
                                {
                                    var productPromotion =
                                        activePromotions.Where(x => x.SkuId.Equals(product.Id)).ToList();

                                    MapAndAddQuantityAndPriceAsPerPromotion(productPromotion, request);
                                }
                            }
                        }
                    }
                }
            }

            return response;
        }

        private void MapAndAddQuantityAndPriceAsPerPromotion(List<ActivePromotion> activePromotions, CartRequest cartRequest)
        {
            if (activePromotions.Count > 0 && cartRequest != null)
            {
                foreach (var activePromotion in activePromotions)
                {
                    var promotionQuantity = activePromotion.Quantity;
                    if (cartRequest.Quantity > promotionQuantity)
                    {

                    }
                    else
                    {
                        Cart.Products.Add(activePromotion.SkuId);
                        Cart.TotalValue += activePromotion.FinalPrice;
                    }
                }
            }
        }
    }
}
