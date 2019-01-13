using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace ING_service
{
    [DataContract]
    public class Item
    {
        [DataMember(Order = 1)]
        public int idItem { get; set; }
        [DataMember(Order = 2)]
        public int idJuego{ get; set; }
        [DataMember(Order = 3)]
        public String nombre{ get; set; }
        [DataMember(Order = 4)]
        public String valor { get; set; }
        [DataMember(Order = 5)]
        public int cupo { get; set; }
        [DataMember(Order = 6)]
        public decimal monto { get; set; }
        [DataMember(Order = 7)]
        public int estatus { get; set; }
    }
}