using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public interface IDao<T>
    {
        T Agregar(T entidad);

        T Modifcar(T entidad);

        void Eliminar(T entidad);

        T Consultar(T entidad);

        List<T> ConsultarTodos();
        
    }
}