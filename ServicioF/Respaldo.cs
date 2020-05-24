using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace ServicioF
{
    class Respaldo
    {
        public void RutasArchivo(TextBox txtruta, string FechaActual)

        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtruta.Text = folder.SelectedPath + @"\Respaldo_BD" + FechaActual + ".sql";
            }

        }

        public void RespaldarBD(TextBox textbox1)
        {
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine(@"cd C:\Program Files\MariaDB 10.1\bin\");
                cmd.StandardInput.Flush();
                cmd.StandardInput.WriteLine(@"mysqldump -hlocalhost -P3306 -uroot -p12345 -opt --routines -add-drop-database --databases serviciof>" + textbox1.Text);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();

                MessageBox.Show("Respaldo realizado", "Respaldo Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textbox1.Clear();
            }

            catch
            {
                MessageBox.Show("no se pudo realizara el respaldo");
            }
        }



        public void BurcarBd()
        {

        }

    }
}
