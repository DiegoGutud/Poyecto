using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace WcfService1
{
    public class MySqlDaoConjunto_Item : IDaoConjunto_Item
    {
        MySqlConnection conn;
        MySqlCommand comm;

        public MySqlDaoConjunto_Item()
        {
            conn = new MySqlDBConnection();
            comm = new MySqlCommand();
        }

        public void Agregar(Conjunto_Item C)
        {
            try
            {
                comm.CommandText = "INSERT INTO persona VALUES (@idItem,@idConjunto,@cupoMax,@montoMax,@estatus)";
                comm.Parameters.AddWithValue("idItem", C.idItem);
                comm.Parameters.AddWithValue("idConjunto", C.idConjunto);
                comm.Parameters.AddWithValue("cupoMax", C.cupoMax);
                comm.Parameters.AddWithValue("montoMax", C.montoMax);
                comm.Parameters.AddWithValue("estatus", C.estatus);
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

        public Conjunto_Item Consultar(Conjunto_Item entidad)
        {
            throw new NotImplementedException();
        }

        public List<Conjunto_Item> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Conjunto_Item entidad)
        {
            throw new NotImplementedException();
        }

        public void Modifcar(Conjunto_Item entidad)
        {
            throw new NotImplementedException();
        }
    }
}