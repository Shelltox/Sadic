using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SADI_Desktop_v1
{
    public partial class FrmCalibraciones : Form
    {
        public Boolean VarGuardar = false;
        int VarIdVehiculo = 0;
        int VarIdCliente = 0;
        int VarFactorK = 0;
        int VarCategoria = 0;
        DateTime VarFechaUltCalibracion;

        public FrmCalibraciones()
        {
            InitializeComponent();
            TxtUltConstanteK.BackColor = Color.White;
            TxtUltConstanteW.BackColor = Color.GreenYellow;
            TxtUltDiametroW.BackColor = Color.GreenYellow;
            OpTipoTacografo2.Checked = true;
            OpRelGear2.Checked = true;
            FrameVehiculo.Visible = false;
        }

        private void FrmCalibracionesLoad(object sender, EventArgs e)
        {
            this.CenterToParent();
            FunBuscarLogo();
            FunCargoComboResponsable();
            FunCargoComboPuertos();
        }

        private void FunBuscarLogo()
        {
            try
            {
                string VarQuery = " SELECT TOP 1 A.Id, A.LogoTipo" +
                                  " FROM TabEmpresa as A " +
                                  " WHERE A.MarcaBaja = 0";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
                if (VarData.Rows.Count.ToString() != "0")
                {
                    if (VarData.Rows[0]["LogoTipo"].ToString() != "0")
                    {
                        PicLogo.Image = Image.FromFile(VarData.Rows[0]["LogoTipo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FunCargoComboResponsable()
        {
            string VarQuery = " SELECT IdRespCalib, RazonSocial" +
                              " FROM TabRespCalib  " +
                              " WHERE MarcaBaja = 0 " +
                              " ORDER BY RazonSocial";

            DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);
            CboResponsable.Items.Clear();
            CboResponsable.Items.Add("");
            for (int i = 0; i < VarData.Rows.Count; i++)
            {
                CboResponsable.Items.Add(VarData.Rows[i]["RazonSocial"]);
            }
        }

        public void FunCargoComboPuertos()
        {
            // En el Path del Proyecto tuve que ejecutar en linea de comandos la siguiente sentencia:
            // dotnet add package system.io.ports

            string[] ports = SerialPort.GetPortNames();
            CboPuerto.Items.Clear();
            CboPuerto.Items.Add("");
            foreach (string port in ports)
            {
                CboPuerto.Items.Add(port);
            }
        }

        private void BtnTomarFotoClick(object sender, EventArgs e)
        {
            if (TxtDominio.TextLength == 0)
            {
                MessageBox.Show("No Olvide Seleccionar el Vehiculo con F2");
                TxtDominio.Focus();
            }
            else
            {
                Negocios.FunLoad_FrmFoto();
                Negocios.aFrmFoto.MdiParent = this.MdiParent;
            }

        }

        private void OpTipoTacografo1CheckedChanged(object sender, EventArgs e)
        {
            TxtUltConstanteK.ReadOnly = false;
            TxtUltConstanteK.BackColor = Color.GreenYellow;
            TxtUltConstanteW.Text = "";
        }

        private void OpTipoTacografo2CheckedChanged(object sender, EventArgs e)
        {
            TxtUltConstanteK.ReadOnly = true;
            TxtUltConstanteK.BackColor = Color.White;
            TxtUltConstanteK.Text = "0000";
            TxtUltConstanteW.Text = "0000";
            TxtUltDiametroW.Text = "0000";
        }

        private void FrmCalibracionesKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "113") //F2
            {
                TxtBuscarVehiculo.Text = "";
                FunBuscarVehiculo();
                TxtBuscarVehiculo.Focus();

                FrameVehiculo.Visible = true;
            }
        }
        private void BtnNuevoVehiculoClick(object sender, EventArgs e)
        {
            Negocios.FunLoad_FrmVehiculo();
            Negocios.aFrmVehiculo.MdiParent = this.MdiParent;
        }
        private void BtnCerrarBusquedaClick(object sender, EventArgs e)
        {
            FrameVehiculo.Visible = false;
        }
        private void TxtBuscarVehiculoKeyUp(object sender, KeyEventArgs e)
        {
            FunBuscarVehiculo();
        }
        private void FunBuscarVehiculo()
        {
            try
            {
                string VarQuery = " SELECT TV.IdVehiculo, TV.IdCliente, TC.Cuit, TC.RazonSocial, TM1.Marca, TM2.Modelo, TV.Dominio, TV.TacoMarca, T.TacoModeloDesc," +
                                  " TV.FactorK, TV.TacoNroSerie, TV.NroMovil, TV.ImgFoto, TV.Categoria" +
                                  " FROM ((((TabVehiculo AS TV " +
                                  " LEFT JOIN TabCliente AS TC ON TC.IdCliente = TV.IdCliente) " +
                                  " LEFT JOIN TabVehiculoModelo AS TM2 ON TM2.IdModelo = TV.IdModelo) " +
                                  " LEFT JOIN TabVehiculoMarca AS TM1 ON TM1.IdMarca = TM2.IdMarca) " +
                                  " LEFT JOIN TabTacografoModelo AS T ON T.TacoModelo = TV.TacoModelo) " +
                                  " WHERE TV.MarcaBaja = 0" +
                                  " AND (TC.RazonSocial LIKE '%" + TxtBuscarVehiculo.Text + "%'" + " OR TV.Dominio LIKE '%" + TxtBuscarVehiculo.Text + "%')" +
                                  " ORDER BY TC.RazonSocial";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                if (VarData.Rows[0].ItemArray[0].ToString() != "")
                {
                    GridVehiculo.DataSource = VarData;
                    GridVehiculo.ReadOnly = true;
                    GridVehiculo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    GridVehiculo.MultiSelect = false;

                    GridVehiculo.ForeColor = Color.Black;

                    GridVehiculo.Columns[0].Visible = false; //IdCliente
                    GridVehiculo.Columns[1].Visible = false; //IdVehiculo
                    GridVehiculo.Columns[2].Width = 80;
                    GridVehiculo.Columns[2].HeaderText = "CUIT";
                    GridVehiculo.Columns[3].Width = 325;
                    GridVehiculo.Columns[3].HeaderText = "Propietario";
                    GridVehiculo.Columns[4].Width = 90;
                    GridVehiculo.Columns[4].HeaderText = "V.Marca";
                    GridVehiculo.Columns[5].Width = 120;
                    GridVehiculo.Columns[5].HeaderText = "V.Modelo";
                    GridVehiculo.Columns[6].Width = 80;
                    GridVehiculo.Columns[6].HeaderText = "V.Dominio";
                    GridVehiculo.Columns[7].Width = 80;
                    GridVehiculo.Columns[7].HeaderText = "T.Marca";
                    GridVehiculo.Columns[8].Width = 80;
                    GridVehiculo.Columns[8].HeaderText = "T.Modelo";
                    GridVehiculo.Columns[9].Width = 75;
                    GridVehiculo.Columns[9].HeaderText = "Factor K";
                    GridVehiculo.Columns[10].Width = 90;
                    GridVehiculo.Columns[10].HeaderText = "T.N°Serie";
                    GridVehiculo.Columns[11].Visible = false; //NroMovil
                    GridVehiculo.Columns[12].Visible = false; //ImgFoto
                    GridVehiculo.Columns[13].Visible = false; //Categoria
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ": " + ex.Message);
            }
        }

        private void GridVehiculoDoubleClick(object sender, EventArgs e)
        {
            VarIdVehiculo = 0;
            VarIdCliente = 0;
            VarFactorK = 0;
            VarCategoria = 0;

            TxtDominio.Text = "";
            TxtDatosDominio.Text = "";
            TxtCliente.Text = "";
            TxtTacografo.Text = "";
            TxtReluctor.Text = "0.00";

            if (GridVehiculo.CurrentRow != null)
            {
                VarIdVehiculo = (int)Convert.ToInt64(GridVehiculo[0, GridVehiculo.CurrentRow.Index].Value.ToString());
                VarIdCliente = (int)Convert.ToInt64(GridVehiculo[1, GridVehiculo.CurrentRow.Index].Value.ToString());

                TxtCliente.Text = GridVehiculo[2, GridVehiculo.CurrentRow.Index].Value.ToString() + ' ' + GridVehiculo[3, GridVehiculo.CurrentRow.Index].Value.ToString();
                TxtDatosDominio.Text = GridVehiculo[4, GridVehiculo.CurrentRow.Index].Value.ToString() + ' ' + GridVehiculo[5, GridVehiculo.CurrentRow.Index].Value.ToString() + ' ' + GridVehiculo[11, GridVehiculo.CurrentRow.Index].Value.ToString();
                TxtDominio.Text = GridVehiculo[6, GridVehiculo.CurrentRow.Index].Value.ToString();
                TxtTacografo.Text = GridVehiculo[7, GridVehiculo.CurrentRow.Index].Value.ToString() + ' ' + GridVehiculo[9, GridVehiculo.CurrentRow.Index].Value.ToString() + ' ' + GridVehiculo[10, GridVehiculo.CurrentRow.Index].Value.ToString();

                VarFactorK = (int)Convert.ToInt64(GridVehiculo[9, GridVehiculo.CurrentRow.Index].Value.ToString());
                VarCategoria = (int)Convert.ToInt64(GridVehiculo[13, GridVehiculo.CurrentRow.Index].Value.ToString());

                string VarPath = Application.StartupPath.ToString() + "Fotos\\ImagenNeutra.jpg";
                PicFoto.Image = Image.FromFile(VarPath);

                if (GridVehiculo[12, GridVehiculo.CurrentRow.Index].Value.ToString() != "")
                {
                    VarPath = Application.StartupPath.ToString() + "Fotos\\" + GridVehiculo[12, GridVehiculo.CurrentRow.Index].Value.ToString();
                    if (File.Exists(VarPath) == true)
                    {

                        PicFoto.Image = Image.FromFile(VarPath);
                    }
                }

                string VarQuery = " SELECT IdVehiculo, Reluctor, MAX(FechaHoraOS) as Fecha " +
                                  " FROM TabCalibraciones " +
                                  " WHERE MarcaBaja = 0 AND IdVehiculo = " + VarIdVehiculo +
                                  " GROUP BY IdVehiculo, Reluctor " +
                                  " ORDER BY MAX(FechaHoraOS) DESC ";

                DataTable VarData = ConexionData.SQL_SelectDT(VarQuery);

                if (VarData.Rows[0].ItemArray[0].ToString() != "")
                {
                    TxtReluctor.Text = VarData.Rows[0].ItemArray[1].ToString();
                    VarFechaUltCalibracion = Convert.ToDateTime(VarData.Rows[0].ItemArray[2].ToString());
                }

                FrameVehiculo.Visible = false;
            }
        }

        private void BtnGuardarMedicion_Click(object sender, EventArgs e)
        {
            if (VarGuardar == false)
            {
                MessageBox.Show("Debe haber realizado una calibracion para poder guardar");
                return;
            }

            if (TxtIdCalibracion.Text == "")
            {
                int VarRespCalib = ConexionData.FunComboId("TabRespCalib", "IdRespCalib", "RazonSocial", CboResponsable.Text);
                string VarFchActual = "";

                string VarQuery = " INSERT INTO TabCalibraciones(FechaHoraOS,TiempoDCalibracion, IdCliente, IdVehiculo," +
                                  " MedicionK,MedicionW,DiametroRodado,VelocidadAparente,VelocidadReal," +
                                  " KAlta,KBaja,RelacionKAltaBaja,WAlta,WBaja,RelacionWAltaBaja,Reluctor,GearRatio," +
                                  " RelacionKW,PulsosXVtaRueda,PulsoEquivaleA,DistanciaPrueba,ErrorKW,PisadaDinamica, " +
                                  " DiametroAconsejado," +
                                  " MetrosPorPulso,PulsosDeLaPrueba,VelocidadDeLimitacion,Observaciones," +
                                  " IdOperador,FchUltModif,MarcaBaja,IdRespCalib, DifKeKs)" +
                                  " VALUES ('" +
                                  VarFchActual + "','" + TiempoCalibracion.Text + "'," + VarIdCliente + "," + VarIdVehiculo + ",'" +
                                  TxtUltConstanteK.Text + "','" + TxtUltConstanteW.Text + "','" + TxtUltDiametroW.Text + "','" + TxtVelocidadAparente.Text + "','" + TxtVelocidadReal.Text + "','" +
                                  TxtAltaK.Text + "','" + TxtBajaK.Text + "','" + TxtRelacionK.Text + "','" + TxtAltaW.Text + "','" + TxtBajaW.Text + "','" + TxtRelacionW.Text + "','" + TxtReluctor.Text + "','" + TxtGearRatio.Text + "','" +
                                  TxtErrorRelacionKW.Text + "','" + TxtPulsosPorVueltaRueda.Text + "','" + TxtValorAngular.Text + "','" + TxtDistanciaDePrueba.Text + "','" + TxtErrorWK.Text + "','" + TxtPisadaDinamica.Text + "','" + TxtDiametroRodadoUltCalibracion.Text + "','" +
                                  TxtCmPorPulso.Text + "','" + TxtPulsosDeLaPrueba.Text + "','" + TxtLimitacionKm.Text + "','" + TxtObservaciones.Text + "'," +
                                  0 + ",'" + VarFchActual + "',0," + VarRespCalib + ",'" + TxtDifKeKs.Text + "')";

                if (ConexionData.SQL_Comando(VarQuery) == true)
                {
                    TxtIdCalibracion.Text = ConexionData.FunUltimoId("IdOrdenServicio", "TabCalibraciones");

                    VarQuery = " UPDATE TabVehiculo SET " +
                               " FactorK = " + TxtUltConstanteW.Text +
                               " WHERE IdVehiculo = " + VarIdVehiculo;
                    
                    if (ConexionData.SQL_Comando(VarQuery) == true)
                    {
                        MessageBox.Show("MEDICION GUARDADA");
                    }
                }
                else
                {
                    MessageBox.Show("NO SE PUDO AGREGAR LA MEDICION");
                }
            }
            else
            {
                string VarQuery = " UPDATE TabCalibraciones SET " +
                                  " Observaciones = '" + TxtObservaciones.Text +
                                  "' WHERE IdOrdenServicio = " + TxtIdCalibracion.Text;

                if (ConexionData.SQL_Comando(VarQuery) == true)
                {
                    MessageBox.Show("La Calibración Guardada fue Modificada Correctamente");
                }
                else
                {
                    MessageBox.Show("La Calibración Guardada NO se pudo Modificar");
                }
            }
         }
    }
}


//Private Sub FunGridBuscarVehiculo()
//    StrConsulta = " SELECT TV.IdVehiculo, TV.IdCliente, TC.Cuit, TC.RazonSocial, TM1.Marca, TM2.Modelo, TV.Dominio, TV.TacoMarca, TV.TacoModelo, TV.FactorK, TV.TacoNroSerie, TV.NroMovil, TV.ImgFoto, TV.Categoria" + 
//                  " FROM (((TabVehiculo AS TV " + 
//                  " LEFT JOIN TabCliente AS TC ON TC.IdCliente = TV.IdCliente)" + 
//                  " LEFT JOIN TabVehiculoMarca AS TM1 ON TM1.IdMarca = TV.IdMarca)" + 
//                  " LEFT JOIN TabVehiculoModelo AS TM2 ON TM2.IdModelo = TV.IdModelo)" + 
//                  " WHERE TV.MarcaBaja = 0 " + 
//                  " AND (TV.Dominio LIKE '%" + Trim(TxtBuscarVehiculo.Text) + "%'" + 
//                  " OR TC.RazonSocial LIKE '%" + Trim(TxtBuscarVehiculo.Text) + "%')" + 
//                  " ORDER BY TC.RazonSocial "


//    FunGridBusqVehiculo
//    If Sis.oDat.RSConsulta("SQLDirect", StrConsulta) = True Then
//        With GridBusqVehiculo
//            .Visible = False
//            Do While Sis.oDat.RSResultado.EOF = False
//                .Rows = .Rows + 1: .Row = .Rows - 1
//                .TextMatrix(.Row, 0) = ""
//                .TextMatrix(.Row, 1) = "" + Sis.oDat.RSResultado!IdCliente
//                .TextMatrix(.Row, 2) = "" + Sis.oDat.RSResultado!IdVehiculo
//                .TextMatrix(.Row, 3) = "" + Sis.oDat.RSResultado!Cuit
//                .TextMatrix(.Row, 4) = "" + Sis.oDat.RSResultado!RazonSocial
//                .TextMatrix(.Row, 5) = "" + Sis.oDat.RSResultado!Marca
//                .TextMatrix(.Row, 6) = "" + Sis.oDat.RSResultado!Modelo
//                .TextMatrix(.Row, 7) = "" + Sis.oDat.RSResultado!Dominio
//                .TextMatrix(.Row, 8) = "" + Sis.oDat.RSResultado!TacoMarca

//                 Select Case Sis.oDat.RSResultado!TacoModelo
//                    Case 0
//                        .TextMatrix(.Row, 9) = ""
//                    Case 1
//                        .TextMatrix(.Row, 9) = "1308 MEC"
//                    Case 2
//                        .TextMatrix(.Row, 9) = "1310 KTCO"
//                    Case 3
//                        .TextMatrix(.Row, 9) = "1318 KTCO"
//                    Case 4
//                        .TextMatrix(.Row, 9) = "1390 MTCO"
//                    Case 5
//                        .TextMatrix(.Row, 9) = "DIGITAL RT3"
//                    Case 6
//                        .TextMatrix(.Row, 9) = "DIGITAL RT4"
//                End Select

//                .TextMatrix(.Row, 10) = "" + Sis.oDat.RSResultado!FactorK
//                .TextMatrix(.Row, 11) = "" + Sis.oDat.RSResultado!TacoNroSerie
//                .TextMatrix(.Row, 12) = "" + Sis.oDat.RSResultado!NroMovil
//                .TextMatrix(.Row, 13) = "" + Sis.oDat.RSResultado!ImgFoto
//                .TextMatrix(.Row, 14) = "" + Sis.oDat.RSResultado!Categoria

//                Sis.oDat.RSResultado.MoveNext
//            Loop
//            .Visible = True
//            .Sort = 0
//        End With
//    End If
//End Sub

//Private Sub FunGridBusqVehiculo()
//     With GridBusqVehiculo
//        .Clear
//        .Cols = 15: .Rows = 1: .Row = 0
//        .AllowUserResizing = flexResizeColumns

//        .Col = 0: .ColWidth(0) = 0
//        .Col = 1: .Text = "IdCliente": .ColWidth(1) = 0
//        .Col = 2: .Text = "IdVehiculo": .ColWidth(2) = 0
//        .Col = 3: .Text = "CUIT": .ColWidth(3) = 1200
//        .Col = 4: .Text = "RazonSocial": .ColWidth(4) = 3600
//        .Col = 5: .Text = "V.Marca": .ColWidth(5) = 2000
//        .Col = 6: .Text = "V.Modelo": .ColWidth(6) = 2000: .ColAlignment(6) = 1
//        .Col = 7: .Text = "V.Dominio": .ColWidth(7) = 1000
//        .Col = 8: .Text = "T.Marca": .ColWidth(8) = 1200
//        .Col = 9: .Text = "T.Modelo": .ColWidth(9) = 1200: .ColAlignment(9) = 1
//        .Col = 10: .Text = "Factor K": .ColWidth(10) = 1000: .ColAlignment(10) = 3
//        .Col = 11: .Text = "T.N°Serie": .ColWidth(11) = 1200: .ColAlignment(11) = 1
//        .Col = 12: .Text = "NroMovil": .ColWidth(12) = 0: .ColAlignment(12) = 1
//        .Col = 13: .Text = "ImgFoto": .ColWidth(13) = 0: .ColAlignment(13) = 1
//        .Col = 14: .Text = "Categoria": .ColWidth(14) = 0: .ColAlignment(14) = 1
//    End With
//End Sub
