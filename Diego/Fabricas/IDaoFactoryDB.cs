using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public interface IDaoFactoryDB
    {
        IDaoJuego CrearDaoJuego();
        IDaoConjunto CrearDaoConjunto();
        IDaoTipoJuego CrearTipoJuego();
    }
}