using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public interface IDaoFactoryDB
    {
        IDao<Juego> CrearDaoJuego();
        IDao<Conjunto> CrearDaoConjunto();
        IDao<TipoJuego> CrearTipoJuego();
    }
}