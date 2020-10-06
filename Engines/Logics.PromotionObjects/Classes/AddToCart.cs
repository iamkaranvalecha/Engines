using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logics.PromotionObjects.Classes
{
    public class AddToCart : BaseCart, IAddToCart
    {
        public void AddProductToCart(List<CartRequest> request)
        {
            if (request != null && request.Count > 0)
            {
                var isCombinedSkipped = false;
                foreach (var cartRequest in request)
                {
                    if (!string.IsNullOrEmpty(cartRequest.ProductName) && cartRequest.Quantity > 0)
                    {
                        var products = BaseProducts.Products;
                        if (products.Count > 0)
                        {
                            var activePromotions = BasePromotions.ActivePromotions;
                            if (activePromotions.Count > 0)
                            {
                                var individualProduct = products.FirstOrDefault(x => x.Name == cartRequest.ProductName
                                    &&
                                    !x.IsCombinedProduct);

                                if (cartRequest.ProductName.Equals(individualProduct?.Name, StringComparison.InvariantCulture))
                                {
                                    var productPromotion =
                                        activePromotions.Where(x => x.SkuId.Equals(individualProduct?.Id)).ToList();

                                    MapAndAddQuantityAndPriceAsPerIndividualPromotion(productPromotion, cartRequest,
                                        individualProduct);
                                }

                                var combinedProduct = products.FirstOrDefault(x => x.Name == cartRequest.ProductName
                                    &&
                                    x.IsCombinedProduct);

                                if (cartRequest.ProductName.Equals(combinedProduct?.Name, StringComparison.InvariantCulture))
                                {
                                    var productPromotion =
                                        activePromotions.Where(x => x.SkuId.Equals(combinedProduct?.Id)).ToList();

                                    MapAndAddQuantityAndPriceAsPerIndividualPromotion(productPromotion, cartRequest,
                                        combinedProduct, true, isCombinedSkipped);

                                    isCombinedSkipped = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MapAndAddQuantityAndPriceAsPerIndividualPromotion(List<ActivePromotion> activePromotions,
            CartRequest cartRequest, Product product, bool isCombined = false, bool isCombinedSkipped = false)
        {
            if (activePromotions.Count > 0 && cartRequest != null)
            {
                foreach (var activePromotion in activePromotions)
                {
                    Cart.Products.Add(product.Id);
                    var promotionQuantity = activePromotion.Quantity;
                    var cartQuantity = cartRequest.Quantity;
                    var remainingQuantity = cartQuantity;
                    if (isCombined && isCombinedSkipped)
                    {
                        //Add Promotion Price
                        Cart.TotalValue += activePromotion.FinalPrice;
                    }
                    else
                    {
                        if (cartQuantity >= promotionQuantity)
                        {
                            for (decimal i = 0; i < remainingQuantity;)
                            {
                                if (remainingQuantity >= promotionQuantity)
                                {
                                    //Add Promotion Price
                                    Cart.TotalValue += activePromotion.FinalPrice;
                                    remainingQuantity -= promotionQuantity;
                                }
                                else
                                {
                                    //Add Unit Price
                                    Cart.TotalValue += product.UnitPrice;
                                    remainingQuantity -= 1;
                                }
                            }
                        }
                        else
                        {
                            Cart.TotalValue += product.UnitPrice;
                        }
                    }
                }
            }
        }
    }
}
