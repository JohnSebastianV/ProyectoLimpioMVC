using ProyectoDeAula3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDeAula3.Controllers
{
    public class IdeasDeNegocioController : Controller
    {
        private static List<IdeaDeNegocio> ideasDeNegocio = new List<IdeaDeNegocio>();

        public ActionResult Index(List<IdeaDeNegocio> ideasDeNegocio)
        {
            return View(ideasDeNegocio);
        }

        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(IdeaDeNegocio idea)
        {
            if (ModelState.IsValid)
            {
                
                idea.Codigo = ideasDeNegocio.Count + 1;

                
                ideasDeNegocio.Add(idea);

                
                return RedirectToAction("Index");
            }

            return View(idea);
        }

        public ActionResult Detalles(int codigo)
        {
            var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigo);
            if (idea == null)
            {
                return RedirectToAction("Index");
            }
            return View(idea);
        }

       
        [HttpPost]
        public ActionResult AgregarIntegrante(int codigo, IntegranteEquipo integrante)
        {
            try
            {
                var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigo);
                if (idea == null)
                {
                    return RedirectToAction("Index");
                }

                
                if (idea.Integrantes == null)
                {
                    idea.Integrantes = new List<IntegranteEquipo>();
                }

              
                idea.Integrantes.Add(integrante);

                return RedirectToAction("Detalles", new { codigo });
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError(string.Empty, "Ocurrió un error al agregar el integrante. Por favor, inténtelo nuevamente.");
                return View();
            }
        }



        
        [HttpPost]
        public ActionResult EliminarIntegrante(int codigo, string identificacion)
        {
            try
            {
                var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigo);
                if (idea != null)
                {
                    var integrante = idea.Integrantes.FirstOrDefault(i => i.Identificacion == identificacion);
                    if (integrante != null)
                    {
                        idea.Integrantes.Remove(integrante);
                    }
                }
                return RedirectToAction("Detalles", new { codigo });
            }
            catch (Exception ex)
            {
              
                ModelState.AddModelError(string.Empty, "Ocurrió un error al eliminar el integrante. Por favor, inténtelo nuevamente.");
                return View();
            }
        }


        
        [HttpPost]
        public ActionResult EditarInversionIngresos(int codigo, decimal valorInversion, decimal ingresos3Anios)
        {
            try
            {
                var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigo);
                if (idea != null)
                {
                    idea.ValorInversion = valorInversion;
                    idea.IngresosGenerados3Anios = ingresos3Anios;
                }
                return RedirectToAction("Detalles", new { codigo });
            }
            catch (Exception ex)
            {
              
                ModelState.AddModelError(string.Empty, "Ocurrió un error al editar los datos. Por favor, inténtelo nuevamente.");
                return View();
            }
        }

    }
}
