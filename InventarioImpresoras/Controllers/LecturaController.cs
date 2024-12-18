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
        public JsonResult ConsultarLectura(int idLectura)
        {
            List<Lecturas> listaLecturas = new List<Lecturas>();
            try
            {
                listaLecturas = objLecturas.getLectura(idLectura);
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
            ViewData["Meses"] = objLecturas.getMeses();
            //ViewData["Impresoras"] = objImpresoras.getImpresoras();
            ViewData["Areas"] = objArea.getAreas();

            return View("Agregar");
        }

        [Authorize(Roles = "1")]
        public IActionResult ViewEditar(int lectura)
        {
            int idLectura = lectura;    
            ViewData["Meses"] = objLecturas.getMeses();
            ViewData["Impresoras"] = objImpresoras.getImpresoras();
            ViewData["Areas"] = objArea.getAreas();
            ViewData["Lectura"] = objLecturas.getLectura(idLectura);
            return View("Editar");
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarImpresorasPorArea(int idArea)
        {
            List<Impresoras> listaImpresoras = new List<Impresoras>();
            try
            {
                listaImpresoras = objImpresoras.getImpresorasPorArea(idArea);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaImpresoras);
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarLecturaAnterior(int idImpresora, int idMes, int año)
        {
            List<Lecturas> listaLecturas = new List<Lecturas>();
            try
            {
                listaLecturas = objLecturas.getLecturaAnterior(idImpresora, idMes, año);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaLecturas);
        }
        [Authorize(Roles = "1")]
        public int CalcularCopiasProcesadas(int lecturaAnterior, int lecturaActual)
        {

            int resultado = lecturaActual - lecturaAnterior;
            return resultado;
        }

        [Authorize(Roles = "1")]
        public decimal registrarLectura(int idMes, int lecturaAnterior, int lecturaActual, string observaciones, int copiasProcesadas, int idImpresora)
        {
            decimal resultado = 0;
            try
            {
                resultado = objLecturas.addLectura(idMes, lecturaAnterior, lecturaActual, observaciones, copiasProcesadas, idImpresora); //objUsuario.registrar(nombre, apellidoPaterno, apellidoMaterno, usuario, password, idRol);
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

