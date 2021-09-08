using System;
using System.Windows.Forms;

namespace SADI_Desktop_v1
{
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }
        private void FrmMDI_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try { 
                switch (e.ClickedItem.Name)
                {
                    case "MnuCalibVencidas":
                        Negocios.FunLoad_FrmCalibVencidas();
                        Negocios.aFrmCalibVencidas.MdiParent = this;
                        break;
                    case "MnuCalibEmail": //Calibraciones Email
                        Negocios.FunLoad_FrmCalibEMail();
                        Negocios.aFrmCalibEMail.MdiParent = this;
                        break;
                    case "MnuCalibracion": //Calibraciones (Medicion)
                        Negocios.FunLoad_FrmCalibracion();
                        Negocios.aFrmCalibracion.MdiParent = this;
                        break;
                    case "MnuRespCalib": //Responsable Calibracion
                        Negocios.FunLoad_FrmRespCalib();
                        Negocios.aFrmRespCalib.MdiParent = this;
                        break;
                    case "MnuEmpresa": //Datos Empresa
                        Negocios.FunLoad_FrmEmpresa();
                        Negocios.aFrmEmpresa.MdiParent = this;
                        break;
                    case "MnuCliente": //Alta de Cliente
                        Negocios.FunLoad_FrmCliente();
                        Negocios.aFrmCliente.MdiParent = this;
                        break;
                    case "MnuVehiculo": //Alta de Vehiculo
                        Negocios.FunLoad_FrmVehiculo();
                        Negocios.aFrmVehiculo.MdiParent = this;
                        break;
                    case "MnuSalir": //Salir del Sistema
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ": " + ex.Message);
            }
        }
        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}