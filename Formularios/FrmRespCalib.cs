using System;
using System.Windows.Forms;
using System.Data;


namespace SADI_Desktop_v1
{
    
    public partial class FrmRespCalib : Form
    {
        public Boolean VarGuardar = false;

        public FrmRespCalib()
        {
           InitializeComponent();
           
        }

        private void FrmRespCalib_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunBuscar();
        }

        private void FunBuscar()
        {
            try
            {
                
                string VarQuery = " SELECT IdRespCalib as Id, RazonSocial as [Apellido y Nombre], Email" +
                                  " FROM TabRespCalib " +
                                  " WHERE RazonSocial LIKE '%" + TxtBuscar.Text + "%'" +
                                  " AND MarcaBaja = 0";

                DataSet VarData = ConexionData.SQL_Select(VarQuery);
                

                GridRespCalib.DataSource = VarData.Tables[0];
                GridRespCalib.ReadOnly = true;
                GridRespCalib.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridRespCalib.MultiSelect = false;

                GridRespCalib.Columns[0].Width = 50;
                GridRespCalib.Columns[1].Width = 230;
                GridRespCalib.Columns[2].Visible = false;

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
            TxtApellNom.Text = "";
            TxtEmail.Text = "";
            TxtApellNom.Focus();
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
            TxtApellNom.Text = TxtApellNom.Text.ToUpper();
            TxtEmail.Text = TxtEmail.Text.ToUpper();

            if (TxtApellNom.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Apellido y Nombre");
                TxtApellNom.Focus();
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
                    string VarQuery = " INSERT INTO TabRespCalib (RazonSocial,Email,MarcaBaja)" + 
                                      " VALUES('" + TxtApellNom.Text + "','" + TxtEmail.Text + "',0)";

                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        TxtID.Text = ConexionData.FunUltimoId("IdRespCalib", "TabRespCalib");
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
                    string VarQuery = " UPDATE TabRespCalib SET " +
                                      " RazonSocial = '" + TxtApellNom.Text + "'" +
                                      ",Email = '" + TxtEmail.Text + "'" +
                                      ",MarcaBaja = 0 " +
                                      " WHERE IdRespCalib = " + TxtID.Text;

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

            //string VarQuery = " DELETE FROM TabRespCalib WHERE IdRespCalib = " + TxtID.Text;
            string VarQuery = " UPDATE TabRespCalib SET MarcaBaja = 1 WHERE IdRespCalib = " + TxtID.Text;

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
            TxtApellNom.Enabled = false;
            TxtEmail.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void FunTrue()
        {
            TxtApellNom.Enabled = true;
            TxtEmail.Enabled = true;
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
                    TxtApellNom.Text = GridRespCalib[1, GridRespCalib.CurrentRow.Index].Value.ToString();
                    TxtEmail.Text = GridRespCalib[2, GridRespCalib.CurrentRow.Index].Value.ToString();
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
