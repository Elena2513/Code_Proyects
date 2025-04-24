using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace PortadoresArmas.Acciones
{
    public static class ExportarC
    {
        public static void ExportarExcel(DataGridView gridView)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    int k = 1;
                    foreach (DataGridViewColumn x in gridView.Columns)
                    {
                       
                        if (x.Visible)
                        {
                            hoja_trabajo.Cells[1, k] = x.HeaderText;
                        }
                        k++;

                    }
                    k = 2;

                    foreach (DataGridViewRow R in gridView.Rows)
                    {

                        int j = 2;

                        foreach (DataGridViewColumn C in gridView.Columns)
                        {
                            if (C.Visible)
                            {
                                hoja_trabajo.Cells[k, j] = R.Cells[C.Name].Value.ToString();
                                j++;
                            }


                        }
                        k++;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("INFORMACIÓN GUARDADA CON EXITO ", "CONBES", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL EXPORTAR LA INFORMACION : " + ex.ToString());
            }
        }
    }
}
