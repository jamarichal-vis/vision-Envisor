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
    /// <summary>
    /// Esta clase gestiona la sección que modifica el frame rate de una cámara.
    /// Este bloque se conectará a la cámara que este seleccionada en la clase <see cref="CameraManager">CameraManager</see>/> 
    /// (clase encargada de modificar la variable <see cref="idCam">idCam</see>/>).
    /// </summary>
    class FrameRateManager
    {
        private const int VALUE_MIN_FRAMERATE = 0;
        private const int VALUE_MAX_FRAMERATE = 100;

        /// <summary>
        /// Variable que contiene toda la estructura del control de las cámaras del sistema.
        /// </summary>
        private MilApp milApp;

        /// <summary>
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        Id idCam;

        /// <summary>
        /// Esta variable almacena el control NumericUpDown que se quiere controlar en esta clase.
        /// </summary>
        NumericUpDown numUpDownFrameRate;

        /// <summary>
        /// Esta variable almacena el control TrackBar que se quiere controlar en esta clase.
        /// </summary>
        TrackBar trBarFrameRate;

        public FrameRateManager(ref MilApp milApp, ref NumericUpDown numUpDown, ref TrackBar trBar, ref Id idCam)
        {
            this.milApp = milApp;
            numUpDownFrameRate = numUpDown;
            trBarFrameRate = trBar;

            this.idCam = idCam;

            numUpDown.Minimum = VALUE_MIN_FRAMERATE;
            numUpDown.Maximum = VALUE_MAX_FRAMERATE;

            trBar.Minimum = VALUE_MIN_FRAMERATE;
            trBar.Maximum = VALUE_MAX_FRAMERATE;

            Events();
        }

        /// <summary>
        /// Esta función almacenará todos los eventos de los controles que controle esta clase.
        /// </summary>
        private void Events()
        {
            ConnectNumUpDownFrameRate();
            ConnectTrBarFrameRate();
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numUpDownFrameRate">numUpDownFrameRate</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownFrameRate_ValueChanged(object sender, EventArgs e)
        {
            DisconnectTrBarFrameRate();

            trBarFrameRate.Value = (int)numUpDownFrameRate.Value;

            ConnectTrBarFrameRate();

            ChangeFrameRate((long)numUpDownFrameRate.Value);
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="trBarFrameRate">trBarFrameRate</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trBarFrameRate_ValueChanged(object sender, EventArgs e)
        {
            DisconnectNumUpDownFrameRate();

            numUpDownFrameRate.Value = trBarFrameRate.Value;

            ConnectNumUpDownFrameRate();

            ChangeFrameRate((long)trBarFrameRate.Value);
        }

        private void ChangeFrameRate(long value)
        {
            if(idCam.DevNSys != -1 && idCam.DevNCam != -1)
            {
                milApp.CamFrameRate(idCam.DevNSys, idCam.DevNCam, value);
            }
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="numUpDownFrameRate">numUpDownFrameRate</see>/>;
        /// </summary>
        private void ConnectNumUpDownFrameRate()
        {
            numUpDownFrameRate.ValueChanged += new System.EventHandler(numUpDownFrameRate_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="numUpDownFrameRate">numUpDownFrameRate</see>/>;
        /// </summary>
        private void DisconnectNumUpDownFrameRate()
        {
            numUpDownFrameRate.ValueChanged -= new System.EventHandler(numUpDownFrameRate_ValueChanged);
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="trBarFrameRate">trBarFrameRate</see>/>;
        /// </summary>
        private void ConnectTrBarFrameRate()
        {
            trBarFrameRate.ValueChanged += new System.EventHandler(trBarFrameRate_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="trBarFrameRate">trBarFrameRate</see>/>;
        /// </summary>
        private void DisconnectTrBarFrameRate()
        {
            trBarFrameRate.ValueChanged -= new System.EventHandler(trBarFrameRate_ValueChanged);
        }
    }
}
