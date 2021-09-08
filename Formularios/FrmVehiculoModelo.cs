using System;
using System.Windows.Forms;
using System.Data;


namespace SADI_Desktop_v1
{
    
    public partial class FrmVehiculoModelo : Form
    {
        public Boolean VarGuardar = false;

        public FrmVehiculoModelo()
        {
           InitializeComponent();
        }
        

        private void FrmVehiculoModelo_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunBuscar();
            FunCargoCombo();
        }

        private void FunBuscar()
        {
            try
            {
                
                string VarQuery = " SELECT A.IdModelo as Id, A.IdMarca , B.Marca, A.Modelo" +
                                  " FROM TabVehiculoModelo as A " +
                                  " INNER JOIN TabVehiculoMarca as B ON A.IdMarca = B.IdMarca " +
                                  " WHERE A.Modelo LIKE '%" + TxtBuscar.Text + "%'" +
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
        private void FunLimpiar()
        {
            TxtID.Text = "";
            CboMarca.Text = "";
            TxtModelo.Text = "";
            TxtModelo.Focus();
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
            TxtModelo.Text = TxtModelo.Text.ToUpper();

            if (CboMarca.Text == "")
            {
                MessageBox.Show("Debe Ingresar la Marca del Vehiculo");
                CboMarca.Focus();
                return false;
            }

            if (TxtModelo.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Modelo del Vehiculo");
                TxtModelo.Focus();
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

                int CboMarcaId = ConexionData.FunComboId("TabVehiculoMarca", "IdMarca", "Marca", CboMarca.Text);

                if (VarGuardar == true)
                {
                    string VarQuery = " INSERT INTO TabVehiculoModelo (IdMarca, Modelo, MarcaBaja)" + 
                                      " VALUES("  + CboMarcaId +  ",'" + TxtModelo.Text + "',0)";
                    
                    MessageBox.Show(VarQuery);

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("IdModelo", "TabVehiculoModelo");
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
                    string VarQuery = " UPDATE TabVehiculoModelo SET " +
                                      " IdMarca = " + CboMarcaId + "" +
                                      ",Modelo = '" + TxtModelo.Text + "'" +
                                      ",MarcaBaja = 0 " +
                                      " WHERE IdMarca = " + TxtID.Text;

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
            string VarQuery = " UPDATE TabVehiculoModelo SET MarcaBaja = 1 WHERE IdModelo = " + TxtID.Text;

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
            //this.Close();
            this.Hide();
        }

        private void FunFalse()
        {
            CboMarca.Enabled = false;
            TxtModelo.Enabled = false;
            BtnMarca.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void FunTrue()
        {
            CboMarca.Enabled = true;
            TxtModelo.Enabled = true;
            BtnMarca.Enabled = true;
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
                    CboMarca.Text = GridRespCalib[2, GridRespCalib.CurrentRow.Index].Value.ToString();
                    TxtModelo.Text = GridRespCalib[3, GridRespCalib.CurrentRow.Index].Value.ToString();
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
            Negocios.FunLoad_FrmVehiculoMarca();
            Negocios.aFrmVehiculoMarca.MdiParent = this.MdiParent;
        }
    }
}
