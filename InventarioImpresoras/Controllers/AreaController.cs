using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class AreaController : Controller
    {
        DAL_Areas objArea = new DAL_Areas();
        // GET: AreaController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarAreas()
        {
            List<Areas> listaAreas = new List<Areas>();
            try
            {
                listaAreas = objArea.getAreas();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaAreas);
        }

        [Authorize(Roles = "1")]
        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                
                resultado = objArea.registrar(nombre);
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
