using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using MilLibrary;

namespace Recording
{
    class SequenceManager
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
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        Id id;

        /// <summary>
        /// This atribute stores the button to record.
        /// </summary>
        Button btnRecord;

        /// <summary>
        /// Este evento es ejecutado cuando se selecciona una cámara. 
        /// Ver, <see cref="treeViewCameras_AfterSelect(object, TreeViewEventArgs)">treeViewCameras_AfterSelect(object, TreeViewEventArgs)</see>/>.
        /// </summary>
        /// <param name="id"></param>
        public delegate void startGrabDelegate();
        public event startGrabDelegate startGrabEvent;

        public SequenceManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, ref Id id, ref Button btnRecord)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            this.id = id;

            this.btnRecord = btnRecord;

            Events();
        }

        /// <summary>
        /// Esta función almacenará todos los eventos de los controles que controle esta clase.
        /// </summary>
        public void Events()
        {
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
        }

        /// <summary>
        /// Este evento se ejecuta cuando se hace click en <see cref="btnRecord">btnRecord</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

            string pathFolder = System.IO.Path.Combine(@"C:\Recording\Records",
                (camInfo["Vendor"] != "" ? (camInfo["Vendor"] + " -") : "") +
                (camInfo["Model"] != "" ? (camInfo["Model"]) : "") +
                (camInfo["Name"] != "" ? (" -" + camInfo["Name"]) : (id.DevNSys.ToString() + id.DevNCam.ToString())) +
                (camInfo["IpAddress"] != "" ? (" -" + camInfo["IpAddress"]) : "") +
                DateTime.Now.ToString(" (dd-MM-yyyy HH-mm-ss-fff)"));

            if (!Directory.Exists(pathFolder))
                Directory.CreateDirectory(pathFolder);

            string pathFile = System.IO.Path.Combine(pathFolder, NAME_VIDEO_FILE + EXTENSION_VIDEO);

            milApp.AddVideo(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY, MIL.M_AVI_MJPEG, timePretrigger: 15, timeStop: 15);

            milApp.CamStartGrabInDisk(id.DevNSys, id.DevNCam, NAME_VIDEO_MILLIBRARY, pathFile);

            if (startGrabEvent != null)
                startGrabEvent.Invoke();
        }
    }
}
