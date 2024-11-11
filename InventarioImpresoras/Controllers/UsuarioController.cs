using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class UsuarioController : Controller
    {
        DAL_Usuarios objUsuario = new DAL_Usuarios();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            try
            {
                listaUsuarios = objUsuario.getEmpleados();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaUsuarios);
        }

        [Authorize(Roles = "1")]
        public IActionResult ViewAgregar()
        {
            //ViewData["Cat_Area"] = objCatalogo.getArea();
            //ViewData["EmpleadosHijosTrue"] = objHijo.getHijosEmpleadosTrue();

            return View("Agregar");
        }












    }
}
