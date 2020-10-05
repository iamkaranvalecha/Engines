using Logics.PromotionEntities.Classes;
using System.Collections.Generic;

namespace Logics.PromotionObjects.Classes
{
    public class BasePromotions
    {
        public static List<ActivePromotion> ActivePromotions;

        public BasePromotions()
        {
            ActivePromotions = new List<ActivePromotion>();
        }
    }
}
