using Logics.PromotionEntities.Classes;
using System.Collections.Generic;

namespace Logics.PromotionObjects.Interfaces
{
    public interface IAddToCart
    {
        void AddProductToCart(List<CartRequest> request);
    }
}