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
                case "AVI":
                    cBoxOutputFormat.SelectedIndex = 0;
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
            recordSettings.OutputFormat = cBoxOutputFormat.Text;

            recordSettings.Root = txBoxRoot.Text;
        }
    }
}
