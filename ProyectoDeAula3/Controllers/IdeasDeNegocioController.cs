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

        public List<Departamento> ObtenerListaDeDepartamentos()
        {
         

            var departamentos = new List<Departamento>
    {
        new Departamento { Codigo = 01, Nombre = "Departamento 1" },
        new Departamento { Codigo = 02, Nombre = "Departamento 2" },
        new Departamento { Codigo = 03, Nombre = "Departamento 3" },
        
    };

            return departamentos;
        }

        public List<string> ObtenerListaDeHerramientas4RI()
        {
           

            var herramientas4RI = new List<string>
    {
        "Inteligencia Artificial",
        "Internet de las Cosas (IoT)",
        "Big Data",
        "Blockchain",
        "Realidad Virtual",
        
    };

            return herramientas4RI;
        }


        public ActionResult Index()
        {
            return View(ideasDeNegocio);
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Crear()
        {

            List<string> herramientas4RI = ObtenerListaDeHerramientas4RI();

            
            ViewBag.Herramientas4RI = new SelectList(herramientas4RI);

            ViewBag.Departamentos = ObtenerListaDeDepartamentos();

            return View();
           
        }

        public List<IdeaDeNegocio> ObtenerTodasLasIdeasDeNegocio()
        {
           
            return ideasDeNegocio;
        }

        public IdeaDeNegocio ObtenerIdeaConMayorImpacto()
        {
            
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

            
            var ideaMayorImpacto = todasLasIdeas.OrderByDescending(i => i.ImpactoSocialOEconomico).FirstOrDefault();

            return ideaMayorImpacto;
        }

        public IdeaDeNegocio ObtenerIdeaConMayorIngresos()
        {
            
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

            
            var ideaMayorIngresos = todasLasIdeas.OrderByDescending(i => i.IngresosGenerados3Anios).FirstOrDefault();

            return ideaMayorIngresos;
        }

        public List<IdeaDeNegocio> ObtenerIdeasMasRentables()
        {
            
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

           
            var ideasOrdenadasPorIngresos = todasLasIdeas.OrderByDescending(i => i.IngresosGenerados3Anios).ToList();

            
            var ideasMasRentables = ideasOrdenadasPorIngresos.Take(3).ToList();

            return ideasMasRentables;
        }

        public List<IdeaDeNegocio> ObtenerIdeasConImpactoEnMasDe3Departamentos()
        {
            
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

            
            var ideasConImpactoEnMasDe3Departamentos = todasLasIdeas
                .Where(i => i.DepartamentosBeneficiados.Count > 3)
                .ToList();

            return ideasConImpactoEnMasDe3Departamentos;
        }

        public List<IdeaDeNegocio> ObtenerIdeasConHerramientas4RI()
        {
          
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

            
            var ideasConHerramientas4RI = todasLasIdeas
                .Where(i => i.Herramientas4RI != null && i.Herramientas4RI.Any())
                .ToList();

            return ideasConHerramientas4RI;
        }

        public List<IdeaDeNegocio> ObtenerIdeasDesarrolloSostenible()
        {
          
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();
            var ideasDesarrolloSostenible = todasLasIdeas
                .Where(idea => idea.ImpactoSocialOEconomico != null &&
                               idea.ImpactoSocialOEconomico.IndexOf("Desarrollo sostenible", StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            return ideasDesarrolloSostenible;
        }

        private List<string> FrasesEspecificas = new List<string>
{
    "Territorios inteligentes",
    "Transicion energetica"
};

        public List<IdeaDeNegocio> ObtenerIdeasConFrasesEspecificas()
        {
         
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

           
            var ideasConFrasesEspecificas = todasLasIdeas
                .Where(idea => idea.ImpactoSocialOEconomico != null &&
                               FrasesEspecificas.Any(frase =>
                                   idea.ImpactoSocialOEconomico.IndexOf(frase, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            return ideasConFrasesEspecificas;
        }

        public IdeaDeNegocio ObtenerIdeaConMayorInversionEnInfraestructura()
        {
            
            var todasLasIdeas = ObtenerTodasLasIdeasDeNegocio();

          
            var ideaMayorInversion = todasLasIdeas
                .OrderByDescending(idea => idea.ValorInversionInfraestructura)
                .FirstOrDefault(); 

            return ideaMayorInversion;
        }


        [HttpPost]
        public ActionResult Crear(IdeaDeNegocio idea) { 
                

        
         
                
                idea.Codigo = ideasDeNegocio.Count + 1;

                
                ideasDeNegocio.Add(idea);

                
                return RedirectToAction("Index");
            
        }

        public ActionResult Detalles()
        {


            return View();
        }

        public ActionResult IdeaConMayorImpacto()
        {
            
            var ideaMayorImpacto = ObtenerIdeaConMayorImpacto();
            var ideaMayorIngresos = ObtenerIdeaConMayorIngresos();

            return View(new Tuple<IdeaDeNegocio, IdeaDeNegocio>(ideaMayorImpacto, ideaMayorIngresos));
        }

        public ActionResult IdeasMasRentables()
        {
            
            var ideasRentables = ObtenerIdeasMasRentables();

            return View(ideasRentables);
        }


        public ActionResult IdeasConImpactoEnMasDe3Departamentos()
        {
           
            var ideasConImpacto = ObtenerIdeasConImpactoEnMasDe3Departamentos();

            return View(ideasConImpacto);
        }

        public ActionResult IdeasConHerramientas4RI()
        {
            
            var ideasConHerramientas4RI = ObtenerIdeasConHerramientas4RI();

            return View(ideasConHerramientas4RI);
        }

        public ActionResult IdeasConFrasesEspecificas()
        {
            
            var ideasConFrasesEspecificas = ObtenerIdeasConFrasesEspecificas();

            return View(ideasConFrasesEspecificas);
        }

        public ActionResult IdeaConMayorInversionEnInfraestructura()
        {
            
            var ideaMayorInversion = ObtenerIdeaConMayorInversionEnInfraestructura();

            return View(ideaMayorInversion);
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

        public ActionResult IdeasDesarrolloSostenible()
        {
            
            var ideasDesarrolloSostenible = ObtenerIdeasDesarrolloSostenible();

            return View(ideasDesarrolloSostenible);
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
