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
    public partial class DisplayCameraFlirForm : Form
    {
        DisplayCameraFlir displayCamera;
        public DisplayCameraFlirForm(ref MilApp milApp, Id id)
        {
            InitializeComponent();

            displayCamera = new DisplayCameraFlir(ref milApp, id, ref pnlCam, ref pnlLut, 
                ref lbTemperature, ref lbMinTemperature, ref lbMaxTemperature,
                ref lbPosX, ref lbPosY, ref lbFps);
            displayCamera.AllocCamera();
        }
    }
}
