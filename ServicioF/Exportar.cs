using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace ServicioF
{
    class Exportar
    {
        //Exportar DataGridView a Archivo de Excel
        public void ExportarDgv(DataGridView dgv)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog()==DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    //recoremos el DataGridView rellenado en la hoja
                    for (int i=0; i< dgv.Rows.Count-1;i++)
                    {
                        for(int j =0;j<dgv.Columns.Count;j++)
                        {
                            if((dgv.Rows[i].Cells[j].Value==null)==false)
                            {
                                hoja_trabajo.Cells[i + 1, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar debido a:" + ex.ToString());
            }
        }


        public void exportarexcel(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn col in dgv.Columns)//columnas
            {
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = col.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow row in dgv.Rows) //filas
            {
                IndiceFila++;
                IndiceColumna = 0;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    IndiceColumna++;
                    excel.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                }
            }

            excel.Visible = true;


        }


    }
}
