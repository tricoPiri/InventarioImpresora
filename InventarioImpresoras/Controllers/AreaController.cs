﻿using InventarioImpresoras.DAL;
using InventarioImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioImpresoras.Controllers
{
    public class AreaController : Controller
    {
        DAL_Areas objArea = new DAL_Areas();
        // GET: AreaController
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public JsonResult ConsultarAreas()
        {
            List<Areas> listaAreas = new List<Areas>();
            try
            {
                listaAreas = objArea.getAreas();
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
            }
            return Json(listaAreas);
        }

        [Authorize(Roles = "1")]
        public decimal registrar(string nombre)
        {
            decimal resultado = 0;
            try
            {
                
                resultado = objArea.registrar(nombre);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int editar(int idArea, string nombre)
        {
            int resultado = 0;
            try
            {
                resultado = objArea.editar(idArea, nombre);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int DesactivarArea(int idArea)
        {
            int resultado = 0;
            try
            {
                //DAL_Roles objRol = new DAL_Roles();
                resultado = objArea.desactivar(idArea);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }
        [Authorize(Roles = "1")]
        public int ActivarArea(int idArea)
        {
            int resultado = 0;
            try
            {
                resultado = objArea.activar(idArea);
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
