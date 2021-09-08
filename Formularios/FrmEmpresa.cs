using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace SADI_Desktop_v1
{
    public partial class FrmEmpresa : Form
    {
        public Boolean VarGuardar = false;
        public string VarPath = "";

        public FrmEmpresa()
        {
           InitializeComponent();
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunCargoCombo();
            FunBuscar();
        }

        private void FunBuscar()
        {
            try
            {
                string VarQuery = " SELECT TOP 1 A.Id, A.RazonSocial, A.Direccion, A.TelFax, A.Email, A.IdLocalidad, B.Descripcion as Localidad, C.Descripcion as Provincia, " +
                                  " A.NroVdo, A.LogoTipo, A.TipoTaller, A.Propietario, A.Cuit" +
                                  " FROM ((TabEmpresa as A " +
                                  " LEFT JOIN TabLocalidad as B ON B.IdLocalidad = A.IdLocalidad )" +
                                  " LEFT JOIN TabProvincia as C ON C.IdProvincia = B.IdProvincia )" +
                                  " WHERE A.MarcaBaja = 0";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
                FunLimpiar();
                if (VarData.Rows.Count.ToString() != "0") 
                {
                    TxtID.Text = VarData.Rows[0]["Id"].ToString();
                    TxtRazonSocial.Text = VarData.Rows[0]["RazonSocial"].ToString();
                    TxtDireccion.Text = VarData.Rows[0]["Direccion"].ToString();
                    TxtTel.Text = VarData.Rows[0]["TelFax"].ToString();
                    TxtEMail.Text = VarData.Rows[0]["Email"].ToString();
                    TxtNroVdo.Text = VarData.Rows[0]["NroVdo"].ToString();
                    TxtTipoTaller.Text = VarData.Rows[0]["TipoTaller"].ToString();
                    TxtPropietario.Text = VarData.Rows[0]["Propietario"].ToString();
                    TxtCuit.Text = VarData.Rows[0]["Cuit"].ToString();

                    if (VarData.Rows[0]["LogoTipo"].ToString() != "0")
                    {
                        VarPath = VarData.Rows[0]["LogoTipo"].ToString();
                        PicLogo.Image = Image.FromFile(VarData.Rows[0]["LogoTipo"].ToString());
                    }
                    
                    VarQuery = " SELECT B.Descripcion as Provincia, A.Descripcion as Localidad" +
                               " FROM TabLocalidad as A" +
                               " INNER JOIN TabProvincia as B ON A.IdProvincia = B.IdProvincia " +
                               " WHERE A.MarcaBaja = 0 " +
                               " AND A.IdLocalidad = " + VarData.Rows[0]["IdLocalidad"];

                    DataTable VarData2 = ConexionData.SQL_SelectDT(VarQuery);
                    if (VarData2.Rows.Count.ToString() != "0")
                    {
                        CboLocalidad.Text = VarData2.Rows[0]["Provincia"].ToString () + " - " + VarData2.Rows[0]["Localidad"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FunCargoCombo()
        {
            string VarQuery = " SELECT A.IdLocalidad, B.Descripcion as Provincia, A.Descripcion as Localidad" +
                              " FROM TabLocalidad as A" +
                              " INNER JOIN TabProvincia as B ON A.IdProvincia = B.IdProvincia " +
                              " WHERE A.MarcaBaja = 0 " +
                              " ORDER BY B.Descripcion, A.Descripcion";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboLocalidad.Items.Clear();
            CboLocalidad.Items.Add("");
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboLocalidad.Items.Add(VarData.Rows[i]["Provincia"]  + " - "  +  VarData.Rows[i]["Localidad"]);
            }
        }
        private void FunLimpiar()
        {
            TxtID.Text = "";
            TxtRazonSocial.Text = "";
            TxtDireccion.Text = "";
            TxtTel.Text = "";
            TxtEMail.Text = "";
            CboLocalidad.Text = ""; 
            TxtNroVdo.Text = "";
            PicLogo.Text = "";
            TxtTipoTaller.Text = "";
            TxtPropietario.Text = "";
            TxtCuit.Text = "";
            TxtRazonSocial.Focus();
        }

        private bool FunValidaciones()
        {
            if (TxtRazonSocial.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Razon Social");
                TxtRazonSocial.Focus();
                return false;
            }
            if (CboLocalidad.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Localidad");
                CboLocalidad.Focus();
                return false;
            }
            if (TxtPropietario.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Propietario del Taller");
                TxtPropietario.Focus();
                return false;
            }

            if (TxtDireccion.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Direccion");
                TxtDireccion.Focus();
                return false;
            }
            if (TxtTel.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Telefono");
                TxtTel.Focus();
                return false;
            }
            if (TxtEMail.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Correo Electronico");
                TxtEMail.Focus();
                return false;
            }
            if (TxtCuit.Text == "")
            {
                MessageBox.Show("Debe Ingresar el CUIT");
                TxtCuit.Focus();
                return false;
            }
            if (TxtTipoTaller.Text == "")
            {
                MessageBox.Show("Debe Ingresar el tipo de Taller");
                TxtTipoTaller.Focus();
                return false;
            }
            if (TxtNroVdo.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Nº VDO");
                TxtNroVdo.Focus();
                return false;
            }

            TxtRazonSocial.Text = TxtRazonSocial.Text.ToUpper();
            TxtDireccion.Text = TxtDireccion.Text.ToUpper();
            TxtTel.Text = TxtTel.Text.ToUpper();
            TxtEMail.Text = TxtEMail.Text.ToUpper();
            TxtNroVdo.Text = TxtNroVdo.Text.ToUpper();
            TxtTipoTaller.Text = TxtTipoTaller.Text.ToUpper();
            TxtPropietario.Text = TxtPropietario.Text.ToUpper();
            TxtCuit.Text = TxtCuit.Text.ToUpper();

            return true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (FunValidaciones() == false) { return; }

                string[] Palabras = CboLocalidad.Text.Split('-');
                int CboLocalidadId = ConexionData.FunComboId("TabLocalidad", "IdLocalidad", "Descripcion", Palabras[1].ToString().Trim());
                string VarQuery = " SELECT Id FROM TabEmpresa WHERE MarcaBaja = 0";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
                if (VarData.Rows.Count <= 0)
                {
                    VarQuery = " INSERT INTO TabEmpresa (IdLocalidad, RazonSocial, Direccion, TelFax, EMail, NroVdo, TipoTaller, Propietario, Cuit, LogoTipo, MarcaBaja)" + 
                               " VALUES("  + CboLocalidadId +  ",'" + TxtRazonSocial.Text + "','" + TxtDireccion.Text + "','" + TxtTel.Text + "','" + TxtEMail.Text +
                               "','" + TxtNroVdo.Text + "','" + TxtTipoTaller.Text + "','" + TxtPropietario.Text + "','" + TxtCuit.Text + "','" + VarPath + "',0)";

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("Id", "TabEmpresa");
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("No se Pudo Agregar el Registro");
                    }
                }
                else
                {
                     VarQuery = " UPDATE TabEmpresa SET " +
                                " IdLocalidad = " + CboLocalidadId + "" +
                                      ",RazonSocial = '" + TxtRazonSocial.Text + "'" +
                                      ",Direccion = '" + TxtDireccion.Text + "'" +
                                      ",TelFax = '" + TxtTel.Text + "'" +
                                      ",EMail = '" + TxtEMail.Text + "'" +
                                      ",NroVdo = '" + TxtNroVdo.Text + "'" +
                                      ",TipoTaller = '" + TxtTipoTaller.Text + "'" +
                                      ",Propietario = '" + TxtPropietario.Text + "'" +
                                      ",Cuit = '" + TxtCuit.Text + "'" +
                                      ",LogoTipo = '" + VarPath + "'" +
                                      ",MarcaBaja = 0 " +
                                      " WHERE Id = " + TxtID.Text;

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        MessageBox.Show("Registro Modificado");
                    }
                    else
                    {
                        MessageBox.Show("No se Pudo Modificar el Registro");
                    }
                }
                FunBuscar();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog OfDialog = new();
            OfDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            OfDialog.Title = "Seleccionar Imagen Logotipo";
            OfDialog.Filter = "Imagen (*.jpg)|*.jpg| Imagen (*.png)|*.png| Imagen (*.bmp)|*.bmp ";

            if (OfDialog.ShowDialog() == DialogResult.OK)
            {
                VarPath = OfDialog.FileName;
                PicLogo.Image = Image.FromFile(OfDialog.FileName);
            }

        }

        private void BtnLocalidad_Click_1(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmLocalidad();
            Negocios.aFrmLocalidad.MdiParent = this.MdiParent;
        }
    }
}
