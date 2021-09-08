using System;
using System.Windows.Forms;
using System.Data;


namespace SADI_Desktop_v1
{
    
    public partial class FrmProvincia : Form
    {
        public Boolean VarGuardar = false;

        public FrmProvincia()
        {
           InitializeComponent();
        }
        

        private void FrmProvincia_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunBuscar();
            FunCargoCombo();
        }

        private void FunBuscar()
        {
            try
            {
                
                string VarQuery = " SELECT A.IdPais as Id, A.IdProvincia , B.Descripcion as Pais, A.Descripcion as Provincia" +
                                  " FROM TabProvincia as A " +
                                  " INNER JOIN TabPais as B ON A.IdPais = B.IdPais " +
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
            string VarQuery = " SELECT IdPais, Descripcion as Pais" +
                              " FROM TabPais  " +
                              " WHERE MarcaBaja = 0 " +
                              " ORDER BY Descripcion";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboPais.Items.Clear();
            CboPais.Items.Add("");
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboPais.Items.Add(VarData.Rows[i]["Pais"]);
            }

        }
        private void FunLimpiar()
        {
            TxtID.Text = "";
            CboPais.Text = "";
            TxtProvincia.Text = "";
            TxtProvincia.Focus();
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
            TxtProvincia.Text = TxtProvincia.Text.ToUpper();

            if (CboPais.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Marca del Vehiculo");
                CboPais.Focus();
                return false;
            }

            if (TxtProvincia.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Modelo del Vehiculo");
                TxtProvincia.Focus();
                return false;
            }

            

            //if (TxtEmail.Text == null)
            //{
            //    MessageBox.Show("Debe Ingresar el Email");
            //    return false;
            //}

            return true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (FunValidaciones() == false) { return; }

                int CboPaisId = ConexionData.FunComboId("TabPais", "IdPais", "Descripcion", CboPais.Text);

                if (VarGuardar == true)
                {
                    string VarQuery = " INSERT INTO TabProvincia (IdPais, Descripcion, MarcaBaja)" + 
                                      " VALUES("  + CboPaisId +  ",'" + TxtProvincia.Text + "',0)";

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("IdProvincia", "TabProvincia");
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
                    string VarQuery = " UPDATE TabProvincia SET " +
                                      " IdPais = " + CboPaisId + "" +
                                      ",Descripcion = '" + TxtProvincia.Text + "'" +
                                      ",MarcaBaja = 0 " +
                                      " WHERE IdProvincia = " + TxtID.Text;

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
            string VarQuery = " UPDATE TabProvincia SET MarcaBaja = 1 WHERE IdProvincia = " + TxtID.Text;

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
            Negocios.aFrmLocalidad.CboProvincia.Text = TxtProvincia.Text;
            this.Hide();
        }

        private void FunFalse()
        {
            CboPais.Enabled = false;
            TxtProvincia.Enabled = false;
            BtnPais.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void FunTrue()
        {
            CboPais.Enabled = true;
            TxtProvincia.Enabled = true;
            BtnPais.Enabled = true;
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
                    CboPais.Text = GridRespCalib[2, GridRespCalib.CurrentRow.Index].Value.ToString();
                    TxtProvincia.Text = GridRespCalib[3, GridRespCalib.CurrentRow.Index].Value.ToString();
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
            Negocios.FunLoad_FrmPais();
            Negocios.aFrmPais.MdiParent = this.MdiParent;

        }
    }
}
