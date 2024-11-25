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
    }
}
