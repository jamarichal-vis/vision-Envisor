using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        private Form form;

        /// <summary>
        /// Este objeto será el <see cref="TreeView">TreeView</see>/> que controle esta clase.
        /// </summary>
        TreeView treeViewCam;

        /// <summary>
        /// This variable storages the gigeVision Node.
        /// </summary>
        TreeNode nodeGigeVision;
        
        /// <summary>
        /// This variable storages the usb3 vision node.
        /// </summary>
        TreeNode nodeUsb3Vision;
        
        /// <summary>
        /// This variable storages the node select by user.
        /// </summary>
        TreeNode nodeCamSelected;

        /// <summary>
        /// This dictionary contains all cameras of the gigevision system.
        /// </summary>
        private Dictionary<string, Camera> cameras_GigeVision;

        /// <summary>
        /// This dictionary contains all cameras of the usb3Vision system.
        /// </summary>
        private Dictionary<string, Camera> cameras_Usb3Vision;

        MilSystem milSysGigeVision;

        MilSystem milSystemUsb3;

        /// <summary>
        /// This variable storages the camera select by user.
        /// It is used to connect all modules of the program.
        /// </summary>
        private Camera camera_selected;

        /// <summary>
        /// Esta variable contiene todas las funciones para cambiar el estado de la barra de herramientas.
        /// </summary>
        private StateTools stateTools;

        public StateTools StateTools { get => stateTools; set => stateTools = value; }

        /// <summary>
        /// Este evento es ejecutado cuando se selecciona una cámara. 
        /// Ver, <see cref="treeViewCameras_AfterSelect(object, TreeViewEventArgs)">treeViewCameras_AfterSelect(object, TreeViewEventArgs)</see>/>.
        /// </summary>
        public delegate void selectedCamDelegate(Camera camera);
        public event selectedCamDelegate selectedCamEvent;

        /// <summary>
        /// Este evento es ejecutado cuando se produce el evento de doble click en un nodo. 
        /// Ver, <see cref="TreeViewCameras_MouseDoubleClick(object, MouseEventArgs)">TreeViewCameras_MouseDoubleClick(object, MouseEventArgs)</see>/>.
        /// </summary>
        /// <param name="id"></param>
        public delegate void grabContinuousCamDelegate();
        public event grabContinuousCamDelegate grabContinuousCamEvent;

        /// <summary>
        /// Este evento es ejecutado cuando se libera una cámara mediante la función <see cref="btnFreeCamera_Click(object, EventArgs)">btnFreeCamera_Click(object, EventArgs)</see>/>. 
        /// </summary>
        /// <param name="id">Id de la cámara que se ha liberado.</param>
        public delegate void FreeCamDelegate();
        public event FreeCamDelegate freeCamCamEvent;

        /// <summary>
        /// Este evento es utilizado para acceder a un control del formulario de manera segura desde otro hilo.
        /// </summary>
        /// <param name="toolStripMenuItem"></param>
        /// <param name="state"></param>
        public delegate void safeControlDelegate(Control control, bool state);
        public safeControlDelegate safeControlEvent;
        
        public delegate void safeModifyIconInNodeDelegate(TreeNode node, string imageKey);
        public safeModifyIconInNodeDelegate safeModifyIconInNodeEvent;

        public CameraManager(Form form, ref TreeView treeView, ref Dictionary<string, Camera> cameras_GigeVision, ref Dictionary<string, Camera> cameras_Usb3Vision, 
            MilSystem milSystemGigeVision, MilSystem milSystemUsb3Vision,
            ref Camera camera_selected)
        {
            this.form = form;

            this.milSysGigeVision = milSystemGigeVision;
            this.milSystemUsb3 = milSystemUsb3Vision;

            this.cameras_GigeVision = cameras_GigeVision;
            this.cameras_Usb3Vision = cameras_Usb3Vision;
            this.camera_selected = camera_selected;

            InitTreeView(ref treeView);

            safeControlEvent += new safeControlDelegate(Enable);
        }

        /// <summary>
        /// This method initializer the <see cref="treeViewCam">treeViewCam</see>/> control.
        /// </summary>
        /// <param name="treeView">Treeview control you want to assign to <see cref="treeViewCam">treeViewCam</see>/>.</param>
        private void InitTreeView(ref TreeView treeView)
        {
            treeViewCam = treeView;

            ImagesInTreeView();

            treeViewCam.BeforeSelect += new TreeViewCancelEventHandler(TreeViewCam_BeforeSelect);
            treeViewCam.MouseDown += new MouseEventHandler(TreeViewCam_MouseDown);
            treeViewCam.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewCameras_MouseDoubleClick);
        }
        
        /// <summary>
        /// Este método muestra en <see cref="treeViewCam">treeViewCam</see>/> las cámaras que esten conectadas en 
        /// <see cref="MilLibrary">MilLibrary</see>/>.
        /// </summary>
        public void ShowCamerasConnected()
        {
            /********************** SYSTEM NODES **********************/
            /**********************************************************/
            /**********************************************************/
            ConnectSystemToTreeView();

            /********************** CAMERA NODES **********************/
            /**********************************************************/
            /**********************************************************/
            foreach(var camera in cameras_GigeVision)
            {
                string name = camera.Value.Vendor + " " + camera.Value.Model + string.Format(" (DEV{0}", camera.Key) + ")";

                ConnectCameraToTreeView(indexSystem: INDEX_GIGEVISION_TREEVIEW, key: camera.Key.ToString(), name: name);
            }
            foreach (var camera in cameras_Usb3Vision)
            {
                string name = camera.Value.Vendor + " " + camera.Value.Model + string.Format(" (DEV{0}", camera.Key) + ")";

                ConnectCameraToTreeView(indexSystem: INDEX_USB3VISION_TREEVIEW, key: camera.Key.ToString(), name);
            }

            foreach (TreeNode treeNode in treeViewCam.Nodes)
                treeNode.Expand();

            //SelectedFirstCam();
        }

        /// <summary>
        /// Este método añade un sistema al control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="system">Nombre del sistema</param>
        /// <param name="index">Indice donde quieres añadir el sistema.</param>
        private void ConnectSystemToTreeView()
        {
            nodeGigeVision = new TreeNode(NAME_GIGEVISION_TREEVIEW, 0, 0);
            nodeUsb3Vision = new TreeNode(NAME_USB3VISION_TREEVIEW, 1, 1);

            treeViewCam.Nodes.Add(nodeGigeVision);
            treeViewCam.Nodes.Add(nodeUsb3Vision);
        }

        /// <summary>
        /// Este método añade una cámara al control <see cref="treeViewCam">treeViewCam</see>/>.
        /// Seleccionando el sistema al que quieres añir dicha cámara a través del parámetro indexSystem.
        /// </summary>
        /// <param name="indexSystem">Indice del sistema que quieres añadir la cámara.</param>
        /// <param name="name">Nombre de la cámara que quieres añadir.</param>
        private void ConnectCameraToTreeView(int indexSystem, string key, string name)
        {
            TreeNode node = new TreeNode(name, 5, 5);
            node.Name = key;

            treeViewCam.Nodes[indexSystem].Nodes.Add(node);
        }

        /******************* TREEVIEW FUNCTIONS ********************/
        /***********************************************************/
        /***********************************************************/

        /// <summary>
        /// This method add the image that it need this program.
        /// </summary>
        private void ImagesInTreeView()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add("System_GigeVision", Properties.Resources.GigE_Vision_Logo);
            imageList.Images.Add("System_Usb3Vision", Properties.Resources.USB3VisionTM);
            imageList.Images.Add("Point_on", Properties.Resources.point_camera_on);
            imageList.Images.Add("Point_off", Properties.Resources.point_camera_off);

            imageList.ColorDepth = ColorDepth.Depth32Bit;
            treeViewCam.ImageList = imageList;
        }

        private void TreeViewCam_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// This function is executed when the user press a node in <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewCam_MouseDown(object sender, MouseEventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;

            var hit = treeViewCam.HitTest(e.X, e.Y);

            if (hit.Node == null)
            {

            }
            else
            {
                TreeNode node = hit.Node;

                SelectCamera(node: node);
            }
        }

        private void SelectCamera(TreeNode node)
        {
            string type = TypeNode(node);

            if (type == "CAMERA_NODE")
            {
                DeselectCameraNode(node: nodeCamSelected);

                nodeCamSelected = node;
                SelectCameraNode(node: nodeCamSelected);

                camera_selected = GetCamera(nodeCamSelected);

                if (selectedCamEvent != null)
                    selectedCamEvent.Invoke(camera: camera_selected);
            }
        }

        /// <summary>
        /// This method return the type of the node passes by parameter.
        /// </summary>
        /// <param name="node">Node you want to check its type.</param>
        /// <returns></returns>
        private string TypeNode(TreeNode node)
        {
            string type = node.Text;

            if(type == NAME_GIGEVISION_TREEVIEW)
                return "GIGE_VISION_NODE";
            else if(type == NAME_USB3VISION_TREEVIEW)
                return "USB3_VISION_NODE";
            else
                return "CAMERA_NODE";
        }

        /// <summary>
        /// This method return a camera in <see cref="cameras_GigeVision">cameras_GigeVision</see>/> or <see cref="cameras_Usb3Vision">cameras_Usb3Vision</see>/>
        /// according to node passes by parameter.
        /// </summary>
        /// <param name="node">Camera node.</param>
        /// <returns>Camera of the camera node passes by paramater.</returns>
        public Camera GetCamera(TreeNode node)
        {
            string camera_id = node.Name;

            TreeNode nodeSystem = node.Parent;
            string system = nodeSystem.Text;

            switch (system)
            {
                case NAME_GIGEVISION_TREEVIEW:
                    if (cameras_GigeVision.ContainsKey(camera_id))
                        return cameras_GigeVision[camera_id];
                    break;

                case NAME_USB3VISION_TREEVIEW:
                    if (cameras_Usb3Vision.ContainsKey(camera_id))
                        return cameras_Usb3Vision[camera_id];
                    break;
            }

            return null;
        }

        /// <summary>
        /// This method is executes when the user press doble click over a node in <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewCameras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (!IsSystemNode())
            //{
            //    grabContinuousCamEvent.Invoke();
            //}
        }

        /// <summary>
        /// This method select a camera node.
        /// </summary>
        /// <param name="node"></param>
        public void SelectCameraNode(TreeNode node)
        {
            if(node != null)
            {
                node.BackColor = Color.FromArgb(93, 169, 229);
                node.ForeColor = Color.White;
                node.ImageKey = "Point_on";
                node.SelectedImageIndex = 2;
            }
        }
        
        /// <summary>
        /// This method deselect a camera node.
        /// </summary>
        /// <param name="node"></param>
        public void DeselectCameraNode(TreeNode node)
        {
            if(node != null)
            {
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
                node.ImageKey = "";
                node.SelectedImageIndex = 10;
                node.ImageIndex = 10;
            }
        }

        /// <summary>
        /// This method select the first camera node in <see cref="treeViewCam">treeViewCam</see>/>. 
        /// </summary>
        private void SelectedFirstCam()
        {
            if(treeViewCam.Nodes.Count > 0)
            {
                if(nodeGigeVision.Nodes.Count > 0)
                {
                    SelectCamera(node: nodeGigeVision.Nodes[0]);
                }
                else if (nodeUsb3Vision.Nodes.Count > 0)
                {
                    SelectCamera(node: nodeUsb3Vision.Nodes[0]);
                }
            }
        }
        
        public void RemoveCamera(Camera camera)
        {
            //int index = -1;

            //if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_GIGE_VISION))
            //    index = INDEX_GIGEVISION_TREEVIEW;
            //else if (id.DevNSys == milApp.GetIndexSystemByType(MIL.M_SYSTEM_USB3_VISION))
            //    index = INDEX_USB3VISION_TREEVIEW;

            //if (index != -1)
            //    treeViewCam.Nodes[index].Nodes[(int)IdentifyCamera(id.DevNSys)].Remove();
        }

        /// <summary>
        /// Esta función modifica el estado del atributo Enable del control <see cref="treeViewCam">treeViewCam</see>/>.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="state"></param>
        public void EnableTreeView(bool state)
        {
            form.Invoke(safeControlEvent, new object[] { treeViewCam, state });
        }

        /// <summary>
        /// Esta función modifica el atributo Enable del control que se pasa por parámetro.
        /// </summary>
        /// <param name="control">Control que quieres modificar.</param>
        /// <param name="state">Estado del atributo Enable.</param>
        private void Enable(Control control, bool state)
        {
            control.Enabled = state;
        }

        private ContextMenuStrip ContextMenuStripToCamera()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            contextMenuStrip.Items.Add("Free", null, btnFreeCamera_Click);

            return contextMenuStrip;
        }

        private void btnFreeCamera_Click(object sender, EventArgs e)
        {
            //RemoveCamera(idCam);

            //freeCamCamEvent.Invoke();

            //milApp.FreeRecourse(idCam.DevNSys, idCam.DevNCam);
        }

        /***************** MODIFY ICONS FUNCTIONS ******************/
        /***********************************************************/
        /***********************************************************/

        /// <summary>
        /// This method set the icon "Point_on" in the node related with the cameras passes by paramater.
        /// </summary>
        /// <param name="cameras">Cameras you want to change its icon in <see cref="treeViewCam">treeViewCam</see>/>.</param>
        public void SetIconConnect(List<Camera> cameras)
        {
            foreach (TreeNode node in nodeGigeVision.Nodes)
                foreach (Camera camera in cameras)
                    if (node.Name == camera.Dev.ToString())
                        treeViewCam.Invoke(new safeModifyIconInNodeDelegate(ModifyIcon), new object[] { node, "Point_on" });
        }

        public void RemoveIconConnect(TreeNode node)
        {
            node.SelectedImageIndex = 5;
            //treeViewCam.Invoke(new safeModifyIconInNodeDelegate(ModifyIcon), new object[] { node, "a" });
        }

        /// <summary>
        /// This method set the icon "Point_off" in the node related with the cameras passes by paramater.
        /// </summary>
        /// <param name="cameras">Cameras you want to change its icon in <see cref="treeViewCam">treeViewCam</see>/>.</param>
        public void ModifyIconGrab(List<Camera> cameras)
        {
            foreach(TreeNode node in nodeGigeVision.Nodes)
                foreach(Camera camera in cameras)
                    if(node.Name == camera.Dev.ToString())
                        node.ImageKey = "Point_off";
        }
        
        /// <summary>
        /// This method is created to modify the icon in a node throught a thread.
        /// </summary>
        /// <param name="node">Node you want to change its icon.</param>
        /// <param name="imageKey">Key of the icon.</param>
        private void ModifyIcon(TreeNode node, string imageKey)
        {
            node.ImageKey = imageKey;
        }

        public void Deselect(Camera camera)
        {
            if(camera.MilSystem == milSysGigeVision.IDSystem())
            {
                foreach (TreeNode node in nodeGigeVision.Nodes)
                {
                    if (node.Name == camera.Dev.ToString())
                    {
                        DeselectCameraNode(node);
                    }
                }
                    
            }
            else if(camera.MilSystem == milSystemUsb3.IDSystem())
            {
                foreach (TreeNode node in nodeGigeVision.Nodes)
                    if (node.Name == camera.Dev.ToString())
                        RemoveIconConnect(node);
            }
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
