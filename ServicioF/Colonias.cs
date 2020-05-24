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
    public partial class Colonias : Form
    {
        Conexion con = new Conexion();

        int id_colonia;
        Boolean editar;

        public Colonias(string Jefe)
        {
            InitializeComponent();
            this.Jefe=Jefe;
            
        }
        string Jefe;
        public void ActualizarGrid()
        {
            con.ActualizarGrid(this.dgvcolonias, "Select * from colonias");
        }

        public void Limpiar()
        {
            txtnombre.Text = "";
            txtpostal.Text = "";
            txtmunicipio.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Colonias_Load(object sender, EventArgs e)
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

                String consulta = "insert into colonias (nombre, codigo_postal, municipio) values  ('" + txtnombre.Text + "', '" + txtpostal.Text + "', '" + txtmunicipio.Text + "');";

                con.EjectuarMysql(consulta);

                this.ActualizarGrid();

                con.Desconectar();

                this.Limpiar();
            }
            

            

        }


        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtnombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtnombre, "Ingrese el nombre de la colonia");
            }

            if (txtpostal.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtpostal, "Ingrese el codigo postal de la colonia");
            }
            if (txtmunicipio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtmunicipio, "Ingrese el municipio de la colonia");
            }




            return ok;
        }

        private void BorrarMensajeError()
        {
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(txtpostal, "");
            errorProvider1.SetError(txtmunicipio, "");
        }



        private void btneditar_Click(object sender, EventArgs e)
        {
            con.Conectar();
            String consulta = "update colonias set nombre = '" + txtnombre.Text + "', codigo_postal = '" + txtpostal.Text + "', municipio = '" + txtmunicipio.Text + "'where id_colonia=" + id_colonia + ";";

            con.EjectuarMysql(consulta);
            this.ActualizarGrid();
            con.Desconectar();
            this.Limpiar();
            editar = false;

        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvcolonias, "select * from colonias where nombre like '" + txtbuscar.Text + "%' OR codigo_postal like '" + txtbuscar.Text + "%' ;");
           

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            id_colonia = int.Parse(this.dgvcolonias.CurrentRow.Cells[0].Value.ToString());

            var resultado = MessageBox.Show("¿Desea borrar el registro?","Confirme la eliminacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                con.Conectar();
                String consulta = "delete from colonias where id_colonia='" + id_colonia + "';";

                con.EjectuarMysql(consulta);
                this.ActualizarGrid();
                con.Desconectar();
                
            }
            else
            {
                return;
            }
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

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvcolonias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editar = true;
            id_colonia = int.Parse(this.dgvcolonias.CurrentRow.Cells[0].Value.ToString());
            txtnombre.Text = this.dgvcolonias.CurrentRow.Cells[1].Value.ToString();
            txtpostal.Text = this.dgvcolonias.CurrentRow.Cells[2].Value.ToString();
            txtmunicipio.Text = this.dgvcolonias.CurrentRow.Cells[3].Value.ToString();
        }

        private void dgvcolonias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
