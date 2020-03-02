using CervezasPruebaTecnica.Entidades.DTO;
using CervezasPruebaTecnica.Logica.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CervezasPruebaTecnica.Controllers.API
{
    public class CervezaController : ApiController
    {
        [HttpPost]
        [Route("api/cerveza/add")]
        public HttpResponseMessage AgregarCerveza(DTOPeticion<DTOCerveza> peticion)
        {
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                CervezaLogica.CrearCerveza(ref estado, peticion.Entidad);
                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <String>>(this, new DTORespuesta<string>() { Mensaje = "OK" }, estado);
            }
            catch (Exception e)
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/cerveza/consumo/add")]
        public HttpResponseMessage AgregaConsumo(DTOPeticion<DTOHistoricoCerveza> peticion)
        {
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                CervezaLogica.AgregarHistorico(ref estado, peticion.Entidad);
                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <String>>(this, new DTORespuesta<string>() { Mensaje = "OK" }, estado);
            }
            catch (Exception e)
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/cerveza/consumo")]
        public HttpResponseMessage ObtenerTodo(DateTime FechaInicio, DateTime FechaFin, int? id)
        {
            string mensaje = string.Empty;
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                List<DTOConsumo> lst = CervezaLogica.ObtenerConsumo(ref estado, ref mensaje, FechaInicio, FechaFin, id);

                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <DTOConsumo>>(this, new DTORespuesta<DTOConsumo>() { Mensaje = mensaje, Datos = lst }, estado);
            }
            catch
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/Cerveza/All")]
        public HttpResponseMessage ObtenerTodo()
        {
            string mensaje = string.Empty;
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                List<DTOCerveza> lst = CervezaLogica.ObtenerTodo(ref estado, ref mensaje);

                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <DTOCerveza>>(this, new DTORespuesta<DTOCerveza>() { Mensaje = mensaje, Datos = lst }, estado);
            }
            catch
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/Cerveza/{id}")]
        public HttpResponseMessage Obtener(int id)
        {
            string mensaje = string.Empty;
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                DTOCerveza token = CervezaLogica.ObtenerCerveza(ref estado, ref mensaje, id);

                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <DTOCerveza>>(this, new DTORespuesta<DTOCerveza>() { Mensaje = mensaje, Entidad = token }, estado);
            }
            catch
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }

    }
}
