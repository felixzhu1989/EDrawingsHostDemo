using System;
using System.Diagnostics;
using System.Windows.Forms;
using eDrawings.Interop.EModelMarkupControl;
using eDrawings.Interop.EModelViewControl;

namespace EDrawingsHostDemo
{
    public partial class FrmMain : Form
    {
        private EModelViewControl m_EDrawingsCtrl;
        //Markup
        private EModelMarkupControl m_EDrawingsMarkupCtrl;
        public FrmMain()
        {
            InitializeComponent();
            //如果工具箱中没法显示自定义控件，那么就可以动态加载
            EDrawingsUserControl ctrlEDrw = new EDrawingsUserControl();
            ctrlEDrw.EDrawingsControlLoaded += this.OnControlLoaded;
            ctrlEDrw.LoadEDrawings();
            panel1.Controls.Add(ctrlEDrw);
            ctrlEDrw.Dock = DockStyle.Fill;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // ctrlEDrw.LoadEDrawings();
        }

        private void OnControlLoaded(EModelViewControl ctrl)
        {
            m_EDrawingsCtrl = ctrl;
            ctrl.OnFinishedLoadingDocument += OnFinishedLoadingDocument;
            ctrl.OnFailedLoadingDocument += OnFailedLoadingDocument;
            //Markup
            m_EDrawingsMarkupCtrl = m_EDrawingsCtrl.CoCreateInstance("EModelViewMarkup.EModelMarkupControl") as EModelMarkupControl;
        }

        private void OnFailedLoadingDocument(string filename, int errorcode, string errorstring)
        {
            Trace.WriteLine($"{filename} failed to loaded: {errorstring}");
        }

        private void OnFinishedLoadingDocument(string filename)
        {
            Trace.WriteLine($"{filename} loaded");
            //Markup自动启用测量
            m_EDrawingsMarkupCtrl.ViewOperator = EMVMarkupOperators.eMVOperatorMeasure;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text.Trim();
            if (!string.IsNullOrEmpty(filePath))
            {
                if (m_EDrawingsCtrl == null)
                {
                    throw new NullReferenceException("eDrawings control is not loaded");
                }
            }
            m_EDrawingsCtrl.CloseActiveDoc("");
            m_EDrawingsCtrl.OpenDoc(filePath, false, false, false, "");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void btnRecordMeasurements_Click(object sender, EventArgs e)
        {
            txtMeasurements.Text += (!string.IsNullOrEmpty(txtMeasurements.Text) ? Environment.NewLine : "") + m_EDrawingsMarkupCtrl.MeasureResultString;
        }
    }
}
