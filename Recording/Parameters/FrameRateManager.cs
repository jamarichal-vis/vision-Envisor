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
        NumericUpDown numUpDownFrameRate;

        /// <summary>
        /// Esta variable almacena el control TrackBar que se quiere controlar en esta clase.
        /// </summary>
        TrackBar trBarFrameRate;

        /// <summary>
        /// Este atributo almacena el label donde se muestra el número máximo de fps de la cámara.
        /// </summary>
        Label lbMaxFrameRate;

        /// <summary>
        /// Este evento es utilizado para acceder de forma segura a los atributos de un control desde otro hilo.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="state"></param>
        public delegate void safeControlDelegate(Control control, bool state);
        public safeControlDelegate safeControlEvent;
        
        /// <summary>
        /// Este evento es utilizado notificar a los demás módulos que se ha modificado el frame rate.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="state"></param>
        public delegate void changeFrameRateDelegate(double value);
        public changeFrameRateDelegate changeFrameRateEvent;

        public FrameRateManager(Form form, ref TableLayoutPanel tableLayoutPanel, ref NumericUpDown numUpDown, ref TrackBar trBar, ref Label lbMax)
        {
            this.form = form;
            
            tbLayoutPanel = tableLayoutPanel;
            numUpDownFrameRate = numUpDown;
            trBarFrameRate = trBar;
            lbMaxFrameRate = lbMax;
            
            safeControlEvent += new safeControlDelegate(Enable);

            Events();
        }

        /// <summary>
        /// This method is executed when the user select a camera in <see cref="CameraManager">CameraManager</see>/> or 
        /// <see cref="PanelManager">PanelManager</see>/>.
        /// </summary>
        public void SelectCam(Camera camera)
        {
            camera_selected = camera;

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
        /// Esta función almacenará todos los eventos de los controles que controle esta clase.
        /// </summary>
        private void Events()
        {
            ConnectNumUpDownFrameRate();
            ConnectTrBarFrameRate();
        }

        /// <summary>
        /// Este método inicializa los valores de frame rate de la cámara que se conecta.
        /// </summary>
        private void InitValue()
        {
            if(camera_selected != null)
            {
                DisconnectNumUpDownFrameRate();
                DisconnectTrBarFrameRate();

                /* MAX */
                double max = 40/*milApp.CamMaxFrameRate(idCam.DevNSys, idCam.DevNCam)*/;

                LimitTrBar(max);
                lbMaxFrameRate.Text = Math.Round(max).ToString();
                
                double frameRate = camera_selected.FrameRate();
                
                if (frameRate > max)
                    frameRate = max;

                numUpDownFrameRate.Value = (decimal)frameRate;
                trBarFrameRate.Value = (int)frameRate;

                if(changeFrameRateEvent != null)
                changeFrameRateEvent.Invoke(frameRate);

                ConnectNumUpDownFrameRate();
                ConnectTrBarFrameRate();
            }
        }

        /******************** LIMIT VALUE CONTROLS ********************/
        /**************************************************************/
        /**************************************************************/

        /// <summary>
        /// Esta función limita el límite superior del control <see cref="numUpDownFrameRate">numUpDownFrameRate</see>/>.
        /// </summary>
        /// <param name="value">Valor que quieres establecer.</param>
        private void LimitNumericUpDown(double value)
        {
            numUpDownFrameRate.Maximum = (decimal)value;
        }

        /// <summary>
        /// Esta función limita el límite superior del control <see cref="trBarFrameRate">trBarFrameRate</see>/>.
        /// </summary>
        /// <param name="value">Valor que quieres establecer.</param>
        private void LimitTrBar(double value)
        {
            trBarFrameRate.Maximum = (int)value;
        }

        /******************* CHANGE VALUE CONTROLS ********************/
        /**************************************************************/
        /**************************************************************/

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

            if (changeFrameRateEvent != null)
                changeFrameRateEvent.Invoke((double)trBarFrameRate.Value);

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

            if (changeFrameRateEvent != null)
                changeFrameRateEvent.Invoke((double)numUpDownFrameRate.Value);

            ChangeFrameRate((long)trBarFrameRate.Value);
        }
        
        /// <summary>
        /// This method change the frame rate of the <see cref="camera_selected">camera_selected</see>/>.
        /// </summary>
        /// <param name="value"></param>
        private void ChangeFrameRate(long value)
        {
            if (camera_selected != null)
                camera_selected.FrameRate(value);
        }

        /**************** CONNECT AND DISCONNECT CONTROLS *************/
        /**************************************************************/
        /**************************************************************/

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
