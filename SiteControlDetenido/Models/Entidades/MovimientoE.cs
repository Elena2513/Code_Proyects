using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class MovimientoE
    {
        public int Idno { get; set; }
        public int IDD { get; set; }
        public string Motivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string NoAsunto { get; set; }
        public string Juzgado { get; set; }
        public string Ubicacion { get; set; }
        public string Procesos { get; set; }
        public string MotivoJuzgado { get; set; }
        public string NombreDoctor { get; set; }
        public string ValoracionMedica { get; set; }
        public string MotivoObserva { get; set; }
        public string OrdenLibertad { get; set; }
        public string NoExpediente { get; set; }
        public string JefeAutoriza { get; set; }
        public string MotivoLibertad { get; set; }
        public string MotivoObservaRC { get; set; }
        public string OrdenTraslado { get; set; }
        public string NoExpedienteT { get; set; }
        public string JefeAutorizaT { get; set; }
        public string OficialET { get; set; }
        public string OficialRT { get; set; }
        public string MotivoTD { get; set; }
        public string OficialEntrega { get; set; }
        public string OficialRecibe { get; set; }
        public string MotivoTraslado { get; set; }
        public string MotivoObservaTC { get; set; }
        public string CeldaActual { get; set; }
        public string CeldaDestino { get; set; }
        public string MotivoCelda { get; set; }
        public string ForenceA { get; set; }
        public string Valoracion { get; set; }
        public string IML { get; set; } 

    }

    public class DetalleDelitoE
    {
        public int IDD { get; set; }
        public int idno { get; set; }
        public DateTime? FechaDetencion { get; set; }
        public string HoraDetencion { get; set; }
        public string Investigador { get; set; }
        public string LugarDetencion { get; set; }
        public string Celda { get; set; }
        public string TipoDetencion { get; set; }
        public string MotivoDetencion { get; set; }
        public string Codigo { get; set; }
        public string Delito { get; set; }
    }
}