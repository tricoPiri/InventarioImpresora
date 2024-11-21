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
        DAL_Roles objRoles = new DAL_Roles();
        
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public IActionResult ViewAgregar()
        {
            ViewData["Roles"] = objRoles.getRoles();

            return View("Agregar");
        }

        [Authorize(Roles = "1")]
        public IActionResult ViewEditar(int usuario)
        {
            ViewData["idUsuario"] = usuario;
            ViewData["Usuarios"] = objUsuario.getUsuario(usuario);
            ViewData["Roles"] = objRoles.getRoles();

            return View("Editar");
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            try
            {
                listaUsuarios = objUsuario.getUsuarios();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaUsuarios);
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarUsuario(int idUsuario)
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            try
            {
                listaUsuarios = objUsuario.getUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaUsuarios);
        }

        [Authorize(Roles = "1")]
        public decimal registrar(string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string password, int idRol)
        {
            decimal resultado = 0;
            try
            {
                DAL_Usuarios objUsuario = new DAL_Usuarios();
                resultado = objUsuario.registrar(nombre, apellidoPaterno, apellidoMaterno, usuario, password, idRol);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int editar(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string password, int idRol)
        {
            int resultado = 0;
            try
            {
                DAL_Usuarios objUsuario = new DAL_Usuarios();
                resultado = objUsuario.editar(idUsuario, nombre, apellidoPaterno, apellidoMaterno, usuario, password, idRol);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int DesactivarUsuario(int idUsuario)
        {
            int resultado = 0;
            try
            {
                DAL_Usuarios objUsuario = new DAL_Usuarios();
                resultado = objUsuario.desactivar(idUsuario);
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
