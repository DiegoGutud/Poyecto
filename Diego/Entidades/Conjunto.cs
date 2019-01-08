using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ING_service
{
    [DataContract]
    public class Conjunto
    {

        [DataMember(Order = 1)]
        public int idConjunto { get; set; }
        [DataMember(Order = 2)]
        public int idJuego { get; set; }
        [DataMember(Order = 3)]
        public String nombre { get; set; }
        [DataMember(Order = 4)]
        public decimal monto { get; set; }
        [DataMember(Order = 5)]
        public int Estatus { get; set; }
    }
}
