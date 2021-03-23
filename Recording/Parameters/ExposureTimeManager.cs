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
        /// This variable storages the camera select by user.
        /// It is used to connect all modules of the program.
        /// </summary>
        private Camera camera_selected;

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

        public ExposureTimeManager(Form form, ref TableLayoutPanel tableLayoutPanel, ref NumericUpDown numUpDown, ref TrackBar trBar)
        {
            this.form = form;
            
            tbLayoutPanel = tableLayoutPanel;
            numUpDownExposureTime = numUpDown;
            trBarExposureTime = trBar;
            
            numUpDown.Minimum = VALUE_MIN_EXPOSURETIME;
            numUpDown.Maximum = VALUE_MAX_EXPOSURETIME;

            trBar.Minimum = VALUE_MIN_EXPOSURETIME;
            trBar.Maximum = VALUE_MAX_EXPOSURETIME;

            safeControlEvent += new safeControlDelegate(Enable);

            Events();
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
        /// This event is executed when the user select a camera in <see cref="CameraManager">CameraManager</see>/> or 
        /// <see cref="PanelManager">PanelManager</see>/>.
        /// </summary>
        public void SelectCam(Camera camera)
        {
            camera_selected = camera;

            InitValue();
        }

        /// <summary>
        /// Este método inicializa los valores de frame rate de la cámara que se conecta.
        /// </summary>
        private void InitValue()
        {
            DisconnectnumUpDownExposureTime();
            DisconnecttrBarExposureTime();

            double exposureTime = (camera_selected as Basler).ExposureTime();
            //exposureTime = exposureTime / 1000;
            double value = VALUE_MIN_EXPOSURETIME > exposureTime ? VALUE_MIN_EXPOSURETIME : exposureTime;
            value = VALUE_MAX_EXPOSURETIME < value ? VALUE_MAX_EXPOSURETIME : value;

            numUpDownExposureTime.Value = (decimal)value;
            trBarExposureTime.Value = (int)value;

            ConnectnumUpDownExposureTime();
            ConnecttrBarExposureTime();
        }

        /******************** LIMIT VALUE CONTROLS ********************/
        /**************************************************************/
        /**************************************************************/

        /// <summary>
        /// Esta función limita el límite superior del control <see cref="numUpDownExposureTime">numUpDownExposureTime</see>/>.
        /// </summary>
        /// <param name="value">Valor que quieres establecer.</param>
        private void LimitNumericUpDown(double value)
        {
            numUpDownExposureTime.Maximum = 0;/*(decimal)value;*/
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
        /// This function calculate the max exposure time for a frame rate value.
        /// </summary>
        /// <param name="frameRate">Frame rate of the camera.</param>
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

        /******************* CHANGE VALUE CONTROLS ********************/
        /**************************************************************/
        /**************************************************************/

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
            if (camera_selected != null)
                (camera_selected as Basler).ExposureTime((double)value);
        }

        /**************** CONNECT AND DISCONNECT CONTROLS *************/
        /**************************************************************/
        /**************************************************************/

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
