using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_12
{
    enum ViewType
    {
        Cartesian,
        Polar,
        Approximation
    }

    delegate void ViewSwitcher(ViewType v);
    delegate void GraphUpdater();

    public partial class ViewManager : Form
    {
        private readonly Graph graph = new Graph();
        private readonly CartesianView cartesianView;
        private readonly PolarView polarView;
        private readonly ApproxView approxView;

        public ViewManager()
        {
            InitializeComponent();

            cartesianView = new CartesianView(graph, SwitchView, UpdateGraph);
            polarView = new PolarView(graph, SwitchView, UpdateGraph);
            approxView = new ApproxView(graph, SwitchView, UpdateGraph);

            ViewPanel.Controls.Add(cartesianView);
        }

        private void SwitchView(ViewType viewType)
        {
            ViewPanel.Controls.Clear();
            graph.ClearPlots();

            UpdateGraph();

            switch (viewType)
            {
                case ViewType.Cartesian:
                    ViewPanel.Controls.Add(cartesianView);
                    break;
                case ViewType.Polar:
                    ViewPanel.Controls.Add(polarView);
                    break;
                case ViewType.Approximation:
                    ViewPanel.Controls.Add(approxView);
                    break;
            }
        }

        private void UpdateGraph() {
            graph.Draw(GraphPicture.CreateGraphics(), GraphPicture.ClientRectangle);
        }
    }
}
