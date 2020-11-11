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
using MilLibrary;

namespace Recording
{
    public partial class RecordingForm : Form
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
        /// Esta variable contiene todas las funciones necesarias para controlar la sección de secuencias de imágenes en una cámara.
        /// </summary>
        private SequenceManager sequenceManager;

        /// <summary>
        /// Esta variable contiene todas las funciones para controlar todos los paneles que se muestren en <see cref="pnlCams">pnlCams</see>/>.
        /// </summary>
        private PanelManager panelManager;

        /// <summary>
        /// Esta variable almacena toda la configuración para poder grabar un vídeo o una secuencia con una cámara.
        /// </summary>
        private RecordSettings recordSettings;

        /// <summary>
        /// Esta variable contiene todas las funciones para cambiar el estado de la barra de herramientas.
        /// </summary>
        private StateTools stateTools;

        /// <summary>
        /// Esta variable almacenará los datos necesarios para identificar una cámara en <see cref="MilLibrary">MilLibrary</see>/>.
        /// Donde siempre se almacenará la cámara que se encuentre seleccionada en <see cref="cameraManager">cameraManager</see>/>.
        /// </summary>
        private Id idCam;

        public RecordingForm()
        {
            InitializeComponent();

            idCam = new Id();

            InitMilLibrary();

            InitCameraManager();

            InitFrameRateManager();

            InitExposureTimeManager();

            InitSequenceManager();

            InitPanelManager();

            InitStateTools();

            CheckCameras();
        }

