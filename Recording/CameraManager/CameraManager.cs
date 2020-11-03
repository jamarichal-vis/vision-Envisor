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
    class CameraManager
    {
        /// <summary>
        /// Indice del sistema gigevision de la lista de nodos del primer nodo del control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        private const int INDEX_GIGEVISION_TREEVIEW = 0;

        /// <summary>
        /// Indice del sistema usb3 vision de la lista de nodos del primer nodo del control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        private const int INDEX_USB3VISION_TREEVIEW = 1;

        /// <summary>
        /// Nombre del sistema gige vision en <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        private const string NAME_GIGEVISION_TREEVIEW = "GigeVision";

        /// <summary>
        /// Nombre del sistema usb3 vision en <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        private const string NAME_USB3VISION_TREEVIEW = "Usb3Vision";

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
        /// Este objeto será el <see cref="TreeView">TreeView</see>/> que controle esta clase.
        /// </summary>
        TreeView treeViewCam;

        TreeNode treeNodeSelected;

        /// <summary>
        /// Este objeto almacena la identificación de la cámara que esta seleccionada en el programa.
        /// </summary>
        Id id;

        /// <summary>
        /// Este evento es ejecutado cuando se selecciona una cámara. 
        /// Ver, <see cref="treeViewCameras_AfterSelect(object, TreeViewEventArgs)">treeViewCameras_AfterSelect(object, TreeViewEventArgs)</see>/>.
        /// </summary>
        /// <param name="id"></param>
        public delegate void selectedCamDelegate();
        public event selectedCamDelegate selectedCamEvent;

        public CameraManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, ref TreeView treeView, ref Id id)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            treeViewCam = treeView;

            this.id = id;

            Events();
        }

        /// <summary>
        /// Esta función almacenará todos los eventos de los controles que controle esta clase.
        /// </summary>
        public void Events()
        {
            treeViewCam.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCameras_AfterSelect);

            treeViewCam.Leave += new System.EventHandler(this.treeViewCameras_Leave);
        }

        private void ImagesInTreeView()
        {
            ImageList imageList = new ImageList();
            //imageList.Images.Add(Properties.Resources.icon_system);
            //imageList.Images.Add(Properties.Resources.icon_camera_connected);
            //imageList.Images.Add(Properties.Resources.icon_camera_disconnected);
            treeViewCam.ImageList = imageList;
        }

        /// <summary>
        /// Este método muestra en <see cref="treeViewCam">treeViewCam</see>/> las cámaras que esten conectadas en 
        /// <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public void ShowCamerasConnected()
        {
            Dictionary<string, string> camInfo = null;

            MIL_INT NbcamerasInGigeVisionSystem = milApp.GetNCameraInSystem(devSysGigeVision);
            MIL_INT NbcamerasInUsb3Vision = milApp.GetNCameraInSystem(devSysUsb3Vision);

            ConnectSystemToTreeView(NAME_GIGEVISION_TREEVIEW, INDEX_GIGEVISION_TREEVIEW);
            ConnectSystemToTreeView(NAME_USB3VISION_TREEVIEW, INDEX_USB3VISION_TREEVIEW);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInGigeVisionSystem; devDig++)
            {
                camInfo = milApp.CamInfo(devSysGigeVision, devDig);

                string name = camInfo["Vendor"] + " " + camInfo["Model"] + string.Format(" (DEV{0}", devDig) + ")";

                ConnectCameraToTreeView(indexSystem: 0, name);
            }

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInUsb3Vision; devDig++)
            {
                camInfo = milApp.CamInfo(devSysUsb3Vision, devDig);

                string name = camInfo["Vendor"] + " " + camInfo["Model"] + string.Format(" (DEV{0}", devDig) + ")";

                ConnectCameraToTreeView(1, name);
            }

            foreach (TreeNode treeNode in treeViewCam.Nodes)
                treeNode.Expand();

            SelectedFirstCam(NbcamerasInGigeVisionSystem, NbcamerasInUsb3Vision);
        }

        /// <summary>
        /// Esta función selecciona la primera cámara que se ha conectado.
        /// </summary>
        private void SelectedFirstCam(MIL_INT NbCamerasInGigeVision, MIL_INT NbCamerasInUsb3Vision)
        {
            if (NbCamerasInGigeVision > 0)
                treeViewCam.SelectedNode = treeViewCam.Nodes[INDEX_GIGEVISION_TREEVIEW].Nodes[0];
            else if (NbCamerasInGigeVision > 0)
                treeViewCam.SelectedNode = treeViewCam.Nodes[INDEX_USB3VISION_TREEVIEW].Nodes[0];
        }

        /// <summary>
        /// Este eventos se ejecuta cuando se selecciona un nodo del control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewCameras_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!IsSystemNode())
            {
                MIL_INT devSys = IdentifySystem();
                MIL_INT devCam = IdentifyCamera(devSys);

                id.Set(devSys, devCam);

                if (selectedCamEvent != null)
                    selectedCamEvent.Invoke();

                if (treeNodeSelected != null)
                {
                    treeNodeSelected.BackColor = Color.Transparent;
                    treeNodeSelected.ForeColor = Color.Black;
                }

                treeNodeSelected = treeViewCam.SelectedNode;
            }
        }

        /// <summary>
        /// Este método añade un sistema al control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="system">Nombre del sistema</param>
        /// <param name="index">Indice donde quieres añadir el sistema.</param>
        private void ConnectSystemToTreeView(string system, int index)
        {
            TreeNode node = new TreeNode(system, 0, 0);

            treeViewCam.Nodes.Insert(index, node);
        }

        /// <summary>
        /// Este método añade una cámara al control <see cref="treeViewCam">treeViewCam</see>/>.
        /// Seleccionando el sistema al que quieres añir dicha cámara a través del parámetro indexSystem.
        /// </summary>
        /// <param name="indexSystem">Indice del sistema que quieres añadir la cámara.</param>
        /// <param name="name">Nombre de la cámara que quieres añadir.</param>
        private void ConnectCameraToTreeView(int indexSystem, string name)
        {
            treeViewCam.Nodes[indexSystem].Nodes.Add(name, name, 1, 1);
        }

        /// <summary>
        /// Esta función identifica el sistema del nodo que esta seleccionado.
        /// </summary>
        /// <returns>Dev de MilLibrary del sistema seleccionado.</returns>
        private MIL_INT IdentifySystem()
        {
            if (treeViewCam.SelectedNode != null)
            {
                MIL_INT devSys = treeViewCam.SelectedNode.Parent.Index;

                return devSys;
            }

            return MIL.M_NULL;
        }

        /// <summary>
        /// Identifica el dev de la cámara en MilLibrary del nodo que se encuentre seleccionado en <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="devSys"></param>
        /// <returns></returns>
        private MIL_INT IdentifyCamera(MIL_INT devSys)
        {
            if (treeViewCam.SelectedNode != null)
            {
                MIL_INT devCam = MIL.M_NULL;

                int dev = FindDev(treeViewCam.SelectedNode.Text);

                devCam = milApp.GetIndexCamByDevN(devSys, dev);

                return devCam;
            }

            return MIL.M_NULL;
        }

        /// <summary>
        /// Esta función indica si el nodo seleccionado es un sistema.
        /// </summary>
        /// <returns>True: si es un sistema. False: si no es un sistema.</returns>
        private bool IsSystemNode()
        {
            if (treeViewCam.SelectedNode.Text == NAME_GIGEVISION_TREEVIEW || treeViewCam.SelectedNode.Text == NAME_USB3VISION_TREEVIEW)
                return true;

            return false;
        }

        /// <summary>
        /// Esta función encuentra el dev de matrox en el nombre que se encuentra en el nodo seleccionado.
        /// </summary>
        /// <param name="name">Nombre de la cámara.</param>
        /// <returns>El dev del nombre que se pasa por parámetro.</returns>
        private int FindDev(string name)
        {
            string dev = "";

            string endCharacter = ")";

            string num = "";

            bool start = false;

            foreach (char character in name)
            {
                if (!start)
                {
                    dev += character;

                    if (dev.Length > 2)
                        if (dev.Substring(dev.Length - 3, 3) == "DEV")
                            start = true;
                }
                else
                {
                    if (character.ToString() != endCharacter)
                    {
                        num += character;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return Convert.ToInt16(num);
        }

        private void treeViewCameras_Leave(object sender, EventArgs e)
        {
            treeViewCam.SelectedNode.BackColor = Color.FromArgb(93, 169, 229);
            treeViewCam.SelectedNode.ForeColor = Color.White;

        }
    }
}
