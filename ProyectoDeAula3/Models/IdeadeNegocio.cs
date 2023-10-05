using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDeAula3.Models
{
    public class IdeaDeNegocio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string ImpactoSocialOEconomico { get; set; }
        public List<Departamento> DepartamentosBeneficiados { get; set; }
        public decimal ValorInversion { get; set; }
        public decimal IngresosGenerados3Anios { get; set; }
        public List<IntegranteEquipo> Integrantes { get; set; }
        public List<string> Herramientas4RI { get; set; }
        public decimal ValorInversionInfraestructura { get; set; }
    }

    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }

    


    public class IntegranteEquipo
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
    }

}