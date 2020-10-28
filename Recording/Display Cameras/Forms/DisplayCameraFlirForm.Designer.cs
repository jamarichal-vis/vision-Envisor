namespace Recording
{
    partial class DisplayCameraFlirForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.tableLayoutPanelCam = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLut = new System.Windows.Forms.Panel();
            this.numericUpDownLutLow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLutHight = new System.Windows.Forms.NumericUpDown();
            this.pnlCam = new System.Windows.Forms.Panel();
            this.lbMinTemperature = new System.Windows.Forms.Label();
            this.lbMaxTemperature = new System.Windows.Forms.Label();
            this.lbFps = new System.Windows.Forms.Label();
            this.lbPosX = new System.Windows.Forms.Label();
            this.lbPosY = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.tableLayoutPanelCam.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutHight)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLabels, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCam, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(478, 450);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelLabels
            // 
            this.tableLayoutPanelLabels.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelLabels.ColumnCount = 3;
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelLabels.Controls.Add(this.lbPosY, 1, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.lbPosX, 0, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.lbFps, 2, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.lbTemperature, 0, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.lbMinTemperature, 1, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.lbMaxTemperature, 2, 0);
            this.tableLayoutPanelLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(63, 3);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 2;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(412, 65);
            this.tableLayoutPanelLabels.TabIndex = 0;
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTemperature.Location = new System.Drawing.Point(4, 1);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(129, 30);
            this.lbTemperature.TabIndex = 0;
            this.lbTemperature.Text = "Temperatura:";
            this.lbTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelCam
            // 
            this.tableLayoutPanelCam.ColumnCount = 1;
            this.tableLayoutPanelCam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCam.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanelCam.Controls.Add(this.pnlCam, 0, 0);
            this.tableLayoutPanelCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCam.Location = new System.Drawing.Point(63, 74);
            this.tableLayoutPanelCam.Name = "tableLayoutPanelCam";
            this.tableLayoutPanelCam.RowCount = 2;
            this.tableLayoutPanelCam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelCam.Size = new System.Drawing.Size(412, 373);
            this.tableLayoutPanelCam.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.pnlLut, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownLutLow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownLutHight, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 336);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlLut
            // 
            this.pnlLut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLut.Location = new System.Drawing.Point(73, 3);
            this.pnlLut.Name = "pnlLut";
            this.pnlLut.Size = new System.Drawing.Size(260, 28);
            this.pnlLut.TabIndex = 0;
            // 
            // numericUpDownLutLow
            // 
            this.numericUpDownLutLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownLutLow.Location = new System.Drawing.Point(3, 7);
            this.numericUpDownLutLow.Name = "numericUpDownLutLow";
            this.numericUpDownLutLow.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownLutLow.TabIndex = 1;
            // 
            // numericUpDownLutHight
            // 
            this.numericUpDownLutHight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownLutHight.Location = new System.Drawing.Point(339, 7);
            this.numericUpDownLutHight.Name = "numericUpDownLutHight";
            this.numericUpDownLutHight.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownLutHight.TabIndex = 2;
            // 
            // pnlCam
            // 
            this.pnlCam.BackColor = System.Drawing.Color.Transparent;
            this.pnlCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCam.ForeColor = System.Drawing.Color.Transparent;
            this.pnlCam.Location = new System.Drawing.Point(3, 3);
            this.pnlCam.Name = "pnlCam";
            this.pnlCam.Size = new System.Drawing.Size(406, 327);
            this.pnlCam.TabIndex = 1;
            // 
            // lbMinTemperature
            // 
            this.lbMinTemperature.AutoSize = true;
            this.lbMinTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMinTemperature.Location = new System.Drawing.Point(140, 1);
            this.lbMinTemperature.Name = "lbMinTemperature";
            this.lbMinTemperature.Size = new System.Drawing.Size(130, 30);
            this.lbMinTemperature.TabIndex = 7;
            this.lbMinTemperature.Text = "Min:";
            this.lbMinTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaxTemperature
            // 
            this.lbMaxTemperature.AutoSize = true;
            this.lbMaxTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMaxTemperature.Location = new System.Drawing.Point(277, 1);
            this.lbMaxTemperature.Name = "lbMaxTemperature";
            this.lbMaxTemperature.Size = new System.Drawing.Size(131, 30);
            this.lbMaxTemperature.TabIndex = 8;
            this.lbMaxTemperature.Text = "Max:";
            this.lbMaxTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFps
            // 
            this.lbFps.AutoSize = true;
            this.lbFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFps.Location = new System.Drawing.Point(277, 32);
            this.lbFps.Name = "lbFps";
            this.lbFps.Size = new System.Drawing.Size(131, 32);
            this.lbFps.TabIndex = 9;
            this.lbFps.Text = "Fps:";
            this.lbFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosX
            // 
            this.lbPosX.AutoSize = true;
            this.lbPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosX.Location = new System.Drawing.Point(4, 32);
            this.lbPosX.Name = "lbPosX";
            this.lbPosX.Size = new System.Drawing.Size(129, 32);
            this.lbPosX.TabIndex = 13;
            this.lbPosX.Text = "Pos. X:";
            this.lbPosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosY
            // 
            this.lbPosY.AutoSize = true;
            this.lbPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosY.Location = new System.Drawing.Point(140, 32);
            this.lbPosY.Name = "lbPosY";
            this.lbPosY.Size = new System.Drawing.Size(130, 32);
            this.lbPosY.TabIndex = 14;
            this.lbPosY.Text = "Pos. Y:";
            this.lbPosY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DisplayCameraFlirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "DisplayCameraFlirForm";
            this.Text = "DisplayCameraFlir";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.tableLayoutPanelCam.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutHight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlCam;
        private System.Windows.Forms.Panel pnlLut;
        private System.Windows.Forms.NumericUpDown numericUpDownLutLow;
        private System.Windows.Forms.NumericUpDown numericUpDownLutHight;
        private System.Windows.Forms.Label lbMinTemperature;
        private System.Windows.Forms.Label lbMaxTemperature;
        private System.Windows.Forms.Label lbPosY;
        private System.Windows.Forms.Label lbPosX;
        private System.Windows.Forms.Label lbFps;
    }
}