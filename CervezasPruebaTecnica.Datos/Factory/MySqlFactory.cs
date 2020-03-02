using CervezasPruebaTecnica.Datos.SQLServer.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Datos.Factory
{
    public class MySqlFactory : BaseFactory
    {
        public override Insertar Insertar()
        {
            throw new NotImplementedException();
        }

        public override Obtener Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
