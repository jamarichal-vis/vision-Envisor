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
    class ExposureTimeManager
    {
        private const int VALUE_MIN_EXPOSURETIME = 1000;
        private const int VALUE_MAX_EXPOSURETIME = 5000;

        /// <summary>
        /// Variable que contiene toda la estructura del control de las cámaras del sistema.
        /// </summary>
        private MilApp milApp;

        /// <summary>
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        Id idCam;

        /// <summary>
        /// Este atributo contiene el control TableLayout que pretende controlar esta clase.
        /// </summary>
        TableLayoutPanel tbLayoutPanel;

        /// <summary>
        /// Esta variable almacena el control NumericUpDown que se quiere controlar en esta clase.
        /// </summary>
        NumericUpDown numUpDownExposureTime;

        /// <summary>
        /// Esta variable almacena el control TrackBar que se quiere controlar en esta clase.
        /// </summary>
        TrackBar trBarExposureTime;

        public ExposureTimeManager(ref MilApp milApp, ref TableLayoutPanel tableLayoutPanel, ref NumericUpDown numUpDown, ref TrackBar trBar, ref Id idCam)
        {
            this.milApp = milApp;

            tbLayoutPanel = tableLayoutPanel;
            numUpDownExposureTime = numUpDown;
            trBarExposureTime = trBar;

            this.idCam = idCam;

            numUpDown.Minimum = VALUE_MIN_EXPOSURETIME;
            numUpDown.Maximum = VALUE_MAX_EXPOSURETIME;

            trBar.Minimum = VALUE_MIN_EXPOSURETIME;
            trBar.Maximum = VALUE_MAX_EXPOSURETIME;

            Events();
        }

        /// <summary>
        /// Este método habilita las funcionalidades de todos los controles de esta clase.
        /// </summary>
        public void Enable()
        {
            tbLayoutPanel.Enabled = true;
        }

        /// <summary>
        /// Este método deshabilita las funcionalidades de todos los controles de esta clase.
        /// </summary>
        public void Disable()
        {
            tbLayoutPanel.Enabled = false;
        }

        /// <summary>
        /// Esta función almacenará todos los eventos de los controles que controle esta clase.
        /// </summary>
        private void Events()
        {
            ConnectnumUpDownExposureTime();
            ConnecttrBarExposureTime();
        }


        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numUpDownFrameRate">numUpDownFrameRate</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownExposureTime_ValueChanged(object sender, EventArgs e)
        {
            DisconnecttrBarExposureTime();

            trBarExposureTime.Value = (int)numUpDownExposureTime.Value;

            ConnecttrBarExposureTime();

            ChangeExposureTime((long)numUpDownExposureTime.Value);
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="trBarExposureTime">trBarExposureTime</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trBarExposureTime_ValueChanged(object sender, EventArgs e)
        {
            DisconnectnumUpDownExposureTime();

            numUpDownExposureTime.Value = trBarExposureTime.Value;

            ConnectnumUpDownExposureTime();

            ChangeExposureTime((long)trBarExposureTime.Value);
        }

        private void ChangeExposureTime(long value)
        {
            if (idCam.DevNSys != -1 && idCam.DevNCam != -1)
            {
                milApp.CamExposureTime(idCam.DevNSys, idCam.DevNCam, value);
            }
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="numUpDownExposureTime">numUpDownExposureTime</see>/>;
        /// </summary>
        private void ConnectnumUpDownExposureTime()
        {
            numUpDownExposureTime.ValueChanged += new System.EventHandler(numUpDownExposureTime_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="numUpDownExposureTime">numUpDownExposureTime</see>/>;
        /// </summary>
        private void DisconnectnumUpDownExposureTime()
        {
            numUpDownExposureTime.ValueChanged -= new System.EventHandler(numUpDownExposureTime_ValueChanged);
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="trBarExposureTime">trBarExposureTime</see>/>;
        /// </summary>
        private void ConnecttrBarExposureTime()
        {
            trBarExposureTime.ValueChanged += new System.EventHandler(trBarExposureTime_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="trBarExposureTime">trBarExposureTime</see>/>;
        /// </summary>
        private void DisconnecttrBarExposureTime()
        {
            trBarExposureTime.ValueChanged -= new System.EventHandler(trBarExposureTime_ValueChanged);
        }

    }
}
