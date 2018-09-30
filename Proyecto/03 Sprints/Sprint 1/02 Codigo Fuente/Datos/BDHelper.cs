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
        //String de conexion a la base de datos
        static string usuario = "sa";
        static string clave = "pav2017";
        static string stringConexion = "Provider=SQLOLEDB.1;Password=" + clave + ";Persist Security Info=True;User ID=" + usuario + ";Initial Catalog=DeliverEat;Data Source=localhost\\SQLEXPRESS";

        public static void Insert(string query)
        {
            //Realiza el insert de la sentencia que entra como parametro
            OleDbConnection conexion = new OleDbConnection();
            OleDbCommand comando = new OleDbCommand();
            
            conexion.ConnectionString = stringConexion;
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = query; 
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public static int Select(string query)
        {
            //Ejecuta la consulta que entra como parametro y devuelve la primera columna de la primera fila
            OleDbConnection conexion = new OleDbConnection();
            OleDbCommand comando = new OleDbCommand();
            
            conexion.ConnectionString = stringConexion;
            conexion.Open();
            
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = query;
            int identity = Convert.ToInt32(comando.ExecuteScalar());

            conexion.Close();

            return identity;
        }
    }
}
