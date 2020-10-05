using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Logics.PromotionEntities.Classes
{
    [Serializable]
    public class CartRequest
    {
        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public string ProductName { get; set; }
    }

    [Serializable]
    public class Cart
    {
        public Cart()
        {
            Products = new List<long>();
        }

        [DataMember]
        public decimal TotalValue { get; set; }

        [DataMember]
        public List<long> Products { get; set; }
    }
}
