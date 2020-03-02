using CervezasPruebaTecnica.Datos.SQLServer.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Datos.Factory
{
    public class SQLServerFactory : BaseFactory
    {
        public override Insertar Insertar()
        {
            return new Insertar();
        }

        public override Obtener Obtener()
        {
            return new Obtener();
        }
    }
}
