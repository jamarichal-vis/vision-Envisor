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
        private const int VALUE_MIN_EXPOSURETIME = 0;
        private const int VALUE_MAX_EXPOSURETIME = 5000; /*us*/

        private Form form;

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

        /// <summary>
        /// Este evento es utilizado para acceder de forma segura a los atributos de un control desde otro hilo.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="state"></param>
        public delegate void safeControlDelegate(Control control, bool state);
        public safeControlDelegate safeControlEvent;

        public ExposureTimeManager(Form form, ref MilApp milApp, ref TableLayoutPanel tableLayoutPanel, ref NumericUpDown numUpDown, ref TrackBar trBar, ref Id idCam)
        {
            this.form = form;

            this.milApp = milApp;

            tbLayoutPanel = tableLayoutPanel;
            numUpDownExposureTime = numUpDown;
            trBarExposureTime = trBar;

            this.idCam = idCam;

            numUpDown.Minimum = VALUE_MIN_EXPOSURETIME;
            numUpDown.Maximum = VALUE_MAX_EXPOSURETIME;

            trBar.Minimum = VALUE_MIN_EXPOSURETIME;
            trBar.Maximum = VALUE_MAX_EXPOSURETIME;

            safeControlEvent += new safeControlDelegate(Enable);

            Events();
        }

        /// <summary>
        /// Este evento se ejecuta cuando se selecciona una cámara.
        /// </summary>
        public void SelectCam()
        {
            InitValue();
        }


        /// <summary>
        /// Este método habilita las funcionalidades de todos los controles de esta clase.
        /// </summary>
        public void Enable(bool safe = false)
        {
            if (safe)
                form.Invoke(safeControlEvent, new object[] { tbLayoutPanel, true });
            else
                tbLayoutPanel.Enabled = true;
        }

        /// <summary>
        /// Este método deshabilita las funcionalidades de todos los controles de esta clase.
        /// </summary>
        public void Disable(bool safe = false)
        {
            if (safe)
                form.Invoke(safeControlEvent, new object[] { tbLayoutPanel, false });
            else
                tbLayoutPanel.Enabled = false;
        }

        /// <summary>
        /// This method set the values to 0.
        /// </summary>
        public void Reset()
        {
            DisconnectnumUpDownExposureTime();
            DisconnecttrBarExposureTime();

            numUpDownExposureTime.Value = 0;

            ConnectnumUpDownExposureTime();
            ConnecttrBarExposureTime();
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
        /// Este método inicializa los valores de frame rate de la cámara que se conecta.
        /// </summary>
        private void InitValue()
        {
            DisconnectnumUpDownExposureTime();
            DisconnecttrBarExposureTime();

            double exposureTime = milApp.CamExposureTime(idCam.DevNSys, idCam.DevNCam);
            exposureTime = exposureTime / 1000;
            double value = VALUE_MIN_EXPOSURETIME > exposureTime ? VALUE_MIN_EXPOSURETIME : exposureTime;
            value = VALUE_MAX_EXPOSURETIME < value ? VALUE_MAX_EXPOSURETIME : value;

            numUpDownExposureTime.Value = (decimal)value;
            trBarExposureTime.Value = (int)value;

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

        /// <summary>
        /// Este método modifica el exposure time de la cámara.
        /// Las unidades del parámetro value son us.
        /// </summary>
        /// <param name="value">Valor que quieres establecer.</param>
        private void ChangeExposureTime(long value)
        {
            if (idCam.DevNSys != -1 && idCam.DevNCam != -1)
            {
                milApp.CamExposureTime(idCam.DevNSys, idCam.DevNCam, value < 35 ? 35 : value);
            }
        }

        public void Max(double frameRate)
        {
            double max = 1 / frameRate;
            max = max * 1000 * 1000; /* us */

            DisconnectnumUpDownExposureTime();
            DisconnecttrBarExposureTime();

            LimitNumericUpDown(max);
            LimitTrBar(max);
            
            numUpDownExposureTime.Value = (decimal)max;
            trBarExposureTime.Value = (int)max;

            ChangeExposureTime((long)max);

            ConnectnumUpDownExposureTime();
            ConnecttrBarExposureTime();
        }

        /// <summary>
        /// Esta función limita el límite superior del control <see cref="numUpDownExposureTime">numUpDownExposureTime</see>/>.
        /// </summary>
        /// <param name="value">Valor que quieres establecer.</param>
        private void LimitNumericUpDown(double value)
        {
            numUpDownExposureTime.Maximum = (decimal)value;
        }

        /// <summary>
        /// Esta función limita el límite superior del control <see cref="trBarExposureTime">trBarExposureTime</see>/>.
        /// </summary>
        /// <param name="value">Valor que quieres establecer.</param>
        private void LimitTrBar(double value)
        {
            trBarExposureTime.Maximum = (int)value;
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

        /// <summary>
        /// Esta función modifica el atributo Enable del control que se pasa por parámetro.
        /// </summary>
        /// <param name="control">Control que quieres modificar.</param>
        /// <param name="state">Estado del atributo Enable.</param>
        private void Enable(Control control, bool state)
        {
            control.Enabled = state;
        }

    }
}
