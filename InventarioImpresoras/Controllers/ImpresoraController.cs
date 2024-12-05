using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class ImpresoraController : Controller
    {
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
