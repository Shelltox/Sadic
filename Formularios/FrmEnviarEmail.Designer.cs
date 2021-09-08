using System;
using System.Data;
using System.Windows.Forms;


namespace SADI_Desktop_v1
{
    public partial class FrmEnviarEmail : Form
    {
        public FrmEnviarEmail()
        {
            InitializeComponent();
        }

        private void FrmEnviarEmail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunCargoComboDestinatarios();
            LblEstado.Text = "Preparado";
        }

        public void FunCargoComboDestinatarios()
        {
            string VarQuery = " SELECT DISTINCT Destinatario, Email FROM ( " +
                              " SELECT  RazonSocial as Destinatario, Email as Email FROM TabCliente  WHERE MarcaBaja = 0 " +
                              " UNION " +
                              " SELECT  RazonSocial as Destinatario, msn as Email FROM TabCliente WHERE MarcaBaja = 0 " +
                              " UNION " +
                              " SELECT  Contacto as Destinatario, CEmail as Email FROM TabCliente WHERE MarcaBaja = 0" +
                              " UNION " +
                              " SELECT  Contacto as Destinatario, Cmsn as Email FROM TabCliente WHERE MarcaBaja = 0 " +
                              " ) AS A ORDER BY Destinatario ";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboDestinatario.Items.Clear();
            CboDestinatario.Items.Add("");

            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                if (VarData.Rows[i]["Destinatario"].ToString() != "" && VarData.Rows[i]["Email"].ToString() != "")
                {
                    CboDestinatario.Items.Add(VarData.Rows[i]["Destinatario"] + " | " + VarData.Rows[i]["Email"]);
                }
            }
        }

        private void BtnEnviar_Click(object sender, System.EventArgs e)
        {
            if (CboDestinatario.Text == "")
            {
                MessageBox.Show("Debe Seleccionar el Correo Electronico del Destinatario");
            }
            else
            {
                String[] VarDestinatario = CboDestinatario.Text.Split("|");
                //MessageBox.Show(VarDestinatario[0].ToString().ToLower());
                //MessageBox.Show(VarDestinatario[1].ToString().ToLower());

                LblEstado.Text = "Enviando Correo...";
                if (Negocios.FunEnviarCorreo(VarDestinatario[1].ToString().ToLower(), "Calibraciones", TxtMensaje.Text, TxtAdjunto.Text) == true)
                {
                    MessageBox.Show("El Correo Fue Enviado!");
                    LblEstado.Text = "Correo Enviado...";
                }
                else
                {
                    LblEstado.Text = "Preparado";
                }
            }


            
        }

        private void BtnCerrar_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void BtnCliente_Click(object sender, System.EventArgs e)
        {
            Negocios.FunLoad_FrmCliente();
            Negocios.aFrmCliente.MdiParent = this.MdiParent;
        }

        public TextBox TxtAdjunto;
    }
}
