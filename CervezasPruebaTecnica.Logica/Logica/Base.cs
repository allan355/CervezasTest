using CervezasPruebaTecnica.Datos.Factory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Logica.Logica
{

    public class Base
    {
        public static BaseFactory baseFactory;
        public static void DefinirBase()
        {
            AppSettingsReader settingsReader = new AppSettingsReader();
            switch (settingsReader.GetValue("Base", typeof(String)).ToString().ToUpper())
            {
                case "SQLSERVER":
                    baseFactory = new SQLServerFactory();
                    break;
                case "MYSQLSERVER":
                default:
                    baseFactory = new SQLServerFactory();
                    break;
            }
        }
    }
}
