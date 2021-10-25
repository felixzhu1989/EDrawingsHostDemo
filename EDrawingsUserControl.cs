using System;
using System.Windows.Forms;
using eDrawings.Interop.EModelViewControl;

namespace EDrawingHost
{
    public partial class EDrawingsUserControl : UserControl
    {
        public event Action<EModelViewControl> EDrawingsControlLoaded; 
        public EDrawingsUserControl()
        {
            InitializeComponent();
        }

        public void LoadEDrawings()
        {
            var host = new EDrawingsHost();
            host.ControlLoaded += OnControlLoaded;
            this.Controls.Add(host);
            host.Dock = DockStyle.Fill;
        }

        private void OnControlLoaded(EModelViewControl ctrl)
        {
            EDrawingsControlLoaded?.Invoke(ctrl);
        }
    }
}
