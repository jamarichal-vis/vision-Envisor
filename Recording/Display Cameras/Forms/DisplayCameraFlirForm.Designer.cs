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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lbPosY = new System.Windows.Forms.Label();
            this.lbPosX = new System.Windows.Forms.Label();
            this.lbFps = new System.Windows.Forms.Label();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.lbMinTemperature = new System.Windows.Forms.Label();
            this.lbMaxTemperature = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbIp = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbName = new System.Windows.Forms.Label();
            this.txBoxName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCam = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCamLut = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLut = new System.Windows.Forms.Panel();
            this.numericUpDownLutLow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLutHight = new System.Windows.Forms.NumericUpDown();
            this.pnlCam = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPalleta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPalletaIron = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPalletaRainbow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPalletaGray = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlBorder.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelCam.SuspendLayout();
            this.tableLayoutPanelCamLut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutHight)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.pnlBorder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.panel1.Size = new System.Drawing.Size(484, 461);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.ForestGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(453, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 19);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlBorder.Controls.Add(this.tableLayoutPanelMain);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 20);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBorder.Size = new System.Drawing.Size(484, 441);
            this.pnlBorder.TabIndex = 1;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLabels, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(474, 431);
            this.tableLayoutPanelMain.TabIndex = 2;
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
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(4, 45);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 2;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(466, 64);
            this.tableLayoutPanelLabels.TabIndex = 0;
            // 
            // lbPosY
            // 
            this.lbPosY.AutoSize = true;
            this.lbPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosY.Location = new System.Drawing.Point(158, 32);
            this.lbPosY.Name = "lbPosY";
            this.lbPosY.Size = new System.Drawing.Size(148, 31);
            this.lbPosY.TabIndex = 14;
            this.lbPosY.Text = "Pos. Y:";
            this.lbPosY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPosX
            // 
            this.lbPosX.AutoSize = true;
            this.lbPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPosX.Location = new System.Drawing.Point(4, 32);
            this.lbPosX.Name = "lbPosX";
            this.lbPosX.Size = new System.Drawing.Size(147, 31);
            this.lbPosX.TabIndex = 13;
            this.lbPosX.Text = "Pos. X:";
            this.lbPosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFps
            // 
            this.lbFps.AutoSize = true;
            this.lbFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFps.Location = new System.Drawing.Point(313, 32);
            this.lbFps.Name = "lbFps";
            this.lbFps.Size = new System.Drawing.Size(149, 31);
            this.lbFps.TabIndex = 9;
            this.lbFps.Text = "Fps:";
            this.lbFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTemperature.Location = new System.Drawing.Point(4, 1);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(147, 30);
            this.lbTemperature.TabIndex = 0;
            this.lbTemperature.Text = "Temperatura:";
            this.lbTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMinTemperature
            // 
            this.lbMinTemperature.AutoSize = true;
            this.lbMinTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMinTemperature.Location = new System.Drawing.Point(158, 1);
            this.lbMinTemperature.Name = "lbMinTemperature";
            this.lbMinTemperature.Size = new System.Drawing.Size(148, 30);
            this.lbMinTemperature.TabIndex = 7;
            this.lbMinTemperature.Text = "Min:";
            this.lbMinTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaxTemperature
            // 
            this.lbMaxTemperature.AutoSize = true;
            this.lbMaxTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMaxTemperature.Location = new System.Drawing.Point(313, 1);
            this.lbMaxTemperature.Name = "lbMaxTemperature";
            this.lbMaxTemperature.Size = new System.Drawing.Size(149, 30);
            this.lbMaxTemperature.TabIndex = 8;
            this.lbMaxTemperature.Text = "Max:";
            this.lbMaxTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.ForestGreen;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lbIp, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbModel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(466, 34);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIp.ForeColor = System.Drawing.SystemColors.Control;
            this.lbIp.Location = new System.Drawing.Point(328, 0);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(135, 34);
            this.lbIp.TabIndex = 2;
            this.lbIp.Text = "Ip:";
            this.lbIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbModel.ForeColor = System.Drawing.SystemColors.Control;
            this.lbModel.Location = new System.Drawing.Point(3, 0);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(180, 34);
            this.lbModel.TabIndex = 0;
            this.lbModel.Text = "Modelo:";
            this.lbModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.Controls.Add(this.lbName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txBoxName, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(189, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(127, 28);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(3, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 28);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Nombre:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txBoxName
            // 
            this.txBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txBoxName.BackColor = System.Drawing.Color.ForestGreen;
            this.txBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txBoxName.ForeColor = System.Drawing.Color.White;
            this.txBoxName.Location = new System.Drawing.Point(53, 7);
            this.txBoxName.Name = "txBoxName";
            this.txBoxName.Size = new System.Drawing.Size(71, 13);
            this.txBoxName.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelCam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 116);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 311);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanelCam
            // 
            this.tableLayoutPanelCam.ColumnCount = 1;
            this.tableLayoutPanelCam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCam.Controls.Add(this.tableLayoutPanelCamLut, 0, 1);
            this.tableLayoutPanelCam.Controls.Add(this.pnlCam, 0, 0);
            this.tableLayoutPanelCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCam.Location = new System.Drawing.Point(43, 3);
            this.tableLayoutPanelCam.Name = "tableLayoutPanelCam";
            this.tableLayoutPanelCam.RowCount = 2;
            this.tableLayoutPanelCam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelCam.Size = new System.Drawing.Size(420, 305);
            this.tableLayoutPanelCam.TabIndex = 2;
            // 
            // tableLayoutPanelCamLut
            // 
            this.tableLayoutPanelCamLut.ColumnCount = 3;
            this.tableLayoutPanelCamLut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelCamLut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCamLut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelCamLut.Controls.Add(this.pnlLut, 1, 0);
            this.tableLayoutPanelCamLut.Controls.Add(this.numericUpDownLutLow, 0, 0);
            this.tableLayoutPanelCamLut.Controls.Add(this.numericUpDownLutHight, 2, 0);
            this.tableLayoutPanelCamLut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCamLut.Location = new System.Drawing.Point(3, 268);
            this.tableLayoutPanelCamLut.Name = "tableLayoutPanelCamLut";
            this.tableLayoutPanelCamLut.RowCount = 1;
            this.tableLayoutPanelCamLut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCamLut.Size = new System.Drawing.Size(414, 34);
            this.tableLayoutPanelCamLut.TabIndex = 0;
            // 
            // pnlLut
            // 
            this.pnlLut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLut.Location = new System.Drawing.Point(73, 3);
            this.pnlLut.Name = "pnlLut";
            this.pnlLut.Size = new System.Drawing.Size(268, 28);
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
            this.numericUpDownLutHight.Location = new System.Drawing.Point(347, 7);
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
            this.pnlCam.Size = new System.Drawing.Size(414, 259);
            this.pnlCam.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAuto, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(34, 305);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemZoom,
            this.toolStripMenuItemPalleta});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(32, 265);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemZoom
            // 
            this.toolStripMenuItemZoom.Name = "toolStripMenuItemZoom";
            this.toolStripMenuItemZoom.Size = new System.Drawing.Size(19, 19);
            this.toolStripMenuItemZoom.Text = "Z";
            // 
            // toolStripMenuItemPalleta
            // 
            this.toolStripMenuItemPalleta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPalletaIron,
            this.toolStripMenuItemPalletaRainbow,
            this.toolStripMenuItemPalletaGray});
            this.toolStripMenuItemPalleta.Name = "toolStripMenuItemPalleta";
            this.toolStripMenuItemPalleta.Size = new System.Drawing.Size(19, 19);
            this.toolStripMenuItemPalleta.Text = "P";
            // 
            // toolStripMenuItemPalletaIron
            // 
            this.toolStripMenuItemPalletaIron.Name = "toolStripMenuItemPalletaIron";
            this.toolStripMenuItemPalletaIron.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemPalletaIron.Text = "Iron";
            // 
            // toolStripMenuItemPalletaRainbow
            // 
            this.toolStripMenuItemPalletaRainbow.Name = "toolStripMenuItemPalletaRainbow";
            this.toolStripMenuItemPalletaRainbow.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemPalletaRainbow.Text = "Rainbow";
            // 
            // toolStripMenuItemPalletaGray
            // 
            this.toolStripMenuItemPalletaGray.Name = "toolStripMenuItemPalletaGray";
            this.toolStripMenuItemPalletaGray.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemPalletaGray.Text = "Gray";
            // 
            // btnAuto
            // 
            this.btnAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuto.Location = new System.Drawing.Point(3, 268);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(28, 34);
            this.btnAuto.TabIndex = 5;
            this.btnAuto.Text = "A";
            this.btnAuto.UseVisualStyleBackColor = true;
            // 
            // DisplayCameraFlirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.panel1);
            this.Name = "DisplayCameraFlirForm";
            this.panel1.ResumeLayout(false);
            this.pnlBorder.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelCam.ResumeLayout(false);
            this.tableLayoutPanelCamLut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLutHight)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.Label lbPosY;
        private System.Windows.Forms.Label lbPosX;
        private System.Windows.Forms.Label lbFps;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.Label lbMinTemperature;
        private System.Windows.Forms.Label lbMaxTemperature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txBoxName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCamLut;
        private System.Windows.Forms.Panel pnlLut;
        private System.Windows.Forms.NumericUpDown numericUpDownLutLow;
        private System.Windows.Forms.NumericUpDown numericUpDownLutHight;
        private System.Windows.Forms.Panel pnlCam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPalleta;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPalletaIron;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPalletaRainbow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPalletaGray;
        private System.Windows.Forms.Button btnAuto;
    }
}