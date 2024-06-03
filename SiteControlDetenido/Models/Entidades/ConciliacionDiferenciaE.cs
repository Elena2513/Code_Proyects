using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class ConciliacionDiferenciaE
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Fisico_TotalDetenidos { get; set; }
        public int Sicond_TotalDetenidos { get; set; }
        public int Diferencia_TotalDetenidos { get; set; }
        public int fisico_RecibidoDia { get; set; }
        public int sicond_RecibidoDia { get; set; }
        public int Diferencia_RecibidoDia { get; set; }
        public int Fisico_IngresoDelito { get; set; }
        public int Sicond_IngresoDelito { get; set; }
        public int Diferencia_IngresoDelito { get; set; }
        public int Sicond_IngresoFalta { get; set; }
        public int Fisico_IngresoFalta { get; set; }
        public int Diferencia_IngresoFalta { get; set; }
        public int Sicond_IngresoTransito { get; set; }
        public int Fisico_IngresoTransito { get; set; }
        public int Diferencia_IngresoTransito { get; set; }
        public int Sicond_EgresoLibertad { get; set; }
        public int Fisico_EgresoLibertad { get; set; }
        public int Diferencia_EgresoLibertad { get; set; }
        public int Sicond_EgresoTrasladoSPN { get; set; }
        public int Fisico_EgresoTrasladoSPN { get; set; }
        public int Diferencia_EgresoTrasladoSPN { get; set; }
        public int Sicond_EgresoTrasladoDeleg { get; set; }
        public int Fisico_EgresoTrasladoDeleg { get; set; }
        public int Diferencia_EgresoTrasladoDeleg { get; set; }
    }
}