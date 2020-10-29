using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording
{
    class PanelManager
    {
        /// <summary>
        /// Este atributo almacena el panel principal que se quiere controlar.
        /// </summary>
        Panel pnlCams;

        /// <summary>
        /// Esta variable contiene todas las funciones necesarias para crear multiples panales en un panel.
        /// </summary>
        DinamicPanels dinamicPanels;

        public PanelManager(int numCams, ref Panel pnl)
        {
            pnlCams = pnl;

            //InitDinamicPanel(numCams: numCams, pnl: pnlCams);
        }

        public void InitDinamicPanel(int numCams, Panel pnl)
        {
            dinamicPanels = new DinamicPanels(numCams);

            dinamicPanels.ClickEvent += new DinamicPanels.getEvent(ClickEvent);

            dinamicPanels.CreatePanelGrid();
            dinamicPanels.FillGrid(pnl);
        }

        private void ClickEvent(object sender, EventArgs e)
        {

        }
    }
}
