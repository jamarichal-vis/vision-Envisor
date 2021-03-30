using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilLibrary;
using Matrox.MatroxImagingLibrary;

namespace Recording
{
    class FormatManager
    {
        /// <summary>
        /// This variable storages the <see cref="Recording">Recording</see>/> form.
        /// </summary>
        private Form form;

        /// <summary>
        /// This variable storages the camera select by user.
        /// It is used to connect all modules of the program.
        /// </summary>
        private Camera camera_selected;

        /// <summary>
        /// This variable storages the table layout of this module.
        /// </summary>
        TableLayoutPanel tbLayoutPanel;

        /// <summary>
        /// This variable storages the combo box where the user can change the format of a camera.
        /// </summary>
        ComboBox cBoxFormat;

        /// <summary>
        /// This variable storages the control to modify the size X of a camera.
        /// </summary>
        NumericUpDown numUpDownSizeX;

        /// <summary>
        /// This variable storages the control to modify the size X of a camera.
        /// </summary>
        NumericUpDown numUpDownSizeY;

        /// <summary>
        /// Este evento es utilizado para acceder de forma segura a los atributos de un control desde otro hilo.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="state"></param>
        public delegate void safeControlDelegate(Control control, bool state);
        public safeControlDelegate safeControlEvent;

        public delegate void changeResolutionDelegate(Camera camera);
        public changeResolutionDelegate changeResolutionEvent;

        public FormatManager(Form form, ref TableLayoutPanel tableLayoutPanel, ref NumericUpDown numUpDownSizeX, ref NumericUpDown numUpDownSizeY)
        {
            this.form = form;

            this.tbLayoutPanel = tableLayoutPanel;
            this.numUpDownSizeX = numUpDownSizeX;
            this.numUpDownSizeY = numUpDownSizeY;

            ConnectNumUpDownSizeX();
            ConnectNumUpDownSizeY();

            safeControlEvent += new safeControlDelegate(Enable);
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
        /// This method is executed when the user select a camera in <see cref="CameraManager">CameraManager</see>/> or 
        /// <see cref="PanelManager">PanelManager</see>/>.
        /// </summary>
        public void SelectCam(Camera camera)
        {
            camera_selected = camera;

            SetMaxSize();
            InitValue();
        }

        /// <summary>
        /// This method set the maximun value in <see cref="numUpDownSizeX">numUpDownSizeX</see>/> and <see cref="numUpDownSizeY">numUpDownSizeY</see>/>.
        /// </summary>
        private void SetMaxSize()
        {
            if (camera_selected != null)
            {
                Dictionary<string, MIL_INT> size = camera_selected.MaxSize();

                numUpDownSizeX.Maximum = size["Width"];
                numUpDownSizeY.Maximum = size["Height"];
            }
        }

        /// <summary>
        /// This method initializer the values in the controls of this class.
        /// </summary>
        public void InitValue()
        {
            if (camera_selected != null)
            {
                DisconnectNumUpDownSizeX();
                DisconnectNumUpDownSizeY();

                Dictionary<string, MIL_INT> size = camera_selected.Size();

                numUpDownSizeX.Value = size["Width"];
                numUpDownSizeY.Value = size["Height"];

                ConnectNumUpDownSizeX();
                ConnectNumUpDownSizeY();
            }
        }

        /**************** CONNECT AND DISCONNECT CONTROLS *************/
        /**************************************************************/
        /**************************************************************/

        /// <summary>
        /// This method connect <see cref="numUpDownSizeX">numUpDownSizeX</see>/> control to this class.;
        /// </summary>
        private void ConnectNumUpDownSizeX()
        {
            numUpDownSizeX.ValueChanged += new System.EventHandler(numUpDownSizeX_ValueChanged);
        }

        /// <summary>
        /// This method connect <see cref="numUpDownSizeY">numUpDownSizeY</see>/> control to this class.;
        /// </summary>
        private void ConnectNumUpDownSizeY()
        {
            numUpDownSizeY.ValueChanged += new System.EventHandler(numUpDownSizeY_ValueChanged);
        }

        /// <summary>
        /// This method connect <see cref="numUpDownSizeX">numUpDownSizeX</see>/> control to this class.;
        /// </summary>
        private void DisconnectNumUpDownSizeX()
        {
            numUpDownSizeX.ValueChanged -= new System.EventHandler(numUpDownSizeX_ValueChanged);
        }

        /// <summary>
        /// This method connect <see cref="numUpDownSizeY">numUpDownSizeY</see>/> control to this class.;
        /// </summary>
        private void DisconnectNumUpDownSizeY()
        {
            numUpDownSizeY.ValueChanged -= new System.EventHandler(numUpDownSizeY_ValueChanged);
        }

        /******************* CHANGE VALUE CONTROLS ********************/
        /**************************************************************/
        /**************************************************************/

        /// <summary>
        /// This method is executed when the user change value in <see cref="numUpDownSizeX">numUpDownSizeX</see>/> control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownSizeX_ValueChanged(object sender, EventArgs e)
        {
            ChangeSize();
        }

        /// <summary>
        /// This method is executed when the user change value in <see cref="numUpDownSizeY">numUpDownSizeY</see>/> control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownSizeY_ValueChanged(object sender, EventArgs e)
        {
            ChangeSize();
        }

        /// <summary>
        /// This method update the size of the <see cref="camera_selected">camera_selected</see>/> with value in
        /// <see cref="numUpDownSizeX">numUpDownSizeX</see>/> and <see cref="numUpDownSizeY">numUpDownSizeY</see>/>.
        /// </summary>
        private void ChangeSize()
        {
            if (camera_selected != null)
            {
                camera_selected.Size((MIL_INT)numUpDownSizeX.Value, (MIL_INT)numUpDownSizeY.Value);

                if (changeResolutionEvent != null)
                    changeResolutionEvent.Invoke(camera_selected);
            }
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
