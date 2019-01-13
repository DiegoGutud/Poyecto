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

        public Juego Consultar(String nombreJuego)
        {
            Juego JuegoRespuesta = new Juego();


            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TB_JUEGO WHERE NOMBRE=@nombre";
                command.Parameters.AddWithValue("nombre", nombreJuego);
                command.CommandType = CommandType.Text;

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {

                    JuegoRespuesta.idJuego = Convert.ToInt32(reader[0]);
                    JuegoRespuesta.TipoJuego = Convert.ToInt32(reader[1]);
                    JuegoRespuesta.nombre = reader[2].ToString();
                    JuegoRespuesta.Estatus = Convert.ToInt32(reader[3]);
                    JuegoRespuesta.FactorPago = Convert.ToInt32(reader[4]);
                    JuegoRespuesta.TiempoCierre = Convert.ToInt32(reader[5]);



                }


                

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



            JuegoRespuesta.Items = ConsultarItems(JuegoRespuesta.idJuego);
            JuegoRespuesta.Conjuntos = ConsultarConjunto(JuegoRespuesta.idJuego);

            return JuegoRespuesta;

        }

        public List<Item> ConsultarItems(int idJuego)
        {
            List<Item> listaI = new List<Item>();
            try
           {
               connection = DB.connectToDB();

               command = connection.CreateCommand();
               command.CommandText = "SELECT * FROM TB_ITEM WHERE ID_JUEGO=@idJuego";
               command.Parameters.AddWithValue("idJuego", idJuego);
               command.CommandType = CommandType.Text;

               connection.Open();

               MySqlDataReader reader = command.ExecuteReader();


               while (reader.Read())
                {
                    Item item = new Item();

                    item.idItem = Convert.ToInt32(reader[0]);
                    item.idJuego = Convert.ToInt32(reader[1]);
                    item.nombre = reader[2].ToString();
                    item.valor = reader[3].ToString();
                    item.cupo = Convert.ToInt32(reader[4]);
                    item.monto = Convert.ToDecimal(reader[5]);
                    item.estatus = Convert.ToInt32(reader[6]);

                    listaI.Add(item);

                }


               return listaI;

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

        public List<Conjunto> ConsultarConjunto(int idJuego)
        {
            List<Conjunto> listaC = new List<Conjunto>();
            try
            {
               
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TB_CONJUNTO WHERE ID_JUEGO=@idJuego";
                command.Parameters.AddWithValue("idJuego", idJuego);
                command.CommandType = CommandType.Text;

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Conjunto conjunto = new Conjunto();

                    conjunto.idConjunto= Convert.ToInt32(reader[0]);
                    conjunto.idJuego = Convert.ToInt32(reader[1]);
                    conjunto.nombre = reader[2].ToString();
                    conjunto.monto = Convert.ToDecimal(reader[3]);
                    conjunto.Estatus = Convert.ToInt32(reader[4]);

                    listaC.Add(conjunto);

                }


                

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


            foreach (Conjunto conjunto in listaC)
            {
                conjunto.Items = ConsultarItemsConjunto(conjunto.idConjunto); 
            }


            return listaC;

        }

        public List<Item> ConsultarItemsConjunto(int idConjunto)
        {
            List<Item> listaI = new List<Item>();
            try
            {
                connection = DB.connectToDB();

                command = connection.CreateCommand();
                command.CommandText = "SELECT A.ID_ITEM, A.ID_JUEGO, A.NOMBRE, A.VALOR, B.CUPO_MAX, B.MONTO_MAX, A.ESTATUS FROM TB_ITEM A JOIN TB_CONJUNTO_ITEM B ON A.ID_ITEM = B.ID_ITEM WHERE B.ID_CONJUNTO = @idConjunto;";
                command.Parameters.AddWithValue("idConjunto", idConjunto);
                command.CommandType = CommandType.Text;

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Item item = new Item();

                    item.idItem = Convert.ToInt32(reader[0]);
                    item.idJuego = Convert.ToInt32(reader[1]);
                    item.nombre = reader[2].ToString();
                    item.valor = reader[3].ToString();
                    item.cupo = Convert.ToInt32(reader[4]);
                    item.monto = Convert.ToDecimal(reader[5]);
                    item.estatus = Convert.ToInt32(reader[6]);

                    listaI.Add(item);

                }


                return listaI;

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