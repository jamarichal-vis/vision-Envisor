using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;

namespace Recording
{
    public partial class RecordingForm : Form
    {
        /// <summary>
        /// Nombre del video en la libraria <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        private const string NAME_VIDEO_MILLIBRARY = "VIDEO";

        /// <summary>
        /// This object storages the app object of MilLibrary.
        /// </summary>
        private MilApp milApp;

        /// <summary>
        /// This dictionary contains all system in this app.
        /// </summary>
        private Dictionary<string, MilSystem> milSystems;

        /// <summary>
        /// This dictionary contains all cameras of the gigevision system.
        /// </summary>
        private Dictionary<string, Camera> cameras_GigeVision;

        /// <summary>
        /// This dictionary contains all cameras of the usb3Vision system.
        /// </summary>
        private Dictionary<string, Camera> cameras_Usb3Vision;

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
        /// Esta variable contiene todas las funciones necesarias para controlar el objeto <see cref="treeViewCameras">treeViewCameras</see>/>.
        /// </summary>
        private CameraManager cameraManager;

        /// <summary>
        /// Esta variable contiene todas las funciones necesarias para controlar la sección de frame rate de las cámaras.
        /// </summary>
        private FrameRateManager frameRateManager;

        /// <summary>
        /// Esta variable contiene todas las funciones necesarias para controlar la sección de exposure time de las cámaras.
        /// </summary>
        private ExposureTimeManager exposureTimeManager;

        /// <summary>
        /// This variable storages all function related format cameras.
        /// </summary>
        private FormatManager formatManager;

        /// <summary>
        /// Esta variable contiene todas las funciones necesarias para controlar la sección de secuencias de imágenes en una cámara.
        /// </summary>
        private SequenceManager sequenceManager;

        /// <summary>
        /// Esta variable contiene todas las funciones para controlar todos los paneles que se muestren en <see cref="pnlCams">pnlCams</see>/>.
        /// </summary>
        private PanelManager panelManager;

        /// <summary>
        /// This variable storages all controls of a information bar of a basler camera.
        /// </summary>
        private Basler_InformatioBar_Controls basler_informationbar_controls;

        /// <summary>
        /// Esta variable almacena toda la configuración para poder grabar un vídeo o una secuencia con una cámara.
        /// </summary>
        private RecordSettings recordSettings;

        /// <summary>
        /// Esta variable contiene todas las funciones para cambiar el estado de la barra de herramientas.
        /// </summary>
        private ButtonsTools buttonsTools;

        /// <summary>
        /// Esta variable almacenará los datos necesarios para identificar una cámara en <see cref="MilLibrary">MilLibrary</see>/>.
        /// Donde siempre se almacenará la cámara que se encuentre seleccionada en <see cref="cameraManager">cameraManager</see>/>.
        /// </summary>
        private Id idCam;

        /************************** ACCESS ****************************/
        /**************************************************************/
        /**************************************************************/

        public Dictionary<string, MilSystem> MilSystems { get => milSystems; set => milSystems = value; }
        public Dictionary<string, Camera> Cameras_GigeVision { get => cameras_GigeVision; set => cameras_GigeVision = value; }
        public Dictionary<string, Camera> Cameras_Usb3Vision { get => cameras_Usb3Vision; set => cameras_Usb3Vision = value; }
        public Camera Camera_selected { get => camera_selected; set => camera_selected = value; }

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetTreeViewTheme(IntPtr treeHandle)
        {
            SetWindowTheme(treeHandle, "explorer", null);
        }

        public RecordingForm()
        {
            InitializeComponent();

            InitMilLibrary();

            InitCameraManager();

            InitSequenceManager();

            InitFrameRateManager();

            InitExposureTimeManager();

            InitFormatManager();

            InitButtonsTools();

            InitPanelManager();

            //tableLayoutPanel2.Width = flowLayoutPanel1.Width;
            //CheckCameras();
            /* Cambio de diseño de treViewCameras. */
            SetTreeViewTheme(treeViewCameras.Handle);
        }

