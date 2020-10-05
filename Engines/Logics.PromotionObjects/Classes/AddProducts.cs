using Logics.PromotionEntities.Classes;
using Logics.PromotionObjects.Interfaces;

namespace Logics.PromotionObjects.Classes
{
    public class AddProducts : BaseProducts, IAddProducts
    {
        public void AddProduct(Product product)
        {
            Products?.Add(product);
        }
    }
}
