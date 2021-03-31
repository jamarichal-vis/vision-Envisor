using Matrox.MatroxImagingLibrary;
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
                case MIL.M_AVI_DIB:
                    cBoxOutputFormat.SelectedIndex = 0;
                    break;
                case MIL.M_AVI_MIL:
                    cBoxOutputFormat.SelectedIndex = 1;
                    break;
                case MIL.M_AVI_MJPG:
                    cBoxOutputFormat.SelectedIndex = 2;
                    break;
            }

            ckBoxFps.Checked = recordSettings.Fps > 0;
            numericUpDownFps.Enabled = recordSettings.Fps > 0;
            numericUpDownFps.Value = (decimal)recordSettings.Fps;

            ckBoxStopRecord.Checked = recordSettings.TimeStop > 0;
            numericUpDownStopRecord.Enabled = recordSettings.TimeStop > 0;
            numericUpDownStopRecord.Value = (decimal)recordSettings.TimeStop;
            cBoxUnitsStopRecord.Enabled = recordSettings.TimeStop > 0;

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
            cBoxUnitsStopRecord.Enabled = ckBoxStopRecord.Checked;
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
            MIL_INT format = MIL.M_NULL;

            switch (cBoxOutputFormat.Text)
            {
                case "M_FILE_FORMAT_AVI":
                    format = MIL.M_FILE_FORMAT_AVI;
                    break;
                case "M_FILE_FORMAT_H264":
                    format = MIL.M_FILE_FORMAT_H264;
                    break;
                case "M_FILE_FORMAT_MP4":
                    format = MIL.M_FILE_FORMAT_MP4;
                    break;
            }
           
            recordSettings.OutputFormat = format;

            if (ckBoxFps.Checked)
                recordSettings.Fps = (double)numericUpDownFps.Value;
            else
                recordSettings.Fps = 0;
            
            if (ckBoxStopRecord.Checked)
                recordSettings.TimeStop = (double)numericUpDownStopRecord.Value;
            else
                recordSettings.TimeStop = 0;

            if (cBoxUnitsStopRecord.Text == "FRAMES")
                recordSettings.Mode_postTrigger = "FRAMES";
            else
                recordSettings.Mode_postTrigger = "TIME";

            recordSettings.UnitTimeStop = cBoxUnitsStopRecord.Text;

            recordSettings.Root = txBoxRoot.Text;
        }
    }
}
