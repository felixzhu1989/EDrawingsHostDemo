
namespace EDrawingHost
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ctrlEDrw = new EDrawingHost.EDrawingsUserControl();
            this.txtMeasurements = new System.Windows.Forms.TextBox();
            this.btnRecordMeasurements = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(507, 444);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 445);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(457, 20);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(475, 444);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ctrlEDrw
            // 
            this.ctrlEDrw.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlEDrw.Location = new System.Drawing.Point(12, 12);
            this.ctrlEDrw.Name = "ctrlEDrw";
            this.ctrlEDrw.Size = new System.Drawing.Size(571, 426);
            this.ctrlEDrw.TabIndex = 0;
            this.ctrlEDrw.EDrawingsControlLoaded += new System.Action<eDrawings.Interop.EModelViewControl.EModelViewControl>(this.OnControlLoaded);
            // 
            // txtMeasurements
            // 
            this.txtMeasurements.Location = new System.Drawing.Point(598, 12);
            this.txtMeasurements.Multiline = true;
            this.txtMeasurements.Name = "txtMeasurements";
            this.txtMeasurements.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMeasurements.Size = new System.Drawing.Size(190, 426);
            this.txtMeasurements.TabIndex = 4;
            this.txtMeasurements.Text = "测量结果：";
            // 
            // btnRecordMeasurements
            // 
            this.btnRecordMeasurements.Location = new System.Drawing.Point(598, 444);
            this.btnRecordMeasurements.Name = "btnRecordMeasurements";
            this.btnRecordMeasurements.Size = new System.Drawing.Size(190, 23);
            this.btnRecordMeasurements.TabIndex = 5;
            this.btnRecordMeasurements.Text = "记录测量";
            this.btnRecordMeasurements.UseVisualStyleBackColor = true;
            this.btnRecordMeasurements.Click += new System.EventHandler(this.btnRecordMeasurements_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 476);
            this.Controls.Add(this.btnRecordMeasurements);
            this.Controls.Add(this.txtMeasurements);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.ctrlEDrw);
            this.Name = "FrmMain";
            this.Text = "WinForm嵌入eDrawing视窗";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDrawingsUserControl ctrlEDrw;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtMeasurements;
        private System.Windows.Forms.Button btnRecordMeasurements;
    }
}

