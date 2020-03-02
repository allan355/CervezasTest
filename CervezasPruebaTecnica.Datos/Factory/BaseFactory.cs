using CervezasPruebaTecnica.Datos.SQLServer.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Datos.Factory
{
    public abstract class BaseFactory
    {
        public abstract Insertar Insertar();
        public abstract Obtener Obtener();
    }
}
