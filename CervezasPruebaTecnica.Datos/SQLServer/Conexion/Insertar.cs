using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Datos.SQLServer.Conexion
{
    public class Insertar
    {

        public void Insert(string procedureName, Dictionary<string, object> Parametros)
        {
            Conexion conexion = new Conexion();
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = procedureName;
            comando.CommandType = CommandType.StoredProcedure;
            foreach (var param in Parametros)
            {
                comando.Parameters.AddWithValue($"@{param.Key}", param.Value);
            }
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
    }
}