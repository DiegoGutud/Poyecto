using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ING_service
{
    [DataContract]
    public class TipoJuego
    {
        [DataMember(Order = 1)]
        public int idTipoJuego { get; set; }
        [DataMember(Order = 2)]
        public String Descripcion { get; set; }
        [DataMember(Order = 3)]
        public String Pagina { get; set; }
        [DataMember(Order = 4)]
        public int Estatus { get; set; }
    }
}
