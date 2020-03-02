using CervezasPruebaTecnica.Datos.SQLServer.Conexion;
using CervezasPruebaTecnica.Entidades.DTO;
using CervezasPruebaTecnica.Logica.Miscelanios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Logica.Logica
{
    public class CervezaLogica
    {
        public static void CrearCerveza(ref HttpStatusCode estado, DTOCerveza cerveza)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("Marca", cerveza.Marca);
                parametros.Add("Alcohol", cerveza.Alcohol);
                parametros.Add("TipoId", cerveza.TipoId);
                parametros.Add("PaisId", cerveza.PaisId);
                Base.baseFactory.Insertar().Insert("PA_NuevaCerveza", parametros);
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

        public static void AgregarHistorico(ref HttpStatusCode estado, DTOHistoricoCerveza cerveza)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("UsuarioId", cerveza.UsuarioId);
                parametros.Add("CervezaId", cerveza.CervezaId);
                parametros.Add("Consumo", cerveza.Consumo);
                Base.baseFactory.Insertar().Insert("PA_AgregarHistoricoCerveza", parametros);
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

        public static List<DTOConsumo> ObtenerConsumo(ref HttpStatusCode estado, ref string mensaje, DateTime FechaInicio, DateTime FechaFin, int? id)
        {
            List<DTOConsumo> Consumo = new List<DTOConsumo>();
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("FechaInicio", FechaInicio);
                parametros.Add("FechaFin", FechaFin);
                parametros.Add("IdUsuario", id);
                Consumo = Base.baseFactory.Obtener().ObtenerLista<DTOConsumo>("PA_ObtenerConsumoFechas", parametros);

                estado = HttpStatusCode.Found;
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
            return Consumo;
        }

        public static List<DTOCerveza> ObtenerTodo(ref HttpStatusCode estado, ref string mensaje)
        {
            List<DTOCerveza> lstCervezas = new List<DTOCerveza>();
            try
            {
                var parametros = new Dictionary<string, object>();
                lstCervezas = Base.baseFactory.Obtener().ObtenerLista<DTOCerveza>("PA_ObtenerTodasCervezas", parametros);
                mensaje = $"La cantidad de cervezas en el sistema es de {lstCervezas.Count()} cerveza{(lstCervezas.Count() == 1 ? "" : "s")}";
                estado = HttpStatusCode.OK;
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
            return lstCervezas;
        }

        public static DTOCerveza ObtenerCerveza(ref HttpStatusCode estado, ref string mensaje, int id)
        {
            DTOCerveza Cerveza = new DTOCerveza();
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("Id", id);
                var Cervezas = Base.baseFactory.Obtener().ObtenerLista<DTOCerveza>("PA_ObtenerCervezas", parametros);
                if (Cervezas.Count() == 0)
                {
                    estado = HttpStatusCode.NotFound;
                    mensaje = "no se encontro la cerveza";
                    return null;
                }
                Cerveza = Cervezas[0];
                estado = HttpStatusCode.Found;
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
            return Cerveza;
        }

    }
}
