using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Logica.Miscelanios
{
    public class MetodosComunes
    {
        public static HttpStatusCode SQLCatch(int Error)
        {
            switch (Error)
            {
                case 2627:
                case 515:
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
