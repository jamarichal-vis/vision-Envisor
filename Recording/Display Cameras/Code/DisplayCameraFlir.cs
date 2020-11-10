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

        /// <summary>
        /// Este atributo almacena el botón para establecer el modo automático de la paleta de colores.
        /// </summary>
        Button btnAuto;

        /// <summary>
        /// Esta variable almacena el control numericUpDown de la temperatura baja.
        /// </summary>
        NumericUpDown numericUpDownTemperatureLow;

        /// <summary>
        /// Esta variable almacena el control numericUpDown de la temperatura alta.
        /// </summary>
        NumericUpDown numericUpDownTemperatureHight;

        private bool firstLoop;

        private delegate bool FocuseDelegate(Control control);
        
        private FocuseDelegate focuseEvent;


        public DisplayCameraFlir(ref MilApp milApp, Id id, Form form,
            ref Panel pnlBorder, ref Label lbModel, ref Label lbName, ref Label lbIp,
            ref Panel pnlCam, ref Panel pnlLut, 
            ref Label lbTemperature, ref Label lbMinTemperature, ref Label lbMaxTemperature, 
            ref Label lbPosX, ref Label lbPosY, ref Label lbFps,
            ref Button btnAuto, ref NumericUpDown numericUpDownManualLutLow, ref NumericUpDown numericUpDownManualLutHight,
            ref TextBox textBox)
        {
            this.milApp = milApp;

            this.IdCam = id;
            this.form = form;

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

            this.btnAuto = btnAuto;
            this.numericUpDownTemperatureLow = numericUpDownManualLutLow;
            this.numericUpDownTemperatureHight = numericUpDownManualLutHight;

            this.txBoxName = textBox;

            focuseEvent = new FocuseDelegate(FocuseSafe);
        }

        public override void AllocCamera()
        {
            milApp.AllocPanelToCam(IdCam.DevNSys, IdCam.DevNCam, pnlCam);

            milApp.CamAddImage(IdCam.DevNSys, IdCam.DevNCam, NAME_IMAGE_LUT, band: 1, sizeX: pnlLut.Width, sizeY: pnlLut.Height, show: false);

            milApp.ShowPallet(IdCam.DevNSys, IdCam.DevNCam, NAME_IMAGE_LUT);
            milApp.AllocPanelToCam(IdCam.DevNSys, IdCam.DevNCam, pnlLut, NAME_IMAGE_LUT);

            /* EVENTS */
            Events();

            /* Info Cam. */
            ShowInfoCam();

            /* GRAB */
            StartGrab();
        }

        /// <summary>
        /// Esta función contiene todos los eventos de esta clase.
        /// </summary>
        private void Events()
        {
            ConnectMouseEvent();
            ConnectTemperatureEvent();
            ConnectFpsEvent();
            ConnectMouseDown();

            ConnectLut();

            ConnectTxBoxName();
        }

        /// <summary>
        /// Este método conecta el evento de mouse de una cámara de <see cref="MilLibrary">MilLibrary</see>/> a este programa.
        /// </summary>
        public override void ConnectMouseEvent()
        {
            EventMouseTemperature eventMouseTemperature = (EventMouseTemperature)milApp.CamEvent(IdCam.DevNSys, IdCam.DevNCam, "MouseTemperature");
            eventMouseTemperature._event += new EventMouseTemperature._eventDelagete(Mouse);

            /* Activamos el evento del mouse a la imagen "AlarmManagement". */
            milApp.CamStartMouseMove(IdCam.DevNSys, IdCam.DevNCam);
        }

        /// <summary>
        /// Esta función conecta el evento de temperatura a la función <see cref="ShowTemperature(double, double)">ShowTemperature(double, double)</see>/>.
        /// Esta función mostrará la temperatura mínima y máxima de la imagen que se esta visualizando.
        /// </summary>
        private void ConnectTemperatureEvent()
        {
            EventTemperature eventTemperature = (EventTemperature)milApp.CamEvent(IdCam.DevNSys, IdCam.DevNCam, "Temperature");
            eventTemperature._event += new EventTemperature._eventDelagete(ShowTemperature);
        }

        private void ConnectLut()
        {
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            numericUpDownTemperatureLow.ValueChanged += new System.EventHandler(numUpDownChangeLutManual_ValueChanged);
            numericUpDownTemperatureHight.ValueChanged += new System.EventHandler(numUpDownChangeLutManual_ValueChanged);
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

            bool focusedLow = (bool)form.Invoke(focuseEvent, new object[] { numericUpDownTemperatureLow });
            bool focusedHight = (bool)form.Invoke(focuseEvent, new object[] { numericUpDownTemperatureHight });

            if(!focusedLow && !focusedHight)
            {
                SetControlPropertyThreadSafe(numericUpDownTemperatureLow, "Value", (decimal)((minValue * 0.04) - 273.15));
                SetControlPropertyThreadSafe(numericUpDownTemperatureHight, "Value", (decimal)((maxValue * 0.04) - 273.15));
            }
        }

        private bool FocuseSafe(Control control)
        {
            return control.Focused;
        }

        /// <summary>
        /// Esta función modifica la paleta de colores de la cámara que este visualizando en esta clase.
        /// </summary>
        /// <param name="palleta">Paleta que quieres seleccionar.</param>
        public override void ChangePalleta(string palleta)
        {
            milApp.ChangePalletLut(IdCam.DevNSys, IdCam.DevNCam, palleta);
            milApp.ShowPallet(IdCam.DevNSys, IdCam.DevNCam, NAME_IMAGE_LUT);
        }

        /// <summary>
        /// Esta función modifica el Lut de la cámara que se esta visualizando en este momento.
        /// </summary>
        public void numUpDownChangeLutManual_ValueChanged(object sender, EventArgs e)
        {
            milApp.ModeLUT(IdCam.DevNSys, IdCam.DevNCam, mode: false);

            milApp.UpdateManualLut(IdCam.DevNSys, IdCam.DevNCam, (double)numericUpDownTemperatureLow.Value, (double)numericUpDownTemperatureHight.Value);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            milApp.ModeLUT(IdCam.DevNSys, IdCam.DevNCam, mode: true);
        }

        /// <summary>
        /// Esta función desconecta el panel de <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public new void DisconnectPanel()
        {
            base.DisconnectPanel();
            milApp.AllocPanelToCam(IdCam.DevNSys, IdCam.DevNCam, panel: null, NAME_IMAGE_LUT);
        }

        protected override void ConnectMouseDown()
        {
            base.ConnectMouseDown();

            pnlLut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbMinTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbMaxTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            btnAuto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            numericUpDownTemperatureLow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            numericUpDownTemperatureHight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
        }
    }
}
