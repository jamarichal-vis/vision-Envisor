using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;
using MilLibrary;
using System.Windows.Forms;

namespace Recording
{
    class DisplayCameraFlir : DisplayCamera
    {
        /// <summary>
        /// Esta variable almacena el panel donde se visualiza el lut de la cámara.
        /// </summary>
        Panel pnlLut;

        Label lbMinTemperature;

        Label lbMaxTemperature;

        public DisplayCameraFlir(ref MilApp milApp, Id id, ref Panel pnlCam, ref Panel pnlLut, ref Label lbTemperature, ref Label lbMinTemperature, ref Label lbMaxTemperature, ref Label lbPosX, ref Label lbPosY, ref Label lbFps)
        {
            this.milApp = milApp;

            this.idCam = id;

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

            milApp.ShowPallet(idCam.DevNSys, idCam.DevNCam, "Lut");
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, pnlLut, "Lut");

            /* EVENTS */
            ConnectMouseEvent();
            ConnectTemperatureEvent();
            ConnectFpsEvent();

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
        /// Esta función desconecta el panel de <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public new void DisconnectPanel()
        {
            base.DisconnectPanel();
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, panel: null, "Lut");
        }
    }
}
