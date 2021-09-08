using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;


namespace SADI_Desktop_v1
{
    
    public partial class FrmVehiculo: Form
    {
        public Boolean VarGuardar = false;

        public FrmVehiculo()
        {
           InitializeComponent();
        }
        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            Panel.Visible = false;
            this.CenterToParent();
            FunCargoComboMarca();
            FunBuscar();
        }
        public void FunCargoComboMarca()
        {
            string VarQuery = " SELECT IdMarca, Marca" +
                              " FROM TabVehiculoMarca  " +
                              " WHERE MarcaBaja = 0 " +
                              " ORDER BY Marca";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboMarca.Items.Clear();
            CboMarca.Items.Add("");
 
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboMarca.Items.Add(VarData.Rows[i]["Marca"]);
            }
        }
        private void FunCargoComboModelo_Event(object sender, EventArgs e)
        {
            FunCargoComboModelo();
        }
        public void FunCargoComboModelo()
        {
            string VarQuery = " SELECT IdModelo, Modelo" +
                              " FROM TabVehiculoModelo  " +
                              " WHERE MarcaBaja = 0 " +
                              " AND IdMarca = " + ConexionData.FunComboId("TabVehiculoMarca", "IdMarca", "Marca", CboMarca.Text) +
                              " ORDER BY Modelo";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboModelo.Items.Clear();
            CboModelo.Items.Add("");
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboModelo.Items.Add(VarData.Rows[i]["Modelo"]);
            }
        }

        private void TxtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            FunBuscar();
        }

        private void FunBuscar()
        {
            try
            {
                string VarQuery = " SELECT A.IdVehiculo as Id, D.Cuit, D.RazonSocial, C.Marca, B.Modelo, A.Dominio, A.NroMovil, A.Operador, A.Categoria, A.TacoMarca, T.TacoModeloDesc," +
                                  " A.FactorK, A.TacoNroSerie, A.Choferes, A.DiscoKM, A.DiscoDias, A.TipoDeUso, A.CodProducto, A.TelefonoConductor, A.Recordatorio, A.ImgFoto" +
                                  " FROM ((((TabVehiculo AS A " +
                                  " LEFT JOIN TabCliente AS D ON D.IdCliente = A.IdCliente) " +
                                  " LEFT JOIN TabVehiculoModelo AS B ON B.IdModelo = A.IdModelo) " +
                                  " LEFT JOIN TabVehiculoMarca AS C ON C.IdMarca = B.IdMarca) " +
                                  " LEFT JOIN TabTacografoModelo AS T ON T.TacoModelo = A.TacoModelo) " +
                                  " WHERE (D.RazonSocial LIKE '%" + TxtBuscar.Text + "%'" + " OR A.Dominio LIKE '%" + TxtBuscar.Text + "%')" +
                                  " AND A.MarcaBaja = 0" +
                                  " ORDER BY D.RazonSocial,  A.IdVehiculo";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                Grid.DataSource = VarData;
                Grid.ReadOnly = true;
                Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Grid.MultiSelect = false;

                Grid.Columns[0].Width = 50;
                Grid.Columns[0].HeaderText = "Id";
                Grid.Columns[1].Width = 80;
                Grid.Columns[1].HeaderText = "CUIT";
                Grid.Columns[2].Width = 300;
                Grid.Columns[2].HeaderText = "Propietario";
                Grid.Columns[3].Width = 100;
                Grid.Columns[3].HeaderText = "Marca";
                Grid.Columns[4].Width = 130;
                Grid.Columns[4].HeaderText = "Modelo";
                Grid.Columns[5].Width = 80;
                Grid.Columns[5].HeaderText = "Dominio";
                Grid.Columns[6].Width = 80;
                Grid.Columns[6].HeaderText = "Nº Movil";

                Grid.Columns[7].Visible = false; //Operador
                Grid.Columns[8].Visible = false; //Categoria
                Grid.Columns[9].Visible = false; //TacoMarca
                Grid.Columns[10].Visible = false; //TacoModelo
                Grid.Columns[11].Visible = false; //FactorK
                Grid.Columns[12].Visible = false; //TacoNroSerie
                Grid.Columns[13].Visible = false; //Choferes
                Grid.Columns[14].Visible = false; //DiscoKM
                Grid.Columns[15].Visible = false; //DiscoDias
                Grid.Columns[16].Visible = false; //TipoDeUso
                Grid.Columns[17].Visible = false; //CodProducto
                Grid.Columns[18].Visible = false; //TelefonoConductor
                Grid.Columns[19].Visible = false; //Recordatorio
                Grid.Columns[20].Visible = false; //ImgFoto

                if (VarData.Rows[0].ItemArray[0].ToString() != "") {FunTrue();}
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

                    //decimal VarIdCFiscal = (decimal)Grid[8, Grid.CurrentRow.Index].Value;
                    //CboCFical.SelectedIndex = (int)VarIdCFiscal;

                    TxtID.Text = Grid[0, Grid.CurrentRow.Index].Value.ToString();
                    TxtCuit.Value = Convert.ToInt64(Grid[1, Grid.CurrentRow.Index].Value.ToString());
                    TxtRazonSocial.Text = Grid[2, Grid.CurrentRow.Index].Value.ToString();
                    CboMarca.Text = Grid[3, Grid.CurrentRow.Index].Value.ToString();
                    FunCargoComboModelo();
                    CboModelo.Text = Grid[4, Grid.CurrentRow.Index].Value.ToString();
                    TxtDominio.Text = Grid[5, Grid.CurrentRow.Index].Value.ToString();
                    if (Grid[6, Grid.CurrentRow.Index].Value.ToString() != ""){ TxtNroMovil.Value = Convert.ToInt32(Grid[6, Grid.CurrentRow.Index].Value.ToString()); }
                    
                    TxtConductor.Text = Grid[7, Grid.CurrentRow.Index].Value.ToString();
                    //CboCategoria.Text = Grid[8, Grid.CurrentRow.Index].Value.ToString();
                    CboCategoria.SelectedIndex = int.Parse((string)Grid[8, Grid.CurrentRow.Index].Value);

                    TxtTacoMarca.Text = Grid[9, Grid.CurrentRow.Index].Value.ToString();

                    CboTacoModelo.Text = Grid[10, Grid.CurrentRow.Index].Value.ToString();
                    //CboTacoModelo.SelectedIndex = int.Parse((string)Grid[10, Grid.CurrentRow.Index].Value.ToString()) ;

                    TxtFactorK.Value = Convert.ToInt64(Grid[11, Grid.CurrentRow.Index].Value.ToString());
                    TxtNSerie.Text = Grid[12, Grid.CurrentRow.Index].Value.ToString();
                    TxtChoferes.Value = Convert.ToInt64(Grid[13, Grid.CurrentRow.Index].Value.ToString());
                    TxtKmDisco.Value = Convert.ToInt64(Grid[14, Grid.CurrentRow.Index].Value.ToString());
                    TxtDiasDisco.Value = Convert.ToInt64(Grid[15, Grid.CurrentRow.Index].Value.ToString());

                    //CboTipoDeUso.Text = Grid[16, Grid.CurrentRow.Index].Value.ToString();
                    CboTipoDeUso.SelectedIndex = int.Parse((string)Grid[16, Grid.CurrentRow.Index].Value.ToString());

                    if (Grid[17, Grid.CurrentRow.Index].Value.ToString() != "") { TxtCodProducto.Value = Convert.ToInt64(Grid[17, Grid.CurrentRow.Index].Value.ToString()); }
                    
                    TxtConductorTel.Text = Grid[18, Grid.CurrentRow.Index].Value.ToString();

                    ChkRecordatorio.Checked = false;
                    if (Grid[19, Grid.CurrentRow.Index].Value.ToString() != "False") 
                    {
                        ChkRecordatorio.Checked = true;
                    }
                    BtnEliminar.Enabled = true;

                    FunCargarGridCalib(TxtID.Text);
                }
                else
                {
                    FunFalse();
                    VarGuardar = true;
                }
            }
        }

        private void FunCargarGridCalib(string VarIdVehiculo)
        {
            try
            {
                string VarQuery = " SELECT TOS.FechaHoraOS, TOS.MedicionK, TOS.MedicionW, TOS.Reluctor, TOS.GearRatio, TOS.FchRecordatorio, TOS.KilometrajeAlMedir, TOS.Observaciones, TOS.IdOrdenServicio, TOS.DifKeKs " +
                                  " FROM TabCalibraciones AS TOS " +
                                  " WHERE TOS.MarcaBaja = 0 " +
                                  " AND TOS.IdVehiculo = " + VarIdVehiculo +
                                  " ORDER BY TOS.FechaHoraOS DESC ";

                BtnCalibrar.Enabled = false;
                BtnElimCalib.Enabled = false;
                BtnEnviarEMail.Enabled = false;
                BtnImprimirPDF.Enabled = false;
                BtnVisualizar.Enabled = false;

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                GridCalib.DataSource = VarData;
                GridCalib.ReadOnly = true;
                GridCalib.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridCalib.MultiSelect = false;

                GridCalib.Columns[0].Width = 110;
                GridCalib.Columns[0].HeaderText = "Fecha-Hora";
                GridCalib.Columns[1].Width = 70;
                GridCalib.Columns[1].HeaderText = "Med. K";
                GridCalib.Columns[2].Width = 75;
                GridCalib.Columns[2].HeaderText = "Med. W";
                GridCalib.Columns[3].Width = 65;
                GridCalib.Columns[3].HeaderText = "Reluctor";
                GridCalib.Columns[4].Width = 65;
                GridCalib.Columns[4].HeaderText = "GearRatio";
                GridCalib.Columns[5].Width = 85;
                GridCalib.Columns[5].HeaderText = "Recordatorio";
                GridCalib.Columns[6].Width = 75;
                GridCalib.Columns[6].HeaderText = "Kilometraje";
                GridCalib.Columns[7].Width = 270;
                GridCalib.Columns[7].HeaderText = "Observaciones";
                GridCalib.Columns[8].Visible = false; //IdOrdenServicio
                GridCalib.Columns[9].Visible = false; //DifKeKs

                if (VarData.Rows.Count != 0) 
                {
                    BtnCalibrar.Enabled = true;
                    BtnElimCalib.Enabled = true;
                    BtnEnviarEMail.Enabled = true;
                    BtnImprimirPDF.Enabled = true;
                    BtnVisualizar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "There is no row at position 0.")
                {
                    FunFalse();
                }
                else
                {
                    MessageBox.Show(ex.Source + ": " + ex.Message);
                }
            }
        }
        private void BtnMarca_Click(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmVehiculoMarca();
            Negocios.aFrmVehiculoMarca.MdiParent = this.MdiParent;

        }
        private void BtnModelo_Click(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmVehiculoModelo();
            Negocios.aFrmVehiculoModelo.MdiParent = this.MdiParent;
        }
        private void BtnCliente_Click(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmCliente();
            Negocios.aFrmCliente.MdiParent = this.MdiParent;
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FunTrue();
            FunLimpiar();
            BtnEliminar.Enabled = false;
            VarGuardar = true;
            GridCalib.DataSource = "";
        }
        private void FrmVehiculo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "113") //F2
            {
                TxtBuscarCliente.Text = "";
                FunBuscarCliente();
                TxtBuscarCliente.Focus();

                Panel.Visible = true;
            }
        }
        private void TxtBuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            FunBuscarCliente();
        }
        private void FunBuscarCliente()
        {
            try
            {
                string VarQuery = " SELECT A.IdCliente as Id, A.Cuit, A.RazonSocial, A.Contacto" +
                                  " FROM TabCliente AS A " +
                                  " WHERE A.RazonSocial LIKE '%" + TxtBuscarCliente.Text + "%'" +
                                  " OR A.Cuit LIKE " + "'%" + TxtBuscarCliente.Text + "%'" +
                                  " AND A.MarcaBaja = 0";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                GridCliente.DataSource = VarData;
                GridCliente.ReadOnly = true;
                GridCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridCliente.MultiSelect = false;

                GridCliente.Columns[0].Width = 50;
                GridCliente.Columns[0].HeaderText = "Id";
                GridCliente.Columns[1].Width = 100;
                GridCliente.Columns[1].HeaderText = "Cuit";
                GridCliente.Columns[2].Width = 330;
                GridCliente.Columns[2].HeaderText = "Razon Social";
                GridCliente.Columns[3].Width = 330;
                GridCliente.Columns[3].HeaderText = "Contacto";

                //if (VarData.Rows.Count != 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ": " + ex.Message);
            }
        }

        private void GridCliente_DoubleClick(object sender, EventArgs e)
        {
            FunSeleccionar();
        }
        private void BtnCerrarCliente_Click(object sender, EventArgs e)
        {
            FunSeleccionar();
        }
        private void FunSeleccionar()
        {
            Panel.Visible = false;

            if (GridCliente.Rows.Count != 0)
            {
                TxtCuit.Value = Convert.ToInt64(GridCliente[1, GridCliente.CurrentRow.Index].Value.ToString());
                TxtRazonSocial.Text = GridCliente[2, GridCliente.CurrentRow.Index].Value.ToString();
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FunValidaciones() == false) {return;}

                int VarIdCliente = ConexionData.FunComboId("TabCliente", "IdCliente", "CUIT", TxtCuit.Text);
                int VarIdMarca = ConexionData.FunComboId("TabVehiculoMarca", "IdMarca", "Marca", CboMarca.Text);
                int VarIdModelo = ConexionData.FunComboId("TabVehiculoModelo", "IdModelo", "Modelo", CboModelo.Text);
                int VarIdTacoModelo = ConexionData.FunComboId("TabTacografoModelo", "TacoModelo", "TacoModeloDesc", CboTacoModelo.Text);

                int VarChkRecordatorio = 1;
                if (ChkRecordatorio.Checked == false)
                {
                    VarChkRecordatorio = 0;
                }

                if (VarGuardar == true)
                {
                    
                    string VarQuery = " INSERT INTO TabVehiculo " +
                                      " (IdCliente, IdMarca, IdModelo, Dominio, Operador, Categoria, " +
                                      " TacoMarca, TacoModelo, FactorK, TacoNroSerie, " +
                                      " Choferes, DiscoKm, DiscoDias,CodProducto,TipoDeUso, MarcaBaja," +
                                      " TelefonoConductor, NroMovil, Recordatorio, ImgFoto) " +
                                      " VALUES (" + VarIdCliente + "," + VarIdMarca + "," + VarIdModelo + ",'" + TxtDominio.Text +  "','" + TxtConductor.Text + "'," + CboCategoria.SelectedIndex +
                                      ",'" + TxtTacoMarca.Text + "'," + VarIdTacoModelo + "," + TxtFactorK.Value.ToString() + ",'" + TxtNSerie.Text +
                                      "'," + TxtChoferes.Value.ToString() + "," + TxtKmDisco.Value.ToString() + "," + TxtDiasDisco.Value.ToString() + "," + TxtCodProducto.Value.ToString() + "," + CboTipoDeUso.SelectedIndex +  
                                      ",0,'" + TxtConductorTel.Text + "','" + TxtNroMovil.Value.ToString() + "'," + VarChkRecordatorio +  ",'" + TxtDominio.Text  + ".jpeg')";

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
                    string VarQuery = " UPDATE TabVehiculo SET " +
                                      " IdMarca = " + VarIdMarca +
                                      ",IdModelo = " + VarIdModelo +
                                      ",Dominio ='" + TxtDominio.Text +
                                      "',Operador ='" + TxtConductor.Text  +
                                      "',TelefonoConductor ='" + TxtConductorTel.Text +
                                      "',Categoria = '" + CboCategoria.SelectedIndex +
                                      "',IdCliente = " + VarIdCliente +
                                      ",TacoMarca = '" + TxtTacoMarca.Text +
                                      "',TacoModelo =" + VarIdTacoModelo +
                                      ",FactorK = " + TxtFactorK.Text +
                                      ",TacoNroSerie = '" + TxtNSerie.Text +
                                      "',Choferes = " + TxtChoferes.Value.ToString() +
                                      ",DiscoKm = " + TxtKmDisco.Value.ToString() +
                                      ",DiscoDias = " + TxtDiasDisco.Value.ToString() +
                                      ",TipoDeUso = " + CboTipoDeUso.SelectedIndex +
                                      ",CodProducto = '"+TxtCodProducto.Value.ToString() +
                                      "',NroMovil = '" + TxtNroMovil.Value.ToString()  +
                                      "',Recordatorio = " + VarChkRecordatorio +
                                      ",ImgFoto = '" + TxtDominio.Text + ".jpeg'" +
                                      " WHERE IdVehiculo = " + TxtID.Text;

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
                FunBuscar();
                FunBuscar();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private bool FunValidaciones()
        {
            if (TxtCuit.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Cliente");
                TxtCuit.Focus();
                return false;
            }
            if (TxtDominio.Text == "" || TxtDominio.Text.Trim().Length < 6 || TxtDominio.Text.Trim().Length > 7)
            {
                 MessageBox.Show("Debe Ingresar la chapa patente valida");
                TxtDominio.Focus();
                return false;
            }
            if (TxtFactorK.Text == "0" || TxtFactorK.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar el Factor K");
                TxtFactorK.Focus();
                return false;
            }


            if (CboTacoModelo.SelectedItem.ToString() == "1390 MTCO" )
            {
                if (CboCategoria.SelectedIndex.ToString() is "2" or "3")
                {
                    if (TxtCodProducto.Text.Length > 5)
                    {
                        if (TxtCodProducto.Text.Substring(4, 2) != "04") //If Not Mid(TxtCodProducto.Text, 4, 2) = "04" Then
                        {
                            MessageBox.Show("Codigo de Producto No Valido para Categoria: M-2 o M-3");
                            TxtCodProducto.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe Ingresar un Codigo de Producto Valido");
                        TxtCodProducto.Focus();
                        return false;
                    }
                }
            }

            TxtConductor.Text = TxtConductor.Text.ToUpper();
            TxtTacoMarca.Text = TxtTacoMarca.Text.ToUpper();
            TxtDominio.Text = TxtDominio.Text.ToUpper();

            return true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TxtID.Text.Length == 0) { return; }
            if (MessageBox.Show("¿Esta Seguro que desea Eliminar el Registro?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) { return; }

            string VarQuery = " UPDATE TabVehiculo SET MarcaBaja = 1 WHERE IdVehiculo = " + TxtID.Text;

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
            this.Hide();
        }

        private void FunLimpiar()
        {
            //TxtID.Text = "";
            TxtCuit.Text = "";
            TxtRazonSocial.Text = "";
            CboMarca.Text = "";
            CboModelo.Text = "";
            TxtDominio.Text = "";
            TxtNroMovil.Text = "";
            TxtConductor.Text = "";
            CboCategoria.SelectedIndex = -1;
            TxtTacoMarca.Text = "";
            CboTacoModelo.SelectedIndex = - 1;
            TxtFactorK.Text = "";
            TxtNSerie.Text = "";
            TxtChoferes.Text = "";
            TxtKmDisco.Text = "";
            TxtDiasDisco.Text = "";
            CboTipoDeUso.SelectedIndex =-1;
            TxtCodProducto.Text = "";
            TxtConductorTel.Text = "";
            ChkRecordatorio.Checked = false;
 
            TxtCuit.Focus();
        }

        private void FunFalse()
        {
            TxtCuit.Enabled = false;
            TxtRazonSocial.Enabled = false;
            CboMarca.Enabled = false;
            CboModelo.Enabled = false;
            TxtDominio.Enabled = false;
            TxtNroMovil.Enabled = false;
            TxtConductor.Enabled = false;
            CboCategoria.Enabled = false;
            TxtTacoMarca.Enabled = false;
            CboTacoModelo.Enabled = false;
            TxtFactorK.Enabled = false;
            TxtNSerie.Enabled = false;
            TxtChoferes.Enabled = false;
            TxtKmDisco.Enabled = false;
            TxtDiasDisco.Enabled = false;
            CboTipoDeUso.Enabled = false;
            TxtCodProducto.Enabled = false;
            TxtConductorTel.Enabled = false;
            ChkRecordatorio.Enabled = false;

            BtnCalibrar.Enabled = false;
            BtnElimCalib.Enabled = false;
            BtnEnviarEMail.Enabled = false;
            BtnImprimirPDF.Enabled = false;
            BtnVisualizar.Enabled = false;
        }

        private void FunTrue()
        {
            TxtCuit.Enabled = true;
            TxtRazonSocial.Enabled = true;
            CboMarca.Enabled = true;
            CboModelo.Enabled = true;
            TxtDominio.Enabled = true;
            TxtNroMovil.Enabled = true;
            TxtConductor.Enabled = true;
            CboCategoria.Enabled = true;
            TxtTacoMarca.Enabled = true;
            CboTacoModelo.Enabled = true;
            TxtFactorK.Enabled = true;
            TxtNSerie.Enabled = true;
            TxtChoferes.Enabled = true;
            TxtKmDisco.Enabled = true;
            TxtDiasDisco.Enabled = true;
            CboTipoDeUso.Enabled = true;
            TxtCodProducto.Enabled = true;
            TxtConductorTel.Enabled = true;
            ChkRecordatorio.Enabled = true;

            BtnCalibrar.Enabled = true;
            BtnElimCalib.Enabled = true;
            BtnEnviarEMail.Enabled = true;
            BtnImprimirPDF.Enabled = true;
            BtnVisualizar.Enabled = true;
        }

        private void BtnElimCalib_Click(object sender, EventArgs e)
        {
            if (GridCalib.CurrentRow != null)
            {
                if (MessageBox.Show("¿Esta Seguro que desea Eliminar la Calibracion?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) { return; }

                string VarQuery = " UPDATE TabCalibraciones SET MarcaBaja = 1 WHERE IdOrdenServicio = " + GridCalib[7, GridCalib.CurrentRow.Index].Value.ToString();

                if (ConexionData.SQL_Comando(VarQuery) == true)
                {
                    MessageBox.Show("Calibracion Eliminada");
                    FunCargarGridCalib(TxtID.Text);
                }
                else
                {
                    MessageBox.Show("No se Pudo Eliminar el Registro");
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Calibracion");
            }
        }

        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridCalib.CurrentRow != null)
                {
                    string VarQuery = " SELECT TOS.*, TV.*, TC.*, TM1.*, TM2.*, T.* " +
                                      " FROM (((((TabVehiculo AS TV " +
                                      " LEFT JOIN TabCliente AS TC ON TC.IdCliente = TV.IdCliente)" +
                                      " LEFT JOIN TabVehiculoMarca AS TM1 ON TM1.IdMarca = TV.IdMarca)" +
                                      " LEFT JOIN TabVehiculoModelo AS TM2 ON TM2.IdModelo = TV.IdModelo)" +
                                      " LEFT JOIN TabCalibraciones AS TOS ON TOS.IdVehiculo = TV.IdVehiculo)" +
                                      " LEFT JOIN TabTacografoModelo AS T ON T.TacoModelo = TV.TacoModelo)" +
                                      " WHERE TOS.MarcaBaja = 0 " +
                                      " AND TOS.IdOrdenServicio = " + GridCalib[8, GridCalib.CurrentRow.Index].Value.ToString() + "";
                    
                    DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
                    if (VarData.Rows.Count != 0)
                    {
                        //MessageBox.Show(VarData.Rows[0].ItemArray[0].ToString());

                        Negocios.FunLoad_FrmCalibracion();
                        Negocios.aFrmCalibracion.MdiParent = this.MdiParent;

                        //LIMPIAR LOS CAMPOS DEL FORMULARIO FRMCALIBRACIONES.-
                        FunLImpiarFrmCalibraciones();
                        
                        //ASIGNAR LOS DATOS A OTRO FORMULARIO

                        Negocios.aFrmCalibracion.TxtIdCalibracion.Text = VarData.Rows[0]["IdOrdenServicio"].ToString();
                        Negocios.aFrmCalibracion.TxtAltaK.Text = VarData.Rows[0]["KAlta"].ToString();
                        Negocios.aFrmCalibracion.TxtBajaK.Text = VarData.Rows[0]["KBaja"].ToString();
                        Negocios.aFrmCalibracion.TxtRelacionK.Text = VarData.Rows[0]["RelacionKAltaBaja"].ToString();
                        Negocios.aFrmCalibracion.TxtAltaW.Text = VarData.Rows[0]["WAlta"].ToString();
                        Negocios.aFrmCalibracion.TxtBajaW.Text = VarData.Rows[0]["WBaja"].ToString();
                        Negocios.aFrmCalibracion.TxtRelacionW.Text = VarData.Rows[0]["RelacionWAltaBaja"].ToString();
                        Negocios.aFrmCalibracion.TxtUltConstanteK.Text = VarData.Rows[0]["MedicionK"].ToString();
                        Negocios.aFrmCalibracion.TxtUltConstanteW.Text = VarData.Rows[0]["MedicionW"].ToString();
                        Negocios.aFrmCalibracion.TxtUltDiametroW.Text = VarData.Rows[0]["DiametroRodado"].ToString(); 
                        Negocios.aFrmCalibracion.TxtValorAngular.Text  = VarData.Rows[0]["PulsoEquivaleA"].ToString(); 
                        Negocios.aFrmCalibracion.TxtVelocidadReal.Text  = VarData.Rows[0]["VelocidadReal"].ToString(); 
                        Negocios.aFrmCalibracion.TxtVelocidadAparente.Text  = VarData.Rows[0]["VelocidadAparente"].ToString();
                        Negocios.aFrmCalibracion.TxtReluctor.Text  = VarData.Rows[0]["Reluctor"].ToString(); 
                        Negocios.aFrmCalibracion.TxtGearRatio.Text  = VarData.Rows[0]["GearRatio"].ToString(); 
                        Negocios.aFrmCalibracion.TxtErrorRelacionKW.Text  = VarData.Rows[0]["RelacionKW"].ToString(); 
                        Negocios.aFrmCalibracion.TxtPulsosPorVueltaRueda.Text  = VarData.Rows[0]["PulsosXVtaRueda"].ToString();
                        Negocios.aFrmCalibracion.TxtDistanciaDePrueba.Text  = VarData.Rows[0]["DistanciaPrueba"].ToString(); 
                        Negocios.aFrmCalibracion.TxtErrorWK.Text  = VarData.Rows[0]["ErrorKW"].ToString(); 
                        Negocios.aFrmCalibracion.TxtPisadaDinamica.Text  = VarData.Rows[0]["PisadaDinamica"].ToString(); 
                        Negocios.aFrmCalibracion.TxtDiametroRodadoUltCalibracion.Text  = VarData.Rows[0]["DiametroAconsejado"].ToString(); 
                        Negocios.aFrmCalibracion.TxtCmPorPulso.Text  = VarData.Rows[0]["MetrosPorPulso"].ToString(); 
                        Negocios.aFrmCalibracion.TxtPulsosDeLaPrueba.Text  = VarData.Rows[0]["PulsosDeLaPrueba"].ToString(); 
                        Negocios.aFrmCalibracion.TxtLimitacionKm.Text  = VarData.Rows[0]["VelocidadDeLimitacion"].ToString(); 
                        Negocios.aFrmCalibracion.TxtObservaciones.Text  = VarData.Rows[0]["Observaciones"].ToString();
                        Negocios.aFrmCalibracion.FchHoraCertificacion.CustomFormat = "dd/mm/yyyy hh:MM:ss";
                        Negocios.aFrmCalibracion.FchHoraCertificacion.Format = DateTimePickerFormat.Custom;
                        Negocios.aFrmCalibracion.FchHoraCertificacion.Text = VarData.Rows[0]["FechaHoraOS"].ToString();
                        Negocios.aFrmCalibracion.TxtDominio.Text = VarData.Rows[0]["Dominio"].ToString();
                        Negocios.aFrmCalibracion.TxtCliente.Text = VarData.Rows[0]["Cuit"].ToString() + ' ' + VarData.Rows[0]["RazonSocial"].ToString();
                        Negocios.aFrmCalibracion.TxtDatosDominio.Text = VarData.Rows[0]["Marca"].ToString() + ' ' + VarData.Rows[0]["Modelo"].ToString();
                        Negocios.aFrmCalibracion.TxtTacografo.Text = VarData.Rows[0]["TacoMarca"].ToString() + ' ' + VarData.Rows[0]["TacoModeloDesc"].ToString() + ' ' + VarData.Rows[0]["TacoNroSerie"].ToString();
                        Negocios.aFrmCalibracion.TiempoCalibracion.Text = VarData.Rows[0]["TiempoDCalibracion"].ToString();
                        Negocios.aFrmCalibracion.TxtDifKeKs.Text = VarData.Rows[0]["DifKeKs"].ToString();

                        string VarPath = Application.StartupPath.ToString() + "Fotos\\ImagenNeutra.jpg";
                        Negocios.aFrmCalibracion.PicFoto.Image = Image.FromFile(VarPath);
                        if (VarData.Rows[0]["ImgFoto"].ToString() != "")
                        {
                            VarPath = Application.StartupPath.ToString() + "Fotos\\" + VarData.Rows[0]["ImgFoto"].ToString();
                            if (File.Exists(VarPath) == true)
                            {
                                Negocios.aFrmCalibracion.PicFoto.Image = Image.FromFile(VarPath);
                            }
                        }

                        if (VarData.Rows[0]["IdRespCalib"].ToString() != "")
                        {
                            Negocios.aFrmCalibracion.CboResponsable.Text = ConexionData.FunComboDesc("RazonSocial", "TabRespCalib", "IdRespCalib", VarData.Rows[0]["IdRespCalib"].ToString());
                        }

                        if (VarData.Rows[0]["DifKeKs"].ToString() != "" && VarData.Rows[0]["VelocidadReal"].ToString() != "")
                        {
                            //Sin Eerror
                            Negocios.aFrmCalibracion.TxtDifKeKs.ForeColor = Color.Blue;
                            if ((Convert.ToDecimal(Negocios.aFrmCalibracion.TxtDifKeKs.Text) - Convert.ToDecimal(Negocios.aFrmCalibracion.TxtVelocidadReal.Text)) > 1)
                            {
                                //Con Error
                                Negocios.aFrmCalibracion.TxtDifKeKs.ForeColor = Color.Red;
                            }
                            if ((Convert.ToDecimal(Negocios.aFrmCalibracion.TxtDifKeKs.Text) - Convert.ToDecimal(Negocios.aFrmCalibracion.TxtVelocidadReal.Text)) < -1)
                            {
                                //Con Error
                                Negocios.aFrmCalibracion.TxtDifKeKs.ForeColor = Color.Red;
                            }
                        }

                        this.Hide();
                     }
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar Una Calibracion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ": " + ex.Message);
            }
        }

        private static void FunLImpiarFrmCalibraciones()
        {
            Negocios.aFrmCalibracion.TxtAltaK.Text = "0000";
            Negocios.aFrmCalibracion.TxtAltaW.Text = "0000";
            Negocios.aFrmCalibracion.TxtBajaK.Text = "0000";
            Negocios.aFrmCalibracion.TxtBajaW.Text = "0000";
            Negocios.aFrmCalibracion.TxtDiametroRodadoUltCalibracion.Text = "0000";
            Negocios.aFrmCalibracion.TxtDistanciaDePrueba.Text = "0000";
            Negocios.aFrmCalibracion.TxtErrorRelacionKW.Text = "0000";
            Negocios.aFrmCalibracion.TxtErrorWK.Text = "0000";
            Negocios.aFrmCalibracion.TxtPisadaDinamica.Text = "0000";
            Negocios.aFrmCalibracion.TxtPulsosPorVueltaRueda.Text = "0000";
            Negocios.aFrmCalibracion.TxtRelacionK.Text = "0000";
            Negocios.aFrmCalibracion.TxtRelacionW.Text = "0000";
            Negocios.aFrmCalibracion.TxtUltConstanteK.Text = "0000";
            Negocios.aFrmCalibracion.TxtUltConstanteW.Text = "0000";
            Negocios.aFrmCalibracion.TxtUltDiametroW.Text = "0000";
            Negocios.aFrmCalibracion.TxtValorAngular.Text = "0000";
            Negocios.aFrmCalibracion.TxtVelocidadReal.Text = "0000";
            Negocios.aFrmCalibracion.TxtVelocidadAparente.Text = "80";
            Negocios.aFrmCalibracion.TxtCmPorPulso.Text = "0000";
            Negocios.aFrmCalibracion.TiempoCalibracion.Text = "00:00:00";
            Negocios.aFrmCalibracion.TiempoInicio.CustomFormat = "HH:MM:ss";
            Negocios.aFrmCalibracion.TiempoInicio.Format = DateTimePickerFormat.Custom;
            Negocios.aFrmCalibracion.FchHoraCertificacion.CustomFormat = "dd/mm/yyyy HH:MM:ss";
            Negocios.aFrmCalibracion.FchHoraCertificacion.Format = DateTimePickerFormat.Custom;
            Negocios.aFrmCalibracion.TxtPulsosDeLaPrueba.Text = "0000";
            Negocios.aFrmCalibracion.TxtLimitacionKm.Text = "0000";
            Negocios.aFrmCalibracion.TxtReluctor.Text = "0.00";
            Negocios.aFrmCalibracion.TxtGearRatio.Text = "0.00";
            Negocios.aFrmCalibracion.CboResponsable.SelectedItem = 0;
            Negocios.aFrmCalibracion.TxtObservaciones.Text = "";
            Negocios.aFrmCalibracion.TxtDominio.Text = "";
            Negocios.aFrmCalibracion.TxtDatosDominio.Text = "";
            Negocios.aFrmCalibracion.TxtCliente.Text = "";
            Negocios.aFrmCalibracion.TxtTacografo.Text = "";
            Negocios.aFrmCalibracion.TxtDifKeKs.Text = "0000";
        }

        private void BtnImprimirPDF_Click(object sender, EventArgs e)
        {
            //VarFile = Sis.oNeg.oRep.FunReporteCalibracion("PDF", True, GridCalibraciones.TextMatrix(GridCalibraciones.Row, 8))

            //string VarPath = Application.StartupPath.ToString() + "Fotos\\ReportePDF.pdf";
            //if (File.Exists(VarPath) == true)
            //{
            //    DDActiveReports2.ActiveReport VarReportePDF = new();
            //    ActiveReportsPDFExport.ARExportPDF oPDF = new();

            //    VarReportePDF.Run();
            //    oPDF.FileName = VarPath;
            //    oPDF.Export (VarReportePDF.Pages);
            //}
        }

        private void BtnEnviarEMail_Click(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmEnviarEmail();
            Negocios.aFrmEnviarEmail.MdiParent = this.MdiParent;

            // ACA VA EL CODIGO QUE GENERA EL ARCHIVO ADJUNTO PDF
            string VarPath = Application.StartupPath.ToString() + "Fotos\\ReportePDF.pdf";
            // ACA VA EL CODIGO QUE GENERA EL ARCHIVO ADJUNTO PDF

            if (File.Exists(VarPath))
            {
                Negocios.aFrmEnviarEmail.TxtAdjunto.Text = VarPath;
            }
        }

        private void BtnCalibrar_Click(object sender, EventArgs e)
        {
            string VarQuery = " SELECT TV.IdVehiculo, TV.IdCliente, TC.Cuit, TC.RazonSocial, TM1.Marca, " +
                              "        TM2.Modelo, TV.Dominio, TV.TacoMarca, TV.TacoModelo, TV.FactorK, " +
                              "        TV.TacoNroSerie, TV.Recordatorio, T.TacoModeloDesc " +
                              " FROM ((((TabVehiculo AS TV " +
                              " LEFT JOIN TabCliente AS TC ON TC.IdCliente = TV.IdCliente)" +
                              " LEFT JOIN TabVehiculoMarca AS TM1 ON TM1.IdMarca = TV.IdMarca)" +
                              " LEFT JOIN TabVehiculoModelo AS TM2 ON TM2.IdModelo = TV.IdModelo)" +
                              " LEFT JOIN TabTacografoModelo AS T ON T.TacoModelo = TV.TacoModelo)" +
                              " WHERE TV.MarcaBaja = 0 " +
                              " AND TV.IdVehiculo = " + TxtID.Text;

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            if (VarData.Rows.Count != 0)
            {
                //MessageBox.Show(VarData.Rows[0].ItemArray[0].ToString());

                Negocios.FunLoad_FrmCalibracion();
                Negocios.aFrmCalibracion.MdiParent = this.MdiParent;

                //LIMPIAR LOS CAMPOS DEL FORMULARIO FRMCALIBRACIONES.-

                FunLImpiarFrmCalibraciones();

                Negocios.aFrmCalibracion.TxtCliente.Text = VarData.Rows[0]["Cuit"].ToString() + ' ' + VarData.Rows[0]["RazonSocial"].ToString();
                Negocios.aFrmCalibracion.TxtDatosDominio.Text = VarData.Rows[0]["Marca"].ToString() + ' ' + VarData.Rows[0]["Modelo"].ToString();
                Negocios.aFrmCalibracion.TxtDominio.Text = VarData.Rows[0]["Dominio"].ToString();
                Negocios.aFrmCalibracion.TxtTacografo.Text = VarData.Rows[0]["TacoMarca"].ToString() + ' ' + VarData.Rows[0]["TacoModeloDesc"].ToString() + ' ' + VarData.Rows[0]["TacoNroSerie"].ToString();

                this.Hide();
            }
        }

        private void GridCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
