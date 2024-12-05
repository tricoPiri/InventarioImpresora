using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InventarioImpresoras.Controllers
{
    public class ModeloController : Controller
    {
        DAL_Modelos objModelo = new DAL_Modelos();

        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarModelos()
        {
            List<Modelos> listaModelos = new List<Modelos>();
            try
            {
                listaModelos = objModelo.getModelos();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaModelos);
        }

        [Authorize(Roles = "1")]
        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                resultado = objModelo.registrar(nombre);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        //[Authorize(Roles = "1")]
        //public int editar(int idRol, string nombre)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        DAL_Roles objRoles = new DAL_Roles();
        //        resultado = objRoles.editar(idRol, nombre);
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL_Utilerias.FormatoExcepcion(ex);
        //        return resultado;
        //    }

        //    return resultado;
        //}
        //[Authorize(Roles = "1")]
        //public int DesactivarRol(int idRol)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        DAL_Roles objRol = new DAL_Roles();
        //        resultado = objRol.desactivar(idRol);
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL_Utilerias.FormatoExcepcion(ex);
        //        return resultado;
        //    }

        //    return resultado;
        //}
        //[Authorize(Roles = "1")]
        //public int ActivarRol(int idRol)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        DAL_Roles objRol = new DAL_Roles();
        //        resultado = objRol.activar(idRol);
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL_Utilerias.FormatoExcepcion(ex);
        //        return resultado;
        //    }

        //    return resultado;
        //}
    }
}
