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

        [Authorize(Roles = "1")]
        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                resultado = objMarca.registrar(nombre);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int editar(int idMarca, string nombre)
        {
            int resultado = 0;
            try
            {
                resultado = objMarca.editar(idMarca, nombre);
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
