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
        Id idCam;

        /// <summary>
        /// Esta variable contiene todas las funciones para cambiar el estado de la barra de herramientas.
        /// </summary>
        private StateTools stateTools;

        public StateTools StateTools { get => stateTools; set => stateTools = value; }

        /// <summary>
        /// Este evento es ejecutado cuando se selecciona una cámara. 
        /// Ver, <see cref="treeViewCameras_AfterSelect(object, TreeViewEventArgs)">treeViewCameras_AfterSelect(object, TreeViewEventArgs)</see>/>.
        /// </summary>
        /// <param name="id"></param>
        public delegate void selectedCamDelegate();
        public event selectedCamDelegate selectedCamEvent;

        /// <summary>
        /// Este evento es ejecutado cuando se libera una cámara mediante la función <see cref="btnFreeCamera_Click(object, EventArgs)">btnFreeCamera_Click(object, EventArgs)</see>/>. 
        /// </summary>
        /// <param name="id">Id de la cámara que se ha liberado.</param>
        public delegate void FreeCamDelegate();
        public event FreeCamDelegate freeCamCamEvent;


        public CameraManager(ref MilApp milApp, ref MIL_INT devSysGigeVision, ref MIL_INT devSysUsb3Vision, ref TreeView treeView, ref Id id)
        {
            this.milApp = milApp;
            this.devSysGigeVision = devSysGigeVision;
            this.devSysUsb3Vision = devSysUsb3Vision;

            treeViewCam = treeView;

            this.idCam = id;

            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.camera);
            treeViewCam.ImageList = imageList;

            ImagesInTreeView();

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
            imageList.Images.Add(Properties.Resources.camera);
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

            //if (NbcamerasInGigeVisionSystem > 0)
            ConnectSystemToTreeView(NAME_GIGEVISION_TREEVIEW, INDEX_GIGEVISION_TREEVIEW);

            //if (NbcamerasInUsb3Vision > 0)
            ConnectSystemToTreeView(NAME_USB3VISION_TREEVIEW, INDEX_USB3VISION_TREEVIEW);

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInGigeVisionSystem; devDig++)
            {
                camInfo = milApp.CamInfo(devSysGigeVision, devDig);

                string name = camInfo["Vendor"] + " " + camInfo["Model"] + string.Format(" (DEV{0}", devDig) + ")";

                ConnectCameraToTreeView(indexSystem: INDEX_GIGEVISION_TREEVIEW, name);
            }

            for (MIL_INT devDig = MIL.M_DEV0; devDig < NbcamerasInUsb3Vision; devDig++)
            {
                camInfo = milApp.CamInfo(devSysUsb3Vision, devDig);

                string name = camInfo["Vendor"] + " " + camInfo["Model"] + string.Format(" (DEV{0}", devDig) + ")";

                ConnectCameraToTreeView(indexSystem: INDEX_USB3VISION_TREEVIEW, name);
            }

            foreach (TreeNode treeNode in treeViewCam.Nodes)
                treeNode.Expand();

            SelectedFirstCam(NbcamerasInGigeVisionSystem, NbcamerasInUsb3Vision);
        }

        /// <summary>
        /// Esta función muestra una cámara en el control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="id">Id de la cámara que quieres mostrar.</param>
        public void ShowCamerasConnected(Id id)
        {
            Dictionary<string, string> camInfo = milApp.CamInfo(id.DevNSys, id.DevNCam);

            string name = camInfo["Vendor"] + " " + camInfo["Model"] + string.Format(" (DEV{0}", id.DevNCam) + ")";

            if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_GIGE_VISION))
                ConnectCameraToTreeView(indexSystem: INDEX_GIGEVISION_TREEVIEW, name);
            else if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_USB3_VISION))
                ConnectCameraToTreeView(indexSystem: INDEX_USB3VISION_TREEVIEW, name);
        }

        public void SelectCamera(Id id)
        {
            int indexSystem = -1;

            int indexCam = -1;

            if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_GIGE_VISION))
                indexSystem = INDEX_GIGEVISION_TREEVIEW;
            else if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_USB3_VISION))
                indexSystem = INDEX_USB3VISION_TREEVIEW;

            indexCam = IndexCamera(treeViewCam.Nodes[indexSystem], id);

            if (indexSystem != -1 && indexCam != -1)
            {
                treeViewCam.SelectedNode = treeViewCam.Nodes[indexSystem].Nodes[indexCam];
            }
        }

        public void DeselectCamera()
        {
            DeselectCameraColor();
            treeViewCam.SelectedNode = null;
            treeNodeSelected = null;
            DeselectCameraColor();
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

                idCam.Set(devSys, devCam);

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
            TreeNode node = new TreeNode(system, 1, 1);

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
            treeViewCam.Nodes[indexSystem].Nodes.Add(name, name, 0, 0);
            //treeViewCam.Nodes[indexSystem].Nodes[treeViewCam.Nodes[indexSystem].Nodes.Count - 1].ContextMenuStrip = ContextMenuStripToCamera();
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
        /// Este método devuelve el índice de la cámara que tu has indicado a través del parámetro id y en el nodo "node".
        /// </summary>
        /// <param name="node">Nodo donde quieres buscar la cámara.</param>
        /// <param name="id">Id de la cñamara que quieres seleccionar.</param>
        /// <returns>Índice de la cámara dentro de node.</returns>
        private int IndexCamera(TreeNode node, Id id)
        {
            if (node.Nodes.Count > 0)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    MIL_INT devCam = MIL.M_NULL;

                    int dev = FindDev(node.Nodes[i].Text);

                    devCam = milApp.GetIndexCamByDevN(id.DevNSys, dev);

                    if (id.DevNCam == devCam)
                        return i;
                }
            }

            return -1;
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
            if (treeNodeSelected != null)
            {
                SelectCameraColor();
            }
        }

        public void SelectCameraColor()
        {
            treeNodeSelected.BackColor = Color.FromArgb(93, 169, 229);
            treeNodeSelected.ForeColor = Color.White;
        }
        
        public void DeselectCameraColor()
        {
            if(treeNodeSelected != null)
            {
                treeNodeSelected.BackColor = Color.White;
                treeNodeSelected.ForeColor = Color.Black;
            }
        }

        public void RemoveCamera(Id id)
        {
            int index = -1;

            if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_GIGE_VISION))
                index = INDEX_GIGEVISION_TREEVIEW;
            else if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_USB3_VISION))
                index = INDEX_USB3VISION_TREEVIEW;

            if (index != -1)
                treeViewCam.Nodes[index].Nodes[(int)IdentifyCamera(id.DevNSys)].Remove();
        }

        private ContextMenuStrip ContextMenuStripToCamera()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            contextMenuStrip.Items.Add("Free", null, btnFreeCamera_Click);

            return contextMenuStrip;
        }

        private void btnFreeCamera_Click(object sender, EventArgs e)
        {
            RemoveCamera(idCam);

            freeCamCamEvent.Invoke();

            milApp.FreeRecourse(idCam.DevNSys, idCam.DevNCam);
        }
    }
}
