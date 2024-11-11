using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class RolesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
