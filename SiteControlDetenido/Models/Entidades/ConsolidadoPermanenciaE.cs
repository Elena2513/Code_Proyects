using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class ConsolidadoPermanenciaE
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Total_Celda { get; set; }
        public int Capacidad_Celda { get; set; }
        public int Recibido_Turno { get; set; }
        public int Egresos_Detenidos { get; set; }
        public int Ingreso_Detenidos { get; set; }
        public int Detenidos_HombresAdult { get; set; }
        public int Detenidos_MujerAdult { get; set; }
        public int Detenido_HombreAdolesc { get; set; }
        public int Detenido_MujerAdolesc { get; set; }
        public int Total_Genero { get; set; }
        public int Procs_Investigativo { get; set; }
        public int Jlocal_Penal { get; set; }
        public int JDistrito_Penal { get; set; }
        public int Juzgado_Adolesc { get; set; }
        public int Detenido_Condenado { get; set; }
        public int Tota_Detenidos { get; set; }
    }
}