        /// <summary>
        /// Esta función contiene todas las funciones necesarias para inicializar <see cref="MilLibrary">MilLibrary</see>/> en este programa.
        /// </summary>
        public void InitMilLibrary()
        {
            milApp = new MilApp("Recording", isTest: false);

            /****************** ADD SYSTEMS ***********************/
            /******************************************************/
            /******************************************************/
            milApp.AddMilSystem(MilApp.GIGEVISION_SYSTEM_NAME);
            milApp.AddMilSystem(MilApp.USB3VISION_SYSTEM_NAME);

            MilSystems = milApp.MilSystems;

            /******************** SETTINGS SYSTEMS ****************/
            /******************************************************/
            /******************************************************/
            if (MilSystems.ContainsKey(MilApp.GIGEVISION_SYSTEM_NAME))
            {
                (MilSystems[MilApp.GIGEVISION_SYSTEM_NAME] as MilSysCameras).ConnectCamera_type = "Dev";

                (MilSystems[MilApp.GIGEVISION_SYSTEM_NAME] as MilSysCameras)._cameraConnectedEvent += new MilSysCameras._cameraDelagete(ConnectedCameraEvent);
                (MilSystems[MilApp.GIGEVISION_SYSTEM_NAME] as MilSysCameras)._cameraPreDisconnectedEvent += new MilSysCameras._cameraDelagete(PreDisconnectedCameraEvent);
                (MilSystems[MilApp.GIGEVISION_SYSTEM_NAME] as MilSysCameras)._cameraPostDisconnectedEvent += new MilSysCameras._Delagete(PostDisconnectedCameraEvent);
            }

            if (MilSystems.ContainsKey(MilApp.USB3VISION_SYSTEM_NAME))
            {
                (MilSystems[MilApp.USB3VISION_SYSTEM_NAME] as MilSysCameras).ConnectCamera_type = "Dev";
            }

            /****************** ADD CAMERAS ***********************/
            /******************************************************/
            /******************************************************/
            if (MilSystems.ContainsKey(MilApp.GIGEVISION_SYSTEM_NAME))
            {
                Cameras_GigeVision = (MilSystems[MilApp.GIGEVISION_SYSTEM_NAME] as MilSysCameras).Cameras;
                (MilSystems[MilApp.GIGEVISION_SYSTEM_NAME] as MilSysCameras).AddCamera();
            }

            if (MilSystems.ContainsKey(MilApp.USB3VISION_SYSTEM_NAME))
            {
                Cameras_Usb3Vision = (MilSystems[MilApp.USB3VISION_SYSTEM_NAME] as MilSysCameras).Cameras;
                (MilSystems[MilApp.USB3VISION_SYSTEM_NAME] as MilSysCameras).AddCamera();
            }

            InitEnvisorAlgorithm();

            InitEnvisorVisualization();

            /************** ADD CAMERAS IN PROGRAM ****************/
            foreach (var camera in Cameras_GigeVision)
                ConnectedCameraInSystem(camera.Value);

            foreach (var camera in Cameras_Usb3Vision)
                ConnectedCameraInSystem(camera.Value);

            camera_selected = null;
        }

        /// <summary>
        /// This method contains all functio to initialize the <see cref="envisor_Algorithm">envisor_Algorithm</see>/>.
        /// </summary>
        public void InitEnvisorAlgorithm()
        {
            envisor_Algorithm = new Envisor_Algorithm();
        }

        /// <summary>
        /// This method contains all functio to initialize the <see cref="envisor_Visualization">envisor_Visualization</see>/>.
        /// </summary>
        public void InitEnvisorVisualization()
        {
            envisor_Visualization = new Envisor_Visualization(milSystem: MilSystems[MilApp.GIGEVISION_SYSTEM_NAME]);
        }

