using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class ConsolidadoE
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Saldo_Anterior { get; set; }
        public int Ingresos { get; set; }
        public int Egresos { get; set; }
        public int Total_Gnral { get; set; }
        public int Delitos { get; set; }
        public int Faltas { get; set; }
        public int Hombres { get; set; }
        public int Mujeres { get; set; }
        public int Total { get; set; }
    }

    public class PruebaE
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int total { get; set; }
    }
}