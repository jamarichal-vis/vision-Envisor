using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        /// Nombre del video en la libraria <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        private const string NAME_VIDEO_MILLIBRARY = "VIDEO";

        /// <summary>
        /// Nombre del archivo con el que se guardará el vídeo.
        /// </summary>
        private const string NAME_VIDEO_FILE = "video";

        /// <summary>
        /// Extensión del vídeo que se guardará.
        /// </summary>
        private const string EXTENSION_VIDEO = ".avi";

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
        /// Esta variable almacena el botón de pause.
        /// </summary>
        ToolStripMenuItem btnPause;

        /// <summary>
        /// Esta variable almacena el botón de grab continuo.
        /// </summary>
        ToolStripMenuItem btnGrabContinuous;

        /// <summary>
        /// Esta variable almacena el botón de reset zoom.
        /// </summary>
        ToolStripMenuItem btnResetZoom;

        /// <summary>
        /// Esta variable almacena el botón de grabar en disco.
        /// </summary>
        ToolStripMenuItem btnRecord;

        /// <summary>
        /// Esta variable almacena el botón de parar la grabación en disco.
        /// </summary>
        ToolStripMenuItem btnStopRecord;

        /// <summary>
        /// Esta variable contiene todas las funciones para cambiar el estado de la barra de herramientas.
        /// </summary>
        private StateTools stateTools;

        /// <summary>
        /// Esta variable almacena toda la configuración para poder grabar un vídeo o una secuencia con una cámara.
        /// </summary>
        private RecordSettings recordSettings;

        /// <summary>
        /// Esta variable almacena el formulario principal. Es utilizado para acceder a ciertas funciones de este formulario.
        /// </summary>
        private RecordingForm recordingForm;

        /// <summary>
        /// This event is used to notify which camera has been selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyMouseDownDelegate(Id id);
        public event notifyMouseDownDelegate notifyMouseDownEvent;
        
        /// <summary>
        /// This event is used to notify which camera has been selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyGrabCameraDelegate();
        public event notifyGrabCameraDelegate notifyGrabCameraEvent;
        
        /// <summary>
        /// Este evento se ejecuta cuando la grabación en disco de las cámaras ha finalizado.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyStopGrabCameraDelegate();
        public event notifyStopGrabCameraDelegate notifyStopGrabCameraEvent;

        /// <summary>
        /// Este evento es utilizado para indicar que un formulario se va a cerrar.
        /// </summary>
        /// <param name="id">Id del visualizador que se quiere cerrar.</param>
        public delegate void notifyCloseDelegate(Id id);
        public event notifyCloseDelegate notifyCloseEvent;

        public StateTools StateTools { get => stateTools; set => stateTools = value; }
        public RecordSettings RecordSettings { get => recordSettings; set => recordSettings = value; }

        public PanelManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, int numCams, ref FlowLayoutPanel pnl, RecordingForm recordingForm)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            flowLayoutPanelCameras = pnl;

            pnlCameras = new Dictionary<Id, Panel>(new IdEqualityComparer());
            camerasForm = new Dictionary<Id, DisplayCameraForm>(new IdEqualityComparer());

            idSelected = null;

            this.recordingForm = recordingForm;

            //ShowCams();
        }

        public void AddControl(ref ToolStripMenuItem btnGrabContinuous, ref ToolStripMenuItem btnPause, ref ToolStripMenuItem btnResetZoom,
            ref ToolStripMenuItem btnRecord, ref ToolStripMenuItem btnStopRecord)
        {
            this.btnGrabContinuous = btnGrabContinuous;
            this.btnPause = btnPause;
            this.btnResetZoom = btnResetZoom;
            this.btnRecord = btnRecord;
            this.btnStopRecord = btnStopRecord;

            ConnectBtns();
        }

        /// <summary>
        /// Esta función es utilizada pra conectar todos los controles utilizados en la función <see cref="AddControl(ref ToolStripMenuItem, ref ToolStripMenuItem)">AddControl(ref ToolStripMenuItem, ref ToolStripMenuItem)</see>/>.
        /// </summary>
        public void ConnectBtns()
        {
            this.btnGrabContinuous.Click += new System.EventHandler(this.BtnGrabContinuous_Click);
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            this.btnResetZoom.Click += new System.EventHandler(this.BtnResetZoom_Click);
            this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            this.btnStopRecord.Click += new System.EventHandler(this.BtnStopRecord_Click);

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

            /* STATE TOOLS */
            stateTools.SingleShot();
            stateTools.Pause();
            stateTools.ResetZoom();
        }

        /// <summary>
        /// Este método añade una cámara al control <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/> en función
        /// del id que se pasa por parámetro.
        /// </summary>
        /// <param name="id">Id de la cámara que quieres conectar.</param>
        public void ShowCams(Id id)
        {
            if (!pnlCameras.ContainsKey(id))
            {
                DisplayCameraForm displayCameraForm = null;

                Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

                if (camInfo["Vendor"] == "Basler")
                    displayCameraForm = new DisplayCameraBaslerForm(ref milApp, id: id);
                else if (camInfo["Vendor"] == "FLIR" || camInfo["Vendor"].Contains("FLIR"))
                    displayCameraForm = new DisplayCameraFlirForm(ref milApp, id: id);

                displayCameraForm.DisplayCamera.notifyMouseDownEvent += new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);
                displayCameraForm.notifyCloseDownEvent += new DisplayCameraForm.notifyCloseDelegate(Remove);

                AddPanel(id, displayCameraForm);
            }

            /* STATE TOOLS */
            stateTools.SingleShot();
            stateTools.GrabContinuous(state: false);
            stateTools.Record();
            stateTools.Pause();
            stateTools.ResetZoom();
        }

        /// <summary>
        /// Esta función elimina un panel del control <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/> por el id de la cámara.
        /// </summary>
        /// <param name="id">Id de la cámara que quieres eliminar. </param>
        public void Remove(Id id)
        {
            flowLayoutPanelCameras.Controls.Remove(pnlCameras[id]);
            RemovePanelToDict(id);

            /* STATE TOOLS */
            if (pnlCameras.Keys.Count > 0)
                stateTools.Record();
            else
            {
                stateTools.Record(state: false);
                stateTools.SingleShot(state: false);
                stateTools.GrabContinuous(state: false);
                stateTools.Pause(state: false);
                stateTools.ResetZoom(state: false);
            }

            if (idSelected != null)
                if (idSelected.Equal(id))
                    idSelected = null;

            notifyCloseEvent.Invoke(idSelected);
        }

        /* Se necesita tener un diccionario con los formularios y acceder a su atributo pnlBorder. */
        public void SelectCamera(Id id)
        {
            if (idSelected != null)
                if (camerasForm.ContainsKey(idSelected))
                    camerasForm[idSelected].DisplayCamera.DeselectCamera();

            idSelected = new Id();

            idSelected.DevNSys = id.DevNSys;
            idSelected.DevNCam = id.DevNCam;

            if (camerasForm.ContainsKey(idSelected))
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
        /// Este método indica si una cámara se esta visualizando.
        /// </summary>
        /// <param name="id">Id de la cámara que se quiere comprobar.</param>
        /// <returns>True: si se esta visualizando la cámara. False: si no se esta visualizando.</returns>
        public bool IsShow(Id id)
        {
            return camerasForm.ContainsKey(id);
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
            if (!pnlCameras.ContainsKey(id))
                pnlCameras.Add(id, pnl);

            if (!camerasForm.ContainsKey(id))
                camerasForm.Add(id, displayCamera);
        }

        /// <summary>
        /// Esta función elimina el pael y el formulario de los diccionarios que se controlan en esta clase para
        /// la gestión de visualizadores de cámaras.
        /// </summary>
        /// <param name="id">Id del visualizador que quieres eliminar..</param>
        private void RemovePanelToDict(Id id)
        {
            if (pnlCameras.ContainsKey(id))
                pnlCameras.Remove(id);

            if (camerasForm.ContainsKey(id))
                camerasForm.Remove(id);
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
        /// Esta función conecta el evento <see cref="DisplayCamera.notifyMouseDownEvent">DisplayCamera.notifyMouseDownEvent</see>/> a la función 
        /// <see cref="NotifyCameraSelected(Id)">NotifyCameraSelected(Id)</see>/>.
        /// </summary>
        public void ConnectNotifyCameraSelected()
        {
            foreach(DisplayCameraForm displayCameraForm in camerasForm.Values)
                displayCameraForm.DisplayCamera.notifyMouseDownEvent += new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

        }
        
        /// <summary>
        /// Esta función desconecta el evento <see cref="DisplayCamera.notifyMouseDownEvent">DisplayCamera.notifyMouseDownEvent</see>/> a la función 
        /// <see cref="NotifyCameraSelected(Id)">NotifyCameraSelected(Id)</see>/>.
        /// </summary>
        public void DisconnectNotifyCameraSelected()
        {
            foreach(DisplayCameraForm displayCameraForm in camerasForm.Values)
                displayCameraForm.DisplayCamera.notifyMouseDownEvent -= new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

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

        private void BtnGrabContinuous_Click(object sender, EventArgs e)
        {
            StartGrabContinuous();
        }

        /// <summary>
        /// Esta función es creada para reaizar el mismo proceso tanto en la función <see cref="BtnGrabContinuous_Click(object, EventArgs)">BtnGrabContinuous_Click(object, EventArgs)</see>/>,
        /// como para enlazar esta función con el evento <see cref="CameraManager.grabContinuousCamEvent">CameraManager.grabContinuousCamEvent</see>/>.
        /// </summary>
        public void StartGrabContinuous()
        {
            ShowCams(idSelected);
            camerasForm[idSelected].DisplayCamera.StartGrab();
            camerasForm[idSelected].DisplayCamera.SelectCamera();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            stateTools.Pause(state: false);
            stateTools.GrabContinuous();

            camerasForm[idSelected].DisplayCamera.Pause();
        }

        private void BtnResetZoom_Click(object sender, EventArgs e)
        {
            camerasForm[idSelected].DisplayCamera.Zoom();
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            foreach (Id id in pnlCameras.Keys)
            {
                Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

                string pathFolder = System.IO.Path.Combine(recordSettings.Root,
                    recordSettings.Type + " - " +
                    (camInfo["Vendor"] != "" ? (camInfo["Vendor"] + " -") : "") +
                    (camInfo["Model"] != "" ? (camInfo["Model"]) : "") +
                    (camInfo["Name"] != "" ? (" -" + camInfo["Name"]) : (id.DevNSys.ToString() + id.DevNCam.ToString())) +
                    (camInfo["IpAddress"] != "" ? (" -" + camInfo["IpAddress"]) : "") +
                    DateTime.Now.ToString(" (dd-MM-yyyy HH-mm-ss-fff)"));

                if (!Directory.Exists(pathFolder))
                    Directory.CreateDirectory(pathFolder);

                switch (recordSettings.Type)
                {
                    case "Vídeo":

                        string pathFile = System.IO.Path.Combine(pathFolder, NAME_VIDEO_FILE + EXTENSION_VIDEO);
                        milApp.AddVideo(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY, (int)recordSettings.OutputFormat, timePretrigger: -1, timeStop: recordSettings.TimeStop);
                        milApp.CamStartGrabInDisk(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY, pathFile);

                        break;

                    case "Secuencia de imágenes":

                        milApp.CamActivateSequenceImages(id.DevNSys, id.DevNCam, recordSettings.TimeStop, recordSettings.OutputFormat);
                        milApp.CamStartSequenceImages(id.DevNSys, id.DevNCam, pathFolder);

                        EventVideo eventEndSequenceVideo = (EventVideo)milApp.CamEvent(id.DevNSys, id.DevNCam, "EndSequenceImages");
                        eventEndSequenceVideo._event += new EventVideo._eventDelagete(recordingForm.EndVideo);

                        break;
                }

                GrabCamera(id);

                notifyGrabCameraEvent.Invoke();
            }

            if (pnlCameras.Keys.Count > 0)
            {
                stateTools.Record(state: false);
                stateTools.Pause(state: false);
                stateTools.SingleShot(state: false);
                stateTools.StopRecord();

                foreach (DisplayCameraForm displayCameraForm in camerasForm.Values)
                    displayCameraForm.EnableBtnClose(state: false);

                DisconnectNotifyCameraSelected();
            }
        }

        private void BtnStopRecord_Click(object sender, EventArgs e)
        {
            foreach (Id id in pnlCameras.Keys)
            {
                switch (recordSettings.Type)
                {
                    case "Vídeo":
                        
                        milApp.CamStopGrabInDisk(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY);

                        break;

                    case "Secuencia de imágenes":

                        milApp.CamStopSequenceImages(id.DevNSys, id.DevNCam);

                        break;
                }

                if (id.Equal(idSelected))
                    SelectCamera(id);
                else
                    DeselectCamera(id);
            }

            stateTools.Record();
            stateTools.Pause();
            stateTools.SingleShot();
            stateTools.StopRecord(state: false);
            ConnectNotifyCameraSelected();

            notifyStopGrabCameraEvent.Invoke();
        }

        /// <summary>
        /// Esta función habilita todos los <see cref="DisplayCameraBaslerForm.btnClose">DisplayCameraBaslerForm.btnClose</see>/> y 
        /// <see cref="DisplayCameraFlirForm.btnClose">DisplayCameraFlirForm.btnClose</see>/>.
        /// </summary>
        public void EnableDisplayCameraFormClose()
        {
            foreach (DisplayCameraForm displayCameraForm in camerasForm.Values)
                displayCameraForm.EnableBtnClose(state: true);
        }
    }
}
