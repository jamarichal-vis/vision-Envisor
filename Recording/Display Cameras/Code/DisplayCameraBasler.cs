﻿using System;
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
        public DisplayCameraBasler(ref MilApp milApp, Id id, ref Panel pnlBorder, ref Label lbModel, ref Label lbName, ref Label lbIp,
            ref Panel pnlCam, ref Label lbIntensity, ref Label lbPosX, ref Label lbPosY, ref Label lbFps)
        {
            this.milApp = milApp;

            this.idCam = id;

            this.pnlBorder = pnlBorder;
            this.lbModel = lbModel;
            this.lbName = lbName;
            this.lbIp = lbIp;

            this.pnlCam = pnlCam;
            
            this.lbValue = lbIntensity;

            this.lbPosX = lbPosX;
            this.lbPosY = lbPosY;
            this.lbFps = lbFps;
        }

        public override void AllocCamera()
        {
            milApp.AllocPanelToCam(idCam.DevNSys, idCam.DevNCam, pnlCam);

            /* EVENTS */
            ConnectMouseEvent();
            ConnectFpsEvent();

            /* Info Cam. */
            ShowInfoCam();

            /* GRAB */
            StartGrab();
        }

        /// <summary>
        /// Este método conecta el evento de mouse de una cámara de <see cref="MilLibrary">MilLibrary</see>/> a este programa.
        /// </summary>
        public override void ConnectMouseEvent()
        {
            EventMouseTemperature eventPresentCameraInfo = (EventMouseTemperature)milApp.CamEvent(idCam.DevNSys, idCam.DevNCam, "Intensity");
            eventPresentCameraInfo._event += new EventMouseTemperature._eventDelagete(Mouse);

            milApp.CamStartMouseMove(idCam.DevNSys, idCam.DevNCam);
        }
    }
}
