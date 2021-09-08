
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SADI_Desktop_v1
{
    partial class FrmMDI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuSistemas = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuRespCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVehiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCalibVencidas = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCalibEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCalibracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSistemas,
            this.MnuCalibVencidas,
            this.MnuCalibEmail,
            this.MnuCalibracion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // MnuSistemas
            // 
            this.MnuSistemas.DropDown = this.contextMenuStrip1;
            this.MnuSistemas.Name = "MnuSistemas";
            this.MnuSistemas.Size = new System.Drawing.Size(65, 20);
            this.MnuSistemas.Text = "Sistemas";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuRespCalib,
            this.MnuEmpresa,
            this.MnuCliente,
            this.MnuVehiculo,
            this.toolStripSeparator1,
            this.MnuSalir});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.OwnerItem = this.MnuSistemas;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 120);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // MnuRespCalib
            // 
            this.MnuRespCalib.Name = "MnuRespCalib";
            this.MnuRespCalib.Size = new System.Drawing.Size(180, 22);
            this.MnuRespCalib.Text = "Alta de Responsable";
            // 
            // MnuEmpresa
            // 
            this.MnuEmpresa.Name = "MnuEmpresa";
            this.MnuEmpresa.Size = new System.Drawing.Size(180, 22);
            this.MnuEmpresa.Text = "Datos Empresa";
            // 
            // MnuCliente
            // 
            this.MnuCliente.Name = "MnuCliente";
            this.MnuCliente.Size = new System.Drawing.Size(180, 22);
            this.MnuCliente.Text = "Alta de Cliente";
            // 
            // MnuVehiculo
            // 
            this.MnuVehiculo.Name = "MnuVehiculo";
            this.MnuVehiculo.Size = new System.Drawing.Size(180, 22);
            this.MnuVehiculo.Text = "Alta de Vehiculo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MnuSalir
            // 
            this.MnuSalir.Name = "MnuSalir";
            this.MnuSalir.Size = new System.Drawing.Size(180, 22);
            this.MnuSalir.Text = "Salir";
            // 
            // MnuCalibVencidas
            // 
            this.MnuCalibVencidas.Name = "MnuCalibVencidas";
            this.MnuCalibVencidas.Size = new System.Drawing.Size(139, 20);
            this.MnuCalibVencidas.Text = "Calibraciones Vencidas";
            // 
            // MnuCalibEmail
            // 
            this.MnuCalibEmail.Name = "MnuCalibEmail";
            this.MnuCalibEmail.Size = new System.Drawing.Size(122, 20);
            this.MnuCalibEmail.Text = "Calibraciones Email";
            // 
            // MnuCalibracion
            // 
            this.MnuCalibracion.Name = "MnuCalibracion";
            this.MnuCalibracion.Size = new System.Drawing.Size(69, 20);
            this.MnuCalibracion.Text = "Medicion";
            // 
            // FrmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 371);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMDI";
            this.Text = "SADI Desktop v1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMDI_FormClosed);
            this.Load += new System.EventHandler(this.FrmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuSistemas;
        private System.Windows.Forms.ToolStripMenuItem MnuCalibVencidas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuCalibEmail;
        private System.Windows.Forms.ToolStripMenuItem MnuCalibracion;
        private System.Windows.Forms.ToolStripMenuItem MnuEmpresa;
        private System.Windows.Forms.ToolStripMenuItem MnuRespCalib;
        private System.Windows.Forms.ToolStripMenuItem MnuCliente;
        private System.Windows.Forms.ToolStripMenuItem MnuVehiculo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuSalir;

        //public ToolStripItemClickedEventHandler MenuStrip1_ItemClicked { get; private set; }
    }
}

