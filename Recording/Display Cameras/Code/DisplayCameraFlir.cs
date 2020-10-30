using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;
using MilLibrary;
using System.Windows.Forms;
using System.Drawing;

namespace Recording
{
    class DisplayCameraFlir : DisplayCamera
    {
        private const string NAME_IMAGE_LUT = "Lut";

        /// <summary>
        /// Esta variable almacena el panel donde se visualiza el lut de la cámara.
        /// </summary>
        Panel pnlLut;

        /// <summary>
        /// Esta variable almacena la temperatura mínima de la imagen que se esta visualizando.
        /// </summary>
        Label lbMinTemperature;

        /// <summary>
        /// Esta variable almacena la temperatura máxima de la imagen que se esta visualizando.
        /// </summary>
        Label lbMaxTemperature;

        public DisplayCameraFlir(ref MilApp milApp, Id id, ref Panel pnlBorder, ref Label lbModel, ref Label lbName, ref Label lbIp,
            ref Panel pnlCam, ref Panel pnlLut, 
            ref Label lbTemperature, ref Label lbMinTemperature, ref Label lbMaxTemperature, 
            ref Label lbPosX, ref Label lbPosY, ref Label lbFps)
        {
            this.milApp = milApp;

            this.idCam = id;

            this.pnlBorder = pnlBorder;
            this.lbModel = lbModel;
            this.lbName = lbName;
            this.lbIp = lbIp;

            this.pnlCam = pnlCam;
            this.pnlLut = pnlLut;

            this.lbValue = lbTemperature;
            this.lbMinTemperature = lbMinTemperature;
            this.lbMaxTemperature = lbMaxTemperature;

            this.lbPosX = lbPosX;
            this.lbPosY = lbPosY;
            this.lbFps = lbFps;
        }

        public override void AllocCamera()
        {
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, pnlCam);

            milApp.CamAddImage(idCam.DevNSys, idCam.DevNCam, NAME_IMAGE_LUT, band: 1, sizeX: pnlLut.Width, sizeY: pnlLut.Height, show: false);

            milApp.ShowPallet(idCam.DevNSys, idCam.DevNCam, NAME_IMAGE_LUT);
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, pnlLut, NAME_IMAGE_LUT);

            /* EVENTS */
            ConnectMouseEvent();
            ConnectTemperatureEvent();
            ConnectFpsEvent();

            /* Info Cam. */
            ShowInfoCam();

            /* GRAB */
            StartGrab();
        }

        /// <summary>
        /// Este método conecta el evento de mouse de una cámara de <see cref="MilLibrary">MilLibrary</see>/> a este programa.
        /// </summary>
        public override void ConnectMouseEvent()
        {
            EventMouseTemperature eventMouseTemperature = (EventMouseTemperature)milApp.CamEvent(idCam.DevNSys, idCam.DevNCam, "MouseTemperature");
            eventMouseTemperature._event += new EventMouseTemperature._eventDelagete(Mouse);

            /* Activamos el evento del mouse a la imagen "AlarmManagement". */
            milApp.CamStartMouseMove(idCam.DevNSys, idCam.DevNCam);
        }

        /// <summary>
        /// Esta función conecta el evento de temperatura a la función <see cref="ShowTemperature(double, double)">ShowTemperature(double, double)</see>/>.
        /// Esta función mostrará la temperatura mínima y máxima de la imagen que se esta visualizando.
        /// </summary>
        private void ConnectTemperatureEvent()
        {
            EventTemperature eventTemperature = (EventTemperature)milApp.CamEvent(idCam.DevNSys, idCam.DevNCam, "Temperature");
            eventTemperature._event += new EventTemperature._eventDelagete(ShowTemperature);
        }

        /// <summary>
        /// Esta función actualiza la información del mouse en la imagen. Se mostrará la intensidad de la imagen en la posición del ratón y 
        /// además, se mostrará la posición del ratón.
        /// </summary>
        /// <param name="value">Valor de intensidad de la imagen.</param>
        /// <param name="positionX">Posición x del ratón.</param>
        /// <param name="positionY">Posición Y del ratón.</param>
        public new void Mouse(double value, int positionX, int positionY)
        {
            SetControlPropertyThreadSafe(lbValue, "Text", "Temperatura: " + value.ToString("#.## °C"));
            SetControlPropertyThreadSafe(lbPosX, "Text", "Pos X: " + positionX.ToString());
            SetControlPropertyThreadSafe(lbPosY, "Text", "Pos Y: " + positionY.ToString());
        }

        public void ShowTemperature(double minValue, double maxValue)
        {
            SetControlPropertyThreadSafe(lbMinTemperature, "Text", "Min: " + ((minValue * 0.04) - 273.15).ToString("#.## °C"));
            SetControlPropertyThreadSafe(lbMaxTemperature, "Text", "Max: " + ((maxValue * 0.04) - 273.15).ToString("#.## °C"));
        }

        /// <summary>
        /// Esta función modifica la paleta de colores de la cámara que este visualizando en esta clase.
        /// </summary>
        /// <param name="palleta">Paleta que quieres seleccionar.</param>
        public override void ChangePalleta(string palleta)
        {
            milApp.ChangePalletLut(idCam.DevNSys, idCam.DevNCam, palleta);
            milApp.ShowPallet(idCam.DevNSys, idCam.DevNCam, NAME_IMAGE_LUT);
        }
        /// <summary>
        /// Esta función desconecta el panel de <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public new void DisconnectPanel()
        {
            base.DisconnectPanel();
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, panel: null, NAME_IMAGE_LUT);
        }
    }
}
