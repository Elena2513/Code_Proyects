using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class DatosDetenidoE
    {
        public int Idno { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Alias { get; set; }
        public string NombrePadre { get; set; }
        public string NombreMadre { get; set; }
        public string NombreConyuge { get; set; }
        public string DireccionConyuge { get; set; }
        public string Estructura { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Foto { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string Ocupacion { get; set; }
        public string NivelAcademico { get; set; }
        public string CentroTrabajo { get; set; }
        public string DireccionCentroTrabajo { get; set; }
        public string Piel { get; set; }
        public string Ojos { get; set; }
        public float Estatura { get; set; }
        public float Peso { get; set; }
        public string SenasParticulares { get; set; }
        public string UbicaSenas { get; set; }
        public string FamiliarCercano { get; set; }
        public string DireccionFamiliarCercano { get; set; }
        public string EstadoCivil { get; set; }
        public string Complexion { get; set; }
        public string Observaciones { get; set; }
        public string Nacionalidad { get; set; }
        public string FamiliarNotificar { get; set; }
        public string Depto { get; set; }
        
       
        public List<MovimientoE> Movimiento { get; set; }
        public List<DetalleDelitoE> Delito { get; set; }
        public List<DetalleDelitoE> DelitoActivo { get; set; }


        //TIPOS DE MOVIMIENTOS
        public List<MovimientoE> BajaPresunto { get; set; }
        public List<MovimientoE> OrdenLibertad { get; set; }
        public List<MovimientoE> AsistenciaJuzgado { get; set; }
        public List<MovimientoE> TrasladoSPN { get; set; }
        public List<MovimientoE> TrasladoDelegacion { get; set; }
        public List<MovimientoE> TrasladoCelda { get; set; }
        public List<MovimientoE> AsistenciaMedica { get; set; }
        public List<MovimientoE> ValoracionMedica { get; set; }
        public List<MovimientoE> ReunionColectiva { get; set; }
        public List<MovimientoE> PrisionPreventiva { get; set; }
    }
}