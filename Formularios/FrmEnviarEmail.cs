
using System.Windows.Forms;

namespace SADI_Desktop_v1
{
    partial class FrmEnviarEmail
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        ///  private GroupBox groupBox1;
        private Button BtnCliente;
        public ComboBox CboDestinatario;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox TxtMensaje;
        private Button BtnCerrar;
        private Button BtnEnviar;
        private Label LblEstado;
        private GroupBox groupBox1;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCliente = new System.Windows.Forms.Button();
            this.CboDestinatario = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtAdjunto = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtMensaje = new System.Windows.Forms.TextBox();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.LblEstado = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCliente);
            this.groupBox1.Controls.Add(this.CboDestinatario);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "* Correo Electronico del Destinatario:";
            // 
            // BtnCliente
            // 
            this.BtnCliente.Location = new System.Drawing.Point(533, 19);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(41, 23);
            this.BtnCliente.TabIndex = 1;
            this.BtnCliente.Text = "...";
            this.BtnCliente.UseVisualStyleBackColor = true;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // CboDestinatario
            // 
            this.CboDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDestinatario.FormattingEnabled = true;
            this.CboDestinatario.Location = new System.Drawing.Point(11, 19);
            this.CboDestinatario.Name = "CboDestinatario";
            this.CboDestinatario.Size = new System.Drawing.Size(516, 23);
            this.CboDestinatario.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtAdjunto);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivo Adjunto";
            // 
            // TxtAdjunto
            // 
            this.TxtAdjunto.Location = new System.Drawing.Point(12, 22);
            this.TxtAdjunto.Name = "TxtAdjunto";
            this.TxtAdjunto.ReadOnly = true;
            this.TxtAdjunto.Size = new System.Drawing.Size(562, 23);
            this.TxtAdjunto.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtMensaje);
            this.groupBox3.Location = new System.Drawing.Point(13, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 259);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mensaje (Opcional)";
            // 
            // TxtMensaje
            // 
            this.TxtMensaje.Location = new System.Drawing.Point(10, 23);
            this.TxtMensaje.Multiline = true;
            this.TxtMensaje.Name = "TxtMensaje";
            this.TxtMensaje.Size = new System.Drawing.Size(563, 226);
            this.TxtMensaje.TabIndex = 0;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(489, 396);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(97, 23);
            this.BtnCerrar.TabIndex = 3;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(386, 397);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(97, 22);
            this.BtnEnviar.TabIndex = 4;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblEstado.Location = new System.Drawing.Point(16, 397);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(43, 15);
            this.LblEstado.TabIndex = 5;
            this.LblEstado.Text = "Estado";
            // 
            // FrmEnviarEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 427);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEnviarEmail";
            this.Load += new System.EventHandler(this.FrmEnviarEmail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
    }
}

