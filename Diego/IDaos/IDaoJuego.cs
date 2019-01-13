using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public interface IDaoJuego
    {
        int Agregar(Juego entidad);

        int Modifcar(Juego entidad);

        int Eliminar(Juego entidad);

        Juego Consultar(String nombreJuego);

        List<Juego> ConsultarTodos();
    }
}