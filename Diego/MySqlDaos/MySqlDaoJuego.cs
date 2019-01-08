using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ING_service
{
    public class MySqlDaoJuego : IDaoJuego
    {
        public MySqlDBConnection DB;
        public MySqlConnection connection;
        public MySqlCommand command;


        public MySqlDaoJuego()
        {
            DB = new MySqlDBConnection();
        }


        public int Agregar(Juego juego)
        {

            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TB_JUEGO VALUES(@idJuego, @TipoJuego, @nombre, @Estatus, @FactorPago, @TiempoCierre)";
                command.Parameters.AddWithValue("idJuego", juego.idJuego);
                command.Parameters.AddWithValue("TipoJuego",juego.TipoJuego);
                command.Parameters.AddWithValue("nombre", juego.nombre);
                command.Parameters.AddWithValue("Estatus", juego.Estatus);
                command.Parameters.AddWithValue("FactorPago", juego.FactorPago);
                command.Parameters.AddWithValue("TiempoCierre", juego.TiempoCierre);

                command.CommandType = CommandType.Text;

                connection.Open();


                return command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
           
        }

        public Juego Consultar(Juego juego)
        {
            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TB_JUEGO WHERE NOMBRE=@nombre";
                command.Parameters.AddWithValue("nombre", juego.nombre);
                command.CommandType = CommandType.Text;

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {

                    juego.idJuego = Convert.ToInt32(reader[0]);
                    juego.TipoJuego = Convert.ToInt32(reader[1]);
                    juego.nombre = reader[2].ToString();
                    juego.Estatus = Convert.ToInt32(reader[3]);
                    juego.FactorPago = Convert.ToInt32(reader[4]);
                    juego.TiempoCierre = Convert.ToInt32(reader[5]);



                }


                return juego;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<Juego> ConsultarTodos()
        {
            List<Juego> listaJ = new List<Juego>();
            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TB_JUEGO";
                command.CommandType = CommandType.Text;

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Juego juego = new Juego();

                    juego.idJuego = Convert.ToInt32(reader[0]);
                    juego.TipoJuego = Convert.ToInt32(reader[1]);
                    juego.nombre = reader[2].ToString();
                    juego.Estatus = Convert.ToInt32(reader[3]);
                    juego.FactorPago = Convert.ToInt32(reader[4]);
                    juego.TiempoCierre = Convert.ToInt32(reader[5]);

                    listaJ.Add(juego);



                }


                return listaJ;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            
        }

        public int Eliminar(Juego juego)
        {
            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM TB_JUEGO WHERE NOMBRE=@nombre";
                command.Parameters.AddWithValue("nombre", juego.nombre);

                command.CommandType = CommandType.Text;

                connection.Open();


                return command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public int Modifcar(Juego juego)
        {
            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "UPDATE TB_JUEGO SET  ID_TIPOJUEGO=@TipoJuego, NOMBRE=@nombre, ESTATUS=@Estatus, FACTORPAGO= @FactorPago, TIEMPOCIERRE=@TiempoCierre WHERE ID_JUEGO=@idJuego";
                command.Parameters.AddWithValue("idJuego", juego.idJuego);
                command.Parameters.AddWithValue("TipoJuego", juego.TipoJuego);
                command.Parameters.AddWithValue("nombre", juego.nombre);
                command.Parameters.AddWithValue("Estatus", juego.Estatus);
                command.Parameters.AddWithValue("FactorPago", juego.FactorPago);
                command.Parameters.AddWithValue("TiempoCierre", juego.TiempoCierre);

                command.CommandType = CommandType.Text;

                connection.Open();


                return command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}