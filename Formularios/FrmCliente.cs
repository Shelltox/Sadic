using System;
using System.Windows.Forms;
using System.Data;


namespace SADI_Desktop_v1
{
    
    public partial class FrmCliente : Form
    {
        public Boolean VarGuardar = false;

        public FrmCliente()
        {
           InitializeComponent();
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunCargoCombo();
            FunBuscar();
        }

        public void FunCargoCombo()
        {
            string VarQuery = " SELECT IdLocalidad, Descripcion as Localidad" +
                              " FROM TabLocalidad  " +
                              " WHERE MarcaBaja = 0 " +
                              " ORDER BY Descripcion";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboLocalidad.Items.Clear();
            CboLocalidad.Items.Add("");
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboLocalidad.Items.Add(VarData.Rows[i]["Localidad"]);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FunBuscar();
        }

        private void FunBuscar()
        {
            try
            {
                string VarQuery = " SELECT A.IdCliente as Id, A.RazonSocial, A.Contacto, A.tTEL05, A.PreCel, A.Cel, A.IdLocalidad , B.Descripcion as Localidad, A.IDCFiscal," +
                                  " A.Email, A.Web as RedSocial, A.Cuit, A.Comentarios, A.Direccion, A.tTEL01, A.Pre01, A.TEL01, A.tTEL02, A.Pre02, A.TEL02, A.tTEL03, A.Pre03, A.TEL03," +
                                  " A.CEmail, A.tTEL06, A.PreTEL, A.TEL" + 
                                  " FROM TabCliente AS A " +
                                  " LEFT JOIN TabLocalidad AS B ON A.IdLocalidad = B.IdLocalidad " +
                                  " WHERE A.RazonSocial LIKE '%" + TxtBuscar.Text + "%'" +
                                  " AND A.MarcaBaja = 0";


                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                Grid.DataSource = VarData;
                Grid.ReadOnly = true;
                Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Grid.MultiSelect = false;

                Grid.Columns[0].Width = 50;
                Grid.Columns[0].HeaderText = "Id";
                Grid.Columns[1].Width = 250;
                Grid.Columns[1].HeaderText = "Razon Social";
                Grid.Columns[2].Width = 150;
                Grid.Columns[2].HeaderText = "Contacto";
                Grid.Columns[3].Width = 100;
                Grid.Columns[3].HeaderText = "Tipo Tel.";
                Grid.Columns[4].Width = 50;
                Grid.Columns[4].HeaderText = "Prefijo";
                Grid.Columns[5].Width = 100;
                Grid.Columns[5].HeaderText = "Numero";
                Grid.Columns[6].Visible = false; //IdLocalidad
                Grid.Columns[7].Visible = false; //Localidad
                Grid.Columns[8].Visible = false; //IdCFiscal
                Grid.Columns[9].Visible = false; //Email
                Grid.Columns[10].Visible = false; //RedSocial
                Grid.Columns[11].Visible = false; //Cuit
                Grid.Columns[12].Visible = false; //Comentarios
                Grid.Columns[13].Visible = false; //Direccion
                Grid.Columns[14].Visible = false; //tTEL01
                Grid.Columns[15].Visible = false; //Pre01
                Grid.Columns[16].Visible = false; //TEL01
                Grid.Columns[17].Visible = false; //tTEL02
                Grid.Columns[18].Visible = false; //Pre02
                Grid.Columns[19].Visible = false; //TEL02
                Grid.Columns[20].Visible = false; //tTEL03
                Grid.Columns[21].Visible = false; //Pre03
                Grid.Columns[22].Visible = false; //TEL03
                Grid.Columns[23].Visible = false; //CEmail
                Grid.Columns[24].Visible = false; //tTEL06
                Grid.Columns[25].Visible = false; //PreTel
                Grid.Columns[26].Visible = false; //Tel


                if (VarData.Rows[0].ItemArray[0].ToString() != "") {FunTrue();}

                //Grid.Columns.Add("nombre",  "Nombre");
                //Grid.Columns.Add("apellido", "Apellido");
                //Grid.Columns.Add("direccion", "Direccion");
                //Grid.Columns.Add("email", "Email");
                //Grid.Columns.Add("telefono", "Telefono");

                //for (int i = 0; i <= VarData.Rows.Count - 1; i++)
                //{
                //      Grid.Rows.Add("Agustin", "Ramos", "Mexico", "evilnapsis@gmail.com", "+5219142791570");
                //      Grid.Rows.Add("John", "Doe", "EU", "john@doe.com", "+1111111111");
                //      System.Windows.Forms.MessageBox.Show(VarData.Tables[0].Rows[i].ItemArray[0] + " -- " + VarData.Tables[0].Rows[i].ItemArray[1]);
                //}
                //if (VarData.Tables[0].Rows[0].ItemArray[0].ToString() != "") {FunTrue();}

            }
            catch (Exception ex)
            {
                if (ex.Message =="There is no row at position 0.")
                {
                    FunFalse();
                }
                else
                {
                    MessageBox.Show(ex.Source + ": " + ex.Message);
                }
            }
        }

