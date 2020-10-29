using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;

namespace Recording
{
    class PanelManager
    {
        /// <summary>
        /// Variable que contiene toda la estructura del control de las cámaras del sistema.
        /// </summary>
        private MilApp milApp;

        /// <summary>
        /// Esta variable indica que posición esta el sistema GigeVision en la lista de sistemas de MilApp.
        /// </summary>
        private MIL_INT devSysUsb3Vision;

        /// <summary>
        /// Esta variable indica que posición esta el sistema GigeVision en la lista de sistemas de MilApp.
        /// </summary>
        private MIL_INT devSysGigeVision;

        /// <summary>
        /// Este atributo almacena el panel principal que se quiere controlar.
        /// </summary>
        FlowLayoutPanel flowLayoutPanelCameras;

        Dictionary<Id, Panel> pnlCameras;

        public PanelManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, int numCams, ref FlowLayoutPanel pnl)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            flowLayoutPanelCameras = pnl;

            pnlCameras = new Dictionary<Id, Panel>();

            ShowCams();
        }

        public void ShowCams()
        {
            Form displayCameraForm = null;

            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);
            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInGigeVisionSystem; devDig++)
            {
                Id id = new Id(devSysGigeVision, devDig);

                Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

                if(camInfo["Vendor"] == "Basler")
                    displayCameraForm = new DisplayCameraBaslerForm(ref milApp, id: id);
                else if(camInfo["Vendor"] == "FLIR" || camInfo["Vendor"].Contains("FLIR"))
                    displayCameraForm = new DisplayCameraFlirForm(ref milApp, id: id);

                AddPanel(id, displayCameraForm);
            }

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInUsb3Vision; devDig++)
            {
                Id id = new Id(devSysUsb3Vision, devDig);
                displayCameraForm = new DisplayCameraBaslerForm(ref milApp, id: id);

                AddPanel(id, displayCameraForm);
            }
        }

        public void Remove()
        {

        }

        /// <summary>
        /// Esta función añade un panel a <see cref="pnlCameras">pnlCameras</see>/>.
        /// Además, se añade la identificación del panel a través de su <see cref="Id">Id</see>/>.
        /// </summary>
        /// <param name="id">Id de la cámara que se esta conectando al panel.</param>
        /// <param name="pnl">Panel que se quiere añadir.</param>
        private void AddPanelToDict(Id id, Panel pnl)
        {
            pnlCameras.Add(id, pnl);
        }

        /// <summary>
        /// Este método añade un panel tanto a <see cref="flowLayoutPanelCameras">pnlCams</see>/> y a <see cref="pnlCameras">pnlCameras</see>/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="displayCameraFlirForm"></param>
        public void AddPanel(Id id, Form displayCameraFlirForm)
        {
            Panel panel = new Panel();
            panel.Size = displayCameraFlirForm.Size;

            AddPanelToDict(id, panel);

            AddFormInPanel(displayCameraFlirForm, panel);

            flowLayoutPanelCameras.Controls.Add(panel);
            flowLayoutPanelCameras.ResumeLayout(false);
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
            fh.Dock = DockStyle.None;

            panel.Controls.Add(fh);
            panel.Tag = fh;
            panel.AutoSize = true;
            fh.Show();
        }
    }
}
