using CervezasPruebaTecnica.Datos.Factory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Datos.SQLServer.Conexion
{
    public class Conexion
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CervezasEntities"].ToString());
        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;

        }
    }
}
