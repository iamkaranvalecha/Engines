using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logics.PromotionObjects.Classes
{
    public class AddToCart : BaseCart, IAddToCart
    {
        public void AddProductToCart(CartRequest request)
        {
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
                            foreach (var product in products.Where(x => !x.IsCombinedProduct))
                            {
                                if (request.ProductName.Equals(product.Name, StringComparison.InvariantCulture))
                                {
                                    var productPromotion =
                                        activePromotions.Where(x => x.SkuId.Equals(product.Id)).ToList();

                                    MapAndAddQuantityAndPriceAsPerIndividualPromotion(productPromotion, request, product);
                                }
                            }

                            foreach (var product in products.Where(x => x.IsCombinedProduct))
                            {
                                if (request.ProductName.Equals(product.Name, StringComparison.InvariantCulture))
                                {
                                    var productPromotion =
                                        activePromotions.Where(x => x.SkuId.Equals(product.Id)).ToList();

                                    MapAndAddQuantityAndPriceAsPerIndividualPromotion(productPromotion, request, product, true);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MapAndAddQuantityAndPriceAsPerIndividualPromotion(List<ActivePromotion> activePromotions, CartRequest cartRequest, Product product, bool isCombined = false)
        {
            if (activePromotions.Count > 0 && cartRequest != null)
            {
                foreach (var activePromotion in activePromotions)
                {
                    Cart.Products.Add(product.Id);
                    var promotionQuantity = activePromotion.Quantity;
                    var cartQuantity = cartRequest.Quantity;
                    var remainingQuantity = cartQuantity;
                    if (cartQuantity > promotionQuantity)
                    {
                        if (isCombined)
                        {
                            Cart.TotalValue += activePromotion.FinalPrice;
                            continue;
                        }

                        for (decimal i = 0; i < remainingQuantity;)
                        {
                            if (remainingQuantity > promotionQuantity)
                            {
                                //Add Promotion Price
                                Cart.TotalValue += activePromotion.FinalPrice;
                                remainingQuantity = cartQuantity - promotionQuantity;
                                i += promotionQuantity;
                            }
                            else
                            {
                                //Add Unit Price
                                Cart.TotalValue += product.UnitPrice;
                                i++;
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
