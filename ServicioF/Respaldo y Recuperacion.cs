using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace ServicioF
{
    public partial class Respaldo_y_Recuperacion : Form
    {
        Respaldo obj = new Respaldo();
        string fecha = DateTime.Now.ToString("yyyy-MM-dd");
        StreamWriter msw;
        StreamReader msr; 
      


        public Respaldo_y_Recuperacion(string Jefe)
        {
            InitializeComponent();
            this.Jefe = Jefe;
        }
        string Jefe;
        
        private void btnbuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrespaldo_Click(object sender, EventArgs e)
        {
            try
            {
                string file;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "SQL Dump File (*.sql)|*.sql|All Files(*.*)|*.*";
                sfd.FileName = "DatabaseBackup.sql";
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    file = sfd.FileName;
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.WorkingDirectory = @"c:\\Program Files\MariaDB 10.1\bin\";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.Start();

                    msw = cmd.StandardInput;
                    msr = cmd.StandardOutput;
                    msw.WriteLine("mysqldump -hlocalhost -p3306 -uroot -p12345 --opt --routines --database serviciof >"+file+"");
                    msw.Close();
                    cmd.WaitForExit();
                    cmd.Close();
                    MessageBox.Show("Se respaldo la base de datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No  se pudo respaldar");
            }
           
        }

        private void btnbuscar2_Click(object sender, EventArgs e)
        {
         
        }

        private void btnrecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                string file;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "SQL File (*.sql)|*.sql|All Files(*.*)|*.*";
                ofd.FileName = "";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    file = ofd.FileName;
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.WorkingDirectory = @"c:\\Program Files\MariaDB 10.1\bin\";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.Start();

                    msw = cmd.StandardInput;
                    msr = cmd.StandardOutput;
                    msw.WriteLine("mysql -hlocalhost -p3306 -uroot -p12345 restored < " + file + "");
                    msw.Close();
                    cmd.WaitForExit();
                    cmd.Close();
                    MessageBox.Show("Se ha restaurado la base de datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No  se pudo restaurar");
            }

        }

        private void Respaldo_y_Recuperacion_Load(object sender, EventArgs e)
        {
            string sql = "select * from data";
           // Fungsi.Set_combox(sql, "data,"cmb);
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            if (Jefe == "Jefe")
            {
                adm z = new adm(Jefe);
                z.Show();
                this.Hide();
            }
            else
            {
                usua z = new usua();
                z.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int posY = 0;
        int posX = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }
    }
}
