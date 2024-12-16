using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class LecturaController : Controller
    {
        DAL_Lecturas objLecturas = new DAL_Lecturas();
        DAL_Impresoras objImpresoras = new DAL_Impresoras();
        DAL_Areas objArea = new DAL_Areas();
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarLecturas()
        {
            List<Lecturas> listaLecturas = new List<Lecturas>();
            try
            {
                listaLecturas = objLecturas.getLecturas();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaLecturas);
        }

        [Authorize(Roles = "1")]
        public IActionResult ViewAgregar()
        {
            DAL_Roles objRoles = new DAL_Roles();
            ViewData["Roles"] = objRoles.getRoles();
            ViewData["Meses"] = objLecturas.getMeses();
            ViewData["Impresoras"] = objImpresoras.getImpresoras();
            ViewData["Areas"] = objArea.getAreas();

            return View("Agregar");
        }

    }
}

