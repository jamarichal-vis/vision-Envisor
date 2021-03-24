using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording
{
    /// <summary>
    /// Esta clase esta diseñada para modificar el estado de los botones.
    /// </summary>
    class StateTools
    {
        Form form;

        ToolStripMenuItem btnSingleShot;
        ToolStripMenuItem btnGrabContinuous;
        ToolStripMenuItem btnPause;
        ToolStripMenuItem btnRecord;
        ToolStripMenuItem btnStopRecord;
        ToolStripMenuItem btnZoomLess;
        ToolStripMenuItem btnZoomPlus;
        ToolStripMenuItem btnResetZoom;

        public delegate void safeControlDelegate(ToolStripMenuItem toolStripMenuItem, bool state);
        public safeControlDelegate safeControlEvent;

        public StateTools(Form form, ref ToolStripMenuItem btnSingleShot,ref ToolStripMenuItem btnGrabContinuous, ref ToolStripMenuItem btnPause, ref ToolStripMenuItem btnRecord,
            ref ToolStripMenuItem btnZoomLess, ref ToolStripMenuItem btnZoomPlus, ref ToolStripMenuItem btnResetZoom, ref ToolStripMenuItem btnStopRecord)
        {
            this.form = form;

            this.btnSingleShot = btnSingleShot;
            this.btnGrabContinuous = btnGrabContinuous;
            this.btnPause = btnPause;
            this.btnRecord = btnRecord;
            this.btnZoomLess = btnZoomLess;
            this.btnZoomPlus = btnZoomPlus;
            this.btnResetZoom = btnResetZoom;
            this.btnStopRecord = btnStopRecord;

            safeControlEvent += new safeControlDelegate(StateControl);
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnSingleShot">btnSingleShot</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void SingleShot(bool state = true)
        {
            form.Invoke(safeControlEvent, new object[] { btnSingleShot, state });
            btnSingleShot.Enabled = state;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnGrabContinuous">btnGrabContinuous</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void GrabContinuous(bool state = true)
        {
            btnGrabContinuous.Enabled = state;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnPause">btnPause</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void Pause(bool state = true)
        {
            form.Invoke(safeControlEvent, new object[] { btnPause, state });
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnRecord">btnRecord</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void Record(bool state = true)
        {
            form.Invoke(safeControlEvent, new object[] { btnRecord, state });

            btnRecord.Enabled = state;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnStopRecord">btnStopRecord</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void StopRecord(bool state = true)
        {
            form.Invoke(safeControlEvent, new object[] { btnStopRecord, state });
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnZoomLess">btnZoomLess</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void ZoomLess(bool state = true)
        {
            btnZoomLess.Enabled = state;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnZoomPlus">btnZoomPlus</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void ZoomPlus(bool state = true)
        {
            btnZoomPlus.Enabled = state;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnResetZoom">btnResetZoom</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void ResetZoom(bool state = true)
        {
            btnResetZoom.Enabled = state;
        }

        private void StateControl(ToolStripMenuItem toolStripMenuItem, bool state)
        {
            toolStripMenuItem.Enabled = state;
        }

        /// <summary>
        /// Función para cambiar los controles en threads separados de forma segura (Invoke)
        /// </summary>
        /// <param name="control"> Control del formulario a cambiar </param>
        /// <param name="propertyName"> Nombre de la propiedad a cambiar como STRING </param>
        /// <param name="propertyValue"> Valor que deseamos cambiar al control </param>
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
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
    }
}
