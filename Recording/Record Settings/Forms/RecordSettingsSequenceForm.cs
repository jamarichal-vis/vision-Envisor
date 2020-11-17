using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;

namespace Recording
{
    public partial class RecordSettingsSequenceForm : Form
    {
        RecordSettings recordSettings;

        public RecordSettingsSequenceForm(ref RecordSettings recordSettings)
        {
            InitializeComponent();

            this.recordSettings = recordSettings;

            DefaultValue();
        }

        private void DefaultValue()
        {
            switch (recordSettings.OutputFormat)
            {
                case MIL.M_MIL:
                    cBoxOutputFormat.SelectedIndex = 0;
                    break;
                
                case MIL.M_PNG:
                    cBoxOutputFormat.SelectedIndex = 1;
                    break;
            }

            txBoxRoot.Text = recordSettings.Root;
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
                case "M_MIL":
                    format = MIL.M_MIL;
                    break;
                case "M_PNG":
                    format = MIL.M_PNG;
                    break;
            }

            recordSettings.OutputFormat = format;

            recordSettings.Root = txBoxRoot.Text;
        }
    }
}
