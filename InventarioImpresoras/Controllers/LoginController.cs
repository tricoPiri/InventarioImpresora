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
            return View();
        }

        [HttpPost]
        public async Task<string> Login(string usuario, string contrasena)
        {
            try
            {
                DAL_Login objLogin = new DAL_Login();
                List<Usuarios> listUsuarios = new List<Usuarios>();
                listUsuarios = objLogin.Login(usuario, contrasena);

                if (listUsuarios.Count == 0)
                {
                    return "401";
                }

                int idUsuario = Convert.ToInt32(listUsuarios[0].IdUsuario);

                if (listUsuarios.Count > 0)
                {

                    var claims = new List<Claim>
                    {
                        new Claim("IdUsuario", Convert.ToString(listUsuarios[0].IdUsuario)),
                        new Claim("Usuario", Convert.ToString(listUsuarios[0].Usuario)),
                        new Claim(ClaimTypes.Role,  Convert.ToString(listUsuarios[0].Roles[0].IdRol))
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return Convert.ToString(listUsuarios[0].Roles[0].IdRol);

                }
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return "402";
        }

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
        
    }
}
