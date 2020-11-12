using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;

namespace Recording
{
    public class DisplayCamera
    {
        /// <summary>
        /// This variable stores the form.
        /// </summary>
        protected Form form;

        /// <summary>
        /// Esta variable es utilizada para definir el color que se utiliza para seleccionar una cámara (Bordes del formulario).
        /// </summary>
        protected Color colorSelected = Color.FromArgb(21, 170, 191);

        /// <summary>
        /// Esta variable es utilizada para definir el color que se utiliza para deseleccionar una cámara (Bordes del formulario).
        /// </summary>
        //protected Color colorDeselected = Color.FromArgb(130, 201, 30);
        protected Color colorDeselected = Color.Green;

        /// <summary>
        /// Esta variable es utilizada para definir el color que se utiliza para deseleccionar una cámara (Bordes del formulario).
        /// </summary>
        protected Color colorGrab = Color.Red;

        /// <summary>
        /// Variable que contiene toda la estructura del control de las cámaras del sistema.
        /// </summary>
        protected MilApp milApp;

        /// <summary>
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        private Id idCam;

        /// <summary>
        /// Esta variable contiene el panel que se utiliza para aplicar un borde a los formularios donde se visualizando las cámaras.
        /// Ver, <see cref="DisplayCameraBaslerForm">DisplayCameraBaslerForm</see>/> y ver también <seealso cref="DisplayCameraFlirForm">DisplayCameraFlirForm</seealso>/>.
        /// </summary>
        protected Panel pnlBorder;

        /// <summary>
        /// Este atributo almacena el panel donde se visualiza la cámara.
        /// </summary>
        protected Panel pnlCam;

        /// <summary>
        /// Esta variable almacena el label referido a mostrar el modelo de la cámara que se conecte a este objeto.
        /// </summary>
        protected Label lbModel;

        /// <summary>
        /// Esta variable almacena el label referido a mostrar el nombre de la cámara que se conecte a este objeto.
        /// </summary>
        protected Label lbName;

        /// <summary>
        /// Esta variable almacena el label referido a mostrar la ip de la cámara que se conecte a este objeto.
        /// </summary>
        protected Label lbIp;

        /// <summary>
        /// Label donde se muestra la el valor de la imagen dependiendo la posición del ratón.
        /// En el caso de cámaras basler, mostrarán la intensidad de la imagen. En caso de una flir, mostrarán el valor de temperatura.
        /// </summary>
        protected Label lbValue;

        /// <summary>
        /// Label donde se muestra la posición x del mouse en la imagen.
        /// </summary>
        protected Label lbPosX;

        /// <summary>
        /// Label donde se muestra la posición Y del mouse en la imagen.
        /// </summary>
        protected Label lbPosY;

        /// <summary>
        /// Label donde se muestran los fps de la cámara.
        /// </summary>
        protected Label lbFps;

        /// <summary>
        /// This atribute stores the text box of the name camera.
        /// </summary>
        protected TextBox txBoxName;

        public Id IdCam { get => idCam; set => idCam = value; }

        /// <summary>
        /// This event is used to notify which camera has been selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyMouseDownDelegate(Id id);
        public event notifyMouseDownDelegate notifyMouseDownEvent;

