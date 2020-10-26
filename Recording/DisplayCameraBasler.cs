using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;
using MilLibrary;
using System.Windows.Forms;


namespace Recording
{
    class DisplayCameraBasler : DisplayCamera
    {
        public DisplayCameraBasler(ref MilApp milApp, ref Id id)
        {
            this.milApp = milApp;

            this.idCam = id;
        }

        protected override void AllocCamera(Panel pnl)
        {
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, pnl);
        }
    }
}
