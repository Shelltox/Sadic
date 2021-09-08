using System;
using System.Windows.Forms;
using System.Data;


namespace SADI_Desktop_v1
{
    
    public partial class FrmVehiculoMarca : Form
    {
        public Boolean VarGuardar = false;

        public FrmVehiculoMarca()
        {
           InitializeComponent();
           
        }

        private void FrmVehiculoMarca_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunBuscar();
        }

        private void FunBuscar()
        {
            try
            {
                
                string VarQuery = " SELECT IdMarca as Id, Marca" +
                                  " FROM TabVehiculoMarca " +
                                  " WHERE Marca LIKE '%" + TxtBuscar.Text + "%'" +
                                  " AND MarcaBaja = 0";

                DataSet VarData = ConexionData.SQL_Select(VarQuery);
                

                GridRespCalib.DataSource = VarData.Tables[0];
                GridRespCalib.ReadOnly = true;
                GridRespCalib.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridRespCalib.MultiSelect = false;

                GridRespCalib.Columns[0].Width = 50;
                GridRespCalib.Columns[1].Width = 230;

                //for (int i = 0; i <= VarData.Tables[0].Rows.Count - 1; i++)
                //{
                //    System.Windows.Forms.MessageBox.Show(VarData.Tables[0].Rows[i].ItemArray[0] + " -- " + VarData.Tables[0].Rows[i].ItemArray[1]);
                //}
                if (VarData.Tables[0].Rows[0].ItemArray[0].ToString() != "") { FunTrue(); }
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

        private void FunLimpiar()
        {
            TxtID.Text = "";
            TxtMarca.Text = "";
            TxtMarca.Focus();
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
            TxtMarca.Text = TxtMarca.Text.ToUpper();

            if (TxtMarca.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Pais");
                TxtMarca.Focus();
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

                if (VarGuardar == true)
                {
                    string VarQuery = " INSERT INTO TabVehiculoMarca (Marca,MarcaBaja)" + 
                                      " VALUES('" + TxtMarca.Text + "',0)";

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("IdMarca", "TabVehiculoMarca");
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
                    string VarQuery = " UPDATE TabVehiculoMarca SET " +
                                      " Marca = '" + TxtMarca.Text + "'" +
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
            string VarQuery = " UPDATE TabVehiculoMarca SET MarcaBaja = 1 WHERE IdMarca = " + TxtID.Text;

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
            //Ejecutar FunCargoCombo(); en FrmVehiculoModelo
            Negocios.aFrmVehiculoModelo.FunCargoCombo();
            Negocios.aFrmVehiculoModelo.CboMarca.Text = TxtMarca.Text;
            this.Hide();
        }

        private void FunFalse()
        {
            TxtMarca.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void FunTrue()
        {
            TxtMarca.Enabled = true;
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
                    TxtMarca.Text = GridRespCalib[1, GridRespCalib.CurrentRow.Index].Value.ToString();
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
    }
}
