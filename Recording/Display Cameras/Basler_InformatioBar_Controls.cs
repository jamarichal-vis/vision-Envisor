using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording
{
    /// <summary>
    /// This class is designed to storages all controls related with information bar of a basler camera.
    /// </summary>
    class Basler_InformatioBar_Controls
    {
        /// <summary>
        /// This variable storages the label where it will shown the ip of a camera.
        /// </summary>
        Label lbIp;

        /// <summary>
        /// This variable storages the label where it will shown the name of a camera.
        /// </summary>
        Label lbName;

        /// <summary>
        /// This variable storages the label where it will shown the intensity of the image in the position mouse in a image.
        /// </summary>
        Label lbIntensity;

        /// <summary>
        /// This variable storages the label where it will shown the position X of the mouse in a image.
        /// </summary>
        Label lbPosX;

        /// <summary>
        /// This variable storages the label where it will shown the position X of the mouse in a image.
        /// </summary>
        Label lbPosY;

        /// <summary>
        /// This variable storages the label where it will shown the fps of a camera.
        /// </summary>
        Label lbFps;

        /// <summary>
        /// This variable storages the tableLayoutPanel where are all control of a basler information bar.
        /// </summary>
        TableLayoutPanel layoutPanelControls;

        public Basler_InformatioBar_Controls(ref Label lbIp, ref Label lbName, ref Label lbIntensity, ref Label lbPosX, ref Label lbPosY, 
            ref Label lbFps, ref TableLayoutPanel tableLayoutPanel)
        {
            LbIp = lbIp;
            LbName = lbName;
            LbIntensity = lbIntensity;
            LbPosX = lbPosX;
            LbPosY = lbPosY;
            LbFps = lbFps;
            LayoutPanelControls = tableLayoutPanel;

            Clear();
        }

        public Label LbIp { get => lbIp; set => lbIp = value; }
        public Label LbName { get => lbName; set => lbName = value; }
        public Label LbIntensity { get => lbIntensity; set => lbIntensity = value; }
        public Label LbPosX { get => lbPosX; set => lbPosX = value; }
        public Label LbPosY { get => lbPosY; set => lbPosY = value; }
        public Label LbFps { get => lbFps; set => lbFps = value; }
        public TableLayoutPanel LayoutPanelControls { get => layoutPanelControls; set => layoutPanelControls = value; }

        public void Clear()
        {
            SetControlPropertyThreadSafe(LbIp, "Text", "");
            SetControlPropertyThreadSafe(LbName, "Text", "");
            SetControlPropertyThreadSafe(LbIntensity, "Text", "");
            SetControlPropertyThreadSafe(LbPosX, "Text", "");
            SetControlPropertyThreadSafe(LbPosY, "Text", "");
            SetControlPropertyThreadSafe(LbFps, "Text", "");
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
