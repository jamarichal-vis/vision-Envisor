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
    class ButtonsTools
    {
        Form form;

        ToolStripMenuItem btnSingleShot;
        ToolStripMenuItem btnGrabContinuous;
        ToolStripMenuItem btnPause;
        ToolStripMenuItem btnRecord;
        ToolStripMenuItem btnStopRecord;
        ToolStripMenuItem btnResetZoom;

        ToolStripMenuItem btnGraphics;
        ToolStripMenuItem btnLine;
        ToolStripMenuItem btnPoint;
        ToolStripMenuItem btnElipse;
        ToolStripMenuItem btnRectangle;
        ToolStripMenuItem btnPolygon;

        public delegate void safeControlDelegate(ToolStripMenuItem toolStripMenuItem, bool state);
        public safeControlDelegate safeControlEvent;

        public ToolStripMenuItem BtnSingleShot { get => btnSingleShot; set => btnSingleShot = value; }
        public ToolStripMenuItem BtnGrabContinuous { get => btnGrabContinuous; set => btnGrabContinuous = value; }
        public ToolStripMenuItem BtnPause { get => btnPause; set => btnPause = value; }
        public ToolStripMenuItem BtnRecord { get => btnRecord; set => btnRecord = value; }
        public ToolStripMenuItem BtnStopRecord { get => btnStopRecord; set => btnStopRecord = value; }
        public ToolStripMenuItem BtnResetZoom { get => btnResetZoom; set => btnResetZoom = value; }
        public ToolStripMenuItem BtnLine { get => btnLine; set => btnLine = value; }
        public ToolStripMenuItem BtnPoint { get => btnPoint; set => btnPoint = value; }
        public ToolStripMenuItem BtnElipse { get => btnElipse; set => btnElipse = value; }
        public ToolStripMenuItem BtnRectangle { get => btnRectangle; set => btnRectangle = value; }
        public ToolStripMenuItem BtnPolygon { get => btnPolygon; set => btnPolygon = value; }
        public ToolStripMenuItem BtnGraphics { get => btnGraphics; set => btnGraphics = value; }

        public ButtonsTools(Form form, ref ToolStripMenuItem btnSingleShot,ref ToolStripMenuItem btnGrabContinuous, ref ToolStripMenuItem btnPause, ref ToolStripMenuItem btnRecord,
         ref ToolStripMenuItem btnResetZoom, ref ToolStripMenuItem btnStopRecord,
         ref ToolStripMenuItem btnGraphics, ref ToolStripMenuItem btnLine, ref ToolStripMenuItem btnPoint, ref ToolStripMenuItem btnElipse, ref ToolStripMenuItem btnRectangle, 
         ref ToolStripMenuItem btnPolygon)
        {
            this.form = form;

            this.btnSingleShot = btnSingleShot;
            this.btnGrabContinuous = btnGrabContinuous;
            this.btnPause = btnPause;
            this.btnRecord = btnRecord;
            this.btnResetZoom = btnResetZoom;
            this.btnStopRecord = btnStopRecord;

            this.btnGraphics = btnGraphics;
            this.btnLine = btnLine;
            this.btnPoint = btnPoint;
            this.btnElipse = btnElipse;
            this.btnRectangle = btnRectangle;
            this.btnPolygon = btnPolygon;

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
        /// Esta función modifica el estado de la variable Enable del control <see cref="btnResetZoom">btnResetZoom</see>/>.
        /// </summary>
        /// <param name="state">Esta que se quiere establecer.</param>
        public void ResetZoom(bool state = true)
        {
            btnResetZoom.Enabled = state;
        }

        /// <summary>
        /// This method set the property Enable of the graphics buttons.
        /// </summary>
        /// <param name="state"></param>
        public void Graphics(bool state = true)
        {
            form.Invoke(safeControlEvent, new object[] { btnGraphics, state });
            form.Invoke(safeControlEvent, new object[] { btnLine, state });
            form.Invoke(safeControlEvent, new object[] { btnPoint, state });
            form.Invoke(safeControlEvent, new object[] { btnElipse, state });
            form.Invoke(safeControlEvent, new object[] { btnRectangle, state });
            form.Invoke(safeControlEvent, new object[] { btnPolygon, state });

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
