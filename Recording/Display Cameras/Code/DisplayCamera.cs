﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;

namespace Recording
{
    class DisplayCamera
    {
        /// <summary>
        /// Variable que contiene toda la estructura del control de las cámaras del sistema.
        /// </summary>
        protected MilApp milApp;

        /// <summary>
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        protected Id idCam;

        protected Panel pnlCam;

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

        public void StartGrab()
        {
            milApp.StartGrab(idCam.DevNSys, idCam.DevNCam);
        }

        /// <summary>
        /// Esta función desconecta el panel de <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public void DisconnectPanel()
        {
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, panel: null);
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
            EventDataDict eventPresentCameraInfo = (EventDataDict)milApp.CamEvent(idCam.DevNSys, idCam.DevNCam, "FPS");
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

        public virtual void AllocCamera() { }

        public virtual void ConnectMouseEvent() { }
    }
}