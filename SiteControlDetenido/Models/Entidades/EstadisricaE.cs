using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class EstadisticaE
    {
        public int Total_Saldo { get; set; }
        public int Total_Egresos { get; set; }
        public int Total_Gnral { get; set; }
        public int Total_Detenidos { get; set; }
        public int Total_HombreAdult { get; set; }
        public int Total_HombreAdolesc { get; set; }
        public int Total_MujerAdult { get; set; }
        public int Total_MujerAdolesc { get; set; }
        public int Total_SinSexo { get; set; }
        public int Delitos { get; set; }
        public int Faltas { get; set; }
        public int Transito { get; set; }
        public int Total_Extranjero { get; set; }
        public int Total_AdultoMayor { get; set; }
        public int Total_DetenidoMes { get; set; }

    }

    public class DelitoE
    {
        public string Clasificacion { get; set; }
        public int TOTAL { get; set; }
        public int Codigo { get; set; }
        public int Saldo { get; set; }
        public int Ingreso { get; set; }
        public int Egreso { get; set; }
        public int Celda { get; set; }
    }

    public class DelegacionE
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Total { get; set; }
    }

    public class RangoHoraDiaE
    {
        public string Clasificacion { get; set; }
        public int Total { get; set; }
    }

    public class DetalleE
    {
        public int Idno { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Delito { get; set; }
        public DateTime? Fecha { get; set; }
        public string Nacionalidad { get; set; }
}

    public class EgresosE
    {
        public int Libertad { get; set; }
        public int TrasladoSPN { get; set; }
        public int Otros { get; set; }
    }

    public class ExtrajAdultoE
    {
        public int Extranjero { get; set; }
        public int Adulto { get; set; }
        public int PrisionPreventiva { get; set; }   
    }
}