        /// <summary>
        /// Esta función será la que este conectada con el evento "ConnectedCameraInfo".
        /// Este evento se ejecutará cuando se conecte una cámara.
        /// Este evento asigna todos los recursos de la cámara conectada.
        /// Asignará tambien los recursos asociados al formulario.
        /// 
        /// Solo se ejecutará cuando se conecte una cámara del sistema GigeVision.
        /// </summary>
        /// <param name="milSys">MIL_ID del sistema.</param>
        /// <param name="devMatrox">identifier that matrox has assigned to the camera that has been connected</param>
        /// <param name="name">Name of the camera that has connected.</param>
        /// <param name="ip">Ip of the camera that has connected.</param>
        public void ConnectedCameraEvent(Camera camera)
        {
            ConnectedCameraInSystem(camera);

            /* CAMERA MANAGER */
            cameraManager.UpdateCameras(safe: true);
        }

        /// <summary>
        /// Evento de desconectar cámaras. La función se ejecutará en el momento previo a eliminar sus datos de MilLibrary.
        /// Solo se ejecutará cuando se desconecte una cámara del sistema GigeVision.
        /// </summary>
        /// <param name="milSys">Sistema de la cámara.</param>
        /// <param name="devN">Posición en MilLibrary de la cámara.</param>
        /// <param name="disconnectedCameraName">Nombre de la cámara.</param>
        /// <param name="disconnectedCameraIp">Ip de la cámara.</param>
        public void PreDisconnectedCameraEvent(Camera camera)
        {
            panelManager.Remove(camera);

            if (cameraManager.Camera_selected == camera)
                cameraManager.Camera_selected = null;
        }

        /// <summary>
        /// This method is executed when a camera is desconnect. This event is executed when the Library has remove the camera of its structure.
        /// </summary>
        /// <param name="camera"></param>
        public void PostDisconnectedCameraEvent()
        {
            /* CAMERA MANAGER */
            cameraManager.UpdateCameras(safe: true);
        }

        /// <summary>
        /// Esta función se utiliza para conectar una cámara al programa.
        /// En su interior se realizarán todas las funciones necesarias para conectar la cámara indicada.
        /// </summary>
        /// <param name="devSys">Dev del sistema.</param>
        /// <param name="devDig">Dev de la cámara en el interior del sistema.</param>
        /// <summary>
        /// Esta función es la encargada de configurar una cámara.
        /// Esta función es utilizada en el constructor IgniteForm y <see cref="ConnectedCameraEvent(MIL_ID, MIL_INT)">ConnectedCameraEvent(MIL_ID, MIL_INT)</see>/>
        /// </summary>
        /// <param name="devDig">Posición de la cámara en el sistema con la que quieres trabajar. En este caso el sistema es GigeVision.</param>
        public void ConnectedCameraInSystem(Camera camera)
        {
            AddVideo(camera);

            /******************** EVENT PROCESSING FUNCTION ****************/
            /***************************************************************/
            /***************************************************************/
            camera._cameraEvent += new Camera._cameraDelagete(ProcessingFunction);
        }

        private void AddVideo(Camera camera)
        {
            string name = NAME_VIDEO_MILLIBRARY + "-" + camera.Dev;

            /* ADD VIDEO */
            if (envisor_Algorithm != null && recordSettings != null)
                envisor_Algorithm.Videos.Add_Video_MSequence(camera: camera, name: name, format: 0,
                    path: "", mode_postTrigger: recordSettings.Mode_postTrigger, valuePretrigger: recordSettings.Pretrigger, valuePostTrigger: recordSettings.TimeStop, fps: 0);
        }

        /// <summary>
        /// This method update the data in videos of the cameras in <see cref="cameras_GigeVision">cameras_GigeVision</see>/> and 
        /// <see cref="cameras_Usb3Vision">cameras_Usb3Vision</see>/>
        /// </summary>
        public void UpdateSequence()
        {
            foreach (var camera in cameras_GigeVision)
                AddVideo(camera.Value);

            foreach (var camera in cameras_Usb3Vision)
                AddVideo(camera.Value);
        }

