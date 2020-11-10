using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilLibrary;


namespace Recording
{
    public partial class DisplayCameraFlirForm : /*Form*/ DisplayCameraForm
    {
        public DisplayCameraFlirForm(ref MilApp milApp, Id id)
        {
            InitializeComponent();

            DisplayCamera = new DisplayCameraFlir(ref milApp, id, this,
                ref pnlBorder, ref lbModel, ref lbName, ref lbIp,
                ref pnlCam, ref pnlLut, 
                ref lbTemperature, ref lbMinTemperature, ref lbMaxTemperature,
                ref lbPosX, ref lbPosY, ref lbFps,
                ref btnAuto, ref numericUpDownLutLow, ref numericUpDownLutHight,
                ref txBoxName);

            DisplayCamera.AllocCamera();
        }

        /// <summary>
        /// Esta función realiza el reset del zoom de la imagen que se este visualizando en este formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemZoom_Click(object sender, EventArgs e)
        {
            DisplayCamera.Zoom();
        }

        /// <summary>
        /// Esta función modifica la paleta de colores de la cámara que se este mostrando en este formulario.
        /// En este caso, se aplica la paleta Iron.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemPalletaIron_Click(object sender, EventArgs e)
        {
            DisplayCamera.ChangePalleta("Iron");
        }

        /// <summary>
        /// Esta función modifica la paleta de colores de la cámara que se este mostrando en este formulario.
        /// En este caso, se aplica la paleta Rainbow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemPalletaRainbow_Click(object sender, EventArgs e)
        {
            DisplayCamera.ChangePalleta("Rainbow");
        }

        /// <summary>
        /// Esta función modifica la paleta de colores de la cámara que se este mostrando en este formulario.
        /// En este caso, se aplica la paleta Gray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemPalletaGray_Click(object sender, EventArgs e)
        {
            DisplayCamera.ChangePalleta("Gray");
        }

        private void toolStripMenuItemPalletaIron_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDownLutLow_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
