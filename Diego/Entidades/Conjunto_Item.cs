using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace ING_service
{
    [DataContract]
    public class Conjunto_Item
    {
        [DataMember(Order = 1)]
        public int idConjuntoItem { get; set; }
        [DataMember(Order = 2)]
        public int idItem { get; set; }
        [DataMember(Order = 3)]
        public int idConjunto { get; set; }
        [DataMember(Order = 4)]
        public int cupoMax { get; set; }
        [DataMember(Order = 5)]
        public decimal montoMax { get; set; }
        [DataMember(Order = 6)]
        public int estatus { get; set; }
    }
}