        /// <summary>
        /// Esta función contiene todas las funciones necesarias para inicializar <see cref="MilLibrary">MilLibrary</see>/> en este programa.
        /// </summary>
        public void InitMilLibrary()
        {
            milApp = new MilApp("Recording", isTest: true);

            /*** SISTEMAS AÑADIDOS ***/
            milApp.AddMilSystem(MIL.M_SYSTEM_GIGE_VISION);
            milApp.AddMilSystem(MIL.M_SYSTEM_USB3_VISION);

            /*** DEV SISTEMAS ***/
            devSysGigeVision = milApp.GetIndexSystemByType(MIL.M_SYSTEM_GIGE_VISION);
            devSysUsb3Vision = milApp.GetIndexSystemByType(MIL.M_SYSTEM_USB3_VISION);

            /*** INSTANCIA DE CÁMARAS ***/
            milApp.AddCameraToSystem();

            /*** EVENTOS DE SISTEMAS ***/
            EventPresentCameraInfo eventPresentCameraInfo = (EventPresentCameraInfo)milApp.SysEvent(devSysGigeVision, "ConnectedCameraInfo");
            eventPresentCameraInfo._event += new EventPresentCameraInfo._eventDelagete(ConnectedCameraEvent);

            EventPresentCameraInfo eventPresentDisconnectCameraInfo = (EventPresentCameraInfo)milApp.SysEvent(devSysGigeVision, "DisconnectedCameraInfo");
            eventPresentDisconnectCameraInfo._event += new EventPresentCameraInfo._eventDelagete(DisconnectedCameraEvent);

            /*** CONEXIÓN DE CÁMARAS ***/

            /*Este for realiza la configuración inicial de todas las cámaras que se encunetran en la aplicación.
                     * Preparamos las cámaras.
                     * Activamos y asignamos la función de los eventos asignados a cada cámara. Este evento se ejecutar cuando se analicen los blobs de las roi de una cámara.
                     * Indicamos el processing function que se ejecuta cuando activemos el hilo de cada cámara.
                     * Activamos el hilo de cada cámara.*/
            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);

            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInGigeVisionSystem; devDig++)
                ConnectedCameraInSystem(devSysGigeVision, devDig);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInUsb3Vision; devDig++)
                ConnectedCameraInSystem(devSysUsb3Vision, devDig);


        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="cameraManager">cameraManager</see>/>.
        /// </summary>
        public void InitCameraManager()
        {
            cameraManager = new CameraManager(ref milApp, ref devSysGigeVision, ref devSysUsb3Vision, ref treeViewCameras, ref idCam);

            cameraManager.selectedCamEvent += new CameraManager.selectedCamDelegate(SelectedCamera);
            cameraManager.freeCamCamEvent += new CameraManager.FreeCamDelegate(FreeCamera);

            cameraManager.ShowCamerasConnected();
        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="frameRateManager">frameRateManager</see>/>.
        /// </summary>
        public void InitFrameRateManager()
        {
            frameRateManager = new FrameRateManager(ref milApp, ref tbLayoutPanelFrameRate, ref numericUpDownFrameRate, ref trBarFrameRate, ref idCam);


        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="exposureTimeManager">exposureTimeManager</see>/>.
        /// </summary>
        public void InitExposureTimeManager()
        {
            exposureTimeManager = new ExposureTimeManager(ref milApp, ref tableLayoutPanelExposureTime, ref numericUpDownExposureTime, ref trackBarExposureTime, ref idCam);
        }

        private void InitSequenceManager()
        {
            sequenceManager = new SequenceManager(ref idCam, ref numericUpDownTotalFrames, ref numericUpDownTrigger, ref numericUpDownPositionTrigger,
                ref cbBoxSequence, ref trackBarSequence, ref lbMaxSequence);

            recordSettings = new RecordSettings();
        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="panelManager">panelManager</see>/>.
        /// </summary>
        public void InitPanelManager()
        {
            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);
            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            int numCams = (int)NbcamerasInGigeVisionSystem + (int)NbcamerasInUsb3Vision;

            panelManager = new PanelManager(ref milApp, ref devSysGigeVision, ref devSysUsb3Vision, numCams, ref pnlCams, this);
            panelManager.AddControl(ref btnContinuousShot, ref btnPause, ref btnResetZoom, ref btnRecord);

            panelManager.notifyMouseDownEvent += new PanelManager.notifyMouseDownDelegate(SelectCameraInCameraManager);
            panelManager.notifyCloseEvent += new PanelManager.notifyCloseDelegate(SelectCameraInCameraManager);
            panelManager.RecordSettings = recordSettings;
        }

        /// <summary>
        /// Este método contiene todas las funciones necesarias para inicializar el objeto <see cref="stateTools">stateTools</see>/>.
        /// </summary>
        private void InitStateTools()
        {
            stateTools = new StateTools(ref btnSingleShot, ref btnContinuousShot, ref btnPause, ref btnRecord, ref btnZoomLess, ref btnZoomPlus, ref btnResetZoom);

            panelManager.StateTools = stateTools;
            cameraManager.StateTools = stateTools;
        }

        /// <summary>
        /// Esta función se encargará de comprobar si se han conectado cámaras.
        /// En caso de que no hayan cámaras conectadas se deshabilitarán los controles de las secciones del rpograma que requieran la conexión de
        /// cámaras.
        /// </summary>
        public void CheckCameras()
        {
            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);
            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            if (NbcamerasInGigeVisionSystem == 0 && NbcamerasInUsb3Vision == 0)
            {
                exposureTimeManager.Disable();
                frameRateManager.Disable();
            }
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
        public void ConnectedCameraEvent(MIL_ID milSys, MIL_INT devMatrox, string name, string ip)
        {
            /*Obtenemos el indice del sistema en la arquitenctura de MilApp a partir del MIL_ID del sistema que ha activado este evento.*/
            MIL_INT devSys = milApp.GetIndexSystemByID(milSys);

            /*Indice de la cámara en el sistema que ha ejecutado este evento.*/
            MIL_INT devDig = milApp.GetIndexCamByDevN(devSysGigeVision, devMatrox);

            Id id = new Id(devSys, devDig);

            ConnectedCameraInSystem(id.DevNSys, id.DevNCam);

            cameraManager.ShowCamerasConnected(id);

            panelManager.ShowCams(id);
        }

        /// <summary>
        /// Evento de desconectar cámaras. La función se ejecutará en el momento previo a eliminar sus datos de MilLibrary.
        /// Solo se ejecutará cuando se desconecte una cámara del sistema GigeVision.
        /// </summary>
        /// <param name="milSys">Sistema de la cámara.</param>
        /// <param name="devN">Posición en MilLibrary de la cámara.</param>
        /// <param name="disconnectedCameraName">Nombre de la cámara.</param>
        /// <param name="disconnectedCameraIp">Ip de la cámara.</param>
        public void DisconnectedCameraEvent(MIL_ID milSys, MIL_INT devN, string disconnectedCameraName, string disconnectedCameraIp)
        {
            /*Obtenemos el indice del sistema en la arquitenctura de MilApp a partir del MIL_ID del sistema que ha activado este evento.*/
            MIL_INT devSys = milApp.GetIndexSystemByID(milSys);

            Id id = new Id(devSys, devN);

            panelManager.Remove(id);

            cameraManager.RemoveCamera(id);
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
        public void ConnectedCameraInSystem(MIL_INT devSys, MIL_INT devDig)
        {
            milApp.AllocSystemRecourse(devSys, devDig);

            /************************ EVENTOS ******************************/
            /*Activamos y asignamos los evento a las funciones correspondinetes.*/

            EventPresentCameraInfo eventProcessingFunction = (EventPresentCameraInfo)milApp.CamEvent(devSys, devDig, "ProcessingFunctionInformation");
            eventProcessingFunction._event += new EventPresentCameraInfo._eventDelagete(ProcessingFunction);

            /********************** VIDEO ********************/

            EventVideo eventEndVideo = (EventVideo)milApp.CamEvent(devSys, devDig, "EndVideo");
            eventEndVideo._event += new EventVideo._eventDelagete(EndVideo);

            /********************* AÑADIR IMAGENES *************************/
            /* Activamos las imagenes en la cámara devDig */
            milApp.CamActivateImages(devSys, devDig);

            /********************** PROCESSING FUNCTION ********************/

            /*Indicamos el processing function que debe ejecutarse cuando se ejecute el hilo de la cámara correspondiente.*/
            milApp.CamSetProcessingFunction(devSys, devDig, "Recording");
        }

        /// <summary>
        /// Esta función se ejecuta en cada hilo de las cámaras que esten conectadas al programa.
        /// </summary>
        /// <param name="milSys">Dev del sistema.</param>
        /// <param name="dev">Dev de la cámara en el interior del sistema.</param>
        /// <param name="name">Nombre de la cámara.</param>
        /// <param name="ip">Ip de la cámara.</param>
        public void ProcessingFunction(MIL_ID milSys, MIL_INT dev, string name, string ip)
        {

        }

        /// <summary>
        /// Esta función se ejecuta cuando se selecciona una cámara en <see cref="cameraManager">cameraManager</see>/>.
        /// Ver, <see cref="CameraManager.selectedCamEvent">CameraManager.selectedCamEvent</see>/>.
        /// La variable <see cref="idCam">idCam</see>/> se actualiza en el interior del objeto <see cref="cameraManager"/>.
        /// Ver, <see cref="CameraManager.treeViewCameras_AfterSelect(object, TreeViewEventArgs)">CameraManager.treeViewCameras_AfterSelect(object, TreeViewEventArgs)</see>/>.
        /// </summary>
        public void SelectedCamera()
        {
            Dictionary<string, string> camInfo = milApp.CamInfo(idCam.DevNSys, idCam.DevNCam);

            //panelManager.ShowCams(idCam);
            panelManager.SelectCamera(idCam);

            frameRateManager.SelectCam();

            if (camInfo["Vendor"] == "FLIR" || camInfo["Vendor"].Contains("FLIR"))
            {
                exposureTimeManager.Reset();
                exposureTimeManager.Disable();
            }
            else
            {
                exposureTimeManager.Enable();
                exposureTimeManager.SelectCam();
            }

            if (panelManager.IsShow(idCam))
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

        /// <summary>
        /// This function is used to select a camera in <see cref="cameraManager">cameraManager</see>/>.
        /// </summary>
        /// <param name="id">Id of the camera you want to select.</param>
        public void SelectCameraInCameraManager(Id id)
        {
            if (id != null)
                cameraManager.SelectCamera(id);
            else
                cameraManager.DeselectCamera();
        }

        public void FreeCamera()
        {
            panelManager.Remove(idCam);
        }

        /// <summary>
        /// Esta función esta conectada con el evento <see cref="SequenceManager.startGrabEvent">"SequenceManager.startGrabEvent</see>/>.
        /// 
        /// Se ejecutará cuando se ejecute el evento click de <see cref="btnRecord">btnRecord</see>/>, 
        /// definido en <see cref="SequenceManager.btnRecord_Click(object, EventArgs)">SequenceManager.btnRecord_Click(object, EventArgs)</see>/>
        /// </summary>
        private void StartGrabVideo()
        {
            panelManager.GrabCamera(idCam);
        }

        /// <summary>
        /// Esta función se ejecuta cuando se termina la grabación de un vídeo o secuencia de imágenes.
        /// </summary>
        /// <param name="milSys">Dev del sistema en MilLibrary.</param>
        /// <param name="CameraName">Nombre de la cámara que ha lanzado este evento.</param>
        /// <param name="CameraIp">Ip de la cámara que ha lanzado este evento.</param>
        /// <param name="path">Path del vídeo que se ha grabado.</param>
        /// <param name="fps">Fps de la cámara.</param>
        public void EndVideo(MIL_ID milSys, MIL_INT matroxDevDig, string CameraName, string CameraIp, string path, double fps)
        {
            MIL_INT devSys = milApp.GetIndexSystemByID(milSys);
            MIL_INT devCam = milApp.GetIndexCamByDevN(devSys, matroxDevDig);

            Id id = new Id(devSys, devCam);

            if (idCam.Equal(id))
                panelManager.SelectCamera(id);
            else
                panelManager.DeselectCamera(id);
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

        private void RecordingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //displayCameraBaslerForm.DisconnectPanel();

            milApp.FreeRecourse();
        }

        private void RecordingForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void grabarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordSettingsForm recordSettingsForm = new RecordSettingsForm(ref recordSettings);

            recordSettingsForm.ShowDialog();
        }
    }
}
