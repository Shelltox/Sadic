using System;
using System.Windows.Forms;
using System.Data;


namespace SADI_Desktop_v1
{
    
    public partial class FrmLocalidad : Form
    {
        public Boolean VarGuardar = false;

        public FrmLocalidad()
        {
           InitializeComponent();
        }
        

        private void FrmLocalidad_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunBuscar();
            FunCargoCombo();
        }

        private void FunBuscar()
        {
            try
            {
                
                string VarQuery = " SELECT A.IdProvincia as Id, A.IdLocalidad , B.Descripcion as Provincia, A.Descripcion as Localidad" +
                                  " FROM TabLocalidad as A " +
                                  " INNER JOIN TabProvincia as B ON A.IdProvincia = B.IdProvincia " +
                                  " WHERE A.Descripcion LIKE '%" + TxtBuscar.Text + "%'" +
                                  " AND A.MarcaBaja = 0";

                DataSet VarData = ConexionData.SQL_Select(VarQuery);
                
                GridRespCalib.DataSource = VarData.Tables[0];
                GridRespCalib.ReadOnly = true;
                GridRespCalib.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridRespCalib.MultiSelect = false;

                GridRespCalib.Columns[0].Width = 50;
                GridRespCalib.Columns[1].Visible = false;
                GridRespCalib.Columns[2].Width = 230;
                GridRespCalib.Columns[3].Width = 230;

                //for (int i = 0; i <= VarData.Tables[0].Rows.Count - 1; i++)
                //{
                //    System.Windows.Forms.MessageBox.Show(VarData.Tables[0].Rows[i].ItemArray[0] + " -- " + VarData.Tables[0].Rows[i].ItemArray[1]);
                //}
                if (VarData.Tables[0].Rows[0].ItemArray[0].ToString() != "") {FunTrue();}
            }
            catch (Exception ex)
            {
                if (ex.Message =="There is no row at position 0.")
                {
                    FunFalse();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(ex.Source + ": " + ex.Message);
                }
                
            }
        }

        public void FunCargoCombo()
        {
            string VarQuery = " SELECT IdProvincia, Descripcion as Provincia" +
                              " FROM TabProvincia  " +
                              " WHERE MarcaBaja = 0 " +
                              " ORDER BY Descripcion";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboProvincia.Items.Clear();
            CboProvincia.Items.Add("");
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboProvincia.Items.Add(VarData.Rows[i]["Provincia"]);
            }

        }
        private void FunLimpiar()
        {
            TxtID.Text = "";
            CboProvincia.Text = "";
            TxtLocalidad.Text = "";
            TxtLocalidad.Focus();
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FunBuscar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FunTrue();
            FunLimpiar();
            BtnEliminar.Enabled = false;
            VarGuardar = true;
        }

        private bool FunValidaciones()
        {
            TxtLocalidad.Text = TxtLocalidad.Text.ToUpper();

            if (CboProvincia.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Marca del Vehiculo");
                CboProvincia.Focus();
                return false;
            }

            if (TxtLocalidad.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Modelo del Vehiculo");
                TxtLocalidad.Focus();
                return false;
            }


            return true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (FunValidaciones() == false) { return; }

                int CboProvinciaId = ConexionData.FunComboId("TabProvincia", "IdProvincia", "Descripcion", CboProvincia.Text);

                if (VarGuardar == true)
                {
                    string VarQuery = " INSERT INTO TabLocalidad (IdProvincia, Descripcion, MarcaBaja)" + 
                                      " VALUES("  + CboProvinciaId +  ",'" + TxtLocalidad.Text + "',0)";
                    
                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("IdLocalidad", "TabLocalidad");
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
                    string VarQuery = " UPDATE TabLocalidad SET " +
                                      " IdProvincia = " + CboProvinciaId + "" +
                                      ",Descripcion = '" + TxtLocalidad.Text + "'" +
                                      ",MarcaBaja = 0 " +
                                      " WHERE IdLocalidad = " + TxtID.Text;

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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TxtID.Text.Length == 0) { return; }
            if (MessageBox.Show("¿Esta Seguro que desea Eliminar el Registro?", "Eliminar", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.No) { return; }

            //string VarQuery = " DELETE FROM TabPais WHERE IdPais = " + TxtID.Text;
            string VarQuery = " UPDATE TabLocalidad SET MarcaBaja = 1 WHERE IdLocalidad = " + TxtID.Text;

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
            Negocios.aFrmLocalidad.FunCargoCombo();
            Negocios.aFrmLocalidad.CboProvincia.Text = TxtLocalidad.Text;

            Negocios.aFrmEmpresa.FunCargoCombo();
            Negocios.aFrmEmpresa.CboLocalidad.Text = TxtLocalidad.Text;

            Negocios.aFrmCliente.FunCargoCombo();
            Negocios.aFrmCliente.CboLocalidad.Text = TxtLocalidad.Text;

            this.Hide();
        }
        private void FunFalse()
        {
            CboProvincia.Enabled = false;
            TxtLocalidad.Enabled = false;
            BtnProvincia.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void FunTrue()
        {
            CboProvincia.Enabled = true;
            TxtLocalidad.Enabled = true;
            BtnProvincia.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnGuardar.Enabled = true;
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
                if (GridRespCalib.CurrentRow != null)
                {
                    FunTrue();
                    
                    TxtID.Text = GridRespCalib[0, GridRespCalib.CurrentRow.Index].Value.ToString();
                    //CboMarcaId = GridRespCalib[1, GridRespCalib.CurrentRow.Index].Value.ToString();
                    CboProvincia.Text = GridRespCalib[2, GridRespCalib.CurrentRow.Index].Value.ToString();
                    TxtLocalidad.Text = GridRespCalib[3, GridRespCalib.CurrentRow.Index].Value.ToString();
                }
                else
                {
                    FunFalse();
                    VarGuardar = true;
                }
            }
        }

        private void GridRespCalib_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void BtnMarca_Click(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmProvincia();
            Negocios.aFrmProvincia.MdiParent = this.MdiParent;
        }
    }
}
