namespace Recording
{
    partial class DisplayCameraFlir
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
            this.lbFps = new System.Windows.Forms.Label();
            this.lbPosY = new System.Windows.Forms.Label();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.lbPosX = new System.Windows.Forms.Label();
            this.tableLayoutPanelCam = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCam = new System.Windows.Forms.Panel();
            this.pnlLut = new System.Windows.Forms.Panel();
            this.numericUpDownLutLow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLutHight = new System.Windows.Forms.NumericUpDown();
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
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLabels, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCam, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(478, 450);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelLabels
            // 
            this.tableLayoutPanelLabels.ColumnCount = 4;
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLabels.Controls.Add(this.lbFps, 3, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.lbPosY, 2, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.lbTemperature, 0, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.lbPosX, 1, 0);
            this.tableLayoutPanelLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(33, 3);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 1;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(442, 24);
            this.tableLayoutPanelLabels.TabIndex = 0;
            // 
            // lbFps
            // 
            this.lbFps.AutoSize = true;
            this.lbFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFps.Location = new System.Drawing.Point(333, 0);
            this.lbFps.Name = "lbFps";
            this.lbFps.Size = new System.Drawing.Size(106, 24);
            this.lbFps.TabIndex = 3;
            this.lbFps.Text = "Fps:";
            this.lbFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosY
            // 
            this.lbPosY.AutoSize = true;
            this.lbPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosY.Location = new System.Drawing.Point(223, 0);
            this.lbPosY.Name = "lbPosY";
            this.lbPosY.Size = new System.Drawing.Size(104, 24);
            this.lbPosY.TabIndex = 2;
            this.lbPosY.Text = "Pos. Y:";
            this.lbPosY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTemperature.Location = new System.Drawing.Point(3, 0);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(104, 24);
            this.lbTemperature.TabIndex = 0;
            this.lbTemperature.Text = "Temperatura:";
            this.lbTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosX
            // 
            this.lbPosX.AutoSize = true;
            this.lbPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosX.Location = new System.Drawing.Point(113, 0);
            this.lbPosX.Name = "lbPosX";
            this.lbPosX.Size = new System.Drawing.Size(104, 24);
            this.lbPosX.TabIndex = 1;
            this.lbPosX.Text = "Pos. X:";
            this.lbPosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelCam
            // 
            this.tableLayoutPanelCam.ColumnCount = 1;
            this.tableLayoutPanelCam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCam.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanelCam.Controls.Add(this.pnlCam, 0, 0);
            this.tableLayoutPanelCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCam.Location = new System.Drawing.Point(33, 33);
            this.tableLayoutPanelCam.Name = "tableLayoutPanelCam";
            this.tableLayoutPanelCam.RowCount = 2;
            this.tableLayoutPanelCam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelCam.Size = new System.Drawing.Size(442, 414);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 377);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlCam
            // 
            this.pnlCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCam.Location = new System.Drawing.Point(3, 3);
            this.pnlCam.Name = "pnlCam";
            this.pnlCam.Size = new System.Drawing.Size(436, 368);
            this.pnlCam.TabIndex = 1;
            // 
            // pnlLut
            // 
            this.pnlLut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLut.Location = new System.Drawing.Point(73, 3);
            this.pnlLut.Name = "pnlLut";
            this.pnlLut.Size = new System.Drawing.Size(290, 28);
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
            this.numericUpDownLutHight.Location = new System.Drawing.Point(369, 7);
            this.numericUpDownLutHight.Name = "numericUpDownLutHight";
            this.numericUpDownLutHight.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownLutHight.TabIndex = 2;
            // 
            // DisplayCameraFlir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "DisplayCameraFlir";
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
        private System.Windows.Forms.Label lbFps;
        private System.Windows.Forms.Label lbPosY;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.Label lbPosX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlCam;
        private System.Windows.Forms.Panel pnlLut;
        private System.Windows.Forms.NumericUpDown numericUpDownLutLow;
        private System.Windows.Forms.NumericUpDown numericUpDownLutHight;
    }
}