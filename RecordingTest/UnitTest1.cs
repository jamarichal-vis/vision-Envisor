using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recording;
using MilLibrary;
using Matrox.MatroxImagingLibrary;
using System.Collections.Generic;

namespace RecordingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int number_cameras_GigeVision = 2;
            int number_cameras_Usb3Vision = 0;

            int number_cameras_GigeVision_result;
            int number_cameras_Usb3Vision_result;

            RecordingForm recordingForm = new RecordingForm();

            recordingForm.InitMilLibrary();

            Dictionary<string, Camera> cameras_GigeVision = recordingForm.Cameras_GigeVision;
            Dictionary<string, Camera> cameras_usb3Vision = recordingForm.Cameras_GigeVision;

            number_cameras_GigeVision_result = cameras_GigeVision.Count;
            number_cameras_Usb3Vision_result = cameras_usb3Vision.Count;

            Assert.AreEqual(number_cameras_GigeVision, number_cameras_GigeVision_result);
            Assert.AreEqual(number_cameras_Usb3Vision, number_cameras_Usb3Vision_result);
        }
    }
}
