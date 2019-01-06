using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace WcfService1
{
    public class MySqlDaoItem : IDaoItem
    {
        MySqlConnection conn;
        MySqlCommand comm;


        public MySqlDaoItem()
        {
            conn = new MySqlDBConnection();
            comm = new MySqlCommand();
        }

        public void Agregar(Item I)
        {
            try
            {
                comm.CommandText = "INSERT INTO persona VALUES (@idJuego,@nombre,@valor,@cupo,@monto,@estatus)";
                comm.Parameters.AddWithValue("idJuego", I.idJuego);
                comm.Parameters.AddWithValue("nombre", I.nombre);
                comm.Parameters.AddWithValue("valor", I.valor);
                comm.Parameters.AddWithValue("cupo", I.cupo);
                comm.Parameters.AddWithValue("monto", I.monto);
                comm.Parameters.AddWithValue("estatus", I.estatus);
                comm.CommandType = CommandType.Text;
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //return new Respuesta(ex.Message, "ERROR", null);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public Item Consultar(Item entidad)
        {
            throw new NotImplementedException();
        }

        public List<Item> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Item entidad)
        {
            throw new NotImplementedException();
        }

        public void Modifcar(Item entidad)
        {
            throw new NotImplementedException();
        }
    }
}