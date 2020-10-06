using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Classes;
using System.Collections.Generic;
using Tests.PromotionEngine.Mocks;
using Xunit;

namespace Tests.PromotionEngine.Classes
{
    public class AddToCartTest : MockAddToCart
    {
        [Fact]
        public void AddToCart_SingleQuantityTest()
        {
            var request = new List<CartRequest> {
                new CartRequest {
                    ProductName = "A",
                    Quantity = 1
                },
                new CartRequest {
                    ProductName = "B",
                    Quantity = 1
                },
                new CartRequest {
                    ProductName = "C",
                    Quantity = 1
                }
            };

            var addToCart = new AddToCart();

            addToCart.AddProductToCart(request);

            Assert.True(BaseCart.Cart.TotalValue == 100);
        }

        [Fact]
        public void AddToCart_WithPromotions()
        {
            var request = new List<CartRequest> {
                new CartRequest {
                    ProductName = "A",
                    Quantity = 5
                },
                new CartRequest {
                    ProductName = "B",
                    Quantity = 5
                },
                new CartRequest {
                    ProductName = "C",
                    Quantity = 1
                }
            };

            var addToCart = new AddToCart();

            addToCart.AddProductToCart(request);

            Assert.True(BaseCart.Cart.TotalValue == 370);
        }

        [Fact]
        public void AddToCart_WithPromotionsAndCombined()
        {
            var request = new List<CartRequest> {
                new CartRequest {
                    ProductName = "A",
                    Quantity = 3
                },
                new CartRequest {
                    ProductName = "B",
                    Quantity = 5
                },
                new CartRequest {
                    ProductName = "C",
                    Quantity = 1
                },
                new CartRequest
                {
                    ProductName = "D",
                    Quantity = 1
                }
            };

            var addToCart = new AddToCart();

            addToCart.AddProductToCart(request);

            Assert.True(BaseCart.Cart.TotalValue == 280);
        }
    }
}
