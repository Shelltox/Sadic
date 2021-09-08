
namespace SADI_Desktop_v1
{
    partial class FrmFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFoto));
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.PicVideo = new System.Windows.Forms.PictureBox();
            this.BtnBuscarFoto = new System.Windows.Forms.Button();
            this.OfDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnTomarFoto = new System.Windows.Forms.Button();
            this.BtnIniciarCamara = new System.Windows.Forms.Button();
            this.CboCamaras = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(319, 314);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(72, 24);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // PicVideo
            // 
            this.PicVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicVideo.Location = new System.Drawing.Point(14, 39);
            this.PicVideo.Name = "PicVideo";
            this.PicVideo.Size = new System.Drawing.Size(300, 300);
            this.PicVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicVideo.TabIndex = 41;
            this.PicVideo.TabStop = false;
            // 
            // BtnBuscarFoto
            // 
            this.BtnBuscarFoto.Location = new System.Drawing.Point(319, 252);
            this.BtnBuscarFoto.Name = "BtnBuscarFoto";
            this.BtnBuscarFoto.Size = new System.Drawing.Size(71, 56);
            this.BtnBuscarFoto.TabIndex = 42;
            this.BtnBuscarFoto.Text = "Buscar Fotografia";
            this.BtnBuscarFoto.UseVisualStyleBackColor = true;
            this.BtnBuscarFoto.Click += new System.EventHandler(this.BtnImagen_Click);
            // 
            // OfDialog
            // 
            this.OfDialog.FileName = "OfDialog";
            // 
            // BtnTomarFoto
            // 
            this.BtnTomarFoto.Location = new System.Drawing.Point(320, 74);
            this.BtnTomarFoto.Name = "BtnTomarFoto";
            this.BtnTomarFoto.Size = new System.Drawing.Size(71, 56);
            this.BtnTomarFoto.TabIndex = 43;
            this.BtnTomarFoto.Text = "Tomar Fotografia";
            this.BtnTomarFoto.UseVisualStyleBackColor = true;
            this.BtnTomarFoto.Click += new System.EventHandler(this.BtnTomarFoto_Click);
            // 
            // BtnIniciarCamara
            // 
            this.BtnIniciarCamara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniciarCamara.Location = new System.Drawing.Point(320, 12);
            this.BtnIniciarCamara.Name = "BtnIniciarCamara";
            this.BtnIniciarCamara.Size = new System.Drawing.Size(71, 56);
            this.BtnIniciarCamara.TabIndex = 44;
            this.BtnIniciarCamara.Text = "Iniciar Camara";
            this.BtnIniciarCamara.UseVisualStyleBackColor = true;
            this.BtnIniciarCamara.Click += new System.EventHandler(this.BtnIniciarCamara_Click);
            // 
            // CboCamaras
            // 
            this.CboCamaras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCamaras.FormattingEnabled = true;
            this.CboCamaras.Location = new System.Drawing.Point(14, 12);
            this.CboCamaras.Name = "CboCamaras";
            this.CboCamaras.Size = new System.Drawing.Size(300, 23);
            this.CboCamaras.TabIndex = 45;
            // 
            // FrmFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(405, 350);
            this.Controls.Add(this.CboCamaras);
            this.Controls.Add(this.BtnIniciarCamara);
            this.Controls.Add(this.BtnTomarFoto);
            this.Controls.Add(this.BtnBuscarFoto);
            this.Controls.Add(this.PicVideo);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de Fotografia";
            this.Load += new System.EventHandler(this.FrmFoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.PictureBox PicVideo;
        private System.Windows.Forms.Button BtnBuscarFoto;
        private System.Windows.Forms.OpenFileDialog OfDialog;
        private System.Windows.Forms.Button BtnTomarFoto;
        private System.Windows.Forms.Button BtnIniciarCamara;
        private System.Windows.Forms.ComboBox CboCamaras;
    }
}

