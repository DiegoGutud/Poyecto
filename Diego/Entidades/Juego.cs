using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ING_service
{
    [DataContract]
    public class Juego
    {
       
            [DataMember(Order = 1)]
            public int idJuego { get; set; }
            [DataMember(Order = 2)]
            public int TipoJuego { get; set; }
            [DataMember(Order = 3)]
            public String nombre { get; set; }
            [DataMember(Order = 4)]
            public int Estatus { get; set; }
            [DataMember(Order = 5)]
            public int FactorPago { get; set; }
            [DataMember(Order = 6)]
            public int TiempoCierre { get; set; }
            [DataMember(Order = 7)]
            public List<Item> Items { get; set; }
            [DataMember(Order = 8)]
            public List<Conjunto> Conjuntos { get; set; }
    }
}