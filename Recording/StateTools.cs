using System;
using System.Collections.Generic;
using System.Linq;
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
        ToolStripMenuItem btnSingleShot;
        ToolStripMenuItem btnGrabContinuous;
        ToolStripMenuItem btnPause;
        ToolStripMenuItem btnRecord;
        ToolStripMenuItem btnZoomLess;
        ToolStripMenuItem btnZoomPlus;
        ToolStripMenuItem btnResetZoom;

        public StateTools(ref ToolStripMenuItem btnSingleShot,ref ToolStripMenuItem btnGrabContinuous, ref ToolStripMenuItem btnPause, ref ToolStripMenuItem btnRecord,
            ref ToolStripMenuItem btnZoomLess, ref ToolStripMenuItem btnZoomPlus, ref ToolStripMenuItem btnResetZoom)
        {
            this.btnSingleShot = btnSingleShot;
            this.btnGrabContinuous = btnGrabContinuous;
            this.btnPause = btnPause;
            this.btnRecord = btnRecord;
            this.btnZoomLess = btnZoomLess;
            this.btnZoomPlus = btnZoomPlus;
            this.btnResetZoom = btnResetZoom;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnSingleShot">btnSingleShot</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void SingleShot(bool state = true)
        {
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
            btnPause.Enabled = state;
        }

        /// <summary>
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnRecord">btnRecord</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void Record(bool state = true)
        {
            btnRecord.Enabled = state;
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
    }
}
