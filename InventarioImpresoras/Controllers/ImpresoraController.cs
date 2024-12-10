﻿using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class ImpresoraController : Controller
    {
        DAL_Impresoras objImpresora = new DAL_Impresoras();
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarImpresoras()
        {
            List<Impresoras> listaImpresoras = new List<Impresoras>();
            try
            {
                listaImpresoras = objImpresora.getImpresoras();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaImpresoras);
        }
    }
}




