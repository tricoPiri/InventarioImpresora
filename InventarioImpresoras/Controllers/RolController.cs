using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class RolController : Controller
    {
        DAL_Roles objRol = new DAL_Roles();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarRoles()
        {
            List<Roles> listaRoles = new List<Roles>();
            try
            {
                listaRoles = objRol.getRoles();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaRoles);
        }

        [Authorize(Roles = "1")]
        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                DAL_Roles objRoles = new DAL_Roles();
                resultado = objRoles.registrar(nombre);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int editar(int idRol, string nombre)
        {
            int resultado = 0;
            try
            {
                DAL_Roles objRoles = new DAL_Roles();
                resultado = objRoles.editar(idRol, nombre);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }
        [Authorize(Roles = "1")]
        public int DesactivarRol(int idRol)
        {
            int resultado = 0;
            try
            {
                DAL_Roles objRol = new DAL_Roles();
                resultado = objRol.desactivar(idRol);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }
        [Authorize(Roles = "1")]
        public int ActivarRol(int idRol)
        {
            int resultado = 0;
            try
            {
                DAL_Roles objRol = new DAL_Roles();
                resultado = objRol.activar(idRol);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }
    }
}
