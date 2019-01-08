using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public interface IDaoTipoJuego
    {
        void Agregar(TipoJuego entidad);

        void Modifcar(TipoJuego entidad);

        void Eliminar(TipoJuego entidad);

        TipoJuego Consultar(TipoJuego entidad);

        List<TipoJuego> ConsultarTodos();
    }
}