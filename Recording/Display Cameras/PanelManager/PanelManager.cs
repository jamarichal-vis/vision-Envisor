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
using FormsMilLibrary;
using FormsLibrary;
using System.Reflection;

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
        /// This variable contains all function about analysis of the image for this program.
        /// </summary>
        private Envisor_Algorithm envisor_Algorithm;

        /// <summary>
        /// This variable contains all function about visualization of the image for this program.
        /// </summary>
        private Envisor_Visualization envisor_Visualization;

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
        /// Esta variable contiene todas las funciones para cambiar el estado de la barra de herramientas.
        /// </summary>
        private ButtonsTools buttonsTools;

        /// <summary>
        /// Esta variable almacena toda la configuración para poder grabar un vídeo o una secuencia con una cámara.
        /// </summary>
        private RecordSettings recordSettings;

        /// <summary>
        /// Esta variable almacena el formulario principal. Es utilizado para acceder a ciertas funciones de este formulario.
        /// </summary>
        private RecordingForm recordingForm;

        /// <summary>
        /// This variable storages all controls of a information bar of a basler camera.
        /// </summary>
        private Basler_InformatioBar_Controls basler_informationbar_controls;

        /// <summary>
        /// This variable storages the color default for the back color of <see cref="basler_informationbar_controls">basler_informationbar_controls</see>/>.
        /// </summary>
        private Color color_default;

        /// <summary>
        /// This variable storages the color when the program is in record mode for the back color of <see cref="basler_informationbar_controls">basler_informationbar_controls</see>/>.
        /// </summary>
        private Color color_record;

        /// <summary>
        /// This variable indicates if the cameras is recording.
        /// </summary>
        private bool _record;

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
        public delegate void notifyGrabCameraDelegate(List<Camera> cameras);
        public event notifyGrabCameraDelegate notifyRecordCameraEvent;

        /// <summary>
        /// Este evento se ejecuta cuando la grabación en disco de las cámaras ha finalizado.
        /// </summary>
        /// <param name="id">Id of the camera selected.</param>
        public delegate void notifyStopGrabCameraDelegate(List<Camera> cameras);
        public event notifyStopGrabCameraDelegate notifyStopGrabCameraEvent;

        /// <summary>
        /// Este evento es utilizado para indicar que un formulario se va a cerrar.
        /// </summary>
        /// <param name="id">Id del visualizador que se quiere cerrar.</param>
        public delegate void notifyCloseDelegate(Camera camera);
        public event notifyCloseDelegate notifyCloseEvent;

        public ButtonsTools StateTools { get => buttonsTools; set => buttonsTools = value; }
        public RecordSettings RecordSettings { get => recordSettings; set => recordSettings = value; }
        public Envisor_Algorithm Envisor_Algorithm { get => envisor_Algorithm; set => envisor_Algorithm = value; }
        public Envisor_Visualization Envisor_Visualization { get => envisor_Visualization; set => envisor_Visualization = value; }
        internal Basler_InformatioBar_Controls Basler_informationbar_controls { get => basler_informationbar_controls; set => basler_informationbar_controls = value; }

        public PanelManager(ref FlowLayoutPanel pnl, ref ButtonsTools buttonsTools, RecordingForm recordingForm)
        {
            flowLayoutPanelCameras = pnl;

            this.buttonsTools = buttonsTools;

            pnlCameras = new Dictionary<Camera, Panel>();
            camerasForm = new Dictionary<Camera, Form>();

            camera_selected = null;

            color_default = Color.FromArgb(0, 113, 206);
            color_record = Color.Red;

            this.recordingForm = recordingForm;

            ConnectBtns();
        }

        /// <summary>
        /// Esta función es utilizada pra conectar todos los controles utilizados en la función <see cref="AddControl(ref ToolStripMenuItem, ref ToolStripMenuItem)">AddControl(ref ToolStripMenuItem, ref ToolStripMenuItem)</see>/>.
        /// </summary>
        public void ConnectBtns()
        {
            buttonsTools.BtnGrabContinuous.Click += new System.EventHandler(this.BtnGrabContinuous_Click);
            buttonsTools.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            buttonsTools.BtnResetZoom.Click += new System.EventHandler(this.BtnResetZoom_Click);
            buttonsTools.BtnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            buttonsTools.BtnStopRecord.Click += new System.EventHandler(this.BtnStopRecord_Click);
            buttonsTools.BtnLine.Click += new System.EventHandler(this.BtnLine_Click);
            buttonsTools.BtnPoint.Click += new System.EventHandler(this.BtnPoint_Click);
            buttonsTools.BtnRectangle.Click += new System.EventHandler(this.BtnRectangle_Click);
            buttonsTools.BtnElipse.Click += new System.EventHandler(this.BtnElipse_Click);
            buttonsTools.BtnPolygon.Click += new System.EventHandler(this.BtnPolygon_Click);
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
            DisconnectMouse();
            DisconnectFps();

            SelectCamera(camera: camera);

            ConnectMouse();
            ConnectFps();
            ShowInformationCamera();
            Color_Information_Bar(color: color_default);

            if (buttonsTools != null)
            {
                if (Count_Cameras_Connected() > 0)
                {
                    /* STATE TOOLS */
                    buttonsTools.SingleShot();
                    buttonsTools.GrabContinuous(state: false);
                    buttonsTools.Pause();
                    buttonsTools.ResetZoom();
                }
                else
                {
                    /* STATE TOOLS */
                    buttonsTools.SingleShot(state: false);
                    buttonsTools.GrabContinuous();
                    buttonsTools.Pause(state: false);
                    buttonsTools.ResetZoom(state: false);
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

                SelectBorder(camera: camera_selected);
            }

            /* STATE TOOLS */
            if (buttonsTools != null)
            {
                buttonsTools.SingleShot();
                buttonsTools.GrabContinuous(state: false);
                buttonsTools.Record();
                buttonsTools.Pause();
                buttonsTools.ResetZoom();
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
                (form as Basler_Display_Form).closeEvent += new Basler_Display_Form.closeDelegate(Remove);
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

        public void RestoreCameraSelectedToPanel()
        {
            if (camera_selected != null)
            {
                if (camerasForm.ContainsKey(camera_selected))
                {
                    Form form = camerasForm[camera_selected];

                    if (camera_selected.GetType().ToString().Contains("Basler"))
                    {
                        (form as Basler_Display_Form).Display.Connect(ref camera_selected);
                    }
                }
            }
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

        /// <summary>
        /// This method return a list with the cameras connected.
        /// </summary>
        /// <returns></returns>
        public List<Camera> CamerasConnected()
        {
            if (pnlCameras != null)
                return pnlCameras.Keys.ToList();
            else
                return new List<Camera>();
        }
        /**************** INFORMATION CAMERA FUNCTION ***********/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method show the information of the <see cref="camera_selected">camera_selected</see>/> in the controls of <see cref="basler_informationbar_controls">basler_informationbar_controls</see>/>.
        /// </summary>
        private void ShowInformationCamera()
        {
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbIp, "Text", camera_selected.IpAddress != "" ? ("Ip: " + camera_selected.IpAddress) : "");
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbName, "Text", "Name: " + camera_selected.Name);
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbFps, "Text", "Fps: " + camera_selected.Fps_Process);
        }

        /*************** INFORMATION BAR FUNCTION ***************/
        /********************************************************/
        /********************************************************/

        private void Color_Information_Bar(Color color)
        {
            basler_informationbar_controls.LayoutPanelControls.BackColor = color;
        }

        /********************* FPS FUNCTION *********************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method connect the <see cref="Camera._fpsEvent">Camera._fpsEvent</see>/> of <see cref="camera_selected">camera_selected</see>/>
        /// with <see cref="ShowFps(double)">ShowFps(double)</see>/> function.
        /// </summary>
        private void ConnectFps()
        {
            if (camera_selected != null)
                camera_selected._fpsEvent += new Camera._fpsDelagete(ShowFps);
        }

        /// <summary>
        /// This method disconnect the <see cref="Camera._fpsEvent">Camera._fpsEvent</see>/> of <see cref="camera_selected">camera_selected</see>/>
        /// with <see cref="ShowFps(double)">ShowFps(double)</see>/> function.
        /// </summary>
        private void DisconnectFps()
        {
            if (camera_selected != null)
                camera_selected._fpsEvent -= new Camera._fpsDelagete(ShowFps);
        }

        /// <summary>
        /// This method show the fps passes by parameter in <see cref="Basler_InformatioBar_Controls.lbFps">Basler_InformatioBar_Controls.lbFps</see>/>
        /// label.
        /// </summary>
        /// <param name="value">Value of the fps.</param>
        private void ShowFps(double value)
        {
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbFps, "Text", "Fps: " + Math.Truncate(value));
        }

        /********************** MOUSE FUNCTION ******************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// This method connect the mouse event of a camera with <see cref="ShowInformationMouse(Point, double)">ShowInformationMouse(Point, double)</see>/>.
        /// </summary>
        private void ConnectMouse()
        {
            if (camera_selected != null)
            {
                if (camera_selected.GetType().ToString().Contains("Basler"))
                    (camera_selected as Basler)._infoMouseEvent += new Camera._infoMouseDelegate(ShowInformationMouse);

                camera_selected.StartMouseMove();
            }
        }

        /// <summary>
        /// This method disconnect the mouse event of a camera with <see cref="ShowInformationMouse(Point, double)">ShowInformationMouse(Point, double)</see>/>.
        /// </summary>
        private void DisconnectMouse()
        {
            if (camera_selected != null)
            {
                camera_selected.StopMouseMove();

                if (camera_selected.GetType().ToString().Contains("Basler"))
                    (camera_selected as Basler)._infoMouseEvent -= new Camera._infoMouseDelegate(ShowInformationMouse);
            }
        }

        /// <summary>
        /// This method show the information of the mouse in the camera selected.
        /// See, <see cref="SelectCamera(ref Camera)">SelectCamera(ref Camera)</see>/>.
        /// </summary>
        /// <param name="point">Point of the mouse in the image.</param>
        /// <param name="intensity">Intensity of the image in the point of the mouse.</param>
        private void ShowInformationMouse(Point point, double intensity)
        {
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbIntensity, "Text", "Intensity: " + intensity.ToString());
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbPosX, "Text", "Position X: " + point.X);
            SetControlPropertyThreadSafe(basler_informationbar_controls.LbPosY, "Text", "Position Y: " + point.Y);
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
                    buttonsTools.Record();
                else
                {
                    buttonsTools.Record(state: false);
                    buttonsTools.SingleShot(state: false);
                    buttonsTools.GrabContinuous(state: false);
                    buttonsTools.Pause(state: false);
                    buttonsTools.ResetZoom(state: false);
                }

                if (camera_selected != null)
                    if (camera_selected == camera)
                        camera_selected = null;

                if (notifyCloseEvent != null)
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
            {
                if (camera.GetType().ToString().Contains("Basler"))
                    ((camerasForm[camera] as Basler_Display_Form).Display as Basler_Display).Disconnect();

                camerasForm.Remove(camera);
            }
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

                if (buttonsTools != null)
                {
                    /* STATE TOOLS */
                    buttonsTools.SingleShot();
                    buttonsTools.GrabContinuous(state: false);
                    buttonsTools.Pause();
                    buttonsTools.ResetZoom();
                    buttonsTools.Graphics();
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
            buttonsTools.Pause(state: false);
            buttonsTools.GrabContinuous();

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
                _record = true;

                string pathFolder = GetPathCameraToRecord(camera: camera);

                switch (recordSettings.Type)
                {
                    case "Vídeo":

                        string pathFile = System.IO.Path.Combine(pathFolder, NAME_VIDEO_FILE + GetExtensition(recordSettings));
                        string name = NAME_VIDEO_MILLIBRARY + "-" + camera.Dev;

                        /* ADD VIDEO */
                        Envisor_Algorithm.Videos.Add_Video_MSequence(camera: camera, name: name, format: (int)recordSettings.OutputFormat,
                            path: pathFile, mode_postTrigger: recordSettings.Mode_postTrigger, timePretrigger: -1, valuePostTrigger: recordSettings.TimeStop, fps: 0);

                        /* START VIDEO */
                        Video video = Envisor_Algorithm.Videos.GetVideo(name: name);

                        if (!video.IsAssignEndEvent())
                            video._endVideoEvent += new Video._endVideoDelagete(StopGrab_Controls);

                        video.Start();

                        break;

                    case "Secuencia de imágenes":

                        /* ADD SEQUENCE */
                        Envisor_Algorithm.Sequences_Images.Add(camera: camera, modePostTrigger: recordSettings.Mode_postTrigger, timeStop: recordSettings.TimeStop, format: recordSettings.OutputFormat);

                        /* START SEQUENCE */
                        Envisor_Algorithm.Sequences_Images.GetSequenceImages(camera: camera).Start(pathFolder);
                        break;
                }

                if (notifyRecordCameraEvent != null)
                    notifyRecordCameraEvent.Invoke(cameras: pnlCameras.Keys.ToList());
            }

            if (pnlCameras.Keys.Count > 0)
            {
                buttonsTools.Record(state: false);
                buttonsTools.Pause(state: false);
                buttonsTools.SingleShot(state: false);
                buttonsTools.StopRecord();
                buttonsTools.Graphics(state: false);

                //foreach (DisplayCameraForm displayCameraForm in camerasForm.Values)
                //    displayCameraForm.EnableBtnClose(state: false);
            }

            Color_Information_Bar(color: color_record);
        }

        /// <summary>
        /// This method prepare the path of a camera to record.
        /// </summary>
        /// <param name="camera">Camera you want to select.</param>
        /// <returns></returns>
        private string GetPathCameraToRecord(Camera camera)
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

            return pathFolder;
        }

        /// <summary>
        /// This method return the extensition in recordingSettings.
        /// </summary>
        /// <param name="recordSettings"></param>
        /// <returns></returns>
        private string GetExtensition(RecordSettings recordSettings)
        {
            switch (recordSettings.OutputFormat)
            {
                case MIL.M_FILE_FORMAT_AVI:
                    return ".avi";
                case MIL.M_FILE_FORMAT_H264:
                    return ".avi";
                case MIL.M_FILE_FORMAT_MP4:
                    return ".mp4";
            }

            return "";
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnStopRecord">btnStopRecord</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopRecord_Click(object sender, EventArgs e)
        {
            Envisor_Algorithm.StopRecord();

            StopGrab_Controls();

            _record = false;
        }

        /// <summary>
        /// This method contains all function need when the record end.
        /// </summary>
        /// <param name="camera"></param>
        private void StopGrab_Controls(Camera camera = null)
        {
            if (_record)
            {
                if (buttonsTools != null)
                {
                    buttonsTools.Record();
                    buttonsTools.Pause();
                    buttonsTools.SingleShot();
                    buttonsTools.StopRecord(state: false);

                    if (camera_selected != null)
                    {
                        buttonsTools.Graphics();
                    }
                }

                if (notifyStopGrabCameraEvent != null)
                    notifyStopGrabCameraEvent.Invoke(cameras: pnlCameras.Keys.ToList());

                Color_Information_Bar(color: color_default);

                _record = false;
            }
        }

        /****************** GRAPHICS FUNCTION *******************/
        /********************************************************/
        /********************************************************/

        private void BtnLine_Click(object sender, EventArgs e)
        {

        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {

        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {

        }

        private void BtnElipse_Click(object sender, EventArgs e)
        {

        }

        private void BtnPolygon_Click(object sender, EventArgs e)
        {
            envisor_Visualization.DrawGraphics.Start(camera_selected.MilDisplay, MIL.M_GRAPHIC_TYPE_POLYGON);
        }

        /// <summary>
        /// This method is executed when the user press right click in a panel of <see cref="flowLayoutPanelCameras">flowLayoutPanelCameras</see>/>.
        /// </summary>
        /// <param name="camera">Camera selected.</param>
        public void NotifyCameraSelected(Camera camera)
        {
            SelectCamera(camera: camera);

            if (notifyMouseDownEvent != null)
                notifyMouseDownEvent.Invoke(camera);
        }

        public void SelectCamera(Camera camera)
        {
            camera_selected = camera;

            SelectBorder(camera: camera);
        }

        private void SelectBorder(Camera camera)
        {
            foreach (var camera_pnl in camerasForm)
            {
                if (camera_pnl.Key.GetType().ToString().Contains("Basler"))
                {
                    if (camera_pnl.Key == camera)
                        ((camera_pnl.Value as Basler_Display_Form).Display as Basler_Display).ChangeColorEdge(color: color_default);
                    else
                        ((camera_pnl.Value as Basler_Display_Form).Display as Basler_Display).ChangeColorEdge(color: Color.FromArgb(228,228,228));
                }
            }
        }

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

        /************* SAFE MODIFY CONTROLS FUNCTION ************/
        /********************************************************/
        /********************************************************/

        /// <summary>
        /// Función para cambiar los controles en threads separados de forma segura (Invoke)
        /// </summary>
        /// <param name="control"> Control del formulario a cambiar </param>
        /// <param name="propertyName"> Nombre de la propiedad a cambiar como STRING </param>
        /// <param name="propertyValue"> Valor que deseamos cambiar al control </param>
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new SetControlPropertyThreadSafeDelegate
                    (SetControlPropertyThreadSafe),
                    new object[] { control, propertyName, propertyValue });
                }
                else
                {
                    control.GetType().InvokeMember(
                        propertyName,
                        BindingFlags.SetProperty,
                        null,
                        control,
                        new object[] { propertyValue });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
    }
}
