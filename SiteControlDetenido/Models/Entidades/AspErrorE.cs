using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteControlDetenido.Models.Entidades
{
    public class AspErrorE
    {
        public int Id { get; set; }
        public string Controlador { get; set; }
        public string Error { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Carnet { get; set; }
        public string Ip { get; set; }
        public string Host { get; set; }
    }
}