using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ING_service.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioJuego" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioJuego.svc o ServicioJuego.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioJuego : IServicioJuego
    {
        
        public int Agregar(Juego juego)
        {
            IDaoFactoryDB DaoDB = new MySqlDaoFactory();
            IDaoJuego DaoJuego = DaoDB.CrearDaoJuego();
            return DaoJuego.Agregar(juego);
        }

        public Juego Consultar(Juego juego)
        {
            IDaoFactoryDB DaoDB = new MySqlDaoFactory();
            IDaoJuego DaoJuego = DaoDB.CrearDaoJuego();
            return DaoJuego.Consultar(juego);
        }

        public List<Juego> ConsultarTodos()
        {
            IDaoFactoryDB DaoDB = new MySqlDaoFactory();
            IDaoJuego DaoJuego = DaoDB.CrearDaoJuego();
            return DaoJuego.ConsultarTodos();
        }

        public int Eliminar(Juego juego)
        {
            IDaoFactoryDB DaoDB = new MySqlDaoFactory();
            IDaoJuego DaoJuego = DaoDB.CrearDaoJuego();
            return DaoJuego.Eliminar(juego);
        }

        public int Modifcar(Juego juego)
        {
            IDaoFactoryDB DaoDB = new MySqlDaoFactory();
            IDaoJuego DaoJuego = DaoDB.CrearDaoJuego();
            return DaoJuego.Modifcar(juego);
        }
    }
}
