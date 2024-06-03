using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SiteControlDetenido.Models
{
    public static class CIpHost
    {
        public static string GetIP4Address()
        {
            string IP4Address = String.Empty;


            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();

                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();

                    break;
                }
            }

            return IP4Address;
        }
        public static string Estacion()
        {
            string uipname = "";

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    uipname = host.HostName;
                    break;
                }
            }
            return uipname;
        }
    }
}