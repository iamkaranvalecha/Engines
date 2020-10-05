using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Logics.PromotionEntities.Classes
{
    [Serializable]
    public class Cart
    {
        [DataMember]
        public decimal TotalValue { get; set; }

        [DataMember]
        public long NumberOfItems { get; set; }

        [DataMember]
        public List<long> Items { get; set; }
    }
}
