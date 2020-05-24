namespace ServicioF
{
    partial class usua
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnsesion = new System.Windows.Forms.Button();
            this.btnclientes = new System.Windows.Forms.Button();
            this.btnrespaldo = new System.Windows.Forms.Button();
            this.btncolonias = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnsesion
            // 
            this.btnsesion.Location = new System.Drawing.Point(12, 27);
            this.btnsesion.Name = "btnsesion";
            this.btnsesion.Size = new System.Drawing.Size(133, 35);
            this.btnsesion.TabIndex = 0;
            this.btnsesion.Text = "cerrar sesion";
            this.btnsesion.UseVisualStyleBackColor = true;
            this.btnsesion.Click += new System.EventHandler(this.btnsesion_Click);
            // 
            // btnclientes
            // 
            this.btnclientes.Location = new System.Drawing.Point(299, 232);
            this.btnclientes.Name = "btnclientes";
            this.btnclientes.Size = new System.Drawing.Size(103, 64);
            this.btnclientes.TabIndex = 1;
            this.btnclientes.Text = "Clientes";
            this.btnclientes.UseVisualStyleBackColor = true;
            this.btnclientes.Click += new System.EventHandler(this.btnclientes_Click);
            // 
            // btnrespaldo
            // 
            this.btnrespaldo.Location = new System.Drawing.Point(787, 232);
            this.btnrespaldo.Name = "btnrespaldo";
            this.btnrespaldo.Size = new System.Drawing.Size(107, 64);
            this.btnrespaldo.TabIndex = 2;
            this.btnrespaldo.Text = "Respaldo y Recuperacion";
            this.btnrespaldo.UseVisualStyleBackColor = true;
            this.btnrespaldo.Click += new System.EventHandler(this.btnrespaldo_Click);
            // 
            // btncolonias
            // 
            this.btncolonias.Location = new System.Drawing.Point(538, 232);
            this.btncolonias.Name = "btncolonias";
            this.btncolonias.Size = new System.Drawing.Size(107, 64);
            this.btncolonias.TabIndex = 3;
            this.btncolonias.Text = "Colonias";
            this.btncolonias.UseVisualStyleBackColor = true;
            this.btncolonias.Click += new System.EventHandler(this.btncolonias_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bienvenido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1031, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1055, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(978, 452);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(170, 30);
            this.btnsalir.TabIndex = 8;
            this.btnsalir.Text = "salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // usua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 494);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncolonias);
            this.Controls.Add(this.btnrespaldo);
            this.Controls.Add(this.btnclientes);
            this.Controls.Add(this.btnsesion);
            this.Name = "usua";
            this.Text = "usua";
            this.Load += new System.EventHandler(this.usua_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsesion;
        private System.Windows.Forms.Button btnclientes;
        private System.Windows.Forms.Button btnrespaldo;
        private System.Windows.Forms.Button btncolonias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsalir;
    }
}