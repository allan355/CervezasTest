using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CervezasPruebaTecnica.Controllers
{
    public class HTTPResponseHelp
    {
        public static HttpResponseMessage CrearResponse<T1>(ApiController controller, T1 objeto, HttpStatusCode statusCode)
        {
            HttpResponseMessage response = controller.Request.CreateResponse<T1>(statusCode, objeto);

            return response;
        }
    }
}