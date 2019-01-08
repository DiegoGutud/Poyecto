using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ING_service
{
    public class MySqlDaoFactory : IDaoFactoryDB
    {
        public IDaoConjunto CrearDaoConjunto()
        {
            return new MySqlDaoConjunto();
        }

        public IDaoJuego CrearDaoJuego()
        {
            return new MySqlDaoJuego();
        }

        public IDaoTipoJuego CrearTipoJuego()
        {
            return new MySqlDaoTipoJuego();
        }
    }
}