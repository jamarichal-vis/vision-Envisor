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
    public partial class RecordSettingsForm : Form
    {
        RecordSettings recordSettings;

        RecordSettingsVideoForm recordSettingsVideoForm;

        RecordSettingsSequenceForm recordSettingsSequenceForm;

        public RecordSettings RecordSettings { get => recordSettings; set => recordSettings = value; }

        public RecordSettingsForm(ref RecordSettings recordSettings)
        {
            InitializeComponent();

            this.recordSettings = recordSettings;

            DefaultValue(recordSettings);
        }

        private void DefaultValue(RecordSettings recordSettings)
        {
            switch (recordSettings.Type)
            {
                case "Vídeo":

                    cBoxRecordType.SelectedIndex = 0;

                    break;

                case "Secuencia de imágenes":

                    cBoxRecordType.SelectedIndex = 1;

                    break;
            }
        }

        private void cBoxRecordType_SelectedIndexChanged(object sender, EventArgs e)
        {

            recordSettingsVideoForm = null;
            recordSettingsSequenceForm = null;

            switch (cBoxRecordType.Text)
            {
                case "Vídeo":

                    recordSettingsVideoForm = new RecordSettingsVideoForm(ref recordSettings);
                    AddFormInPanel(recordSettingsVideoForm, pnl);

                    break;

                case "Secuencia de imágenes":

                    recordSettingsSequenceForm = new RecordSettingsSequenceForm(ref recordSettings);
                    AddFormInPanel(recordSettingsSequenceForm, pnl);

                    break;
            }
        }

        /// <summary>
        /// Función para añadir un formulario dentro de un panel
        /// </summary>
        /// <param name="fh"></param>
        /// <param name="panel"></param>
        public void AddFormInPanel(Form fh, Panel panel) /*(MetroForm fh)*/
        {
            if (panel.Controls.Count > 0)
                panel.Controls.RemoveAt(0);

            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.ControlBox = false;
            //fh.ShadowType = MetroFormShadowType.None;
            fh.Dock = DockStyle.Fill;

            panel.Controls.Add(fh);
            panel.Tag = fh;
            panel.AutoSize = true;
            fh.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            recordSettings.Type = cBoxRecordType.Text;

            if (recordSettingsVideoForm != null)
                recordSettingsVideoForm.Save();

            if (recordSettingsSequenceForm != null)
                recordSettingsSequenceForm.Save();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
