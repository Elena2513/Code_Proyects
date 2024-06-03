using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class ConciliacionE
    {
        public int Id { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string CodDelegacion { get; set; }
        public string DelegacionPolicial { get; set; }
        public int TotalDetenidos { get; set; }
        public int RecibidoDia { get; set; }
        public int IngresoDelito { get; set; }
        public int IngresoFalta { get; set; }
        public int IngresoTransito { get; set; }
        public int EgresoOrdenLibertad { get; set; }
        public int EgresoTrasladoSPN { get; set; }
        public int EgresoTrasladoDelegacion { get; set; }
        public int HombreAdulto { get; set; }
        public int MujerAdulta { get; set; }
        public int HombreAdolescente { get; set; }
        public int MujerAdolescente { get; set; }
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }

    
}