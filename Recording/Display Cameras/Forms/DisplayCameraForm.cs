using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording
{
    public partial class DisplayCameraForm : Form
    {
        private DisplayCamera displayCamera;

        /// <summary>
        /// Este evento es utilizado para indicar que el formulario se va a cerrar.
        /// </summary>
        /// <param name="id">Id del visualizador que se quiere cerrar.</param>
        public delegate void notifyCloseDelegate(Id id);
        public event notifyCloseDelegate notifyCloseDownEvent;

        public delegate void safeControlDelegate(Button toolStripMenuItem, bool state);
        public safeControlDelegate safeControlEvent;

        public DisplayCameraForm()
        {
            InitializeComponent();

            safeControlEvent += new safeControlDelegate(StateControl);
        }

        public DisplayCamera DisplayCamera { get => displayCamera; set => displayCamera = value; }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            DisplayCamera.Pause();
            notifyCloseDownEvent.Invoke(DisplayCamera.IdCam);
        }

        public virtual void EnableBtnClose(bool state) { }

        protected void StateControl(Button button, bool state)
        {
            button.Enabled = state;
        }
    }
}
