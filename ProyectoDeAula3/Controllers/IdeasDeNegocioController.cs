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
                // Genera un código único para la idea de negocio
                idea.Codigo = ideasDeNegocio.Count + 1;

                // Agrega la nueva idea de negocio a la lista
                ideasDeNegocio.Add(idea);

                // Redirige al usuario a la página de lista de ideas de negocio
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

        // Acción para agregar un integrante al equipo
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

                // Asegúrate de que idea.Integrantes no sea null
                if (idea.Integrantes == null)
                {
                    idea.Integrantes = new List<IntegranteEquipo>();
                }

                // Lógica para agregar el integrante al equipo aquí
                idea.Integrantes.Add(integrante);

                return RedirectToAction("Detalles", new { codigo });
            }
            catch (Exception ex)
            {
                // Manejo de la excepción, como registrarla en un archivo de registro o mostrar un mensaje de error al usuario
                ModelState.AddModelError(string.Empty, "Ocurrió un error al agregar el integrante. Por favor, inténtelo nuevamente.");
                return View();
            }
        }



        // Acción para eliminar un integrante del equipo
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
                // Manejo de la excepción, como registrarla en un archivo de registro o mostrar un mensaje de error al usuario
                ModelState.AddModelError(string.Empty, "Ocurrió un error al eliminar el integrante. Por favor, inténtelo nuevamente.");
                return View();
            }
        }


        // Acción para editar el valor de la inversión y el total de ingresos
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
                // Manejo de la excepción, como registrarla en un archivo de registro o mostrar un mensaje de error al usuario
                ModelState.AddModelError(string.Empty, "Ocurrió un error al editar los datos. Por favor, inténtelo nuevamente.");
                return View();
            }
        }

    }
}
