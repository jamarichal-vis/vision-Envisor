using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;

namespace Recording
{
    class SequenceManager
    {
        /// <summary>
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        private Id id;

        /// <summary>
        /// Esta variable almacena el contorl numeriUpDown que controla el número de frames totales que se quieren grabar.
        /// </summary>
        private NumericUpDown numericUpTotalFrames;

        /// <summary>
        /// Esta variable almacena el contorl numeriUpDown que controla el número de frames que se grabarán en pre o post trigger.
        /// La decisión de pre o post trigger estará dirigida por 
        /// </summary>
        private NumericUpDown numericUpTrigger;

        /// <summary>
        /// Esta variable almacena el contorl numeriUpDown que controla el número de frames totales que se quieren grabar.
        /// </summary>
        private NumericUpDown numericUpPositionTrigger;

        /// <summary>
        /// Esta variable almacena el contorl comboBox que decide si el valor del control <see cref="numericUpTrigger">numericUpTrigger</see>/> es en referencia al pre o post trigger.
        /// </summary>
        private ComboBox cBoxTrigger;

        /// <summary>
        /// Esta variable almacena el contorl track bar que controla la posición del post trigger en función del número total de frames.
        /// </summary>
        private TrackBar trackBarPositionTrigger;

        /// <summary>
        /// Esta variable almacena el contorl label que indica el número de frames máximos que se van a grabar.
        /// </summary>
        private Label lbMaxFrames;

        /// <summary>
        /// Esta variable almacena el número total de frames.
        /// </summary>
        private double totalFrames;

        /// <summary>
        /// Esta variable almacena el número de frames que se guardan de pre trigger.
        /// </summary>
        private double preTrigger;

        /// <summary>
        /// Esta variable almacena el número de frames que se guardan de post trigger.
        /// </summary>
        private double postTrigger;

        public SequenceManager(ref Id id, ref NumericUpDown numericUpTotalFrames, ref NumericUpDown numericUpTrigger, ref NumericUpDown numericUpPositionTrigger,
            ref ComboBox cBoxTrigger, ref TrackBar trackBarPositionTrigger, ref Label lbMaxFrames)
        {
            this.id = id;

            this.numericUpTotalFrames = numericUpTotalFrames;
            this.numericUpTrigger = numericUpTrigger;
            this.numericUpPositionTrigger = numericUpPositionTrigger;
            this.cBoxTrigger = cBoxTrigger;
            this.trackBarPositionTrigger = trackBarPositionTrigger;
            this.lbMaxFrames = lbMaxFrames;

            this.numericUpTrigger.Value = 100;
            this.numericUpPositionTrigger.Value = 0;
            this.trackBarPositionTrigger.Value = 0;

            Events();

            this.cBoxTrigger.SelectedIndex = 1;
            this.numericUpTotalFrames.Value = 100;
        }

