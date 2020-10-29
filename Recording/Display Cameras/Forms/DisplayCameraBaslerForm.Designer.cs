namespace Recording
{
    partial class DisplayCameraBaslerForm
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
            this.pnlCam = new System.Windows.Forms.Panel();
            this.lbPosX = new System.Windows.Forms.Label();
            this.lbIntensity = new System.Windows.Forms.Label();
            this.lbPosY = new System.Windows.Forms.Label();
            this.lbFps = new System.Windows.Forms.Label();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLabels, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pnlCam, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(478, 450);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // pnlCam
            // 
            this.pnlCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCam.Location = new System.Drawing.Point(3, 33);
            this.pnlCam.Name = "pnlCam";
            this.pnlCam.Size = new System.Drawing.Size(472, 414);
            this.pnlCam.TabIndex = 1;
            // 
            // lbPosX
            // 
            this.lbPosX.AutoSize = true;
            this.lbPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosX.Location = new System.Drawing.Point(121, 0);
            this.lbPosX.Name = "lbPosX";
            this.lbPosX.Size = new System.Drawing.Size(112, 24);
            this.lbPosX.TabIndex = 1;
            this.lbPosX.Text = "Pos. X:";
            this.lbPosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIntensity
            // 
            this.lbIntensity.AutoSize = true;
            this.lbIntensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntensity.Location = new System.Drawing.Point(3, 0);
            this.lbIntensity.Name = "lbIntensity";
            this.lbIntensity.Size = new System.Drawing.Size(112, 24);
            this.lbIntensity.TabIndex = 0;
            this.lbIntensity.Text = "Intensidad:";
            this.lbIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosY
            // 
            this.lbPosY.AutoSize = true;
            this.lbPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosY.Location = new System.Drawing.Point(239, 0);
            this.lbPosY.Name = "lbPosY";
            this.lbPosY.Size = new System.Drawing.Size(112, 24);
            this.lbPosY.TabIndex = 2;
            this.lbPosY.Text = "Pos. Y:";
            this.lbPosY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFps
            // 
            this.lbFps.AutoSize = true;
            this.lbFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFps.Location = new System.Drawing.Point(357, 0);
            this.lbFps.Name = "lbFps";
            this.lbFps.Size = new System.Drawing.Size(112, 24);
            this.lbFps.TabIndex = 3;
            this.lbFps.Text = "Fps:";
            this.lbFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanelLabels.Controls.Add(this.lbIntensity, 0, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.lbPosX, 1, 0);
            this.tableLayoutPanelLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 1;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(472, 24);
            this.tableLayoutPanelLabels.TabIndex = 0;
            // 
            // DisplayCameraBaslerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "DisplayCameraBaslerForm";
            this.Text = "DisplayCamera";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.Label lbFps;
        private System.Windows.Forms.Label lbPosY;
        private System.Windows.Forms.Label lbIntensity;
        private System.Windows.Forms.Label lbPosX;
        private System.Windows.Forms.Panel pnlCam;
    }
}