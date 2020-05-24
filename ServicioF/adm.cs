using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicioF
{
    public partial class adm : Form
    {
       
        public adm(string u, string cosa)
        {
            InitializeComponent();
            this.u = u;
            this.cosa = cosa;
           
        }
        string u,cosa;
        string Jefe = "Jefe";





        public adm(string Jefe)
        {
            InitializeComponent();

            this.Jefe = Jefe;
            

        }

        private void btnsesion_Click(object sender, EventArgs e)
        {
            Login z = new Login();
            z.Show();
            this.Hide();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrespaldo_Click(object sender, EventArgs e)
        {
            Respaldo_y_Recuperacion z = new Respaldo_y_Recuperacion(Jefe);
            z.Show();
            this.Hide();
        }

        private void adm_Load(object sender, EventArgs e)
        {
            label2.Text = (u);
           
            label4.Text = (Jefe);
        }

        private void btnempleados_Click(object sender, EventArgs e)
        {
            Usuarios z = new Usuarios(Jefe);
            z.Show();
            this.Hide();
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            Form1 z = new Form1(Jefe);
            z.Show();
            this.Hide();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncolonias_Click(object sender, EventArgs e)
        {
            Colonias z = new Colonias(Jefe);
            z.Show();
            this.Hide();
        }
    }
}
