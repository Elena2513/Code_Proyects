using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class UsuarioE
    {
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string CodEstructura { get; set; }
        public string Estructura { get; set; }
        public string NombreCompleto { get; set; }
        public string Perfil { get; set; }      
        public string CodDepto { get; set; }  
        public string Depto { get; set; }       
    }
}