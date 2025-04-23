using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortadoresArmas.Acciones
{
    public static class PortadoresArmas
    {
        private static string Connection = "data source=PNSQLXX;initial catalog=SERVICIOS;user id=Sectorizar;password=S3ct0riz@#123";

        public static DataTable ToList(string delegacion)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("delegacion", delegacion));
            DataTable dt = new DataTable();
            dt = Data.Data.Query("Select Top 200 * From VWSIGESPROC_PORTADORARMA where CodBarrio is null AND coddelegacion = @delegacion or @delegacion='' Order By NombreCompleto ASC ", parametros, CommandType.Text, strConnString);
            return dt;
        }
     
        public static DataTable Get(string idPersona)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("idPersona", idPersona));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("Select Top 200 * From VWSIGESPROC_PORTADORARMA WHERE IdPersona=@idPersona", parametros, CommandType.Text, strConnString);
            return dt;
        }
        public static DataTable Pordelegacion(string delegacion)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("delegacion", delegacion));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("Select Top 200 * From VWSIGESPROC_PORTADORARMA WHERE Coddelegacion=@delegacion", parametros, CommandType.Text, strConnString);
            return dt;
        }

        

        public static DataTable Sectorizarpersona(int idPersona, string codBarrioUbicacion, string codDelegacion,  string host,string Observaciones)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("idPersona", idPersona));
            parametros.Add(new SqlParameter("codBarrioUbicacion",int.Parse(codBarrioUbicacion)));
            parametros.Add(new SqlParameter("codDelegacion", codDelegacion));
            //parametros.Add(new SqlParameter("Observaciones", Observaciones));
            parametros.Add(new SqlParameter("host", host));
            parametros.Add(new SqlParameter("Descripcion", "Sectorización del Portador de Arma"+(Observaciones.Length>0)+", Otras Observaciones "+Observaciones));
            DataTable dt = new DataTable();
            dt = Data.Data.Query("PERSONAS.dbo.SP_SectorizarPersonas", parametros, CommandType.StoredProcedure, strConnString);
            return dt;
        }
        public static int ContadorSectorizado(string delegacion)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("delegacion", delegacion));
            
            DataTable dt = new DataTable();
            dt = Data.Data.Query("SELECT COUNT(*) FROM VWSIGESPROC_PORTADORARMA WHERE CodBarrio is not null AND (CodDelegacion=@delegacion  OR @delegacion='')", parametros, CommandType.Text, strConnString);
            return int.Parse(dt.Rows[0][0].ToString()) ;
        }
        public static int ContadorSinSectorizado(string delegacion)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("delegacion", delegacion));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("SELECT COUNT(*) FROM VWSIGESPROC_PORTADORARMA WHERE CodBarrio is null AND (CodDelegacion=@delegacion  OR @delegacion='')", parametros, CommandType.Text, strConnString);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        //public static DataTable Search(string filtro)
        //{
        //    string strConnString = Connection;
        //    List<SqlParameter> parametros = new List<SqlParameter>();
        //    parametros.Add(new SqlParameter("filtro", filtro));

        //    DataTable dt = new DataTable();
        //    dt = Data.Data.Query("Select Top 200 * From VWSIGESPROC_PORTADORARMA where NombreCompleto Like @filtro+'%' OR Identificacion=@filtro Order By NombreCompleto ASC", parametros, CommandType.Text, strConnString);
        //    return dt;
        //}
        public static DataTable Search_Sectorizado(string filtro)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("filtro", filtro));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("Select Top 200 * From VWSIGESPROC_PORTADORARMA where CodBarrio is not null AND (NombreCompleto Like @filtro+'%' OR Identificacion=@filtro)    Order By NombreCompleto ASC", parametros, CommandType.Text, strConnString);
            return dt;
        }

        public static DataTable Duplicados(string Identificacion)
        {
            string strConnString = Connection;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Identificacion", Identificacion));

            DataTable dt = new DataTable();
            dt = Data.Data.Query("SELECT [IdPersona],[NombreCompleto],[Identificacion] FROM [SERVICIOSPN].[dbo].[VWSIGESPROC_PORTADORARMA] WHERE [Identificacion]= @Identificacion", parametros, CommandType.Text, strConnString);
            return dt;

        }


        public static Image Fotopersona(int IdPersona)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdPersona", IdPersona));

            byte[] MisFotos = new byte[0];
            DataTable dt = Data.Data.Query("select Foto from FotosPn.dbo.Fotos where IdPersona=@IdPersona", parametros, CommandType.Text, Connection);
            DataRow myRow = dt.Rows[0];
            MisFotos = (byte[])myRow["Foto"];
            MemoryStream ms = new MemoryStream(MisFotos);
            Image foto = Image.FromStream(ms);
            return foto;

                      
         }

       
        //internal static void Search()
        //{
        //    throw new NotImplementedException();
        //}
    }

    internal class PictureBox1
    {
        public static Image Image { get; internal set; }
    }
}

