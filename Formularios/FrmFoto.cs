using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;

namespace SADI_Desktop_v1
{
    public partial class FrmFoto : Form
    {
 
        public FrmFoto()
        {
           InitializeComponent();
        }

        public FilterInfoCollection MisDispositivos;
        public VideoCaptureDevice MiWebCam;

        private string VarDominio;
  
        private void FrmFoto_Load(object sender, EventArgs e)
        {
            try 
            { 
                this.CenterToParent();
                BtnTomarFoto.Enabled = false;

                FilterInfoCollection MisDispositivos = new(FilterCategory.VideoInputDevice);
                foreach (FilterInfo FilterInfo in MisDispositivos)
                {
                    CboCamaras.Items.Add(FilterInfo.Name.ToString());
                }
                CboCamaras.SelectedIndex = -1;

                VarDominio = Negocios.aFrmCalibracion.TxtDominio.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnIniciarCamara_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (CboCamaras.SelectedIndex.ToString() != "-1")
                {
                    FilterInfoCollection MisDispositivos = new(FilterCategory.VideoInputDevice);
                    VideoCaptureDevice MiWebCam = new(MisDispositivos[CboCamaras.SelectedIndex].MonikerString);

                    FunCerrarWebCam();

                    MiWebCam.NewFrame += VideoCaptureDevice_NewFrame;
                    MiWebCam.Start();

                    BtnTomarFoto.Enabled = true;
                }
                else
                {
                    //MessageBox.Show("No se detectan Webcams conectadas a este equipo");
                    MessageBox.Show("No Olvide Seleccionar una Camara");
                }
            } 
            catch (Exception ex)
            {
                BtnTomarFoto.Enabled = false;
                MessageBox.Show( ex.Message);
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                PicVideo.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                BtnTomarFoto.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTomarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (VarDominio == "")
                {
                    MessageBox.Show("No Olvide Seleccionar previamente un Vehiculo");
                    FunCerrarWebCam();
                    this.Hide();
                }
                else
                {
                    string VarNomArchivo = @"" + Application.StartupPath.ToString() + "Fotos\\" + VarDominio + ".jpg";
                    MessageBox.Show(VarNomArchivo);
                    //bitmap.Save(VarNomArchivo, ImageFormat.Jpeg);
                    if (File.Exists(VarNomArchivo))
                    {
                        MessageBox.Show("El Archivo ya Existe");
                    }
                    else
                    {
                        Bitmap varBmp = new(PicVideo.Image);
                        Bitmap newBitmap = new(varBmp);
                        varBmp.Save(VarNomArchivo);
                        varBmp.Dispose();
                        varBmp = null;

                        FunGuardar(VarNomArchivo);
                        MessageBox.Show("Archivo Guardado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog OfDialog = new();
            OfDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            OfDialog.Title = "Seleccionar Imagen Logotipo";
            OfDialog.Filter = "Imagen (*.jpg)|*.jpg| Imagen (*.png)|*.png| Imagen (*.bmp)|*.bmp ";

            if (OfDialog.ShowDialog() == DialogResult.OK)
            {
                string VarPath = OfDialog.FileName;
                PicVideo.Image = Image.FromFile(OfDialog.FileName);
                FunGuardar(VarPath);
            }
        }

        private static void FunGuardar (String VarPathArch)
        {
            Negocios.aFrmCalibracion.PicFoto.Image = Image.FromFile(VarPathArch);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            FunCerrarWebCam();
            this.Hide();
        }

        private void FunCerrarWebCam()
        {
            if (MiWebCam != null && MiWebCam.IsRunning == true)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
                MiWebCam.Stop();
            }
        }
    }
}
