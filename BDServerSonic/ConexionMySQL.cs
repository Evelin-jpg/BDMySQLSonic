
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BDServerSonic
{
    class ConexionMySQL
    {
        public static MySqlConnection conexion = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "sonic";
        static string ususario = "root";
        static string password = "Sonic";
        static string port = "3306";

        static String cadenaConexion = "server=" + servidor + ";" + "user id =" + ususario + ";" + "password=" + password + ";" + "port=" +port+ ";" + "database=" + bd + ";";

        private static void conectar()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                //MessageBox.Show("Se conecto correctamente la base de datos");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se puede conectar a la base de datos de Sql Server, error:" + e.ToString());
            }


        }

        public static DataTable EjecutaConsultaSelect(string consulta)
        {
            conectar();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public static void EjecutaConsulta(string consulta)
        {
            conectar();
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
