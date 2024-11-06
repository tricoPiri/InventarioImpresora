using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
//using Serilog;
using System.Security.Claims;
using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using InventarioImpresoras.DAL;

namespace RH.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            DAL_Conexion objConexion = new DAL_Conexion();
            objConexion.Conectar();
            return View();
        }

        /*
        [HttpPost]
        
        public async Task<string> Login(string usuario, string contrasena)
        {
            try
            {
                DAL_Login objLogin = new DAL_Login();
                List<Login> listLogin = new List<Login>();
                listLogin = objLogin.Login(usuario, contrasena);

                if (listLogin.Count == 0)
                {
                    return "404";
                }

				int idUsuario = Convert.ToInt32(listLogin[0].IdUsuario);
                string rol = null;

                if (listLogin.Count > 0)
                {
                    var obtenerPermisos = objLogin.obtenerPermisos(idUsuario);
                    if (obtenerPermisos.Count > 0)
                    {
                        if (obtenerPermisos[0].Admin == true)
                        {
                            //rol = "Administrador";
                            //consulta todo
                            rol = "1";
                        }
                        else if (obtenerPermisos[0].Exp_RH == true && obtenerPermisos[0].Aux_BD == false)
                        {
                            //rol = "Exp_RH";
                            //captura todo
                            rol = "2";
                        }
                        else if (obtenerPermisos[0].Exp_RH == true && obtenerPermisos[0].Aux_BD == true) 
                        {
                            //rol = "Exp_RH";
                            //captura todo y edita todo
                            rol = "3";
                        }
                    }

                    var claims = new List<Claim>
                    {
                        new Claim("IdUsuario", Convert.ToString(listLogin[0].IdUsuario)),
                        new Claim("Usuario", Convert.ToString(listLogin[0].Usuario)),
                        new Claim(ClaimTypes.Role, rol)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    
                    return rol;
                    
                }
            }
            catch (Exception ex)
            {
				//DAL_Utilerias.FormatoExcepcion(ex);
			}
            return "404";
        }
        */
        /*
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }

            return RedirectToAction("Index", "Login");
        }
        */
    }
}
