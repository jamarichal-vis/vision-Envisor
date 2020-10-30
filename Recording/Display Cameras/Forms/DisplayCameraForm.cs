using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording
{
    public partial class DisplayCameraForm : Form
    {

        private DisplayCamera displayCamera;

        public DisplayCameraForm()
        {
            InitializeComponent();
        }

        public DisplayCamera DisplayCamera { get => displayCamera; set => displayCamera = value; }
    }
}
