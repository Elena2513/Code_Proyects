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
using System.Windows.Forms.DataVisualization.Charting;
using EasyTabs;
using PortadoresArmas.Acciones;
using System.Configuration;


namespace PortadoresArmas
{
    public partial class Form1 : Form
    {
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }
        public Form1()
        {
            InitializeComponent();

        }
        int tipo = 1;
        int reporte = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //BUSQUEDA Y FILTRADO EN EL GRIDVIEW--ESTO AGILIZA LA BUSQUEDA VER App.config y NOTA
            String conexionSPN = ConfigurationManager.ConnectionStrings["ConexionServiciosPN"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conexionSPN);
            string Sqlquery = "Select Top 200 * From VWSIGESPROC_PORTADORARMA";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(Sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvData.DataSource = dt;
            sqlconn.Close();

            //MessageBox.Show(Environment.UserDomainName);
            //if (Environment.UserDomainName != "POLICIANACIONAL")

            //{
            //    this.Close();
            //}
            try
            {

                
                cmbDelegacion.DataSource = CatalogoC.Delegaciones();
                cmbDelegacion.ValueMember = "CodDelegacionPolicial";
                cmbDelegacion.DisplayMember = "DelegacionPolicial";
                txtContador.Text = PortadoresArmas.Acciones.PortadoresArmas.ContadorSectorizado("").ToString();
                txtSinSectorizar.Text= PortadoresArmas.Acciones.PortadoresArmas.ContadorSinSectorizado("").ToString();
                Listar("");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cmbDelegacion.Visible = !cmbDelegacion.Visible;
            if (cmbDelegacion.Visible==false)
            {
                Listar("");
            }
        }



        private void ToolStripButton3_Click(object sender, EventArgs e)
        {


            try
            {
                Ventana.FrmPortadorArma frm = new Ventana.FrmPortadorArma();
                frm.Data = PortadoresArmas.Acciones.PortadoresArmas.Get(dgvData.CurrentRow.Cells["IdPersona"].Value.ToString());
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                Listar(cmbDelegacion.SelectedValue.ToString());
            }
            catch

            {

            }
        }

      

        private void PortadoresDeArmasSectorizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reporte = 1;
                if (reporte==1)
                {
                    bsReporte.DataSource = ReporteC.Sectorizado(6, cmbDelegacion.SelectedValue.ToString());
                    bnReporte.BindingSource = bsReporte;
                    dgvReporte.DataSource = bsReporte;
                }
                Listar(cmbDelegacion.SelectedValue.ToString());
            }
            catch
            {

            }

        }

        private void ConsolidadoDePortadoresDeArmasPendientesASectorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = 1;
                reporte = 3;
                bsReporte.DataSource = ReporteC.NoSectorizacion(tipo, "");
                bnReporte.BindingSource = bsReporte;
                dgvReporte.DataSource = bsReporte;
                dgvReporte.Columns[0].Visible = false;

                //chrReporte.Titles.Add("Consolidado de Lo Que Sea");
                foreach (DataGridViewRow item in dgvReporte.Rows)
                {
                    Series series = chrReporte.Series.Add(item.Cells[1].Value.ToString());
                    series.Points.Add(Convert.ToDouble(item.Cells[2].Value.ToString()));
                    series.Label = item.Cells[2].Value.ToString();


                }
               
            }
            catch
            {

            }
        }

        private void DgvReporte_DoubleClick(object sender, EventArgs e)
        {
            if (tipo <= 6)
            {
                tipo++;
                if (reporte == 1)
                {

                }
                else if (reporte == 2)
                {
                    try
                    {
                        ReporteC.Sectorizado(tipo, dgvReporte.CurrentRow.Cells[0].Value.ToString());
                        bsReporte.DataSource = ReporteC.Sectorizado(tipo, dgvReporte.CurrentRow.Cells[0].Value.ToString());
                        bnReporte.BindingSource = bsReporte;
                        dgvReporte.DataSource = bsReporte;
                        dgvReporte.Columns[0].Visible = false;
                        chrReporte.Series.Clear();
                        //chrReporte.Titles.Add("Consolidado de Lo Que Sea");
                        foreach (DataGridViewRow item in dgvReporte.Rows)
                        {
                            Series series = chrReporte.Series.Add(item.Cells[1].Value.ToString());
                            series.Points.Add(Convert.ToDouble(item.Cells[2].Value.ToString()));
                            series.Label = item.Cells[2].Value.ToString();


                        }
                    }
                    catch
                    {

                    }

                }
                else
                {
                    if (tipo == 4)
                    {
                        tipo = 1;
                    }
                    bsReporte.DataSource = ReporteC.NoSectorizacion(tipo, dgvReporte.CurrentRow.Cells[0].Value.ToString());
                    bnReporte.BindingSource = bsReporte;
                    dgvReporte.DataSource = bsReporte;
                    dgvReporte.Columns[0].Visible = false;
                    chrReporte.Series.Clear();
                    //chrReporte.Titles.Add("Consolidado de Lo Que Sea");
                    foreach (DataGridViewRow item in dgvReporte.Rows)
                    {
                        Series series = chrReporte.Series.Add(item.Cells[1].Value.ToString());
                        series.Points.Add(Convert.ToDouble(item.Cells[2].Value.ToString()));
                        series.Label = item.Cells[2].Value.ToString();
                       

                    }
                }

            }
            else
            {
                tipo = 1;
            }
        }

        private void ConsolidadoDePortadoresDeArmasSectorizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = 1;
                reporte = 2;
                bsReporte.DataSource = ReporteC.Sectorizado(tipo, "");
                bnReporte.BindingSource = bsReporte;
                dgvReporte.DataSource = bsReporte;
                dgvReporte.Columns[0].Visible = false;

                //chrReporte.Titles.Add("Consolidado de Lo Que Sea");
                foreach (DataGridViewRow item in dgvReporte.Rows)
                {
                    Series series = chrReporte.Series.Add(item.Cells[1].Value.ToString());
                    series.Points.Add(Convert.ToDouble(item.Cells[2].Value.ToString()));
                    series.Label = item.Cells[2].Value.ToString();


                }

            }
            catch
            {

            }

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            ExportarC.ExportarExcel(dgvReporte);
        }

        private void Listar(string codigo)
        {
            bsData.DataSource = PortadoresArmas.Acciones.PortadoresArmas.ToList(codigo);
            bnData.BindingSource = bsData;
            dgvData.DataSource = bsData;
            tscmbPersona.ComboBox.DataSource = bsData;
            tscmbPersona.ComboBox.DisplayMember = "NombreCompleto";
            tscmbPersona.ComboBox.ValueMember = "IdPersona";
            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].Visible = false;

            }
            dgvData.Columns["NombreCompleto"].Visible = true;
            dgvData.Columns["Identificacion"].Visible = true;
        }

       

        private void TxtBusqueda_TextChanged(object sender, EventArgs e) // TxtBusqueda de busqueda ver conexion en App.config y nota
        {
            String conexionSPN = ConfigurationManager.ConnectionStrings["ConexionServiciosPN"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conexionSPN);
            string Sqlquery = "Select Top 200 * From VWSIGESPROC_PORTADORARMA where NombreCompleto Like '"+ txtBusqueda.Text + "%'";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(Sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvData.DataSource = dt;
            sqlconn.Close();
        }

        //private void Txtsectorizado_TextChanged(object sender, EventArgs e)
        //{

        //    bsReporte.DataSource = Acciones.PortadoresArmas.Search(txtsectorizado.Text);
        //    bnReporte.BindingSource = bsReporte;
        //    dgvReporte.DataSource = bsReporte;
        //    tscmbPersona.ComboBox.DataSource = bsReporte;
        //    tscmbPersona.ComboBox.DisplayMember = "NombreCompleto";
        //    tscmbPersona.ComboBox.ValueMember = "IdPersona";
        //    for (int i = 0; i < dgvReporte.Columns.Count; i++)
        //    {
        //        dgvReporte.Columns[i].Visible = false;

        //    }
        //    dgvReporte.Columns["NombreCompleto"].Visible = true;
        //    dgvReporte.Columns["Identificacion"].Visible = true;

        //}

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            bsReporte.DataSource = Acciones.PortadoresArmas.Search_Sectorizado(txtsectorizado.Text);
            bnReporte.BindingSource = bsReporte;
            dgvReporte.DataSource = bsReporte;
            tscmbPersona.ComboBox.DataSource = bsReporte;
            tscmbPersona.ComboBox.DisplayMember = "NombreCompleto";
            tscmbPersona.ComboBox.ValueMember = "IdPersona";
            for (int i = 0; i < dgvReporte.Columns.Count; i++)
            {
                dgvReporte.Columns[i].Visible = false;

            }
            dgvReporte.Columns["NombreCompleto"].Visible = true;
            dgvReporte.Columns["Identificacion"].Visible = true;
        }

        private void CmbDelegacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if (reporte == 1)
                {
                    bsReporte.DataSource = ReporteC.Sectorizado(6, cmbDelegacion.SelectedValue.ToString());
                    bnReporte.BindingSource = bsReporte;
                    dgvReporte.DataSource = bsReporte;
                }
                else
                {
                    Listar(cmbDelegacion.SelectedValue.ToString());
                    txtContador.Text = PortadoresArmas.Acciones.PortadoresArmas.ContadorSectorizado(cmbDelegacion.SelectedValue.ToString()).ToString();
                    txtSinSectorizar.Text = PortadoresArmas.Acciones.PortadoresArmas.ContadorSinSectorizado(cmbDelegacion.SelectedValue.ToString()).ToString();
                }
                
                    
                
            }
            catch
            {

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.TimeOfDay.ToString();
        }
    }
}
