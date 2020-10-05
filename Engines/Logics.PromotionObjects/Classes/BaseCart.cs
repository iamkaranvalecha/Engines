using Logics.PromotionEntities.Classes;
using System.Collections.Generic;

namespace Logics.PromotionObjects.Classes
{
    public class BaseCart
    {
        public static Cart Cart;

        public BaseCart()
        {
            Cart = new Cart();
        }
    }
}
