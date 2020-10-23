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

        private FrameRateManager frameRateManager;

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

            cameraManager.ShowCamerasConnected();
        }

        public void InitFrameRateManager()
        {
            frameRateManager = new FrameRateManager(ref milApp, ref numericUpDownFrameRate, ref trBarFrameRate, ref idCam);
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

            /********************** PROCESSING FUNCTION ********************/

            /*Indicamos el processing function que debe ejecutarse cuando se ejecute el hilo de la cámara correspondiente.*/
            milApp.CamSetProcessingFunction(devSys, devDig, "Recording");

            //milApp.StartGrab(devSys, devDig);
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
            string h = "";
        }

        private void RecordingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            milApp.Destroy();
        }
    }
}
