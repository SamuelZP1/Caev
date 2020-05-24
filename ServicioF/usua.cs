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
    public partial class usua : Form
    {
        public usua(string u, string cosa)
        {
            InitializeComponent();
            this.u = u;
            this.cosa = cosa;
           
        }
        string Usuario = "Usuario";

        public usua()
        {
            InitializeComponent();
        }
        string u,cosa;

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsesion_Click(object sender, EventArgs e)
        {
            Login z = new Login();
            z.Show();
            this.Hide();
        }

        private void usua_Load(object sender, EventArgs e)
        {
            label2.Text=(u);
            label4.Text = (Usuario);
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            Form1 z = new Form1(Usuario);
            z.Show();
            this.Hide();
        }

        private void btnrespaldo_Click(object sender, EventArgs e)
        {
            Respaldo_y_Recuperacion z = new Respaldo_y_Recuperacion(Usuario);
            z.Show();
            this.Hide();
        }

        private void btncolonias_Click(object sender, EventArgs e)
        {
            Colonias z = new Colonias(Usuario);
            z.Show();
            this.Hide();
        }
    }
}
