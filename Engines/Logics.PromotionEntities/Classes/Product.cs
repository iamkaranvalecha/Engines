using System;
using System.Runtime.Serialization;

namespace Logics.PromotionEntities.Classes
{
    [Serializable]
    public class Product
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public bool IsCombinedProduct { get; set; }
    }
}
