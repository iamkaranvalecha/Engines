using Logics.PromotionEntities.Classes;

namespace Logics.PromotionObjects.Interfaces
{
    public interface IAddToCart
    {
        bool AddProductToCart(CartRequest request);
    }
}