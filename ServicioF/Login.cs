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
using System.Configuration;
using System.Runtime.InteropServices;

namespace ServicioF
{
    public partial class Login : Form
    {

       


        Conexion con = new Conexion();
        MySqlConnection conn;

        public void Conectar()
        {
            conn = new MySqlConnection("Server=localhost; Database=serviciof; Uid=root;Pwd=12345;");
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }

        //public static class Datos
        //{
        //    public static DataTable Buscar(string user)
        //    {
        //        DataTable dt = new DataTable();
        //        MySqlConnection conexio = new MySqlConnection("Server=localhost; Database=serviciof; Uid=root;Pwd=12345;");
        //        string consulta = "SELECT tipo_usuario FROM usuarios WHERE nombre_usuario=@user";
        //        MySqlCommand comando = new MySqlCommand(consulta, conexio);
        //        comando.Parameters.AddWithValue("@user",user );
        //        MySqlDataAdapter adap = new MySqlDataAdapter(comando);
        //        adap.Fill(dt);

        //        return dt;
        //    }
        //}
        //string tipo;
       
        public Login()
        {
            InitializeComponent();
        }
        string u;

       

        public void Logear(string Usuario, string Contraseña)
        {
            
            try
            {
                Conectar();
                MySqlCommand cmd = new MySqlCommand("SELECT nombre, tipo_usuario FROM usuarios where nombre_usuario=@usuario AND contraseña=@contraseña", conn);
                cmd.Parameters.AddWithValue("usuario", Usuario);
                cmd.Parameters.AddWithValue("contraseña", Contraseña);
                
                u = Usuario;
               
               
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Jefe")
                    {
                        new adm(u, dt.Rows[0][0].ToString()).Show();
                    }

                    else if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        new usua(u, dt.Rows[0][0].ToString()).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrecto");
                }
            }

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                Desconectar();
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btningresar_Click(object sender, EventArgs e)
        {
           
            //DataTable dt = Datos.Buscar(txtusuario.Text);
            //if (dt.Rows.Count>0)
            //{
            //    DataRow row = dt.Rows[0];
            //    tipo = Convert.ToString(row["tipo_usuario"]);
            //}


            iniciar();

            Logear(txtusuario.Text, this.txtcontraseña.Text);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iniciar()
        {
            if (txtusuario.Text == "")
            {
                lblu.Text = "Ingrese el usuario";
                lblu.ForeColor = Color.Red;
                txtusuario.Focus();
            }
            else
            {
                if (txtcontraseña.Text == "")
                {
                    lblc.Text = "Ingrese la Contraseña";
                    lblc.ForeColor = Color.Red;
                    txtcontraseña.Focus();
                }
                else
                {

                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        int posY = 0;
        int posX = 0;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
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

        private void lblc_Click(object sender, EventArgs e)
        {

        }
    }
}
