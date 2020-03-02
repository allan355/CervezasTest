using CervezasPruebaTecnica.Datos.SQLServer.Conexion;
using CervezasPruebaTecnica.Entidades.DTO;
using CervezasPruebaTecnica.Logica.Logica;
using CervezasPruebaTecnica.Logica.Miscelanios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace CervezasPruebaTecnica.Logica.Usuario
{
    public class UsuarioLogica
    {
        public static void CrearUsuario(ref HttpStatusCode estado, DTOUsuario usuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("Nombre", usuario.Nombre);
                parametros.Add("Apellido1", usuario.Apellido1);
                parametros.Add("Apellido2", usuario.Apellido2);
                parametros.Add("Alias", usuario.Alias);
                parametros.Add("Contrasena", Miscelanios.Ecriptacion.Encriptar(usuario.Contrasena, true));
                parametros.Add("TipoUsuarioId", usuario.Admin ? 1 : 2);
                Base.baseFactory.Insertar().Insert("PA_InsertarUsuario", parametros);
                estado = HttpStatusCode.Created;
            }
            catch (SqlException sqlex)
            {
                estado = MetodosComunes.SQLCatch(sqlex.Number);
                throw;
            }
            catch (Exception e)
            {
                estado = HttpStatusCode.InternalServerError;
                throw;
            }
        }

        public static DTOLoginRespuesta Login(ref HttpStatusCode estado, ref string mensaje, DTOUsuario usuario)
        {
            DTOLoginRespuesta loginRespuesta = new DTOLoginRespuesta();
            try
            {
                if (string.IsNullOrEmpty(usuario.Alias) || string.IsNullOrEmpty(usuario.Contrasena))
                {
                    estado = HttpStatusCode.BadRequest;
                    mensaje = "Alias o contrasena no ingresados";
                    return null;
                }
                var parametros = new Dictionary<string, object>();
                parametros.Add("Alias", usuario.Alias);
                parametros.Add("Contrasena", Miscelanios.Ecriptacion.Encriptar(usuario.Contrasena, true));
                loginRespuesta = Base.baseFactory.Obtener().ObtenerLista<DTOLoginRespuesta>("PA_Login", parametros)[0];
                if (string.IsNullOrEmpty(loginRespuesta.TOKEN))
                {
                    estado = HttpStatusCode.Unauthorized;
                    mensaje = "Alias o Contraseña incorrectos";
                }
                else
                {
                    estado = HttpStatusCode.Created;
                    mensaje = "OK";
                }
            }
            catch (SqlException sqlex)
            {
                MetodosComunes.SQLCatch(sqlex.Number);
                //throw;
            }
            catch (Exception e)
            {
                //estado = HttpStatusCode.InternalServerError;
                throw;
            }
            return loginRespuesta;
        }
    }
}
