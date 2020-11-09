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
    public partial class RecordSettingsVideoForm : Form
    {
        RecordSettings recordSettings;

        public RecordSettingsVideoForm(ref RecordSettings recordSettings)
        {
            InitializeComponent();

            this.recordSettings = recordSettings;

            DefaultValue();
        }

        private void DefaultValue()
        {
            switch (recordSettings.OutputFormat)
            {
                case "AVI":
                    cBoxOutputFormat.SelectedIndex = 0;
                    break;
            }

            ckBoxFps.Checked = recordSettings.Fps > 0;
            numericUpDownFps.Enabled = recordSettings.Fps > 0;
            numericUpDownFps.Value = (decimal)recordSettings.Fps;

            ckBoxStopRecord.Checked = recordSettings.TimeStop > 0;
            numericUpDownStopRecord.Enabled = recordSettings.TimeStop > 0;
            numericUpDownStopRecord.Value = (decimal)recordSettings.TimeStop;

            switch (recordSettings.UnitTimeStop)
            {
                case "Segundos":
                    cBoxUnitsStopRecord.SelectedIndex = 0;
                    break;

                case "Minutos":
                    cBoxUnitsStopRecord.SelectedIndex = 1;
                    break;

                case "Hora":
                    cBoxUnitsStopRecord.SelectedIndex = 2;
                    break;
            }

            txBoxRoot.Text = recordSettings.Root;
        }

        private void ckBoxFps_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownFps.Enabled = ckBoxFps.Checked;
        }

        private void ckBoxStopRecord_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownStopRecord.Enabled = ckBoxStopRecord.Checked;
            cBoxOutputFormat.Enabled = ckBoxStopRecord.Checked;
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txBoxRoot.Text = folderBrowserDialog.SelectedPath;
            }
        }

        public void Save()
        {
            recordSettings.OutputFormat = cBoxOutputFormat.Text;

            if (ckBoxFps.Checked)
                recordSettings.Fps = (double)numericUpDownFps.Value;
            else
                recordSettings.Fps = -1;
            
            if (ckBoxStopRecord.Checked)
                recordSettings.TimeStop = (double)numericUpDownStopRecord.Value;
            else
                recordSettings.TimeStop = -1;

            recordSettings.UnitTimeStop = cBoxUnitsStopRecord.Text;

            recordSettings.Root = txBoxRoot.Text;
        }
    }
}
