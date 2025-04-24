using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
namespace PortadoresArmas
{
    public partial class AppContainer : TitleBarTabs
    {
        public Form ventana;
        public AppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                // El contenido será una instancia de otro formulario.
                // En nuestro ejemplo, crearemos una nueva instancia de Form1
                //Content = ventana
                //{
                //    Text = "New Tab"
                //}
            };
        }

        private void AppContainer_Load(object sender, EventArgs e)
        {

        }
    }
}
