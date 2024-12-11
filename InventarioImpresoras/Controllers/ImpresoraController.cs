﻿using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using InventarioImpresoras.DAL;
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
        [Authorize(Roles = "1")]
        public IActionResult ViewAgregar()
        {
            DAL_Marcas objMarcas  = new DAL_Marcas();
            DAL_Modelos objModelos = new DAL_Modelos();
            DAL_Areas objAreas = new DAL_Areas();
            
            ViewData["Marcas"] = objMarcas.getMarcas();
            ViewData["Modelos"] = objModelos.getModelos();
            ViewData["Areas"] = objAreas.getAreas();

            return View("Agregar");
        }

        public IActionResult ViewEditar(int Impresora)
        {
            int idImpresora = Impresora;
            DAL_Marcas objMarcas = new DAL_Marcas();
            DAL_Modelos objModelos = new DAL_Modelos();
            DAL_Areas objAreas = new DAL_Areas();

            ViewData["idImpresora"] = idImpresora;
            ViewData["Marcas"] = objMarcas.getMarcas();
            ViewData["Modelos"] = objModelos.getModelos();
            ViewData["Areas"] = objAreas.getAreas();
            ViewData["Impresora"] = objImpresora.getImpresora(idImpresora);


            return View("Editar");
        }

        [Authorize(Roles = "1")]
        public decimal registrar(string numeroSerie, string nombre, int idMarca, int idModelo, int idArea)
        {
            decimal resultado = 0;
            try
            {
                resultado = objImpresora.registrar(numeroSerie, nombre, idMarca, idModelo,  idArea);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }
        [Authorize(Roles = "1")]
        public decimal editar(int idImpresora, string numeroSerie, string nombre, int idMarca, int idModelo, int idArea)
        {
            decimal resultado = 0;
            try
            {
                resultado = objImpresora.editar(idImpresora, numeroSerie, nombre, idMarca, idModelo, idArea);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }
        [Authorize(Roles = "1")]
        public int Desactivar(int idImpresora)
        {
            int resultado = 0;
            try
            {
                resultado = objImpresora.desactivar(idImpresora);
            }
            catch (Exception ex)
            {
                DAL_Utilerias.FormatoExcepcion(ex);
                return resultado;
            }

            return resultado;
        }

        [Authorize(Roles = "1")]
        public int Activar(int idImpresora)
        {
            int resultado = 0;
            try
            {
                resultado = objImpresora.activar(idImpresora);
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





