using System.Runtime.Serialization;
using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class MarcaController : Controller
    {
        DAL_Marcas objMarca = new DAL_Marcas();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarMarcas()
        {
            List<Marcas> listaMarcas = new List<Marcas>();
            try
            {
                listaMarcas = objMarca.getMarcas();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaMarcas);
        }

    }
}
