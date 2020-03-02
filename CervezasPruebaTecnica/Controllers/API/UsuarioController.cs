using CervezasPruebaTecnica.Entidades.DTO;
using CervezasPruebaTecnica.Logica.Miscelanios;
using CervezasPruebaTecnica.Logica.Usuario;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CervezasPruebaTecnica.Controllers.API
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/usuario/add")]
        public HttpResponseMessage AgregarNuevoUsuario(DTOPeticion<DTOUsuario> peticion)
        {
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                UsuarioLogica.CrearUsuario(ref estado, peticion.Entidad);
                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <String>>(this, new DTORespuesta<string>() { Mensaje = "OK" }, estado);
            }
            catch (Exception e)
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/usuario/login")]
        public HttpResponseMessage Login(DTOPeticion<DTOUsuario> peticion)
        {
            string mensaje = string.Empty;
            HttpStatusCode estado = default(HttpStatusCode);
            try
            {
                DTOLoginRespuesta token = UsuarioLogica.Login(ref estado, ref mensaje, peticion.Entidad);

                return HTTPResponseHelp.CrearResponse<DTORespuesta
                    <DTOLoginRespuesta>>(this, new DTORespuesta<DTOLoginRespuesta>() { Mensaje = mensaje, Entidad = token }, estado);
            }
            catch
            {
                return HTTPResponseHelp.CrearResponse<DTORespuesta<String>>(this, new DTORespuesta<string>() { Mensaje = "Error" }, HttpStatusCode.InternalServerError);
            }
        }
    }
}
