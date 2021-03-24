﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;
using FormsMilLibrary;
using FormsLibrary;

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
        /// This variable storages the camera select by user.
        /// It is used to connect all modules of the program.
        /// </summary>
        private Camera camera_selected;

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
        Dictionary<Camera, Panel> pnlCameras;

        /// <summary>
        /// Este diccionario contiene todos los formularios correspondientes a cada panel.
        /// Con ello, se podrá acceder a cada formulario para poder modificarlo si fuera necesario.
        /// Ver, <see cref="SelectCamera(Id)">SelectCamera(Id)</see>/>.
        /// </summary>
        Dictionary<Camera, Form> camerasForm;

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
        public delegate void notifyMouseDownDelegate(Camera camera);
        public event notifyMouseDownDelegate notifyMouseDownEvent;

        /// <summary>
        /// This event is used to notify a camera is grab. Also, it indicates the camera selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyGrabContinuousCameraDelegate(Camera camera);
        public event notifyGrabContinuousCameraDelegate notifyGrabContinuousCameraEvent;
        
        /// <summary>
        /// This event is used to notify a camera is grab. Also, it indicates the camera selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyPauseCameraDelegate(Camera camera);
        public event notifyPauseCameraDelegate notifyPauseCameraEvent;

        /// <summary>
        /// This event is used to notify a camera is grab. Also, it indicates the camera selected.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyGrabCameraDelegate(Camera camera);
        public event notifyGrabCameraDelegate notifyGrabCameraEvent;

        /// <summary>
        /// Este evento se ejecuta cuando la grabación en disco de las cámaras ha finalizado.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyStopGrabCameraDelegate(Camera camera);
        public event notifyStopGrabCameraDelegate notifyStopGrabCameraEvent;

        /// <summary>
        /// Este evento es utilizado para indicar que un formulario se va a cerrar.
        /// </summary>
        /// <param name="id">Id del visualizador que se quiere cerrar.</param>
        public delegate void notifyCloseDelegate(Camera camera);
        public event notifyCloseDelegate notifyCloseEvent;

        public StateTools StateTools { get => stateTools; set => stateTools = value; }
        public RecordSettings RecordSettings { get => recordSettings; set => recordSettings = value; }

        public PanelManager(ref FlowLayoutPanel pnl, RecordingForm recordingForm)
        {
            flowLayoutPanelCameras = pnl;

            pnlCameras = new Dictionary<Camera, Panel>();
            camerasForm = new Dictionary<Camera, Form>();

            camera_selected = null;

            this.recordingForm = recordingForm;
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

        /***************** SHOW CAMERA FUNCTION *****************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method set a camera in <see cref="camera_selected">camera_selected</see>/>.
        /// </summary>
        /// <param name="camera"></param>
        public void SelectCamera(ref Camera camera)
        {
            camera_selected = camera;

            if (stateTools != null)
            {
                if (Count_Cameras_Connected() > 0)
                {
                    /* STATE TOOLS */
                    stateTools.SingleShot();
                    stateTools.GrabContinuous(state: false);
                    stateTools.Pause();
                    stateTools.ResetZoom();
                }
                else
                {
                    /* STATE TOOLS */
                    stateTools.SingleShot(state: false);
                    stateTools.GrabContinuous();
                    stateTools.Pause(state: false);
                    stateTools.ResetZoom(state: false);
                }
            }
        }

        /// <summary>
        /// This method show a camera in <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>.
        /// </summary>
        /// <param name="camera">Camera you want to add.</param>
        public void ShowCam(ref Camera camera)
        {
            if (!pnlCameras.ContainsKey(camera_selected))
            {
                Form form = GetDisplayForm(ref camera_selected);

                AddPanel(ref camera_selected, form);
            }

            /* STATE TOOLS */
            if (stateTools != null)
            {
                stateTools.SingleShot();
                stateTools.GrabContinuous(state: false);
                stateTools.Record();
                stateTools.Pause();
                stateTools.ResetZoom();
            }
        }

        /// <summary>
        /// This method return the form according to camera passes by parameter.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public Form GetDisplayForm(ref Camera camera)
        {
            Form form = null;

            if (camera.GetType().ToString().Contains("Basler"))
            {
                form = new Basler_Display_Form(ref camera);

                ((form as Basler_Display_Form).Display as Basler_Display).notifyMouseDownEvent += new Basler_Display.notifyMouseDownDelegate(NotifyCameraSelected);
            }

            return form;
        }

        /// <summary>
        /// This method add the camera passes by paramater and its form in <see cref="pnlCameras">pnlCameras</see>/>,
        /// <see cref="camerasForm">camerasForm</see>/> and <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>.
        /// </summary>
        /// <param name="camera">Camera you want to show in this class.</param>
        /// <param name="form">Form of the camera you want to add.</param>
        public void AddPanel(ref Camera camera, Form form)
        {
            Panel panel = new Panel();
            panel.Size = form.Size;

            AddPanelToDict(ref camera, panel, form);

            AddFormInPanel(form, panel);

            flowLayoutPanelCameras.Controls.Add(panel);
            flowLayoutPanelCameras.ResumeLayout(false);
        }

        /// <summary>
        /// This method add the camera, panel and form passes by parameter in <see cref="pnlCameras">pnlCameras</see>/> and
        /// <see cref="camerasForm">camerasForm</see>/>.
        /// </summary>
        /// <param name="camera">Camera you want to add to this class.</param>
        /// <param name="pnl">Panel of the camera you wnat to add.</param>
        /// <param name="form">Form of the camera you want to add.</param>
        private void AddPanelToDict(ref Camera camera, Panel pnl, Form form)
        {
            if (!pnlCameras.ContainsKey(camera))
                pnlCameras.Add(camera, pnl);

            if (!camerasForm.ContainsKey(camera))
                camerasForm.Add(camera, form);
        }

        /// <summary>
        /// This method add a form in a panel.
        /// </summary>
        /// <param name="fh">Form you want to add.</param>
        /// <param name="panel">Panel where you want to add a form.</param>
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

        /*************** CAMERAS CONNECTED FUNCTION *************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method return the number of the camera connected in this class.
        /// </summary>
        /// <returns>Int with number of the cameras connected in this class.</returns>
        public int Count_Cameras_Connected()
        {
            if (pnlCameras != null)
                return pnlCameras.Count;

            return 0;
        }

        /***************** REMOVE CAMERA FUNCTION ***************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method remove a camera of <see cref="pnlCameras">pnlCameras</see>/>, <see cref="camerasForm">camerasForm</see>/> and 
        /// <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>.
        /// </summary>
        /// <param name="camera">Camera you want to remove.</param>
        public void Remove(Camera camera)
        {
            if (pnlCameras.ContainsKey(camera))
            {
                flowLayoutPanelCameras.Controls.Remove(pnlCameras[camera]);

                RemovePanelToDict(camera);

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

                if (camera_selected != null)
                    if (camera_selected == camera)
                        camera_selected = null;

                notifyCloseEvent.Invoke(camera);
            }
        }

        /// <summary>
        /// This method remove a camera of <see cref="pnlCameras">pnlCameras</see>/> and <see cref="camerasForm">camerasForm</see>/>.
        /// </summary>
        /// <param name="camera">Camera you want to remove.</param>
        private void RemovePanelToDict(Camera camera)
        {
            if (pnlCameras.ContainsKey(camera))
                pnlCameras.Remove(camera);

            if (camerasForm.ContainsKey(camera))
                camerasForm.Remove(camera);
        }

        /******************* BUTTONS FUNCTION *******************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method is executed when the user press the <see cref="btnGrabContinuous">btnGrabContinuous</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGrabContinuous_Click(object sender, EventArgs e)
        {
            StartGrabContinuous();
        }

        /// <summary>
        /// This method is create to use in <see cref="BtnGrabContinuous_Click(object, EventArgs)">BtnGrabContinuous_Click(object, EventArgs)</see>/> or
        /// <see cref="CameraManager.grabContinuousCamEvent">CameraManager.grabContinuousCamEvent</see>/>.
        /// </summary>
        public void StartGrabContinuous()
        {
            if (camera_selected != null)
            {
                ShowCam(ref camera_selected);

                if (camerasForm.ContainsKey(camera_selected))
                    if (camera_selected.GetType().ToString().Contains("Basler"))
                        ((camerasForm[camera_selected] as Basler_Display_Form).Display as Basler_Display).Start();

                if (stateTools != null)
                {
                    /* STATE TOOLS */
                    stateTools.SingleShot();
                    stateTools.GrabContinuous(state: false);
                    stateTools.Pause();
                    stateTools.ResetZoom();
                }

                if (notifyGrabContinuousCameraEvent != null)
                    notifyGrabContinuousCameraEvent.Invoke(camera: camera_selected);
            }
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnPause">btnPause</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPause_Click(object sender, EventArgs e)
        {
            stateTools.Pause(state: false);
            stateTools.GrabContinuous();

            if (camerasForm.ContainsKey(camera_selected))
                if (camera_selected.GetType().ToString().Contains("Basler"))
                    ((camerasForm[camera_selected] as Basler_Display_Form).Display as Basler_Display).Stop();

            if (notifyPauseCameraEvent != null)
                notifyPauseCameraEvent.Invoke(camera_selected);
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnResetZoom">btnResetZoom</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetZoom_Click(object sender, EventArgs e)
        {
            if (camerasForm.ContainsKey(camera_selected))
                if (camera_selected.GetType().ToString().Contains("Basler"))
                    ((camerasForm[camera_selected] as Basler_Display_Form).Display as Basler_Display).ResetZoom();
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnRecord">btnRecord</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRecord_Click(object sender, EventArgs e)
        {
            foreach (Camera camera in pnlCameras.Keys)
            {
                string pathFolder = System.IO.Path.Combine(recordSettings.Root,
                    recordSettings.Type + " - " +
                    (camera.Vendor != "" ? (camera.Vendor + " -") : "") +
                    (camera.Model != "" ? (camera.Model) : "") +
                    (camera.Name != "" ? (" -" + camera.Name) : (camera.SerialNumber)) +
                    (camera.IpAddress != "" ? (" -" + camera.IpAddress) : "") +
                    DateTime.Now.ToString(" (dd-MM-yyyy HH-mm-ss-fff)"));

                if (!Directory.Exists(pathFolder))
                    Directory.CreateDirectory(pathFolder);

                //switch (recordSettings.Type)
                //{
                //    case "Vídeo":

                //        string pathFile = System.IO.Path.Combine(pathFolder, NAME_VIDEO_FILE + EXTENSION_VIDEO);
                //        //milApp.AddVideo(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY, (int)recordSettings.OutputFormat, timePretrigger: -1, timeStop: recordSettings.TimeStop);
                //        //milApp.CamStartGrabInDisk(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY, pathFile/*, recordSettings.Fps*/);

                //        break;

                //    case "Secuencia de imágenes":

                //        //milApp.CamActivateSequenceImages(id.DevNSys, id.DevNCam, recordSettings.TimeStop, recordSettings.OutputFormat);
                //        //milApp.CamStartSequenceImages(id.DevNSys, id.DevNCam, pathFolder);

                //        //EventVideo eventEndSequenceVideo = (EventVideo)milApp.CamEvent(id.DevNSys, id.DevNCam, "EndSequenceImages");
                //        //eventEndSequenceVideo._event += new EventVideo._eventDelagete(recordingForm.EndVideo);

                //        break;
                //}

                //GrabCamera(id);

                //notifyGrabCameraEvent.Invoke();
            }

            if (pnlCameras.Keys.Count > 0)
            {
                stateTools.Record(state: false);
                stateTools.Pause(state: false);
                stateTools.SingleShot(state: false);
                stateTools.StopRecord();

                foreach (DisplayCameraForm displayCameraForm in camerasForm.Values)
                    displayCameraForm.EnableBtnClose(state: false);

                //DisconnectNotifyCameraSelected();
            }
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnStopRecord">btnStopRecord</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopRecord_Click(object sender, EventArgs e)
        {
            //foreach (Id id in pnlCameras.Keys)
            //{
            //    switch (recordSettings.Type)
            //    {
            //        case "Vídeo":

            //            //milApp.CamStopGrabInDisk(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY);

            //            break;

            //        case "Secuencia de imágenes":

            //            //milApp.CamStopSequenceImages(id.DevNSys, id.DevNCam);

            //            break;
            //    }

            //    if (id.Equal(idSelected))
            //        SelectCamera(id);
            //    else
            //        DeselectCamera(id);
            //}

            stateTools.Record();
            stateTools.Pause();
            stateTools.SingleShot();
            stateTools.StopRecord(state: false);
            //ConnectNotifyCameraSelected();

            //notifyStopGrabCameraEvent.Invoke();
        }

        /// <summary>
        /// Esta función notifica la cámara que quieres seleccionar.
        /// </summary>
        /// <param name="id">El id de la cñamara que quieres seleccionar.</param>
        public void NotifyCameraSelected(Camera camera)
        {
            if (notifyMouseDownEvent != null)
                notifyMouseDownEvent.Invoke(camera);
        }

        /// <summary>
        /// Esta función conecta el evento <see cref="DisplayCamera.notifyMouseDownEvent">DisplayCamera.notifyMouseDownEvent</see>/> a la función 
        /// <see cref="NotifyCameraSelected(Id)">NotifyCameraSelected(Id)</see>/>.
        /// </summary>
        //public void ConnectNotifyCameraSelected()
        //{
        //    foreach(DisplayCameraForm displayCameraForm in camerasForm.Values)
        //        displayCameraForm.DisplayCamera.notifyMouseDownEvent += new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

        //}

        /// <summary>
        /// Esta función desconecta el evento <see cref="DisplayCamera.notifyMouseDownEvent">DisplayCamera.notifyMouseDownEvent</see>/> a la función 
        /// <see cref="NotifyCameraSelected(Id)">NotifyCameraSelected(Id)</see>/>.
        /// </summary>
        //public void DisconnectNotifyCameraSelected()
        //{
        //    foreach(DisplayCameraForm displayCameraForm in camerasForm.Values)
        //        displayCameraForm.DisplayCamera.notifyMouseDownEvent -= new DisplayCamera.notifyMouseDownDelegate(NotifyCameraSelected);

        //}

        /// <summary>
        /// This method enable all btn close of <see cref="camerasForm">camerasForm</see>/>.
        /// </summary>
        public void EnableBtnCloseForms()
        {
            foreach (var camera in camerasForm)
                if (camera.Key.GetType().ToString().Contains("Basler"))
                    (camera.Value as Basler_Display_Form).EnableBtnClose(state: true);
        }

        /// <summary>
        /// This method disable all btn close of <see cref="camerasForm">camerasForm</see>/>.
        /// </summary>
        public void DisableBtnCloseForms()
        {
            foreach (var camera in camerasForm)
                if (camera.Key.GetType().ToString().Contains("Basler"))
                    (camera.Value as Basler_Display_Form).EnableBtnClose(state: false);
        }
    }
}