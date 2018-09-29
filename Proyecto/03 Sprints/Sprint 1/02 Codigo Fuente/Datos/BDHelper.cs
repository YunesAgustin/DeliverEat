using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Datos
{
    class BDHelper
    {
        //local connection string
        static string user = "sa";
        static string pass = "pav2017";
        static String cnxString = "Provider=SQLOLEDB.1;Password=" + pass + ";Persist Security Info=True;User ID=" + user + ";Initial Catalog=DeliverEat;Data Source=localhost\\SQLEXPRESS";

        public static void insert(string query)
        {
            OleDbConnection cnx = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            //abro conexion
            cnx.ConnectionString = cnxString;
            cnx.Open();
            //comando
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            //execute
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public static int select(string query)
        {
            OleDbConnection cnx = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            //abro conexion
            cnx.ConnectionString = cnxString;
            cnx.Open();
            //comando
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            //cargo tabla
            int identity = Convert.ToInt32(cmd.ExecuteScalar());
            return identity;
        }
    }
}
