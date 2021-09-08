using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Data;

namespace SADI_Desktop_v1
{
    class Negocios
    {
        public static bool FunEnviarCorreo(string VarCorreoDestino, string VarEncaezado, string VarBody, string VarAtach)
        {
            try
            {
                //string VarCorreoOrigen = "sadic.noresponder@gmail.com";
                //string VarCorreoOrigen = "vdo.calibraciones@gmail.com";
                //string VarContraseña = "soketesokete";

                string VarCorreoOrigen = "";
                string VarContraseña = "";

                string VarQuery = "SELECT TOP 1 EMail, EMailPass FROM TabEmpresa";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                if (VarData.Rows[0]["EMail"].ToString() != "")
                {
                    VarCorreoOrigen = VarData.Rows[0]["EMail"].ToString();
                    VarContraseña = VarData.Rows[0]["EMailPass"].ToString();
                }
                else
                {
                    return false;
                }

                MailMessage oMailMessage = new(VarCorreoOrigen, VarCorreoDestino, VarEncaezado, VarBody);
                oMailMessage.IsBodyHtml = true;

                if (VarAtach != "")
                {
                    var attachment = new Attachment(VarAtach);
                    oMailMessage.Attachments.Add(attachment);
                }
                

                SmtpClient oSmtpClient = new("smtp.gmail.com");
                oSmtpClient.Host = "smtp.gmail.com";
                oSmtpClient.EnableSsl = true;
                oSmtpClient.UseDefaultCredentials = false;
                oSmtpClient.Port = 587;
                oSmtpClient.Credentials = new NetworkCredential(VarCorreoOrigen, VarContraseña);
                oSmtpClient.Send(oMailMessage);
                oSmtpClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ": " + ex.Message);
                return false;
            }
        }



        public static FrmPais aFrmPais = new();
        public static FrmProvincia aFrmProvincia = new();
        public static FrmLocalidad aFrmLocalidad = new();
        public static FrmEmpresa aFrmEmpresa = new();
        public static FrmCliente aFrmCliente = new();

        public static FrmRespCalib aFrmRespCalib = new();
        public static FrmVehiculoMarca aFrmVehiculoMarca = new();
        public static FrmVehiculoModelo aFrmVehiculoModelo = new();
        public static FrmVehiculo aFrmVehiculo = new();

        public static FrmCalibraciones aFrmCalibracion = new();

        public static FrmCalibVencidas aFrmCalibVencidas = new();
        public static FrmCalibEMail aFrmCalibEMail = new();
        public static FrmFoto aFrmFoto = new();

        public static FrmEnviarEmail aFrmEnviarEmail = new FrmEnviarEmail();


        public static void FunLoad_FrmCalibVencidas() 
        {
            if (Application.OpenForms["FrmCalibVencidas"] == null)
            {
                aFrmCalibVencidas = null;
                aFrmCalibVencidas = new FrmCalibVencidas();
                aFrmCalibVencidas.Show();
            }
        }

        public static void FunLoad_FrmCalibEMail()
        {
            if (Application.OpenForms["FrmCalibEMail"] == null)
            {
                aFrmCalibEMail = null;
                aFrmCalibEMail = new FrmCalibEMail();
                aFrmCalibEMail.Show();
            }
        }
        public static void FunLoad_FrmCalibracion()
        {
            if (Application.OpenForms["FrmCalibraciones"] == null)
            {
                aFrmCalibracion = null;
                aFrmCalibracion = new FrmCalibraciones();
                aFrmCalibracion.Show();
            }
        }

        public static void FunLoad_FrmRespCalib()
        {
            if (Application.OpenForms["FrmRespCalib"] == null)
            {
                aFrmRespCalib = null;
                aFrmRespCalib = new FrmRespCalib();
                aFrmRespCalib.Show();
            }
        }

        public static void FunLoad_FrmEmpresa()
        {
            if (Application.OpenForms["FrmEmpresa"] == null)
            {
                aFrmEmpresa = null;
                aFrmEmpresa = new FrmEmpresa();
                aFrmEmpresa.Show();
            }
        }

        public static void FunLoad_FrmCliente()
        {
            if (Application.OpenForms["FrmCliente"] == null)
            {
                aFrmCliente = null;
                aFrmCliente = new FrmCliente();
                aFrmCliente.Show();
            }
        }

        public static void FunLoad_FrmVehiculo()
        {
            if (Application.OpenForms["FrmVehiculo"] == null)
            {
                aFrmVehiculo = null;
                aFrmVehiculo = new FrmVehiculo();
                aFrmVehiculo.Show();
            }
        }

        public static void FunLoad_FrmPais()
        {
            if (Application.OpenForms["FrmPais"] == null)
            {
                aFrmPais = null;
                aFrmPais = new FrmPais();
                aFrmPais.Show();
            }
        }
        public static void FunLoad_FrmProvincia()
        {
            if (Application.OpenForms["FrmProvincia"] == null)
            {
                aFrmProvincia = null;
                aFrmProvincia = new FrmProvincia();
                aFrmProvincia.Show();
            }
        }

        public static void FunLoad_FrmLocalidad()
        {
            if (Application.OpenForms["FrmLocalidad"] == null)
            {
                aFrmLocalidad = null;
                aFrmLocalidad = new FrmLocalidad();
                aFrmLocalidad.Show();
            }
        }

        public static void FunLoad_FrmVehiculoMarca()
        {
            if (Application.OpenForms["FrmVehiculoMarca"] == null)
            {
                aFrmVehiculoMarca = null;
                aFrmVehiculoMarca = new FrmVehiculoMarca();
                aFrmVehiculoMarca.Show();
            }
        }

        public static void FunLoad_FrmVehiculoModelo()
        {
            if (Application.OpenForms["FrmVehiculoModelo"] == null)
            {
                aFrmVehiculoModelo = null;
                aFrmVehiculoModelo = new FrmVehiculoModelo();
                aFrmVehiculoModelo.Show();
            }
        }

        public static void FunLoad_FrmFoto()
        {
            if (Application.OpenForms["FrmFoto"] == null)
            {
                aFrmFoto = null;
                aFrmFoto = new FrmFoto();
                aFrmFoto.Show();
            }
        }
        public static void FunLoad_FrmEnviarEmail()
        {
            if (Application.OpenForms["FrmEnviarEmail"] == null)
            {
                aFrmEnviarEmail = null;
                aFrmEnviarEmail = new FrmEnviarEmail();
                aFrmEnviarEmail.Show();
            }
        }

        

    }

    
    





    //MessageBox.Show(Menu.Items.ToString());
    //FrmRespCalib Frm = new();
    //Frm.Show();

    //MessageBox.Show(e.ClickedItem.Text);
    //switch (e.ClickedItem.Name)
    //{
    //    case "Sistema":
    //        MessageBox.Show(e.ClickedItem.Text);
    //        break;
    //    case "MnuRespCalibracion":
    //        FrmRespCalib Frm = new();
    //        Frm.Show();
    //        break;
    //}
    //    class SQL_Select
    //    {
    //        using (var adap = new OledbDataAdapter()){
    //   using (var comm = new Oledbcommand()){
    //      comm.CommandText = "tu query";
    //      adap.selectcommand = comm;
    //      using (var dset = new Dataset()){
    //         adap.fill(dset,'tu tabla');
    //         /*
    //          *    Llenas tu grid View usando de data Source 
    //          *    Dataset y de datamember
    //          *    Un string con el nombre de tu tabla.
    //          */
    //         this.Datagridview.DataSource= dset;
    //         this.Datagridview.Datamember= "tu tabla";
    //}
    //}
    //}
    //    }
}
