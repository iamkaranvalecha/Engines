using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Interfaces;

namespace Logics.PromotionObjects.Classes
{
    public class AddPromotions : BasePromotions, IAddPromotions
    {
        public void AddPromotion(ActivePromotion activePromotion)
        {
            ActivePromotions?.Add(activePromotion);
        }
    }
}
