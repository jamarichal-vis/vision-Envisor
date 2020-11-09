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

        /// <summary>
        /// Este diccionario contiene todos los paneles que se han introducido en <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>.
        /// Ver, <see cref="AddPanelToDict(Id, Panel, DisplayCameraForm)">AddPanelToDict(Id, Panel, DisplayCameraForm)</see>/>.
        /// 
        /// Es utilizado para eliminar los paneles del control <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>, 
        /// ver <see cref="Remove(Id)">Remove(Id)</see>/>.
        /// </summary>
        Dictionary<Id, Panel> pnlCameras;

        /// <summary>
        /// Este diccionario contiene todos los formularios correspondientes a cada panel.
        /// Con ello, se podrá acceder a cada formulario para poder modificarlo si fuera necesario.
        /// Ver, <see cref="SelectCamera(Id)">SelectCamera(Id)</see>/>.
        /// </summary>
        Dictionary<Id, DisplayCameraForm> camerasForm;

        Id idSelected;

        /// <summary>
        /// This event is used to notify which camera has been selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyMouseDownDelegate(Id id);
        public event notifyMouseDownDelegate notifyMouseDownEvent;

        public PanelManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, int numCams, ref FlowLayoutPanel pnl)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            flowLayoutPanelCameras = pnl;

            pnlCameras = new Dictionary<Id, Panel>(new IdEqualityComparer());
            camerasForm = new Dictionary<Id, DisplayCameraForm>(new IdEqualityComparer());

            idSelected = null;

            ShowCams();
        }

        /// <summary>
        /// Este método se encarga de mostrar todas las cámaras en diferentes panel del control <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>.
        /// </summary>
        public void ShowCams()
        {
            DisplayCameraForm displayCameraForm = null;

            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);
            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInGigeVisionSystem; devDig++)
            {
                Id id = new Id(devSysGigeVision, devDig);

                Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

                if (camInfo["Vendor"] == "Basler")
                    displayCameraForm = new DisplayCameraBaslerForm(ref milApp, id: id);
                else if (camInfo["Vendor"] == "FLIR" || camInfo["Vendor"].Contains("FLIR"))
                    displayCameraForm = new DisplayCameraFlirForm(ref milApp, id: id);
                
                displayCameraForm.DisplayCamera.notifyMouseDownEvent += new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

                AddPanel(id, displayCameraForm);
            }

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInUsb3Vision; devDig++)
            {
                Id id = new Id(devSysUsb3Vision, devDig);
                displayCameraForm = new DisplayCameraBaslerForm(ref milApp, id: id);
                
                displayCameraForm.DisplayCamera.notifyMouseDownEvent += new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

                AddPanel(id, displayCameraForm);
            }
        }

        /// <summary>
        /// Este método añade una cámara al control <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/> en función
        /// del id que se pasa por parámetro.
        /// </summary>
        /// <param name="id">Id de la cámara que quieres conectar.</param>
        public void ShowCams(Id id)
        {
            DisplayCameraForm displayCameraForm = null;

            Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

            if (camInfo["Vendor"] == "Basler")
                displayCameraForm = new DisplayCameraBaslerForm(ref milApp, id: id);
            else if (camInfo["Vendor"] == "FLIR" || camInfo["Vendor"].Contains("FLIR"))
                displayCameraForm = new DisplayCameraFlirForm(ref milApp, id: id);

            displayCameraForm.DisplayCamera.notifyMouseDownEvent += new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

            AddPanel(id, displayCameraForm);
        }

        /// <summary>
        /// Esta función elimina un panel del control <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/> por el id de la cámara.
        /// </summary>
        /// <param name="id">Id de la cámara que quieres eliminar. </param>
        public void Remove(Id id)
        {
            flowLayoutPanelCameras.Controls.Remove(pnlCameras[id]);
        }

        /* Se necesita tener un diccionario con los formularios y acceder a su atributo pnlBorder. */
        public void SelectCamera(Id id)
        {
            if (idSelected != null)
                camerasForm[idSelected].DisplayCamera.DeselectCamera();

            idSelected = new Id();

            idSelected.DevNSys = id.DevNSys;
            idSelected.DevNCam = id.DevNCam;

            camerasForm[idSelected].DisplayCamera.SelectCamera();
        }

        /// <summary>
        /// Esta función es utilizada pra deseleccionar una cámara mediante el id que se pasa por parámetro.
        /// </summary>
        /// <param name="id">Id de la cámara que quiere deseleccionar.</param>
        public void DeselectCamera(Id id)
        {
            camerasForm[id].DisplayCamera.DeselectCamera();
        }

        /// <summary>
        /// Esta función es utilizada para indicar que se esta grabando en la cámara indicada mediante el id que se pasa por parámetro.
        /// </summary>
        /// <param name="id">Ide de la cámara que quiere idicar que se esta grabando.</param>
        public void GrabCamera(Id id)
        {
            camerasForm[id].DisplayCamera.GrabCamera();
        }

        /// <summary>
        /// Esta función añade un panel a <see cref="pnlCameras">pnlCameras</see>/>.
        /// Además, se añade la identificación del panel a través de su <see cref="Id">Id</see>/>.
        /// </summary>
        /// <param name="id">Id de la cámara que se esta conectando al panel.</param>
        /// <param name="pnl">Panel que se quiere añadir.</param>
        private void AddPanelToDict(Id id, Panel pnl, DisplayCameraForm displayCamera)
        {
            pnlCameras.Add(id, pnl);
            camerasForm.Add(id, displayCamera);
        }

        /// <summary>
        /// Este método añade un panel tanto a <see cref="flowLayoutPanelCameras">pnlCams</see>/> y a <see cref="pnlCameras">pnlCameras</see>/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="displayCameraFlirForm"></param>
        public void AddPanel(Id id, DisplayCameraForm displayCameraFlirForm)
        {
            Panel panel = new Panel();
            panel.Size = displayCameraFlirForm.Size;

            AddPanelToDict(new Id(id.DevNSys, id.DevNCam), panel, displayCameraFlirForm);

            AddFormInPanel(displayCameraFlirForm, panel);

            flowLayoutPanelCameras.Controls.Add(panel);
            flowLayoutPanelCameras.ResumeLayout(false);
        }

        /// <summary>
        /// Esta función notifica la cámara que quieres seleccionar.
        /// </summary>
        /// <param name="id">El id de la cñamara que quieres seleccionar.</param>
        public void NotifyCameraSelected(Id id)
        {
            if (notifyMouseDownEvent != null)
                notifyMouseDownEvent.Invoke(id);
        }

        /// <summary>
        /// Función para añadir un formulario dentro de un panel
        /// </summary>
        /// <param name="fh"></param>
        /// <param name="panel"></param>
        public void AddFormInPanel(DisplayCameraForm fh, Panel panel) /*(MetroForm fh)*/
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