        /// <summary>
        /// Esta función se ejecuta en cada hilo de las cámaras que esten conectadas al programa.
        /// </summary>
        /// <param name="milSys">Dev del sistema.</param>
        /// <param name="dev">Dev de la cámara en el interior del sistema.</param>
        /// <param name="name">Nombre de la cámara.</param>
        /// <param name="ip">Ip de la cámara.</param>
        public void ProcessingFunction(Camera camera)
        {
            if (envisor_Visualization != null)
            {
                if (envisor_Visualization.IsShowData)
                {
                    //envisor_Visualization.DrawGraphics.Start()
                }
            }

            if (envisor_Algorithm != null)
            {
                envisor_Algorithm.Record();
            }
        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="cameraManager">cameraManager</see>/>.
        /// </summary>
        public void InitCameraManager()
        {
            cameraManager = new CameraManager(this, ref treeViewCameras, cameras_GigeVision: ref cameras_GigeVision, cameras_Usb3Vision: ref cameras_Usb3Vision,
                milSystemGigeVision: milSystems[MilApp.GIGEVISION_SYSTEM_NAME], milSystemUsb3Vision: milSystems[MilApp.USB3VISION_SYSTEM_NAME], camera_selected: ref camera_selected);

            cameraManager.selectedCamEvent += new CameraManager.selectedCamDelegate(SelectedCamera);
            cameraManager.FreeCameraEvent += new CameraManager.FreeCameraDelegate(PreDisconnectedCameraEvent);

            cameraManager.UpdateCameras();
        }

        /// <summary>
        /// This method initializer the <see cref="frameRateManager">frameRateManager</see>/> object.
        /// </summary>
        public void InitFrameRateManager()
        {
            frameRateManager = new FrameRateManager(this, ref tbLayoutPanelFrameRate, ref numericUpDownFrameRate, ref trBarFrameRate, ref lbMaxFrameRate);

            frameRateManager.changeFrameRateEvent += new FrameRateManager.changeFrameRateDelegate(ChangeFrameRate);
        }

        /// <summary>
        /// This method initializer the <see cref="frameRateManager">frameRateManager</see>/> object.
        /// </summary>
        public void InitExposureTimeManager()
        {
            exposureTimeManager = new ExposureTimeManager(this, ref tableLayoutPanelExposureTime, ref numericUpDownExposureTime, ref trackBarExposureTime);
        }

        /// <summary>
        /// This method initializer the <see cref="formatManager">formatManager</see>/> object.
        /// </summary>
        public void InitFormatManager()
        {
            formatManager = new FormatManager(this, tableLayoutPanel: ref tableLayoutPanelFormat, numUpDownSizeX: ref numericUpDownImageFormatPixelX,
                numUpDownSizeY: ref numericUpDownImageFormatPixelY);

            formatManager.changeResolutionEvent += new FormatManager.changeResolutionDelegate(RestoreCameraSelectedToPanel);
        }

        private void InitSequenceManager()
        {
            recordSettings = new RecordSettings();

            sequenceManager = new SequenceManager(cBoxUnits: ref cbBoxUnits, numericUpDownTotal: ref numericUpDownTotal,
                lbTotalUnits: ref lbSequenceValueTotalUnits, cBoxTypetrigger: ref cbBoxTypeTrigger, numericUpDownTrigger: ref numericUpDownTrigger,
                lbTriggerUnit: ref lbSequenceTriggerUnits, numericUpDownPosition: ref numericUpDownPositionTrigger,
                trBarPosition: ref trackBarSequence, lbMaxTrBar: ref lbMaxSequence);

            sequenceManager.updateSequenceEvent += new SequenceManager.updateSequenceDelegate(UpdateSequence);

            sequenceManager.RecordSettings = recordSettings;
            sequenceManager.UpdateRecordingSettings();
        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="panelManager">panelManager</see>/>.
        /// </summary>
        public void InitPanelManager()
        {
            panelManager = new PanelManager(pnl: ref pnlCams, buttonsTools: ref buttonsTools, recordingForm: this);

            panelManager.notifyGrabContinuousCameraEvent += new PanelManager.notifyGrabContinuousCameraDelegate(NotifyCameraGrabContinuous);
            panelManager.notifyPauseCameraEvent += new PanelManager.notifyPauseCameraDelegate(NotifyCameraPause);
            panelManager.notifyRecordCameraEvent += new PanelManager.notifyGrabCameraDelegate(NotifyCameraGrab);
            panelManager.notifyStopGrabCameraEvent += new PanelManager.notifyStopGrabCameraDelegate(NotifyCameraStopGrab);
            panelManager.notifyMouseDownEvent += new PanelManager.notifyMouseDownDelegate(NotifyMouseDown);
            panelManager.notifyCloseEvent += new PanelManager.notifyCloseDelegate(NotifyClose);

            basler_informationbar_controls = new Basler_InformatioBar_Controls(lbIp: ref lbIp, lbName: ref lbName, lbIntensity: ref lbIntensity,
                lbPosX: ref lbPosX, lbPosY: ref lbPosY, lbFps: ref lbFps, tableLayoutPanel: ref tableLayoutPanelInformationBar);

            panelManager.RecordSettings = recordSettings;
            panelManager.Envisor_Algorithm = envisor_Algorithm;
            panelManager.Envisor_Visualization = envisor_Visualization;
            panelManager.Basler_informationbar_controls = basler_informationbar_controls;

            cameraManager.grabContinuousCamEvent += new CameraManager.grabContinuousCamDelegate(panelManager.StartGrabContinuous);
        }

        ///// <summary>
        ///// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="stateTools">stateTools</see>/>.
        ///// </summary>
        private void InitButtonsTools()
        {
            buttonsTools = new ButtonsTools(this, ref btnSingleShot, ref btnContinuousShot, ref btnPause, ref btnRecord, ref btnResetZoom,
                ref btnStopRecord, btnGraphics: ref btnGraphics, btnLine: ref btnLine, btnPoint: ref btnPoint, btnElipse: ref btnElipse, btnRectangle: ref btnRectangle,
                btnPolygon: ref btnPolygon);

            cameraManager.StateTools = buttonsTools;
        }

        /****************** CAMERA MANAGER FUNCTION ***********************/
        /******************************************************************/
        /******************************************************************/

        /// <summary>
        /// This method is used to notify to this form that the user have selected a camera.
        /// 
        /// The camera selected is in <see cref="camera_selected">camera_selected</see>/>.
        /// </summary>
        private void SelectedCamera(Camera camera)
        {
            /* FORMAT */
            if (formatManager != null)
            {
                formatManager.Enable();
                formatManager.SelectCam(camera: camera);
            }

            /* FRAME RATE */
            if (frameRateManager != null)
            {
                frameRateManager.Enable();
                frameRateManager.SelectCam(camera: camera);
            }

            /* EXPOSURE TIME */
            if (exposureTimeManager != null)
            {
                if (camera.GetType().ToString().Contains("Basler"))
                {
                    exposureTimeManager.Enable();
                    exposureTimeManager.SelectCam(camera: camera);
                }
                else
                {
                    exposureTimeManager.Reset();
                    exposureTimeManager.Disable();
                }
            }

            /* PANEL MANAGER */
            if (panelManager != null)
            {
                panelManager.SelectCamera(camera: ref camera);
            }
        }

        /// <summary>
        /// This method is used to notify to this form that the user have freed a camera in <see cref="CameraManager">CameraManager</see>/>.
        /// 
        /// See, <see cref="InitCameraManager">InitCameraManager</see>/>.
        /// </summary>
        private void FreeCamera()
        {

        }

        /******************* PANEL MANAGER FUNCTION ***********************/
        /******************************************************************/
        /******************************************************************/

        /// <summary>
        /// This method is executes when the user press <see cref="btnContinuousShot">btnContinuousShot</see>/>.
        /// 
        /// Also, this function is connect with <see cref="PanelManager.notifyGrabContinuousCameraEvent">PanelManager.notifyGrabContinuousCameraEvent</see>/>.
        /// See, <see cref="InitPanelManager">InitPanelManager</see>/>.
        /// </summary>
        /// <param name="camera">Camera selected in panel manager.</param>
        private void NotifyCameraGrabContinuous(Camera camera)
        {
            formatManager.Disable();
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnPause">btnPause</see>/>.
        /// 
        /// Also, this function is connect with <see cref="PanelManager.notifyPauseCameraEvent">PanelManager.notifyPauseCameraEvent</see>/>.
        /// See, <see cref="InitPanelManager">InitPanelManager</see>/>.
        /// </summary>
        /// <param name="camera">Camera selected in panel manager.</param>
        private void NotifyCameraPause(Camera camera)
        {
            formatManager.Enable();
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnRecord">btnRecord</see>/>.
        /// 
        /// Also, this function is connect with <see cref="PanelManager.notifyStopGrabCameraEvent">PanelManager.notifyStopGrabCameraEvent</see>/>.
        /// See, <see cref="InitPanelManager">InitPanelManager</see>/>.
        /// </summary>
        /// <param name="cameras">Cameras connect in panel manager.</param>
        private void NotifyCameraGrab(List<Camera> cameras)
        {
            cameraManager.ModifyIconGrab(cameras: cameras);

            frameRateManager.Disable();
            exposureTimeManager.Disable();
        }

        /// <summary>
        /// This method is executes when the user press <see cref="btnStopRecord">btnStopRecord</see>/>.
        /// 
        /// Also, this function is connect with <see cref="PanelManager.notifyStopGrabCameraEvent">PanelManager.notifyStopGrabCameraEvent</see>/>.
        /// See, <see cref="InitPanelManager">InitPanelManager</see>/>.
        /// </summary>
        /// <param name="cameras">Cameras connect in panel manager.</param>
        private void NotifyCameraStopGrab(List<Camera> cameras)
        {
            cameraManager.SetIconConnect(cameras: cameras);

            frameRateManager.Enable(safe: true);
            exposureTimeManager.Enable(safe: true);
        }

        /// <summary>
        /// This function is executed when the user click in a panel of <see cref="panelManager">panelManager</see>/>.
        /// </summary>
        /// <param name="cameras">Camera selected.</param>
        private void NotifyMouseDown(Camera camera)
        {
            if (camera.IsGrabProcessingFunction)
            {
                formatManager.Disable(safe: true);
            }
            else
            {
                formatManager.Enable(safe: true);
                frameRateManager.Enable(safe: true);
                exposureTimeManager.Enable(safe: true);
            }
        }

        /// <summary>
        /// This function is executed when the user click in button close in a panel of <see cref="panelManager">panelManager</see>/>.
        /// </summary>
        /// <param name="cameras">Camera selected.</param>
        private void NotifyClose(Camera camera)
        {
            cameraManager.Deselect(camera);

            formatManager.Disable(safe: true);
            frameRateManager.Disable(safe: true);
            exposureTimeManager.Disable(safe: true);
        }

        /// <summary>
        /// This method restore the camera selected in the panel that it is showing the <see cref="PanelManager.camera_selected">PanelManager.camera_selected</see>/>.
        /// </summary>
        private void RestoreCameraSelectedToPanel(Camera camera)
        {
            if (panelManager != null)
            {
                panelManager.RestoreCameraSelectedToPanel();
            }
        }

        /****************** FRAME RATE MANAGER FUNCTION *******************/
        /******************************************************************/
        /******************************************************************/

        /// <summary>
        /// This method is executed when the user modify the frame rate of a camera in <see cref="frameRateManager">frameRateManager</see>/>.
        /// See <see cref="InitFrameRateManager">InitFrameRateManager</see>/>.
        /// </summary>
        /// <param name="value">Value of the frame rate modified</param>
        public void ChangeFrameRate(double value)
        {
            //exposureTimeManager.Max(value);
        }

        /********************** MENU FUNCTION *****************************/
        /******************************************************************/
        /******************************************************************/

        private void grabarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordSettingsForm recordSettingsForm = new RecordSettingsForm(ref recordSettings);
            recordSettingsForm.StartPosition = FormStartPosition.CenterScreen;

            recordSettingsForm.ShowDialog();

            UpdateSequence();
        }

        ///// <summary>
        ///// Esta función se ejecuta cuando se selecciona una cámara en <see cref="cameraManager">cameraManager</see>/>.
        ///// Ver, <see cref="CameraManager.selectedCamEvent">CameraManager.selectedCamEvent</see>/>.
        ///// La variable <see cref="idCam">idCam</see>/> se actualiza en el interior del objeto <see cref="cameraManager"/>.
        ///// Ver, <see cref="CameraManager.treeViewCameras_AfterSelect(object, TreeViewEventArgs)">CameraManager.treeViewCameras_AfterSelect(object, TreeViewEventArgs)</see>/>.
        ///// </summary>
        //public void SelectedCamera()
        //{
        //    Dictionary<string, string> camInfo = milApp.CamInfo(idCam.DevNSys, idCam.DevNCam);

        //    //panelManager.ShowCams(idCam);
        //    panelManager.SelectCamera(idCam);

        //    frameRateManager.Enable();
        //    frameRateManager.SelectCam();

        //    if (camInfo["Vendor"] == "FLIR" || camInfo["Vendor"].Contains("FLIR"))
        //    {
        //        exposureTimeManager.Reset();
        //        exposureTimeManager.Disable();
        //    }
        //    else
        //    {
        //        exposureTimeManager.Enable();
        //    }

        //    if (panelManager.IsShow(idCam))
        //    {
        //        /* STATE TOOLS */
        //        stateTools.SingleShot();
        //        stateTools.GrabContinuous(state: false);
        //        stateTools.Pause();
        //        stateTools.ResetZoom();
        //    }
        //    else
        //    {
        //        /* STATE TOOLS */
        //        stateTools.SingleShot(state: false);
        //        stateTools.GrabContinuous();
        //        stateTools.Pause(state: false);
        //        stateTools.ResetZoom(state: false);
        //    }

        //}

        ///// <summary>
        ///// This function is used to select a camera in <see cref="cameraManager">cameraManager</see>/>.
        ///// </summary>
        ///// <param name="id">Id of the camera you want to select.</param>
        //public void SelectCameraInCameraManager(Id id)
        //{
        //    if (id != null)
        //        cameraManager.SelectCamera(id);
        //    else
        //        cameraManager.DeselectCamera();
        //}

        //public void ChangeFrameRate(double value)
        //{
        //    exposureTimeManager.Max(value);
        //}

        //public void FreeCamera()
        //{
        //    panelManager.Remove(idCam);
        //}

        ///// <summary>
        ///// Esta función esta conectada con el evento <see cref="SequenceManager.startGrabEvent">"SequenceManager.startGrabEvent</see>/>.
        ///// 
        ///// Se ejecutará cuando se ejecute el evento click de <see cref="btnRecord">btnRecord</see>/>, 
        ///// definido en <see cref="SequenceManager.btnRecord_Click(object, EventArgs)">SequenceManager.btnRecord_Click(object, EventArgs)</see>/>
        ///// </summary>
        //private void StartGrabVideo()
        //{
        //    panelManager.GrabCamera(idCam);
        //}

        ///// <summary>
        ///// Esta función se conectará con el evento <see cref="PanelManager.notifyGrabCameraEvent">PanelManager.notifyGrabCameraEvent</see>/>.
        ///// 
        ///// Aqui, se aplicarán todas las funciones necesarias cuando se comience a grabar en <see cref="PanelManager">PanelManager</see>/>.
        ///// </summary>
        //private void NotifyGrabCameras()
        //{
        //    cameraManager.EnableTreeView(state: false);
        //    frameRateManager.Disable();
        //    exposureTimeManager.Disable();
        //}

        ///// <summary>
        ///// Esta función se conectará con el evento <see cref="PanelManager.notifyStopGrabCameraEvent">PanelManager.notifyStopGrabCameraEvent</see>/>.
        ///// 
        ///// Aqui, se aplicarán todas las funciones necesarias cuando se termine la grabación en <see cref="PanelManager">PanelManager</see>/>.
        ///// </summary>
        //private void NotifyStopGrabCameras()
        //{
        //    cameraManager.EnableTreeView(state: true);
        //    frameRateManager.Enable(safe: true);
        //    exposureTimeManager.Enable(safe: true);
        //}

        ///// <summary>
        ///// Esta función se ejecuta cuando se termina la grabación de un vídeo o secuencia de imágenes.
        ///// </summary>
        ///// <param name="milSys">Dev del sistema en MilLibrary.</param>
        ///// <param name="CameraName">Nombre de la cámara que ha lanzado este evento.</param>
        ///// <param name="CameraIp">Ip de la cámara que ha lanzado este evento.</param>
        ///// <param name="path">Path del vídeo que se ha grabado.</param>
        ///// <param name="fps">Fps de la cámara.</param>
        //public void EndVideo(MIL_ID milSys, MIL_INT matroxDevDig, string CameraName, string CameraIp, string path, double fps)
        //{
        //    MIL_INT devSys = milApp.GetIndexSystemByID(milSys);
        //    MIL_INT devCam = milApp.GetIndexCamByDevN(devSys, matroxDevDig);

        //    Id id = new Id(devSys, devCam);

        //    if (idCam.Equal(id))
        //        panelManager.SelectCamera(id);
        //    else
        //        panelManager.DeselectCamera(id);

        //    stateTools.Record();
        //    stateTools.StopRecord(state: false);
        //    stateTools.Pause();
        //    stateTools.SingleShot();

        //    panelManager.EnableDisplayCameraFormClose();
        //    panelManager.ConnectNotifyCameraSelected();
        //    cameraManager.EnableTreeView(state: true);
        //    frameRateManager.Enable(safe: true);
        //    exposureTimeManager.Enable(safe: true);
        //}

        ///// <summary>
        ///// Función para añadir un formulario dentro de un panel
        ///// </summary>
        ///// <param name="fh"></param>
        ///// <param name="panel"></param>
        //public void AddFormInPanel(Form fh, Panel panel) /*(MetroForm fh)*/
        //{
        //    if (panel.Controls.Count > 0)
        //        panel.Controls.RemoveAt(0);

        //    fh.TopLevel = false;
        //    fh.FormBorderStyle = FormBorderStyle.None;
        //    fh.ControlBox = false;
        //    //fh.ShadowType = MetroFormShadowType.None;
        //    fh.Dock = DockStyle.Fill;

        //    panel.Controls.Add(fh);
        //    panel.Tag = fh;
        //    panel.AutoSize = true;
        //    fh.Show();
        //}

        //private void RecordingForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //displayCameraBaslerForm.DisconnectPanel();

        //    milApp.FreeRecourse();
        //}

        //private void RecordingForm_MouseDown(object sender, MouseEventArgs e)
        //{

        //}

        //private void RecordingForm_Load(object sender, EventArgs e)
        //{

        //}
    }


}
