using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ServicioF
{
    public partial class Usuarios : Form
    {

        Conexion con = new Conexion();
        int n_usuario;
        Boolean editar;

        public Usuarios(string Jefe)
        {
            InitializeComponent();
            this.Jefe = Jefe;
            
        }
        string Jefe;

        public void ActualizarGrid()
        {
            con.ActualizarGrid(this.dgvusuarios, "Select * from usuarios");
        }

        public void Limpiar()
        {
            txtnombre.Text = "";
            txtusuario.Text = "";
           cbtipo.Text = "";
            txtcontraseña.Text = "";
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            editar = false;
            this.ActualizarGrid();
            
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidarCampos())
            {
                con.Conectar();

                String consulta = "insert into usuarios (nombre, nombre_usuario, tipo_usuario, contraseña) values  ('" + txtnombre.Text + "', '" + txtusuario.Text + "', '" + cbtipo.Text + "', '" + txtcontraseña.Text + "');";

                con.EjectuarMysql(consulta);

                this.ActualizarGrid();

                con.Desconectar();

                this.Limpiar();
            }
            
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtnombre.Text=="")
            {
                ok = false;
                errorProvider1.SetError(txtnombre, "Ingrese el nombre del usuario");
            }

            if (txtusuario.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtusuario, "Ingrese un nombre de usuario");
            }
            if (txtcontraseña.Text=="")
            {
                ok = false;
                errorProvider1.SetError(txtcontraseña, "Ingrese una contraseña");
            }




            return ok;
        }

        private void BorrarMensajeError()
        {
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(txtusuario, "");
            errorProvider1.SetError(txtcontraseña, "");
        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvusuarios, "select * from usuarios where nombre like '" + txtbuscar.Text + "%' OR nombre_usuario like '" + txtbuscar.Text + "%' OR tipo_usuario like '" + txtbuscar.Text + "%' ;");
        }

        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvusuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editar = true;
            n_usuario = int.Parse(this.dgvusuarios.CurrentRow.Cells[0].Value.ToString());
            txtnombre.Text = this.dgvusuarios.CurrentRow.Cells[1].Value.ToString();
            txtusuario.Text = this.dgvusuarios.CurrentRow.Cells[2].Value.ToString();
            cbtipo.Text = this.dgvusuarios.CurrentRow.Cells[3].Value.ToString();
            txtcontraseña.Text = this.dgvusuarios.CurrentRow.Cells[4].Value.ToString();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            con.Conectar();
            String consulta = "update usuarios set nombre = '" + txtnombre.Text + "', nombre_usuario = '" + txtusuario.Text + "', tipo_usuario = '" + cbtipo.Text + "', contraseña = '" + txtcontraseña.Text + "'  where n_usuario=" + n_usuario + ";";

            con.EjectuarMysql(consulta);
            this.ActualizarGrid();
            con.Desconectar();
            this.Limpiar();
            editar = false;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
