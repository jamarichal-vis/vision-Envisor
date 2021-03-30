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
        /// This variable storages the unites of time in this module.
        /// </summary>
        const string UNITS_TIME = "s";

        /// <summary>
        /// This variable storages the unites of frames in this module.
        /// </summary>
        const string UNITS_FRAMES = "frm";
        
        /// <summary>
        /// This variable storages the unites of time in this module.
        /// </summary>
        const string MODE_TIME = "TIME";

        /// <summary>
        /// This variable storages the unites of frames in this module.
        /// </summary>
        const string MODE_FRAMES = "FRAMES";

        /// <summary>
        /// This variable storages the numericUpDown control where it manages the total time or number frames.
        /// </summary>
        private NumericUpDown numericUpTotal;

        /// <summary>
        /// This variable storages the numericUpDown control where it manages the value of the pre or post trigger.
        /// </summary>
        private NumericUpDown numericUpTrigger;

        /// <summary>
        /// This variable storages the numericUpDown control where it manages the value of <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/>.
        /// </summary>
        private NumericUpDown numericUpPositionTrigger;

        /// <summary>
        /// This variable storages the comboBox control where it manages the units of pre or post trigger, time or number of frames.
        /// </summary>
        private ComboBox cBoxUnits;

        // <summary>
        /// This variable storages the comboBox control where it manages the value of pre and post trigger.
        /// </summary>
        private ComboBox cBoxTrigger;

        /// <summary>
        /// This variable storages the track bar control where it manages the position of the trigger.
        /// </summary>
        private TrackBar trackBarPositionTrigger;

        /// <summary>
        /// This variable storages the label where it will shown the units of total value of pre or post trigger.
        /// </summary>
        private Label lbTotalUnits;

        /// <summary>
        /// This variable storages the label where it will shown the units of value of pre or post trigger.
        /// </summary>
        private Label lbTriggerUnits;

        /// <summary>
        /// This variable storages the label where it will shown the max value of <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/>.
        /// </summary>
        private Label lbMaxTrackBar;

        /// <summary>
        /// This variable storages the mode of the pre and post trigger. The mode could be Time or number of the frames.
        /// </summary>
        private string mode_trigger;

        /// <summary>
        /// This variable storages the max time or frames the user want to record.
        /// </summary>
        private double total;

        /// <summary>
        /// Esta variable almacena el número de frames que se guardan de pre trigger.
        /// </summary>
        private double preTrigger;

        /// <summary>
        /// Esta variable almacena el número de frames que se guardan de post trigger.
        /// </summary>
        private double postTrigger;

        /// <summary>
        /// Esta variable almacena toda la configuración para poder grabar un vídeo o una secuencia con una cámara.
        /// </summary>
        private RecordSettings recordSettings;

        public RecordSettings RecordSettings { get => recordSettings; set => recordSettings = value; }

        public SequenceManager(ref ComboBox cBoxUnits, ref NumericUpDown numericUpDownTotal, ref Label lbTotalUnits,
            ref ComboBox cBoxTypetrigger, ref NumericUpDown numericUpDownTrigger, ref Label lbTriggerUnit, 
            ref NumericUpDown numericUpDownPosition, ref TrackBar trBarPosition, ref Label lbMaxTrBar)
        {
            InitModeControl(cboxUnits: ref cBoxUnits);
            InitTotalsControl(numericUpTotal: ref numericUpDownTotal, lbTotal: ref lbTotalUnits);
            InitTrigger(comboBox: ref cBoxTypetrigger, numericUpDown: ref numericUpDownTrigger, lbUnits: ref lbTriggerUnit);
            InitPositionTrigger(numericUpDown: ref numericUpDownPosition, trBar: ref trBarPosition, lbMaxTrBar: ref lbMaxTrBar);

            DisconnectEvents();
            InitValue_Frames();
            ConnectEvents();

            UpdateRecordingSettings();
        }

        private void InitModeControl(ref ComboBox cboxUnits)
        {
            this.cBoxUnits = cboxUnits;

            cBoxUnits.SelectedIndex = 0;

            ConnectCBoxUnit();
        }
        
        private void InitTotalsControl(ref NumericUpDown numericUpTotal, ref Label lbTotal)
        {
            this.numericUpTotal = numericUpTotal;
            this.lbTotalUnits = lbTotal;

            ConnectNumUpDownTotal();
        }

        private void InitTrigger(ref ComboBox comboBox, ref NumericUpDown numericUpDown, ref Label lbUnits)
        {
            this.cBoxTrigger = comboBox;
            this.numericUpTrigger = numericUpDown;
            this.lbTriggerUnits = lbUnits;

            ConnectCBoxTrigger();
            ConnectNumUpDownTrigger();
        }

        private void InitPositionTrigger(ref NumericUpDown numericUpDown, ref TrackBar trBar, ref Label lbMaxTrBar)
        {
            this.numericUpPositionTrigger = numericUpDown;
            this.trackBarPositionTrigger = trBar;
            this.lbMaxTrackBar = lbMaxTrBar;

            ConnectNumUpDownPosition();
            ConnectTrBarPositionTrigger();
        }

        /******************* EVENT FUNCTIONS *********************/
        /*********************************************************/
        /*********************************************************/

        /// <summary>
        /// This method connect all events of the controls manage in this class.
        /// </summary>
        private void ConnectEvents()
        {
            ConnectCBoxUnit();
            ConnectNumUpDownTotal();
            ConnectCBoxTrigger();
            ConnectNumUpDownTrigger();
            ConnectNumUpDownPosition();
            ConnectTrBarPositionTrigger();
        }

        /// <summary>
        /// This method disconnect all events of the controls manage in this class.
        /// </summary>
        private void DisconnectEvents()
        {
            DisconnectCBoxUnit();
            DisconnectNumUpDownTotal();
            DisconnectCBoxTrigger();
            DisconnectNumUpDownTrigger();
            DisconnectNumUpDownPosition();
            DisconnectTrBarPositionTrigger();
        }

        /// <summary>
        /// This method connect the event ValueChanged of <see cref="cBoxUnits">numericUpTotalFrames</see>/> control with 
        /// <see cref="CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)">CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void ConnectCBoxUnit()
        {
            cBoxUnits.SelectedIndexChanged += new System.EventHandler(this.CBoxUnits_SelectedIndexChanged);
        }

        /// <summary>
        /// This method disconnect the event ValueChanged of <see cref="cBoxUnits">numericUpTotalFrames</see>/> control with 
        /// <see cref="CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)">CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void DisconnectCBoxUnit()
        {
            cBoxUnits.SelectedIndexChanged -= new System.EventHandler(this.CBoxUnits_SelectedIndexChanged);
        }

        /// <summary>
        /// This method connect the event ValueChanged of <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/> control with 
        /// <see cref="numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)">numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void ConnectNumUpDownTotal()
        {
            numericUpTotal.ValueChanged += new System.EventHandler(numUpDownTotalFrame_ValueChanged);
        }
        
        /// <summary>
        /// This method disconnect the event ValueChanged of <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/> control with 
        /// <see cref="numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)">numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void DisconnectNumUpDownTotal()
        {
            numericUpTotal.ValueChanged -= new System.EventHandler(numUpDownTotalFrame_ValueChanged);
        }

        /// <summary>
        /// This method connect the event ValueChanged of <see cref="cBoxUnits">numericUpTotalFrames</see>/> control with 
        /// <see cref="CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)">CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void ConnectCBoxTrigger()
        {
            cBoxTrigger.SelectedIndexChanged += new System.EventHandler(this.CBoxTrigger_SelectedIndexChanged);
        }

        /// <summary>
        /// This method disconnect the event ValueChanged of <see cref="cBoxUnits">numericUpTotalFrames</see>/> control with 
        /// <see cref="CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)">CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void DisconnectCBoxTrigger()
        {
            cBoxTrigger.SelectedIndexChanged -= new System.EventHandler(this.CBoxTrigger_SelectedIndexChanged);
        }

        /// <summary>
        /// This method connect the event ValueChanged of <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/> control with 
        /// <see cref="numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)">numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void ConnectNumUpDownTrigger()
        {
            numericUpTrigger.ValueChanged += new System.EventHandler(numUpDownTrigger_ValueChanged);
        }

        /// <summary>
        /// This method disconnect the event ValueChanged of <see cref="numericUpTrigger">numericUpTrigger</see>/> control with 
        /// <see cref="numUpDownTrigger_ValueChanged(object, EventArgs)">numUpDownTrigger_ValueChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void DisconnectNumUpDownTrigger()
        {
            numericUpTrigger.ValueChanged -= new System.EventHandler(numUpDownTrigger_ValueChanged);
        }

        /// <summary>
        /// This method connect the event ValueChanged of <see cref="numericUpPositionTrigger">numericUpPositionTrigger</see>/> control with 
        /// <see cref="numUpDownPositionTrigger_ValueChanged(object, EventArgs)">numUpDownPositionTrigger_ValueChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void ConnectNumUpDownPosition()
        {
            numericUpPositionTrigger.ValueChanged += new System.EventHandler(numUpDownPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// This method disconnect the event ValueChanged of <see cref="numericUpTrigger">numericUpTrigger</see>/> control with 
        /// <see cref="numUpDownTrigger_ValueChanged(object, EventArgs)">numUpDownTrigger_ValueChanged(object sender, EventArgs e)</see>/>.
        /// </summary>
        private void DisconnectNumUpDownPosition()
        {
            numericUpPositionTrigger.ValueChanged -= new System.EventHandler(numUpDownPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// This method connect the event ValueChanged of <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/> control with 
        /// <see cref="trackBarPositionTrigger_ValueChanged(object, EventArgs)">trackBarPositionTrigger_ValueChanged(object, EventArgs)</see>/>.
        /// </summary>
        private void ConnectTrBarPositionTrigger()
        {
            trackBarPositionTrigger.ValueChanged += new System.EventHandler(trackBarPositionTrigger_ValueChanged);
        }

        /// <summary>
        /// This method disconnect the event ValueChanged of <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/> control with 
        /// <see cref="trackBarPositionTrigger_ValueChanged(object, EventArgs)">trackBarPositionTrigger_ValueChanged(object, EventArgs)</see>/>.
        /// </summary>
        private void DisconnectTrBarPositionTrigger()
        {
            trackBarPositionTrigger.ValueChanged -= new System.EventHandler(trackBarPositionTrigger_ValueChanged);
        }

        /******************* UNITS FUNCTIONS *********************/
        /*********************************************************/
        /*********************************************************/

        /// <summary>
        /// This event is executes when the user modify the item in <see cref="cBoxUnits">cBoxUnits</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBoxUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUnites();

            DisconnectEvents();

            switch (mode_trigger)
            {
                case MODE_FRAMES:
                    InitValue_Frames();
                    break;

                case MODE_TIME:
                    InitValue_Time();
                    break;
            }

            ConnectEvents();

            UpdateRecordingSettings();
        }

        /// <summary>
        /// This method update the label of units according to value of <see cref="cBoxUnits">cBoxUnits</see>/>.
        /// </summary>
        private void UpdateUnites()
        {
            if (cBoxUnits.Text == "Nº Frames")
            {
                lbTotalUnits.Text = UNITS_FRAMES;
                lbTriggerUnits.Text = UNITS_FRAMES;
                mode_trigger = MODE_FRAMES;
            }
            else if (cBoxUnits.Text == "Tiempo")
            {
                lbTotalUnits.Text = UNITS_TIME;
                lbTriggerUnits.Text = UNITS_TIME;
                mode_trigger = MODE_TIME;
            }
        }

        /// <summary>
        /// This method initializer the value of each control manages in this class for Time mode.
        /// </summary>
        private void InitValue_Time()
        {
            mode_trigger = MODE_TIME;

            /* TOTAL */
            total = 60;
            numericUpTotal.Value = 60;

            /* TRIGGER */
            cBoxTrigger.SelectedIndex = 0;
            numericUpTrigger.Value = 30;

            preTrigger = 30;
            postTrigger = 30;

            /* POSITION */
            numericUpPositionTrigger.Value = 50;
            trackBarPositionTrigger.Value = 50;
        }

        /// <summary>
        /// This method initializer the value of each control manages in this class for Frames mode.
        /// </summary>
        private void InitValue_Frames()
        {
            mode_trigger = MODE_FRAMES;

            /* TOTAL */
            total = 100;
            numericUpTotal.Value = 100;

            /* TRIGGER */
            cBoxTrigger.SelectedIndex = 0;
            numericUpTrigger.Value = 50;

            preTrigger = 50;
            postTrigger = 50;

            /* POSITION */
            numericUpPositionTrigger.Value = 50;
            trackBarPositionTrigger.Value = 50;
        }

        /******************* TOTAL FUNCTIONS *********************/
        /*********************************************************/
        /*********************************************************/

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numericUpTotalFrames">numericUpTotalFrames</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownTotalFrame_ValueChanged(object sender, EventArgs e)
        {
            total = (double)numericUpTotal.Value;

            preTrigger = total * (double)numericUpPositionTrigger.Value / 100;
            postTrigger = total - preTrigger;

            DisconnectEvents();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            ConnectEvents();

            UpdateRecordingSettings();
        }
        
        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numericUpTrigger">numericUpTrigger</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownTrigger_ValueChanged(object sender, EventArgs e)
        {
            double percentage = 0;

            DisconnectEvents();

            if (cBoxTrigger.Text == "Pre-Trigger")
            {
                preTrigger = (double)numericUpTrigger.Value;

                if (preTrigger > total)
                {
                    preTrigger = total;
                    numericUpTrigger.Value = (decimal)preTrigger;
                }

                postTrigger = total - preTrigger;

                percentage = 100 - (preTrigger * 100 / total);
            }
            else if (cBoxTrigger.Text == "Post-Trigger")
            {
                postTrigger = (double)numericUpTrigger.Value;

                if (postTrigger > total)
                {
                    postTrigger = total;
                    numericUpTrigger.Value = (decimal)postTrigger;
                }

                preTrigger = total - postTrigger;

                percentage = (preTrigger * 100 / total);
            }
            
            numericUpPositionTrigger.Value = (decimal)percentage;
            trackBarPositionTrigger.Value = (int)percentage;

            ConnectEvents();

            UpdateRecordingSettings();
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="numericUpPositionTrigger">numericUpPositionTrigger</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUpDownPositionTrigger_ValueChanged(object sender, EventArgs e)
        {
            preTrigger = total * (double)numericUpPositionTrigger.Value / 100;
            postTrigger = total - preTrigger;

            DisconnectEvents();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            trackBarPositionTrigger.Value = (int)numericUpPositionTrigger.Value;

            ConnectEvents();

            UpdateRecordingSettings();
        }

        private void CBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisconnectNumUpDownTrigger();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            ConnectNumUpDownTrigger();

            UpdateRecordingSettings();
        }

        /// <summary>
        /// Este evento se ejecuta cuando se modifica el valor del control <see cref="trackBarPositionTrigger">trackBarPositionTrigger</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarPositionTrigger_ValueChanged(object sender, EventArgs e)
        {
            preTrigger = total * (double)trackBarPositionTrigger.Value / 100;
            postTrigger = total - preTrigger;

            DisconnectEvents();

            if (cBoxTrigger.Text == "Pre-Trigger")
                numericUpTrigger.Value = (decimal)preTrigger;
            else if (cBoxTrigger.Text == "Post-Trigger")
                numericUpTrigger.Value = (decimal)postTrigger;

            numericUpPositionTrigger.Value = (decimal)trackBarPositionTrigger.Value;

            ConnectEvents();

            UpdateRecordingSettings();
        }

        /// <summary>
        /// This method update the data in <see cref="recordSettings">recordSettings</see>/> with
        /// <see cref="preTrigger">preTrigger</see>/> and <see cref="postTrigger">postTrigger</see>/>.
        /// </summary>
        public void UpdateRecordingSettings()
        {
           if(recordSettings != null)
            {
                recordSettings.Mode_postTrigger = cBoxUnits.Text == "Tiempo" ? MODE_TIME : MODE_FRAMES;

                recordSettings.Pretrigger = preTrigger;
                recordSettings.TimeStop = postTrigger;
                recordSettings.UnitTimeStop = "Segundos";
            }
        }
    }
}
