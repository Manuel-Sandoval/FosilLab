using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Fosiles.Models.Settings;
using Oracle.DataAccess.Client;

namespace Fosiles.Models.DAO
{
    public class Conexion
    {
        OracleConnection connection;

        public void conectar(Config conf)
        {
            this.connection = new OracleConnection();
            connection.ConnectionString = getConexion(conf);

            try
            {
                connection.Open();
            }
            catch (OracleException ex)
            {

                //Mandar Mensaje
                MessageBox.Show(ex.Message, "Advertencia");
                
            }

        }

        public OracleDataReader ejecutarSentencia (string sentencia)
        {

            OracleDataReader reader;

            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = sentencia;
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                reader.Read();
            }

            return reader;
        }

        public int ejecutarDML(string sentencia)
        {
            int filasAfectadas = 0;
            OracleDataReader reader = ejecutarSentencia(sentencia);
            filasAfectadas = (int) reader.GetDecimal(0);
            return filasAfectadas;
        }

        public void desconectar()
        {
            this.connection.Close();
            this.connection.Dispose();
        }

        public string getConexion(Config config)
        {
            return "Data Source = (DESCRIPTION = " +
              "(ADDRESS = (PROTOCOL = " + config.Protocol + ")(HOST = " + config.Host + ")(PORT = " + config.Port + "))" +
              "(CONNECT_DATA = " +
                "(SERVER = " + config.Server + ")" +
                "(SERVICE_NAME = " + config.ServiceName + ")" +
              ")" +
            ");User Id = " + config.User + ";password=" + config.Password + ";";

        }
    }
}
