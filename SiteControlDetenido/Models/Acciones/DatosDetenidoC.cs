using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using SiteControlDetenido.Models.Entidades;

namespace SiteControlDetenido.Models.Acciones
{
    public class DatosDetenidoC
    {
        public static DatosDetenidoE Get_DatosDetenido(int Idno)
        {
            DatosDetenidoE d = new DatosDetenidoE();
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Idno", Idno));  
            string sql = "Sicond_Datos_Detenido";
            DataTable dt = Data.Query(sql, parametros, CommandType.StoredProcedure, strConnString);

            if (dt.Rows.Count > 0)
            {
                d.Idno = int.Parse(dt.Rows[0]["Idno"].ToString());
                d.Cedula = dt.Rows[0]["Cedula"].ToString();
                d.NombreCompleto = dt.Rows[0]["NombreCompleto"].ToString();
                d.Nombre1 = dt.Rows[0]["Nombre1"].ToString();
                d.Nombre2 = dt.Rows[0]["Nombre2"].ToString();
                d.Apellido1 = dt.Rows[0]["Apellido1"].ToString();
                d.Apellido2 = dt.Rows[0]["Apellido2"].ToString();
                d.Alias = dt.Rows[0]["Alias"].ToString();
                d.NombrePadre = dt.Rows[0]["NombrePadre"].ToString();
                d.NombreMadre = dt.Rows[0]["NombreMadre"].ToString();
                d.NombreConyuge = dt.Rows[0]["NombreConyuge"].ToString();
                d.Estructura = dt.Rows[0]["Estructura"].ToString();
                d.Direccion = dt.Rows[0]["Direccion"].ToString();
                d.FechaNac = DateTime.Parse(dt.Rows[0]["FechaNac"].ToString());
                d.Sexo = dt.Rows[0]["Sexo"].ToString();
                d.Edad = int.Parse(dt.Rows[0]["Edad"].ToString());
                d.FechaRegistro = DateTime.Parse(dt.Rows[0]["FechaRegistro"].ToString());
                d.Nacionalidad = dt.Rows[0]["Nacionalidad"].ToString();
                d.Ocupacion = dt.Rows[0]["Ocupacion"].ToString();
                d.NivelAcademico = dt.Rows[0]["NivelAcademico"].ToString();
                d.CentroTrabajo = dt.Rows[0]["CentroTrabajo"].ToString();
                d.DireccionCentroTrabajo = dt.Rows[0]["DireccionCentroTrabajo"].ToString();
                d.EstadoCivil = dt.Rows[0]["EstadoCivil"].ToString();
                d.DireccionConyuge = dt.Rows[0]["DireccionConyuge"].ToString();
                d.Ojos = dt.Rows[0]["Ojos"].ToString();
                d.Estatura = float.Parse(dt.Rows[0]["Estatura"].ToString());
                d.Peso = float.Parse(dt.Rows[0]["Peso"].ToString());
                d.SenasParticulares = dt.Rows[0]["SenasParticulares"].ToString();
                d.UbicaSenas = dt.Rows[0]["UbicaSenas"].ToString();
                d.FamiliarCercano = dt.Rows[0]["FamiliarCercano"].ToString();
                d.DireccionFamiliarCercano = dt.Rows[0]["DireccionFamiliarCercano"].ToString();
                d.Piel = dt.Rows[0]["Piel"].ToString();
                d.Complexion = dt.Rows[0]["Complexion"].ToString();
                d.FamiliarNotificar = dt.Rows[0]["FamiliarNotificar"].ToString();
                d.Depto = dt.Rows[0]["Depto"].ToString();
                d.Observaciones = dt.Rows[0]["Observaciones"].ToString();
                d.DelitoActivo = MovimientoC.ToList_Delito(d.Idno,0);
                d.Delito = MovimientoC.ToList_Delito(d.Idno,1);
                d.BajaPresunto = MovimientoC.ToList_BajaPresunto(d.Idno);
                d.OrdenLibertad = MovimientoC.ToList_OrdenLibertad(d.Idno);
                d.AsistenciaJuzgado = MovimientoC.ToList_AsistenciaJuzgado(d.Idno);
                d.TrasladoSPN = MovimientoC.ToList_TrasladoSPN(d.Idno);
                d.TrasladoDelegacion = MovimientoC.ToList_TrasladoDelegacion(d.Idno);
                d.TrasladoCelda = MovimientoC.ToList_TrasladoCelda(d.Idno);
                d.AsistenciaMedica = MovimientoC.ToList_AsistenciaMedica(d.Idno);
                d.ValoracionMedica = MovimientoC.ToList_ValoracionMedica(d.Idno);
                d.ReunionColectiva = MovimientoC.ToList_ReunionColectiva(d.Idno);
                d.PrisionPreventiva = MovimientoC.ToList_PrisionPreventiva(d.Idno);
                
                try
                {
                    d.Foto = Fotopersona(d.Idno);
                }
                catch 
                {
                    d.Foto = "";
                }
                
            }

            return d;
        }

        public static string Fotopersona(int Idno)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Idno", Idno));
            string strConnString = ConfigurationManager.ConnectionStrings["SicondConnection"].ConnectionString;
            byte[] MisFotos = new byte[0];
            DataTable dt = Data.Query("SELECT Foto FROM Laboraorio.[dbo].[tbModeloDatos] WHERE Idno = @Idno", parametros, CommandType.Text, strConnString);
            DataRow myRow = dt.Rows[0];
            MisFotos = (byte[])myRow["Foto"];
            MemoryStream ms = new MemoryStream(MisFotos);
            MisFotos = (byte[])myRow["Foto"];
            string foto = "data:image/png;base64,";
            return (foto + Convert.ToBase64String(MisFotos));

        }

       



    }
}