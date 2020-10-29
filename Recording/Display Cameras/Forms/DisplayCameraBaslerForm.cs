using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilLibrary;

namespace Recording
{
    public partial class DisplayCameraBaslerForm : Form
    {
        DisplayCameraBasler displayCamera;

        public DisplayCameraBaslerForm(ref MilApp milApp, Id id)
        {
            InitializeComponent();

            displayCamera = new DisplayCameraBasler(ref milApp, id, ref pnlBorder, ref lbModel, ref lbName, ref lbIp,
                ref pnlCam, ref lbIntensity, ref lbPosX, ref lbPosY, ref lbFps);
            displayCamera.AllocCamera();
        }

        public void DisconnectPanel()
        {
            displayCamera.DisconnectPanel();
        }
    }
}
