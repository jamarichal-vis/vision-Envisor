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
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lbFps = new System.Windows.Forms.Label();
            this.lbPosY = new System.Windows.Forms.Label();
            this.lbIntensity = new System.Windows.Forms.Label();
            this.lbPosX = new System.Windows.Forms.Label();
            this.pnlCam = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbIp = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.pnlBorder.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.Color.Green;
            this.pnlBorder.Controls.Add(this.tableLayoutPanelMain);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBorder.Size = new System.Drawing.Size(484, 461);
            this.pnlBorder.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLabels, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.pnlCam, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(474, 451);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelLabels
            // 
            this.tableLayoutPanelLabels.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
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
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 1;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(468, 24);
            this.tableLayoutPanelLabels.TabIndex = 0;
            // 
            // lbFps
            // 
            this.lbFps.AutoSize = true;
            this.lbFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFps.Location = new System.Drawing.Point(352, 1);
            this.lbFps.Name = "lbFps";
            this.lbFps.Size = new System.Drawing.Size(112, 22);
            this.lbFps.TabIndex = 3;
            this.lbFps.Text = "Fps:";
            this.lbFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosY
            // 
            this.lbPosY.AutoSize = true;
            this.lbPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosY.Location = new System.Drawing.Point(236, 1);
            this.lbPosY.Name = "lbPosY";
            this.lbPosY.Size = new System.Drawing.Size(109, 22);
            this.lbPosY.TabIndex = 2;
            this.lbPosY.Text = "Pos. Y:";
            this.lbPosY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIntensity
            // 
            this.lbIntensity.AutoSize = true;
            this.lbIntensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntensity.Location = new System.Drawing.Point(4, 1);
            this.lbIntensity.Name = "lbIntensity";
            this.lbIntensity.Size = new System.Drawing.Size(109, 22);
            this.lbIntensity.TabIndex = 0;
            this.lbIntensity.Text = "Intensidad:";
            this.lbIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosX
            // 
            this.lbPosX.AutoSize = true;
            this.lbPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosX.Location = new System.Drawing.Point(120, 1);
            this.lbPosX.Name = "lbPosX";
            this.lbPosX.Size = new System.Drawing.Size(109, 22);
            this.lbPosX.TabIndex = 1;
            this.lbPosX.Text = "Pos. X:";
            this.lbPosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCam
            // 
            this.pnlCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCam.Location = new System.Drawing.Point(3, 73);
            this.pnlCam.Name = "pnlCam";
            this.pnlCam.Size = new System.Drawing.Size(468, 375);
            this.pnlCam.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.ForestGreen;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.33433F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.33283F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.33283F));
            this.tableLayoutPanel1.Controls.Add(this.lbIp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbModel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIp.ForeColor = System.Drawing.SystemColors.Control;
            this.lbIp.Location = new System.Drawing.Point(337, 0);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(128, 34);
            this.lbIp.TabIndex = 2;
            this.lbIp.Text = "Ip:";
            this.lbIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbName.Location = new System.Drawing.Point(205, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(126, 34);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Nombre:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbModel.ForeColor = System.Drawing.SystemColors.Control;
            this.lbModel.Location = new System.Drawing.Point(3, 0);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(196, 34);
            this.lbModel.TabIndex = 0;
            this.lbModel.Text = "Modelo:";
            this.lbModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DisplayCameraBaslerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.pnlBorder);
            this.Name = "DisplayCameraBaslerForm";
            this.Text = "DisplayCamera";
            this.pnlBorder.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.Label lbFps;
        private System.Windows.Forms.Label lbPosY;
        private System.Windows.Forms.Label lbIntensity;
        private System.Windows.Forms.Label lbPosX;
        private System.Windows.Forms.Panel pnlCam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbModel;
    }
}