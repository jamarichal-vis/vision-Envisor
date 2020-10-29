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
        FlowLayoutPanel pnlCams;

        public PanelManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, int numCams, ref FlowLayoutPanel pnl)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            pnlCams = pnl;

            ShowCams();
        }

        public void ShowCams()
        {
            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);
            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInGigeVisionSystem; devDig++)
            {
                Id id = new Id(devSysGigeVision, devDig);
                DisplayCameraFlirForm displayCameraFlirForm = new DisplayCameraFlirForm(ref milApp, id: id);

                AddPanel(displayCameraFlirForm);
            }
            
            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInUsb3Vision; devDig++)
            {
                Id id = new Id(devSysUsb3Vision, devDig);
                DisplayCameraBaslerForm displayCameraBaslerForm = new DisplayCameraBaslerForm(ref milApp, id: id);

                AddPanel(displayCameraBaslerForm);
            }

        }

        public void AddPanel(DisplayCameraFlirForm displayCameraFlirForm)
        {
            Panel panel = new Panel();
            panel.Size = displayCameraFlirForm.Size;

            AddFormInPanel(displayCameraFlirForm, panel);

            pnlCams.Controls.Add(panel);
            pnlCams.ResumeLayout(false);
        }
        
        public void AddPanel(DisplayCameraBaslerForm displayCameraFlirForm)
        {
            Panel panel = new Panel();
            panel.Size = displayCameraFlirForm.Size;

            AddFormInPanel(displayCameraFlirForm, panel);

            pnlCams.Controls.Add(panel);
            pnlCams.ResumeLayout(false);
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