        /// <summary>
        /// Función para cambiar los controles en threads separados de forma segura (Invoke)
        /// </summary>
        /// <param name="control"> Control del formulario a cambiar </param>
        /// <param name="propertyName"> Nombre de la propiedad a cambiar como STRING </param>
        /// <param name="propertyValue"> Valor que deseamos cambiar al control </param>
        protected delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        protected void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new SetControlPropertyThreadSafeDelegate
                    (SetControlPropertyThreadSafe),
                    new object[] { control, propertyName, propertyValue });
                }
                else
                {
                    control.GetType().InvokeMember(
                        propertyName,
                        BindingFlags.SetProperty,
                        null,
                        control,
                        new object[] { propertyValue });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

        public DisplayCamera()
        {

        }

        /// <summary>
        /// Esta función activa el hilo de la cámara seleccionada en <see cref="IdCam">idCam</see>/>.
        /// </summary>
        public void StartGrab()
        {
            milApp.StartGrab(IdCam.DevNSys, IdCam.DevNCam);
        }

        /// <summary>
        /// Esta función detiene el hilo de la cámara seleccionada mediante <see cref="IdCam">idCam</see>/>.
        /// </summary>
        public void Pause()
        {
            milApp.StopGrab(IdCam.DevNSys, IdCam.DevNCam);
        }

        /// <summary>
        /// Esta función desconecta el panel de <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public void DisconnectPanel()
        {
            milApp.AllocPanelToCam(IdCam.DevNSys, IdCam.DevNCam, panel: null);
        }

        public void ShowInfoCam()
        {
            Dictionary<string, string> camInfo = milApp.CamInfo(IdCam.DevNSys, IdCam.DevNCam);

            string model = camInfo["Vendor"] + " " + camInfo["Model"] + string.Format(" (DEV{0}", IdCam.DevNCam) + ")";
            lbModel.Text = model;

            txBoxName.Text = camInfo["Name"];
            lbIp.Text = (camInfo["IpAddress"] != null) ? ("Ip: " + camInfo["IpAddress"]) : "";
        }

        public void ConnectTxBoxName()
        {
            txBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ChangeName);
        }

        public void ChangeName(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                if (txBoxName.Text != "")
                    milApp.CamName(IdCam.DevNSys, IdCam.DevNCam, txBoxName.Text);
        }

        /// <summary>
        /// Esta función actualiza la información del mouse en la imagen. Se mostrará la intensidad de la imagen en la posición del ratón y 
        /// además, se mostrará la posición del ratón.
        /// </summary>
        /// <param name="value">Valor de intensidad de la imagen.</param>
        /// <param name="positionX">Posición x del ratón.</param>
        /// <param name="positionY">Posición Y del ratón.</param>
        public void Mouse(double value, int positionX, int positionY)
        {
            SetControlPropertyThreadSafe(lbValue, "Text", "Intensidad: " + value.ToString());
            SetControlPropertyThreadSafe(lbPosX, "Text", "Pos X: " + positionX.ToString());
            SetControlPropertyThreadSafe(lbPosY, "Text", "Pos Y: " + positionY.ToString());
        }

        /// <summary>
        /// Esta función conecta el evento que envia la información de los fps de una cámara de <see cref="MilLibrary">MilLibrary</see>/> a este programa.
        /// </summary>
        public void ConnectFpsEvent()
        {
            EventDataDict eventPresentCameraInfo = (EventDataDict)milApp.CamEvent(IdCam.DevNSys, IdCam.DevNCam, "FPS");
            eventPresentCameraInfo._event += new EventDataDict._eventDelagete(Fps);
        }

        /// <summary>
        /// Este método actualiza el label que muestra la información de los fps de la cámara.
        /// </summary>
        /// <param name="milSys"></param>
        /// <param name="milDig"></param>
        /// <param name="data"></param>
        public void Fps(MIL_ID milSys, MIL_ID milDig, Dictionary<string, double> data)
        {
            SetControlPropertyThreadSafe(lbFps, "Text", "Fps: " + Math.Truncate(data["FPS"]).ToString());
        }

        protected virtual void ConnectMouseDown()
        {
            form.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            pnlBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            pnlCam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbModel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbIp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbPosX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbPosY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            lbFps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            txBoxName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
        }

        /// <summary>
        /// This function is used to notify that the mouse it is in the <see cref="form">form</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (notifyMouseDownEvent != null)
                notifyMouseDownEvent.Invoke(IdCam);
        }

        

        /// <summary>
        /// Esta función es utilizada para seleccionar esta cámara.
        /// Es decir, se modificará el color del borde del formulario.
        /// Ver, <see cref="DisplayCamera.colorSelected">DisplayCamera.colorSelected</see>/>.
        /// </summary>
        public void SelectCamera()
        {
            pnlBorder.BackColor = colorSelected;
        }

        /// <summary>
        /// Esta función es utilizada para deseleccionar esta cámara.
        /// Es decir, se modificará el color del borde del formulario.
        /// </summary>
        public void DeselectCamera()
        {
            pnlBorder.BackColor = colorDeselected;
        }

        /// <summary>
        /// Este método es utilizado para indicar que la cámara esta grabando por medio de la interface.
        /// Se modificará el color del borde del <see cref="pnlBorder">pnlBorder</see>/>.
        /// </summary>
        public void GrabCamera()
        {
            pnlBorder.BackColor = colorGrab;
        }

        /// <summary>
        /// Este método hace el reset del zoom que se ha aplicado a la imagen que se esta visualizando.
        /// </summary>
        public void Zoom()
        {
            milApp.Zoom(IdCam.DevNSys, IdCam.DevNCam);
        }

        

        public virtual void AllocCamera() { }

        public virtual void ConnectMouseEvent() { }

        public virtual void ChangePalleta(string palleta) { }
    }
}