        private void GridRespCalib_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) 
            {
                VarGuardar = false;
                FunBuscar();
            }
            else
            {
                FunLimpiar();
                if (Grid.CurrentRow != null)
                {
                    FunTrue();
                    
                    TxtID.Text = Grid[0, Grid.CurrentRow.Index].Value.ToString();
                    TxtRazonSocial.Text = Grid[1, Grid.CurrentRow.Index].Value.ToString();
                    TxtContApeNom.Text = Grid[2, Grid.CurrentRow.Index].Value.ToString();
                    CboTipoTel04.Text = Grid[3, Grid.CurrentRow.Index].Value.ToString();
                    TxtPreTel04.Text = Grid[4, Grid.CurrentRow.Index].Value.ToString();
                    TxtNumero04.Text = Grid[5, Grid.CurrentRow.Index].Value.ToString();
                    //CboLocalidadId = Grid[6, Grid.CurrentRow.Index].Value.ToString();
                    CboLocalidad.Text = Grid[7, Grid.CurrentRow.Index].Value.ToString();

                    decimal VarIdCFiscal = (decimal)Grid[8, Grid.CurrentRow.Index].Value;
                    CboCFical.SelectedIndex = (int)VarIdCFiscal;

                    TxtEMail.Text = Grid[9, Grid.CurrentRow.Index].Value.ToString();
                    TxtRedSocial.Text = Grid[10, Grid.CurrentRow.Index].Value.ToString();
                    TxtCuit.Text = Grid[11, Grid.CurrentRow.Index].Value.ToString();
                    TxtObs.Text = Grid[12, Grid.CurrentRow.Index].Value.ToString();
                    TxtDireccion.Text = Grid[13, Grid.CurrentRow.Index].Value.ToString();
                    CboTipoTel01.Text = Grid[14, Grid.CurrentRow.Index].Value.ToString();
                    TxtPreTel01.Text = Grid[15, Grid.CurrentRow.Index].Value.ToString();
                    TxtNumero01.Text = Grid[16, Grid.CurrentRow.Index].Value.ToString();
                    CboTipoTel02.Text = Grid[17, Grid.CurrentRow.Index].Value.ToString();
                    TxtPreTel02.Text = Grid[18, Grid.CurrentRow.Index].Value.ToString();
                    TxtNumero02.Text = Grid[19, Grid.CurrentRow.Index].Value.ToString();
                    CboTipoTel03.Text = Grid[20, Grid.CurrentRow.Index].Value.ToString();
                    TxtPreTel03.Text = Grid[21, Grid.CurrentRow.Index].Value.ToString();
                    TxtNumero03.Text = Grid[22, Grid.CurrentRow.Index].Value.ToString();
                    TxtContEMail.Text = Grid[23, Grid.CurrentRow.Index].Value.ToString();
                    CboTipoTel05.Text = Grid[24, Grid.CurrentRow.Index].Value.ToString();
                    TxtPreTel05.Text = Grid[25, Grid.CurrentRow.Index].Value.ToString();
                    TxtNumero05.Text = Grid[26, Grid.CurrentRow.Index].Value.ToString();

                    BtnEliminar.Enabled = true;
                }
                else
                {
                    FunFalse();
                    VarGuardar = true;
                }
            }
        }

        private void BtnLocalidad_Click(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmLocalidad();
            Negocios.aFrmLocalidad.MdiParent = this.MdiParent;
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FunTrue();
            FunLimpiar();
            BtnEliminar.Enabled = false;
            VarGuardar = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FunValidaciones() == false) {return;}

                int CboLocalidadId = ConexionData.FunComboId("TabLocalidad", "IdLocalidad", "Descripcion", CboLocalidad.Text);

                if (VarGuardar == true)
                {
                    string VarQuery = " INSERT INTO TabCliente (IdLocalidad, RazonSocial, Contacto, tTEL05, PreCel, Cel, IdCFiscal, EMail, Web, Cuit, Comentarios," +
                                      " Direccion, tTEL01, Pre01, TEL01, tTEL02, Pre02, TEL02, tTEL03, Pre03, TEL03, CEmail, tTEL06, PreTEL, TEL, MarcaBaja)" +
                                      " VALUES(" + CboLocalidadId + ",'" + TxtRazonSocial.Text + "','" + TxtContApeNom.Text + "','" + CboTipoTel04.Text + "','" + TxtPreTel04.Text + "','" + TxtNumero04.Text + "'," + CboCFical.SelectedIndex +
                                      ",'" + TxtEMail.Text + "','" + TxtRedSocial.Text + "','" + TxtCuit.Text + "','" + TxtObs.Text + "','" + TxtDireccion.Text + "','" + CboTipoTel01.Text + "','" + TxtPreTel01.Text + "','" + TxtNumero01.Text +
                                      "','" + CboTipoTel02.Text + "','" + TxtPreTel02.Text + "','" + TxtNumero02.Text + "','" + CboTipoTel03.Text + "','" + TxtPreTel03.Text + "','" + TxtNumero03.Text + "','" + TxtContEMail.Text + 
                                      "','" + CboTipoTel05.Text + "','" + TxtPreTel05.Text + "','" + TxtNumero05.Text + "',0)";

                    MessageBox.Show(VarQuery);

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("IdCliente", "TabCliente");
                        VarGuardar = false;
                        TxtBuscar.Text = "";
                        FunTrue();
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("No se Pudo Agregar el Registro");
                    }
                }
                else
                {
                    string VarQuery = " UPDATE TabCliente SET " +
                                      " IdLocalidad = " + CboLocalidadId +
                                      ",RazonSocial = '" + TxtRazonSocial.Text + "',Contacto = '" + TxtContApeNom.Text +
                                      "',tTEL05 = '" + CboTipoTel04.Text + "',PreCel = '" + TxtPreTel04.Text + "', Cel = '" + TxtNumero04.Text +
                                      "',IdCFiscal = " + CboCFical.SelectedIndex + ",EMail = '" + TxtEMail.Text +
                                      "',Web = '" + TxtRedSocial.Text + "',Cuit = '" + TxtCuit.Text +
                                      "',Comentarios = '" + TxtObs.Text + "',Direccion = '" + TxtDireccion.Text +
                                      "',tTEL01 = '" + CboTipoTel01.Text + "',Pre01 = '" + TxtPreTel01.Text + "',TEL01 = '" + TxtNumero01.Text +
                                      "',tTEL02 = '" + CboTipoTel02.Text + "',Pre02 = '" + TxtPreTel02.Text + "',TEL02 = '" + TxtNumero02.Text +
                                      "',tTEL03 = '" + CboTipoTel03.Text + "',Pre03 = '" + TxtPreTel03.Text + "',TEL03 = '" + TxtNumero03.Text +
                                      "',tTEL06 = '" + CboTipoTel05.Text + "',PreTel = '" + TxtPreTel05.Text + "',Tel = '" + TxtNumero05.Text +
                                      "',CEmail = '" + TxtContEMail.Text + "',MarcaBaja = 0 " +
                                      " WHERE IdCliente = " + TxtID.Text;

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

        private bool FunValidaciones()
        {
            if (TxtRazonSocial.Text == "")
            {
                MessageBox.Show("Debe Ingresar La Razon Social");
                TxtRazonSocial.Focus();
                return false;
            }

            if (CboCFical.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Condicion Fiscal");
                CboCFical.Focus();
                return false;
            }

            if (CboCFical.Text !="Sin Inscripcion" && TxtCuit.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Cuit");
                TxtCuit.Focus();
                return false;
            }

            if (CboLocalidad.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Localidad");
                CboLocalidad.Focus();
                return false;
            }

            TxtRazonSocial.Text = TxtRazonSocial.Text.ToUpper();
            TxtContApeNom.Text = TxtContApeNom.Text.ToUpper();
            TxtContEMail.Text = TxtContEMail.Text.ToUpper();
            TxtDireccion.Text = TxtDireccion.Text.ToUpper();
            TxtEMail.Text = TxtEMail.Text.ToUpper();
            TxtObs.Text = TxtObs.Text.ToUpper();
            TxtRedSocial.Text = TxtRedSocial.Text.ToUpper();

            return true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TxtID.Text.Length == 0) { return; }
            if (MessageBox.Show("¿Esta Seguro que desea Eliminar el Registro?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) { return; }

            //string VarQuery = " DELETE FROM TabPais WHERE IdPais = " + TxtID.Text;
            string VarQuery = " UPDATE TabCliente SET MarcaBaja = 1 WHERE IdCliente = " + TxtID.Text;

            if (ConexionData.SQL_Comando(VarQuery) == true)
            {
                MessageBox.Show("Registro Eliminado");
                FunBuscar();
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se Pudo Eliminar el Registro");
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Negocios.aFrmEnviarEmail.FunCargoComboDestinatarios();
            this.Hide();
        }

        private void FunLimpiar()
        {
            TxtID.Text = "";
            TxtRazonSocial.Text = "";
            TxtEMail.Text = "";
            TxtRedSocial.Text = "";
            CboCFical.SelectedIndex = -1;
            TxtCuit.Text = "";
            CboLocalidad.SelectedIndex = -1;
            TxtObs.Text = "";
            TxtDireccion.Text = "";
            CboTipoTel01.SelectedIndex = -1;
            TxtPreTel01.Text = "";
            TxtNumero01.Text = "";
            CboTipoTel02.SelectedIndex = -1;
            TxtPreTel02.Text = "";
            TxtNumero02.Text = "";
            CboTipoTel03.SelectedIndex = -1;
            TxtPreTel03.Text = "";
            TxtNumero03.Text = "";
            TxtContApeNom.Text = "";
            TxtContEMail.Text = "";
            CboTipoTel04.SelectedIndex = -1;
            TxtPreTel04.Text = "";
            TxtNumero04.Text = "";
            CboTipoTel05.SelectedIndex = -1;
            TxtPreTel05.Text = "";
            TxtNumero05.Text = "";

            TxtRazonSocial.Focus();
        }

        private void FunFalse()
        {
            CboLocalidad.Enabled = false;
            TxtRazonSocial.Enabled = false;
            TxtEMail.Enabled = false;
            TxtRedSocial.Enabled = false;
            CboCFical.Enabled = false;
            TxtCuit.Enabled = false;
            CboLocalidad.Enabled = false;
            TxtObs.Enabled = false;
            TxtDireccion.Enabled = false;
            CboTipoTel01.Enabled = false;
            TxtPreTel01.Enabled = false;
            TxtNumero01.Enabled = false;
            CboTipoTel02.Enabled = false;
            TxtPreTel02.Enabled = false;
            TxtNumero02.Enabled = false;
            CboTipoTel03.Enabled = false;
            TxtPreTel03.Enabled = false;
            TxtNumero03.Enabled = false;
            TxtContApeNom.Enabled = false;
            TxtContEMail.Enabled = false;
            CboTipoTel04.Enabled = false;
            TxtPreTel04.Enabled = false;
            TxtNumero04.Enabled = false;
            CboTipoTel05.Enabled = false;
            TxtPreTel05.Enabled = false;
            TxtNumero05.Enabled = false;
        }

        private void FunTrue()
        {
            CboLocalidad.Enabled = true;
            TxtRazonSocial.Enabled = true;
            TxtEMail.Enabled = true;
            TxtRedSocial.Enabled = true;
            CboCFical.Enabled = true;
            TxtCuit.Enabled = true;
            CboLocalidad.Enabled = true;
            TxtObs.Enabled = true;
            TxtDireccion.Enabled = true;
            CboTipoTel01.Enabled = true;
            TxtPreTel01.Enabled = true;
            TxtNumero01.Enabled = true;
            CboTipoTel02.Enabled = true;
            TxtPreTel02.Enabled = true;
            TxtNumero02.Enabled = true;
            CboTipoTel03.Enabled = true;
            TxtPreTel03.Enabled = true;
            TxtNumero03.Enabled = true;
            TxtContApeNom.Enabled = true;
            TxtContEMail.Enabled = true;
            CboTipoTel04.Enabled = true;
            TxtPreTel04.Enabled = true;
            TxtNumero04.Enabled = true;
            CboTipoTel05.Enabled = true;
            TxtPreTel05.Enabled = true;
            TxtNumero05.Enabled = true;
        }
    }
}
