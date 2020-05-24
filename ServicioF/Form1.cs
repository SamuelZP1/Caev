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
    public partial class Form1 : Form
    {
        
        Conexion con = new Conexion();
        Exportar exp = new Exportar();
        int id_cliente;
        Boolean editar;
        string status;
        string u;
      



        public Form1(string Jefe)
        {
            InitializeComponent();
            this.Jefe=Jefe;
            
          

        }
        

        string Jefe;

        public void ActualizarGrid2()
        {
            con.ActualizarGrid2(this.dgvclientes, "Select * from clientes");
        }
        public void Limpiar()
        {
            txtcontrato.Text = "";    
            txtverificador.Text = "";
            txtfolio.Text = "";
            txtnombre.Text = "";
            cbcolonia.Text = "";
            txtdireccion.Text = "";
            txtmeses.Text = "";
            txtcantidad.Text = "";
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (Jefe=="Jefe")
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

        private void cbcolonia_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActualizarGrid2();
            con.Conectar();
            con.comboBox(cbcolonia);
            
            con.Desconectar();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidarCampos())
            {
                con.Conectar();

                if (rbcongelado.Checked == true)
                {
                    status = rbcongelado.Text;
                }
                else
                {
                    rbdescogelado.Checked = true;
                    status = rbdescogelado.Text;
                }

                String consulta = "insert into clientes (n_contrato, d_verificador, se_ruta_folio, nombre, colonia, direccion, meses_deuda, can_deuda, status) values  ('" + txtcontrato.Text + "', '" + txtverificador.Text + "', '" + txtfolio.Text + "', '" + txtnombre.Text + "', '" + cbcolonia.Text + "', '" + txtdireccion.Text + "', " + txtmeses.Text + ", " + txtcantidad.Text + ", '" + status + "');";

                con.EjectuarMysql(consulta);

                this.ActualizarGrid2();

                con.Desconectar();

                this.Limpiar();
            }
        }



        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtcontrato.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtcontrato, "Ingrese numero de contrato");
            }

            if (txtverificador.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtverificador, "Ingrese el digitio verificador");
            }

            if (txtfolio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtfolio, "Ingrese el sector,ruta y folio");
            }

            if (txtnombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtnombre, "Ingrese el nombre");
            }
            if (cbcolonia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cbcolonia, "Ingrese la colonia");
            }

            if (txtdireccion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtdireccion, "Ingrese la direccion");
            }

            if (txtmeses.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtcontrato, "Ingrese los meses de deuda");
            }

            return ok;
        }

        private void BorrarMensajeError()
        {
            errorProvider1.SetError(txtcontrato, "");
            errorProvider1.SetError(txtverificador, "");
            errorProvider1.SetError(txtfolio, "");
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(cbcolonia, "");
            errorProvider1.SetError(txtdireccion, "");
            errorProvider1.SetError(txtmeses, "");

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try {
            con.Conectar();
            if (rbcongelado.Checked == true)
            {
                status = rbcongelado.Text;
            }
            else
            {
                rbdescogelado.Checked = true;
                status = rbdescogelado.Text;
            }

            String consulta = "update clientes set d_verificador = '" + txtverificador.Text + "', se_ruta_folio = '" + txtfolio.Text + "', nombre = '" + txtnombre.Text + "', colonia = '" + cbcolonia.Text + "', direccion = '" + txtdireccion.Text + "', meses_deuda = '" + txtmeses.Text + "', can_deuda = '" + txtcantidad.Text + "', status = '" + status + "' where n_contrato =" + txtcontrato.Text + ";";

            con.EjectuarMysql(consulta);
            this.ActualizarGrid2();
            con.Desconectar();
            this.Limpiar();
            editar = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Introdusca todo los datos");
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
        
        }

        private void txtmeses_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmeses_Leave(object sender, EventArgs e)
        {
           
        }

        private void dgvclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void rbcongelado_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvclientes, "select * from clientes where n_contrato like '" + txtbuscar.Text + "%';");
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            //exp.ExportarDgv(dgvclientes);
            exp.exportarexcel(dgvclientes);
        }

        private void txtbuscar2_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvclientes, "select * from clientes where nombre like '" + txtbuscar2.Text + "%';");
        }

        private void txtbuscar3_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvclientes, "select * from clientes where colonia like '" + txtbuscar3.Text + "%';");
        }

        private void txtbuscar4_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvclientes, "select * from clientes where direccion like '" + txtbuscar4.Text + "%';");
        }

        private void txtbuscar5_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvclientes, "select * from clientes where meses_deuda like '" + txtbuscar5.Text + "%';");
        }

        private void txtbuscar6_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.dgvclientes, "select * from clientes where can_deuda like '" + txtbuscar6.Text + "%';");
        }

        private void txtmeses_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int n1, n2, r;
                n1 = Convert.ToInt32(txtmeses.Text);
                n2 = 121;
                r = n1 * n2;
                txtcantidad.Text = r.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Introduzc un numero");
            }
        }

        private void dgvclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           

            editar = true;
            
            txtcontrato.Text = this.dgvclientes.CurrentRow.Cells[0].Value.ToString();
            txtverificador.Text = this.dgvclientes.CurrentRow.Cells[1].Value.ToString();
            txtfolio.Text = this.dgvclientes.CurrentRow.Cells[2].Value.ToString();
            txtnombre.Text = this.dgvclientes.CurrentRow.Cells[3].Value.ToString();
            cbcolonia.Text = this.dgvclientes.CurrentRow.Cells[4].Value.ToString();
            txtdireccion.Text = this.dgvclientes.CurrentRow.Cells[5].Value.ToString();
            txtmeses.Text = this.dgvclientes.CurrentRow.Cells[6].Value.ToString();
            txtcantidad.Text = this.dgvclientes.CurrentRow.Cells[7].Value.ToString();
            status = this.dgvclientes.CurrentRow.Cells[8].Value.ToString();

            switch(status)
            {
                case "Congelado":
                    rbcongelado.Checked= true;
                    rbdescogelado.Checked = false;
                    break;
                case "Descongelado":
                    rbcongelado.Checked = false;
                    rbdescogelado.Checked = true;
                    break;
            }

        }

        private void txtcontrato_TextChanged(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
