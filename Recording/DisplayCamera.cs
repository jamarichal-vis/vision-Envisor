using System;
using System.Collections.Generic;
using System.Linq;
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

        Label lbPosX;

        Label lbPosY;

        Label lbFps;

        public DisplayCamera()
        {

        }

        protected virtual void AllocCamera(Panel pnl) { }

        protected virtual void ConnectMouseEvent() { }
    }
}
