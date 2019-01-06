using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public class MySqlDaoFactory : IDaoFactoryDB
    {
        public IDao<Conjunto> CrearDaoConjunto()
        {
            return new MySqlDaoConjunto();
        }

        public IDao<Juego> CrearDaoJuego()
        {
            return new MySqlDaoJuego();
        }

        public IDao<TipoJuego> CrearTipoJuego()
        {
            return new MySqlDaoTipoJuego();
        }
    }
}