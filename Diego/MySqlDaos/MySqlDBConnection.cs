using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace ING_service
{
    public class MySqlDBConnection
    {
        public MySqlConnection connectToDB()
        {
           MySqlConnectionStringBuilder connStBld = new MySqlConnectionStringBuilder();

            connStBld.Server = "127.0.0.1";
            connStBld.Port = 3306;
            connStBld.Database = "loto";
            connStBld.UserID = "root";
            connStBld.Password = "MyFortachon";

            return new MySqlConnection(connStBld.ToString());
            
        }
    }
}