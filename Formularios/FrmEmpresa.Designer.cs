
namespace SADI_Desktop_v1
{
    partial class FrmEmpresa
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpresa));
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnLocalidad = new System.Windows.Forms.Button();
            this.CboLocalidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRazonSocial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtEMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNroVdo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtTipoTaller = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtPropietario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtCuit = new System.Windows.Forms.TextBox();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.BtnImagen = new System.Windows.Forms.Button();
            this.OfDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(637, 347);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(72, 24);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnLocalidad
            // 
            this.BtnLocalidad.Location = new System.Drawing.Point(331, 115);
            this.BtnLocalidad.Name = "BtnLocalidad";
            this.BtnLocalidad.Size = new System.Drawing.Size(21, 23);
            this.BtnLocalidad.TabIndex = 24;
            this.BtnLocalidad.Text = "..";
            this.BtnLocalidad.UseVisualStyleBackColor = true;
            this.BtnLocalidad.Click += new System.EventHandler(this.BtnLocalidad_Click_1);
            // 
            // CboLocalidad
            // 
            this.CboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboLocalidad.FormattingEnabled = true;
            this.CboLocalidad.Location = new System.Drawing.Point(12, 116);
            this.CboLocalidad.Name = "CboLocalidad";
            this.CboLocalidad.Size = new System.Drawing.Size(313, 23);
            this.CboLocalidad.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Razon Social";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "ID:";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(12, 27);
            this.TxtID.Name = "TxtID";
            this.TxtID.ReadOnly = true;
            this.TxtID.Size = new System.Drawing.Size(108, 23);
            this.TxtID.TabIndex = 21;
            this.TxtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(637, 317);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(71, 24);
            this.BtnGuardar.TabIndex = 18;
            this.BtnGuardar.Text = "&Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Localidad";
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Location = new System.Drawing.Point(12, 72);
            this.TxtRazonSocial.MaxLength = 35;
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(345, 23);
            this.TxtRazonSocial.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Direccion";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(12, 206);
            this.TxtDireccion.MaxLength = 35;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(345, 23);
            this.TxtDireccion.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Telefono";
            // 
            // TxtTel
            // 
            this.TxtTel.Location = new System.Drawing.Point(13, 255);
            this.TxtTel.MaxLength = 35;
            this.TxtTel.Name = "TxtTel";
            this.TxtTel.Size = new System.Drawing.Size(345, 23);
            this.TxtTel.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Correo Electronico";
            // 
            // TxtEMail
            // 
            this.TxtEMail.Location = new System.Drawing.Point(13, 302);
            this.TxtEMail.MaxLength = 35;
            this.TxtEMail.Name = "TxtEMail";
            this.TxtEMail.Size = new System.Drawing.Size(345, 23);
            this.TxtEMail.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Nº VDO";
            // 
            // TxtNroVdo
            // 
            this.TxtNroVdo.Location = new System.Drawing.Point(366, 116);
            this.TxtNroVdo.MaxLength = 35;
            this.TxtNroVdo.Name = "TxtNroVdo";
            this.TxtNroVdo.Size = new System.Drawing.Size(345, 23);
            this.TxtNroVdo.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(364, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tipo Taller";
            // 
            // TxtTipoTaller
            // 
            this.TxtTipoTaller.Location = new System.Drawing.Point(366, 72);
            this.TxtTipoTaller.MaxLength = 35;
            this.TxtTipoTaller.Name = "TxtTipoTaller";
            this.TxtTipoTaller.Size = new System.Drawing.Size(345, 23);
            this.TxtTipoTaller.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 38;
            this.label10.Text = "Propietario";
            // 
            // TxtPropietario
            // 
            this.TxtPropietario.Location = new System.Drawing.Point(13, 160);
            this.TxtPropietario.MaxLength = 35;
            this.TxtPropietario.Name = "TxtPropietario";
            this.TxtPropietario.Size = new System.Drawing.Size(345, 23);
            this.TxtPropietario.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "CUIT";
            // 
            // TxtCuit
            // 
            this.TxtCuit.Location = new System.Drawing.Point(13, 346);
            this.TxtCuit.MaxLength = 35;
            this.TxtCuit.Name = "TxtCuit";
            this.TxtCuit.Size = new System.Drawing.Size(345, 23);
            this.TxtCuit.TabIndex = 39;
            // 
            // PicLogo
            // 
            this.PicLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicLogo.Location = new System.Drawing.Point(366, 160);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(209, 209);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLogo.TabIndex = 41;
            this.PicLogo.TabStop = false;
            // 
            // BtnImagen
            // 
            this.BtnImagen.Location = new System.Drawing.Point(637, 255);
            this.BtnImagen.Name = "BtnImagen";
            this.BtnImagen.Size = new System.Drawing.Size(71, 56);
            this.BtnImagen.TabIndex = 42;
            this.BtnImagen.Text = "Buscar Logo";
            this.BtnImagen.UseVisualStyleBackColor = true;
            this.BtnImagen.Click += new System.EventHandler(this.BtnImagen_Click);
            // 
            // OfDialog
            // 
            this.OfDialog.FileName = "OfDialog";
            // 
            // FrmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(719, 374);
            this.Controls.Add(this.BtnImagen);
            this.Controls.Add(this.PicLogo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtCuit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtPropietario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtTipoTaller);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtNroVdo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtEMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtTel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.BtnLocalidad);
            this.Controls.Add(this.CboLocalidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtRazonSocial);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de la Empresa";
            this.Load += new System.EventHandler(this.FrmEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnLocalidad;
        public System.Windows.Forms.ComboBox CboLocalidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRazonSocial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtEMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtNroVdo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtTipoTaller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtPropietario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtCuit;
        private System.Windows.Forms.PictureBox PicLogo;
        private System.Windows.Forms.Button BtnImagen;
        private System.Windows.Forms.OpenFileDialog OfDialog;
    }
}

