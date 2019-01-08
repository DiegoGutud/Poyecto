using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public interface IDaoConjunto 
    {
        void Agregar(Conjunto entidad);

        void Modifcar(Conjunto entidad);

        void Eliminar(Conjunto entidad);

        Conjunto Consultar(Conjunto entidad);

        List<Conjunto> ConsultarTodos();
    }
}