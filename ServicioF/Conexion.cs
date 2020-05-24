using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Windows.Forms;




namespace ServicioF
{
    class Conexion
    {
        MySqlConnection conn;
        MySqlDataReader dr;

        public void Conectar()
        {
            conn = new MySqlConnection("Server=localhost; Database=serviciof; Uid=root;Pwd=12345;");
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }

        public void EjectuarMysql(String consulta)
        {
            MySqlCommand con = new MySqlCommand(consulta, conn);

            int filasAfectadas = con.ExecuteNonQuery();

            if (filasAfectadas > 0)
                MessageBox.Show("Operacion  realizada correctamente", "la base de datos a sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se a conectado a la base de datos", "Error del sistema",  MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void ActualizarGrid(DataGridView dg, String consulta)
        {
            this.Conectar();

            System.Data.DataSet ds = new System.Data.DataSet();

            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn);

            

            da.Fill(ds, "colonias");

            dg.DataSource = ds;
            dg.DataMember = "colonias";
            this.Desconectar();
        }


        public void comboBox(ComboBox cb)
        {
            try
            {
              MySqlCommand cmd = new MySqlCommand("select nombre from colonias",conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["nombre"].ToString());
                }
                dr.Close();
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se pudo mostrar los dato:  "+ex.ToString());
            }


        }

        public void ActualizarGrid2(DataGridView dg, String consulta)
        {
            this.Conectar();

            System.Data.DataSet ds = new System.Data.DataSet();

            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn);



            da.Fill(ds, "clientes");

            dg.DataSource = ds;
            dg.DataMember = "clientes";
            this.Desconectar();
        }


       

    }
}
