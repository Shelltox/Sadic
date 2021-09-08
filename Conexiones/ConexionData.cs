using System;
using System.Data.OleDb;
using System.Data;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace SADI_Desktop_v1
{   
    class ConexionData
    {
        public static bool SQL_Comando(string VarQuery) 
        {
            try
            {
                ConexionString VarStr = new();
                OleDbConnection VarCon = new(VarStr.ConString);
                VarCon.Open();
                    OleDbCommand VarComando = new(VarQuery, VarCon);
                    VarComando.ExecuteNonQuery();
                    VarComando.Dispose();
                VarCon.Close();

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static DataSet SQL_Select(string VarQuery)
        {
            try
            {
                ConexionString VarStr = new();
                OleDbConnection VarCon = new(VarStr.ConString);
                VarCon.Open();
                    DataSet VarDataSet = new ();
                    OleDbDataAdapter VarDataAdapter = new(VarQuery, VarCon);
                    VarDataAdapter.Fill(VarDataSet);
                    VarDataAdapter.Dispose();
                VarCon.Close();

                return VarDataSet;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable SQL_SelectDT(string VarQuery)
        {
            try
            {
                ConexionString VarStr = new();
                OleDbConnection VarCon = new(VarStr.ConString);
                VarCon.Open();
                    DataTable VarDataTable = new();
                    OleDbDataAdapter VarDataAdapter = new(VarQuery, VarCon);
                    VarDataAdapter.Fill(VarDataTable);
                    VarDataAdapter.Dispose();
                VarCon.Close();

                return VarDataTable;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string FunUltimoId(String VarId, string VarTabla)
        {
            string VarQuery = "SELECT MAX(" + VarId + ") As ID FROM " + VarTabla;

            ConexionString VarStr = new();
            OleDbConnection VarCon = new(VarStr.ConString);
            VarCon.Open();
                DataSet VarDataSet = new();
                OleDbDataAdapter VarDataAdapter = new(VarQuery, VarCon);
                VarDataAdapter.Fill(VarDataSet);
                VarDataAdapter.Dispose();
            VarCon.Close();

            return VarDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        public static int FunComboId(String VarTabla, string VarId, string VarCampo, string VarDato)
        {
            string VarQuery = "SELECT "+ VarId +" As ID FROM "+ VarTabla +" WHERE " + VarCampo + " = '" + VarDato +"'";

            ConexionString VarStr = new();
            OleDbConnection VarCon = new(VarStr.ConString);
            VarCon.Open();
                DataTable VarDataTable = new();
                OleDbDataAdapter VarDataAdapter = new(VarQuery, VarCon);
                VarDataAdapter.Fill(VarDataTable);
                VarDataAdapter.Dispose();
            VarCon.Close();
            

            if (VarDataTable != null)
            {
                return (int)VarDataTable.Rows[0][0];
            }
            else 
            { 
                return 0;
            }

            //FunComboId("TabVehiculoModelo", "IdMarca", "Marca", CboMarca.Text)
        }

        public static string FunComboDesc(string VarDatoDesc, string VarTabla, string VarCampoId, string VarId)
        {
            string VarQuery = "SELECT " + VarDatoDesc + " As Descripcion FROM " + VarTabla + " WHERE " + VarCampoId + " = " + VarId;

            ConexionString VarStr = new();
            OleDbConnection VarCon = new(VarStr.ConString);
            VarCon.Open();
            DataTable VarDataTable = new();
            OleDbDataAdapter VarDataAdapter = new(VarQuery, VarCon);
            VarDataAdapter.Fill(VarDataTable);
            VarDataAdapter.Dispose();
            VarCon.Close();


            if (VarDataTable != null)
            {
                return VarDataTable.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

            //FunComboId("Marca", "TabVehiculoModelo", "IdMarca", MarcaId)
        }

    }
}