        /// <summary>
        /// Esta función almacenará todos los eventos de los controles que controle esta clase.
        /// </summary>
        public void Events()
        {
            ConnectNumUpDownTotalFrames();
            ConnectNumUpDownTrigger();
            ConnectCBoxTrigger();
            ConnectNumUpDownPositionTrigger();
            ConnectTrBarPositionTrigger();
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/>;
        /// </summary>
        private void ConnectNumUpDownTotalFrames()
        {
            numericUpTotalFrames.ValueChanged += new System.EventHandler(numUpDownTotalFrame_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/>;
        /// </summary>
        private void DisconnectNumUpDownTotalFrames()
        {
            numericUpTotalFrames.ValueChanged -= new System.EventHandler(numUpDownTotalFrame_ValueChanged);
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="numericUpTrigger">numericUpTrigger</see>/>;
        /// </summary>
        private void ConnectNumUpDownTrigger()
        {
            numericUpTrigger.ValueChanged += new System.EventHandler(numUpDownTrigger_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="numericUpTrigger">numericUpTrigger</see>/>;
        /// </summary>
        private void DisconnectNumUpDownTrigger()
        {
            numericUpTrigger.ValueChanged -= new System.EventHandler(numUpDownTrigger_ValueChanged);
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="numericUpPositionTrigger">numericUpPositionTrigger</see>/>;
        /// </summary>
        private void ConnectNumUpDownPositionTrigger()
        {
            numericUpPositionTrigger.ValueChanged += new System.EventHandler(numUpDownPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="numericUpPositionTrigger">numericUpPositionTrigger</see>/>;
        /// </summary>
        private void DisconnectNumUpDownPositionTrigger()
        {
            numericUpPositionTrigger.ValueChanged -= new System.EventHandler(numUpDownPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="cBoxTrigger">cBoxTrigger</see>/>;
        /// </summary>
        private void ConnectCBoxTrigger()
        {
            cBoxTrigger.SelectedIndexChanged += new System.EventHandler(this.CBoxTrigger_SelectedIndexChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="cBoxTrigger">cBoxTrigger</see>/>;
        /// </summary>
        private void DiconnectCBoxTrigger()
        {
            cBoxTrigger.SelectedIndexChanged -= new System.EventHandler(this.CBoxTrigger_SelectedIndexChanged);
        }

        /// <summary>
        /// Esta función conecta el evento ValueChanged del control <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/>;
        /// </summary>
        private void ConnectTrBarPositionTrigger()
        {
            trackBarPositionTrigger.ValueChanged += new System.EventHandler(trackBarPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// Esta función desconecta el evento ValueChanged del control <see cref="trBarFrameRate">trBarFrameRate</see>/>;
        /// </summary>
        private void DisconnectTrBarPositionTrigger()
        {
            trackBarPositionTrigger.ValueChanged -= new System.EventHandler(trackBarPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)
        {
            totalFrames = (double)numericUpTotalFrames.Value;
            lbMaxFrames.Text = ((double)numericUpTotalFrames.Value).ToString();

            postTrigger = totalFrames * (100 - (double)numericUpPositionTrigger.Value) / 100;
            preTrigger = totalFrames - postTrigger;

            DisconnectNumUpDownTrigger();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            ConnectNumUpDownTrigger();
        }
        
        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numericUpTrigger">numericUpTrigger</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownTrigger_ValueChanged(object sender, EventArgs e)
        {
            double percentage = 0;

            if (cBoxTrigger.Text == "Pre-Trigger")
            {
                preTrigger = (double)numericUpTrigger.Value;

                if (preTrigger > totalFrames)
                    preTrigger = totalFrames;

                postTrigger = totalFrames - preTrigger;

                percentage = 100 - (postTrigger * 100 / totalFrames);
            }
            else if (cBoxTrigger.Text == "Post-Trigger")
            {
                postTrigger = (double)numericUpTrigger.Value;

                if (postTrigger > totalFrames)
                    postTrigger = totalFrames;

                preTrigger = totalFrames - postTrigger;

                percentage = 100 - (postTrigger * 100 / totalFrames);
            }
                
            DisconnectNumUpDownPositionTrigger();
            DisconnectTrBarPositionTrigger();

            numericUpPositionTrigger.Value = (decimal)percentage;
            trackBarPositionTrigger.Value = (int)percentage;

            ConnectNumUpDownPositionTrigger();
            ConnectTrBarPositionTrigger();
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numericUpPositionTrigger">numericUpPositionTrigger</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownPositionTrigger_ValueChanged(object sender, EventArgs e)
        {

            postTrigger = totalFrames * (100 - (double)numericUpPositionTrigger.Value) / 100;
            preTrigger = totalFrames - postTrigger;

            DisconnectNumUpDownTrigger();
            DisconnectTrBarPositionTrigger();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            trackBarPositionTrigger.Value = (int)numericUpPositionTrigger.Value;

            ConnectNumUpDownTrigger();
            ConnectTrBarPositionTrigger();
        }

        private void CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisconnectNumUpDownTrigger();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            ConnectNumUpDownTrigger();
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarPositionTrigger_ValueChanged(object sender, EventArgs e)
        {
            postTrigger = totalFrames * (100 - (double)numericUpPositionTrigger.Value) / 100;
            preTrigger = totalFrames - postTrigger;

            DisconnectNumUpDownTrigger();
            DisconnectNumUpDownPositionTrigger();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            numericUpPositionTrigger.Value = (decimal)trackBarPositionTrigger.Value;

            ConnectNumUpDownTrigger();
            ConnectNumUpDownPositionTrigger();
        }
    }
}
