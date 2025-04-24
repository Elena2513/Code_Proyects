using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortadoresArmas.Data;
using System.Windows.Forms.DataVisualization.Charting;
using EasyTabs;
using System.Net;
using System.Web.UI.WebControls;

namespace PortadoresArmas.Ventana
{
    public partial class FrmPortadorArma : Form
    {
            
        public DataTable Data { get; internal set; }

        public FrmPortadorArma()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPortadorArma_Load(object sender, EventArgs e)
        {
            try
            {
                               
                cmbdpto.DataSource = Acciones.CatalogoC.ToList(1, "");
                cmbdpto.DisplayMember = "Descripcion";
                cmbdpto.ValueMember = "Codigo";


                txtDireccion.Text = Data.Rows[0]["DireccionActual"].ToString();
                txtIdentificacion.Text = Data.Rows[0]["Identificacion"].ToString();
                txtNombre.Text = Data.Rows[0]["NombreCompleto"].ToString();
                txtDireccionD.Text = Data.Rows[0]["DireccionDoc"].ToString();
                



                bsDuplicado.DataSource = PortadoresArmas.Acciones.PortadoresArmas.Duplicados(txtIdentificacion.Text);
                bnDupli.BindingSource = bsDuplicado;
                dgvDuplicado.DataSource = bsDuplicado;
                dgvDuplicado.Columns[0].Visible = false;
                if (dgvDuplicado.Rows.Count>1)
                {
                    gbDuplicado.Visible = true;
                    groupBox3.Size = new Size(400, 144);
                }
                else
                {
                    gbDuplicado.Visible = false;
                    groupBox3.Size = new Size(777, 144);
                }
                try
                {
                    pictureBox1.Image = PortadoresArmas.Acciones.PortadoresArmas.Fotopersona(int.Parse(Data.Rows[0][0].ToString()));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //    for (int i = 0; i < dgvDuplicado.Columns.Count; i++)
                //    {
                //        dgvDuplicado.Columns[i].Visible = false;

                //    }
                //    dgvDuplicado.Columns["IdPersona"].Visible = true;
                //    dgvDuplicado.Columns["NombreCompleto"].Visible = true;
                //    dgvDuplicado.Columns["Identificacion"].Visible = true;


            }
            catch
            {

            }

               
                
               

        }

        private void Cmbdpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbmun.DataSource = Acciones.CatalogoC.ToList(2, cmbdpto.SelectedValue.ToString());
                cmbmun.DisplayMember = "Descripcion";
                cmbmun.ValueMember = "Codigo";
            }
            catch
            {

            }
        }

        private void Cmbmun_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBarrio.DataSource = Acciones.CatalogoC.ToList(5, cmbmun.SelectedValue.ToString());
                cmbBarrio.DisplayMember = "Descripcion";
                cmbBarrio.ValueMember = "Codigo";
            }
            catch
            {

            }
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idpersona = int.Parse(Data.Rows[0]["idPersona"].ToString());
                string codBarrioUbicacion = cmbBarrio.SelectedValue.ToString();
                string codDelegacion = Data.Rows[0]["codDelegacion"].ToString();
                string Observaciones = txtObservaciones.Text;
                string host = Environment.UserName.ToString();
                ////IPHostEntry hosting;
                //string localIP = "";
                //hosting = Dns.GetHostEntry(Dns.GetHostName());
                //foreach (IPAddress ip in hosting.AddressList)
                //{
                //    if (ip.AddressFamily.ToString() == "InterNetwork")
                //    {
                //        localIP = ip.ToString();
                //    }
                //}

                PortadoresArmas.Acciones.PortadoresArmas.Sectorizarpersona(idpersona, codBarrioUbicacion, codDelegacion, host, Observaciones);
                MessageBox.Show("Sectorizado con exito!", "Exito",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al sectorizar \n "+ex.Message , "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtObservaciones.Enabled = true;
                             
            }
            else
            {
                txtObservaciones.Enabled = false;
               
            }
        }
    }
}
