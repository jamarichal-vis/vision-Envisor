namespace Recording
{
    partial class RecordingForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutPanelSettings = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutPanelCameras = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutPanelTitleCamera = new System.Windows.Forms.TableLayoutPanel();
            this.lbCamera = new System.Windows.Forms.Label();
            this.treeViewCameras = new System.Windows.Forms.TreeView();
            this.tbLayoutPanelParameter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelExposureTime = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbExposure = new System.Windows.Forms.Label();
            this.numericUpDownExposureTime = new System.Windows.Forms.NumericUpDown();
            this.lbExposureUnits = new System.Windows.Forms.Label();
            this.trackBarExposureTime = new System.Windows.Forms.TrackBar();
            this.lbParameter = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbImageFormatX = new System.Windows.Forms.Label();
            this.numericUpDownImageFormatPixelX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lbImageFormatY = new System.Windows.Forms.Label();
            this.lbImageFormat = new System.Windows.Forms.Label();
            this.cbBoxImageFormat = new System.Windows.Forms.ComboBox();
            this.tbLayoutPanelFrameRate = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbFrameRate = new System.Windows.Forms.Label();
            this.numericUpDownFrameRate = new System.Windows.Forms.NumericUpDown();
            this.lbFrameRateUnits = new System.Windows.Forms.Label();
            this.trBarFrameRate = new System.Windows.Forms.TrackBar();
            this.tbLayoutPanelSequence = new System.Windows.Forms.TableLayoutPanel();
            this.trackBarSequence = new System.Windows.Forms.TrackBar();
            this.tbLayoutPanelSequenceContent = new System.Windows.Forms.TableLayoutPanel();
            this.lbSequencePositionTriggerUnits = new System.Windows.Forms.Label();
            this.lbSequencePreTriggerUnits = new System.Windows.Forms.Label();
            this.lbSequence = new System.Windows.Forms.Label();
            this.numericUpDownTrigger = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPreTrigger = new System.Windows.Forms.NumericUpDown();
            this.cbBoxSequence = new System.Windows.Forms.ComboBox();
            this.lbSequenceTriggerUnits = new System.Windows.Forms.Label();
            this.lbPositinTrigger = new System.Windows.Forms.Label();
            this.numericUpDownPositionTrigger = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbStorage = new System.Windows.Forms.Label();
            this.cbBoxStorage = new System.Windows.Forms.ComboBox();
            this.tbLayoutPanelVisualization = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutPanelTitleVisualization = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.pnlCams = new System.Windows.Forms.Panel();
            this.tbLayoutPanelMain.SuspendLayout();
            this.tbLayoutPanelSettings.SuspendLayout();
            this.tbLayoutPanelCameras.SuspendLayout();
            this.tbLayoutPanelTitleCamera.SuspendLayout();
            this.tbLayoutPanelParameter.SuspendLayout();
            this.tableLayoutPanelExposureTime.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExposureTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExposureTime)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImageFormatPixelX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tbLayoutPanelFrameRate.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarFrameRate)).BeginInit();
            this.tbLayoutPanelSequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSequence)).BeginInit();
            this.tbLayoutPanelSequenceContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPositionTrigger)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tbLayoutPanelVisualization.SuspendLayout();
            this.tbLayoutPanelTitleVisualization.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLayoutPanelMain
            // 
            this.tbLayoutPanelMain.ColumnCount = 2;
            this.tbLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbLayoutPanelMain.Controls.Add(this.tbLayoutPanelSettings, 0, 0);
            this.tbLayoutPanelMain.Controls.Add(this.tbLayoutPanelVisualization, 1, 0);
            this.tbLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tbLayoutPanelMain.Name = "tbLayoutPanelMain";
            this.tbLayoutPanelMain.RowCount = 1;
            this.tbLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelMain.Size = new System.Drawing.Size(1296, 712);
            this.tbLayoutPanelMain.TabIndex = 0;
            // 
            // tbLayoutPanelSettings
            // 
            this.tbLayoutPanelSettings.ColumnCount = 1;
            this.tbLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelSettings.Controls.Add(this.tbLayoutPanelCameras, 0, 0);
            this.tbLayoutPanelSettings.Controls.Add(this.tbLayoutPanelParameter, 0, 1);
            this.tbLayoutPanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelSettings.Location = new System.Drawing.Point(3, 3);
            this.tbLayoutPanelSettings.Name = "tbLayoutPanelSettings";
            this.tbLayoutPanelSettings.RowCount = 2;
            this.tbLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tbLayoutPanelSettings.Size = new System.Drawing.Size(253, 706);
            this.tbLayoutPanelSettings.TabIndex = 0;
            // 
            // tbLayoutPanelCameras
            // 
            this.tbLayoutPanelCameras.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbLayoutPanelCameras.ColumnCount = 1;
            this.tbLayoutPanelCameras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelCameras.Controls.Add(this.tbLayoutPanelTitleCamera, 0, 0);
            this.tbLayoutPanelCameras.Controls.Add(this.treeViewCameras, 0, 1);
            this.tbLayoutPanelCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelCameras.Location = new System.Drawing.Point(3, 3);
            this.tbLayoutPanelCameras.Name = "tbLayoutPanelCameras";
            this.tbLayoutPanelCameras.RowCount = 2;
            this.tbLayoutPanelCameras.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbLayoutPanelCameras.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelCameras.Size = new System.Drawing.Size(247, 205);
            this.tbLayoutPanelCameras.TabIndex = 0;
            // 
            // tbLayoutPanelTitleCamera
            // 
            this.tbLayoutPanelTitleCamera.ColumnCount = 2;
            this.tbLayoutPanelTitleCamera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbLayoutPanelTitleCamera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbLayoutPanelTitleCamera.Controls.Add(this.lbCamera, 0, 0);
            this.tbLayoutPanelTitleCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelTitleCamera.Location = new System.Drawing.Point(4, 4);
            this.tbLayoutPanelTitleCamera.Name = "tbLayoutPanelTitleCamera";
            this.tbLayoutPanelTitleCamera.RowCount = 1;
            this.tbLayoutPanelTitleCamera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelTitleCamera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tbLayoutPanelTitleCamera.Size = new System.Drawing.Size(239, 24);
            this.tbLayoutPanelTitleCamera.TabIndex = 0;
            // 
            // lbCamera
            // 
            this.lbCamera.AutoSize = true;
            this.lbCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCamera.Location = new System.Drawing.Point(3, 0);
            this.lbCamera.Name = "lbCamera";
            this.lbCamera.Size = new System.Drawing.Size(185, 24);
            this.lbCamera.TabIndex = 0;
            this.lbCamera.Text = "CÁMARAS";
            this.lbCamera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeViewCameras
            // 
            this.treeViewCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCameras.Location = new System.Drawing.Point(4, 35);
            this.treeViewCameras.Name = "treeViewCameras";
            this.treeViewCameras.Size = new System.Drawing.Size(239, 166);
            this.treeViewCameras.TabIndex = 1;
            // 
            // tbLayoutPanelParameter
            // 
            this.tbLayoutPanelParameter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbLayoutPanelParameter.ColumnCount = 1;
            this.tbLayoutPanelParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelParameter.Controls.Add(this.tableLayoutPanelExposureTime, 0, 3);
            this.tbLayoutPanelParameter.Controls.Add(this.lbParameter, 0, 0);
            this.tbLayoutPanelParameter.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tbLayoutPanelParameter.Controls.Add(this.tbLayoutPanelFrameRate, 0, 2);
            this.tbLayoutPanelParameter.Controls.Add(this.tbLayoutPanelSequence, 0, 4);
            this.tbLayoutPanelParameter.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.tbLayoutPanelParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelParameter.Location = new System.Drawing.Point(3, 214);
            this.tbLayoutPanelParameter.Name = "tbLayoutPanelParameter";
            this.tbLayoutPanelParameter.RowCount = 6;
            this.tbLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tbLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tbLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tbLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbLayoutPanelParameter.Size = new System.Drawing.Size(247, 489);
            this.tbLayoutPanelParameter.TabIndex = 1;
            // 
            // tableLayoutPanelExposureTime
            // 
            this.tableLayoutPanelExposureTime.ColumnCount = 1;
            this.tableLayoutPanelExposureTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExposureTime.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanelExposureTime.Controls.Add(this.trackBarExposureTime, 0, 1);
            this.tableLayoutPanelExposureTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelExposureTime.Location = new System.Drawing.Point(4, 217);
            this.tableLayoutPanelExposureTime.Name = "tableLayoutPanelExposureTime";
            this.tableLayoutPanelExposureTime.RowCount = 2;
            this.tableLayoutPanelExposureTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelExposureTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExposureTime.Size = new System.Drawing.Size(239, 74);
            this.tableLayoutPanelExposureTime.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.Controls.Add(this.lbExposure, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDownExposureTime, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbExposureUnits, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(233, 24);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // lbExposure
            // 
            this.lbExposure.AutoSize = true;
            this.lbExposure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExposure.Location = new System.Drawing.Point(3, 0);
            this.lbExposure.Name = "lbExposure";
            this.lbExposure.Size = new System.Drawing.Size(75, 24);
            this.lbExposure.TabIndex = 0;
            this.lbExposure.Text = "Exposición";
            this.lbExposure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownExposureTime
            // 
            this.numericUpDownExposureTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownExposureTime.Location = new System.Drawing.Point(84, 3);
            this.numericUpDownExposureTime.Name = "numericUpDownExposureTime";
            this.numericUpDownExposureTime.Size = new System.Drawing.Size(110, 20);
            this.numericUpDownExposureTime.TabIndex = 1;
            // 
            // lbExposureUnits
            // 
            this.lbExposureUnits.AutoSize = true;
            this.lbExposureUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExposureUnits.Location = new System.Drawing.Point(200, 0);
            this.lbExposureUnits.Name = "lbExposureUnits";
            this.lbExposureUnits.Size = new System.Drawing.Size(30, 24);
            this.lbExposureUnits.TabIndex = 2;
            this.lbExposureUnits.Text = "us";
            this.lbExposureUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarExposureTime
            // 
            this.trackBarExposureTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarExposureTime.Location = new System.Drawing.Point(3, 33);
            this.trackBarExposureTime.Name = "trackBarExposureTime";
            this.trackBarExposureTime.Size = new System.Drawing.Size(233, 38);
            this.trackBarExposureTime.TabIndex = 1;
            // 
            // lbParameter
            // 
            this.lbParameter.AutoSize = true;
            this.lbParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParameter.Location = new System.Drawing.Point(4, 1);
            this.lbParameter.Name = "lbParameter";
            this.lbParameter.Size = new System.Drawing.Size(239, 30);
            this.lbParameter.TabIndex = 0;
            this.lbParameter.Text = "PARÁMETROS";
            this.lbParameter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbImageFormat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbBoxImageFormat, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(239, 94);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.lbImageFormatX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownImageFormatPixelX, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDown1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbImageFormatY, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(233, 43);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lbImageFormatX
            // 
            this.lbImageFormatX.AutoSize = true;
            this.lbImageFormatX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageFormatX.Location = new System.Drawing.Point(96, 0);
            this.lbImageFormatX.Name = "lbImageFormatX";
            this.lbImageFormatX.Size = new System.Drawing.Size(17, 43);
            this.lbImageFormatX.TabIndex = 0;
            this.lbImageFormatX.Text = "x";
            this.lbImageFormatX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownImageFormatPixelX
            // 
            this.numericUpDownImageFormatPixelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownImageFormatPixelX.Location = new System.Drawing.Point(3, 11);
            this.numericUpDownImageFormatPixelX.Name = "numericUpDownImageFormatPixelX";
            this.numericUpDownImageFormatPixelX.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownImageFormatPixelX.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(119, 11);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(87, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // lbImageFormatY
            // 
            this.lbImageFormatY.AutoSize = true;
            this.lbImageFormatY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageFormatY.Location = new System.Drawing.Point(212, 0);
            this.lbImageFormatY.Name = "lbImageFormatY";
            this.lbImageFormatY.Size = new System.Drawing.Size(18, 43);
            this.lbImageFormatY.TabIndex = 3;
            this.lbImageFormatY.Text = "y";
            this.lbImageFormatY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbImageFormat
            // 
            this.lbImageFormat.AutoSize = true;
            this.lbImageFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageFormat.Location = new System.Drawing.Point(3, 0);
            this.lbImageFormat.Name = "lbImageFormat";
            this.lbImageFormat.Size = new System.Drawing.Size(233, 20);
            this.lbImageFormat.TabIndex = 4;
            this.lbImageFormat.Text = "Formato de la Imagen";
            this.lbImageFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBoxImageFormat
            // 
            this.cbBoxImageFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBoxImageFormat.FormattingEnabled = true;
            this.cbBoxImageFormat.Location = new System.Drawing.Point(3, 23);
            this.cbBoxImageFormat.Name = "cbBoxImageFormat";
            this.cbBoxImageFormat.Size = new System.Drawing.Size(233, 21);
            this.cbBoxImageFormat.TabIndex = 5;
            // 
            // tbLayoutPanelFrameRate
            // 
            this.tbLayoutPanelFrameRate.ColumnCount = 1;
            this.tbLayoutPanelFrameRate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelFrameRate.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tbLayoutPanelFrameRate.Controls.Add(this.trBarFrameRate, 0, 1);
            this.tbLayoutPanelFrameRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelFrameRate.Location = new System.Drawing.Point(4, 136);
            this.tbLayoutPanelFrameRate.Name = "tbLayoutPanelFrameRate";
            this.tbLayoutPanelFrameRate.RowCount = 2;
            this.tbLayoutPanelFrameRate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbLayoutPanelFrameRate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbLayoutPanelFrameRate.Size = new System.Drawing.Size(239, 74);
            this.tbLayoutPanelFrameRate.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Controls.Add(this.lbFrameRate, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownFrameRate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbFrameRateUnits, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(233, 24);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lbFrameRate
            // 
            this.lbFrameRate.AutoSize = true;
            this.lbFrameRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFrameRate.Location = new System.Drawing.Point(3, 0);
            this.lbFrameRate.Name = "lbFrameRate";
            this.lbFrameRate.Size = new System.Drawing.Size(75, 24);
            this.lbFrameRate.TabIndex = 0;
            this.lbFrameRate.Text = "Frame Rate";
            this.lbFrameRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownFrameRate
            // 
            this.numericUpDownFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFrameRate.Location = new System.Drawing.Point(84, 3);
            this.numericUpDownFrameRate.Name = "numericUpDownFrameRate";
            this.numericUpDownFrameRate.Size = new System.Drawing.Size(110, 20);
            this.numericUpDownFrameRate.TabIndex = 1;
            // 
            // lbFrameRateUnits
            // 
            this.lbFrameRateUnits.AutoSize = true;
            this.lbFrameRateUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFrameRateUnits.Location = new System.Drawing.Point(200, 0);
            this.lbFrameRateUnits.Name = "lbFrameRateUnits";
            this.lbFrameRateUnits.Size = new System.Drawing.Size(30, 24);
            this.lbFrameRateUnits.TabIndex = 2;
            this.lbFrameRateUnits.Text = "fps";
            this.lbFrameRateUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trBarFrameRate
            // 
            this.trBarFrameRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trBarFrameRate.Location = new System.Drawing.Point(3, 33);
            this.trBarFrameRate.Name = "trBarFrameRate";
            this.trBarFrameRate.Size = new System.Drawing.Size(233, 38);
            this.trBarFrameRate.TabIndex = 1;
            // 
            // tbLayoutPanelSequence
            // 
            this.tbLayoutPanelSequence.ColumnCount = 1;
            this.tbLayoutPanelSequence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelSequence.Controls.Add(this.trackBarSequence, 0, 1);
            this.tbLayoutPanelSequence.Controls.Add(this.tbLayoutPanelSequenceContent, 0, 0);
            this.tbLayoutPanelSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelSequence.Location = new System.Drawing.Point(4, 298);
            this.tbLayoutPanelSequence.Name = "tbLayoutPanelSequence";
            this.tbLayoutPanelSequence.RowCount = 2;
            this.tbLayoutPanelSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tbLayoutPanelSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbLayoutPanelSequence.Size = new System.Drawing.Size(239, 114);
            this.tbLayoutPanelSequence.TabIndex = 4;
            // 
            // trackBarSequence
            // 
            this.trackBarSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarSequence.Location = new System.Drawing.Point(3, 83);
            this.trackBarSequence.Name = "trackBarSequence";
            this.trackBarSequence.Size = new System.Drawing.Size(233, 28);
            this.trackBarSequence.TabIndex = 2;
            // 
            // tbLayoutPanelSequenceContent
            // 
            this.tbLayoutPanelSequenceContent.ColumnCount = 3;
            this.tbLayoutPanelSequenceContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tbLayoutPanelSequenceContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tbLayoutPanelSequenceContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tbLayoutPanelSequenceContent.Controls.Add(this.lbSequencePositionTriggerUnits, 2, 2);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.lbSequencePreTriggerUnits, 2, 1);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.lbSequence, 0, 0);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.numericUpDownTrigger, 1, 0);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.numericUpDownPreTrigger, 1, 1);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.cbBoxSequence, 0, 1);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.lbSequenceTriggerUnits, 2, 0);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.lbPositinTrigger, 0, 2);
            this.tbLayoutPanelSequenceContent.Controls.Add(this.numericUpDownPositionTrigger, 1, 2);
            this.tbLayoutPanelSequenceContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelSequenceContent.Location = new System.Drawing.Point(3, 3);
            this.tbLayoutPanelSequenceContent.Name = "tbLayoutPanelSequenceContent";
            this.tbLayoutPanelSequenceContent.RowCount = 3;
            this.tbLayoutPanelSequenceContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutPanelSequenceContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutPanelSequenceContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutPanelSequenceContent.Size = new System.Drawing.Size(233, 74);
            this.tbLayoutPanelSequenceContent.TabIndex = 0;
            // 
            // lbSequencePositionTriggerUnits
            // 
            this.lbSequencePositionTriggerUnits.AutoSize = true;
            this.lbSequencePositionTriggerUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSequencePositionTriggerUnits.Location = new System.Drawing.Point(207, 50);
            this.lbSequencePositionTriggerUnits.Name = "lbSequencePositionTriggerUnits";
            this.lbSequencePositionTriggerUnits.Size = new System.Drawing.Size(23, 25);
            this.lbSequencePositionTriggerUnits.TabIndex = 8;
            this.lbSequencePositionTriggerUnits.Text = "%";
            this.lbSequencePositionTriggerUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSequencePreTriggerUnits
            // 
            this.lbSequencePreTriggerUnits.AutoSize = true;
            this.lbSequencePreTriggerUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSequencePreTriggerUnits.Location = new System.Drawing.Point(207, 25);
            this.lbSequencePreTriggerUnits.Name = "lbSequencePreTriggerUnits";
            this.lbSequencePreTriggerUnits.Size = new System.Drawing.Size(23, 25);
            this.lbSequencePreTriggerUnits.TabIndex = 5;
            this.lbSequencePreTriggerUnits.Text = "frm";
            this.lbSequencePreTriggerUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSequence
            // 
            this.lbSequence.AutoSize = true;
            this.lbSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSequence.Location = new System.Drawing.Point(3, 0);
            this.lbSequence.Name = "lbSequence";
            this.lbSequence.Size = new System.Drawing.Size(96, 25);
            this.lbSequence.TabIndex = 0;
            this.lbSequence.Text = "Sequence";
            this.lbSequence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownTrigger
            // 
            this.numericUpDownTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTrigger.Location = new System.Drawing.Point(105, 3);
            this.numericUpDownTrigger.Name = "numericUpDownTrigger";
            this.numericUpDownTrigger.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownTrigger.TabIndex = 1;
            // 
            // numericUpDownPreTrigger
            // 
            this.numericUpDownPreTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPreTrigger.Location = new System.Drawing.Point(105, 28);
            this.numericUpDownPreTrigger.Name = "numericUpDownPreTrigger";
            this.numericUpDownPreTrigger.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownPreTrigger.TabIndex = 2;
            // 
            // cbBoxSequence
            // 
            this.cbBoxSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBoxSequence.FormattingEnabled = true;
            this.cbBoxSequence.Location = new System.Drawing.Point(3, 28);
            this.cbBoxSequence.Name = "cbBoxSequence";
            this.cbBoxSequence.Size = new System.Drawing.Size(96, 21);
            this.cbBoxSequence.TabIndex = 3;
            // 
            // lbSequenceTriggerUnits
            // 
            this.lbSequenceTriggerUnits.AutoSize = true;
            this.lbSequenceTriggerUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSequenceTriggerUnits.Location = new System.Drawing.Point(207, 0);
            this.lbSequenceTriggerUnits.Name = "lbSequenceTriggerUnits";
            this.lbSequenceTriggerUnits.Size = new System.Drawing.Size(23, 25);
            this.lbSequenceTriggerUnits.TabIndex = 4;
            this.lbSequenceTriggerUnits.Text = "frm";
            this.lbSequenceTriggerUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPositinTrigger
            // 
            this.lbPositinTrigger.AutoSize = true;
            this.lbPositinTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPositinTrigger.Location = new System.Drawing.Point(3, 50);
            this.lbPositinTrigger.Name = "lbPositinTrigger";
            this.lbPositinTrigger.Size = new System.Drawing.Size(96, 25);
            this.lbPositinTrigger.TabIndex = 6;
            this.lbPositinTrigger.Text = "Posición Trigger";
            this.lbPositinTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownPositionTrigger
            // 
            this.numericUpDownPositionTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPositionTrigger.Location = new System.Drawing.Point(105, 53);
            this.numericUpDownPositionTrigger.Name = "numericUpDownPositionTrigger";
            this.numericUpDownPositionTrigger.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownPositionTrigger.TabIndex = 7;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.lbStorage, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbBoxStorage, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 419);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(239, 94);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // lbStorage
            // 
            this.lbStorage.AutoSize = true;
            this.lbStorage.Location = new System.Drawing.Point(3, 0);
            this.lbStorage.Name = "lbStorage";
            this.lbStorage.Size = new System.Drawing.Size(85, 13);
            this.lbStorage.TabIndex = 0;
            this.lbStorage.Text = "Almacenamiento";
            // 
            // cbBoxStorage
            // 
            this.cbBoxStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBoxStorage.FormattingEnabled = true;
            this.cbBoxStorage.Location = new System.Drawing.Point(3, 23);
            this.cbBoxStorage.Name = "cbBoxStorage";
            this.cbBoxStorage.Size = new System.Drawing.Size(233, 21);
            this.cbBoxStorage.TabIndex = 1;
            // 
            // tbLayoutPanelVisualization
            // 
            this.tbLayoutPanelVisualization.ColumnCount = 1;
            this.tbLayoutPanelVisualization.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelVisualization.Controls.Add(this.tbLayoutPanelTitleVisualization, 0, 0);
            this.tbLayoutPanelVisualization.Controls.Add(this.pnlCams, 0, 1);
            this.tbLayoutPanelVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelVisualization.Location = new System.Drawing.Point(262, 3);
            this.tbLayoutPanelVisualization.Name = "tbLayoutPanelVisualization";
            this.tbLayoutPanelVisualization.RowCount = 2;
            this.tbLayoutPanelVisualization.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tbLayoutPanelVisualization.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelVisualization.Size = new System.Drawing.Size(1031, 706);
            this.tbLayoutPanelVisualization.TabIndex = 1;
            // 
            // tbLayoutPanelTitleVisualization
            // 
            this.tbLayoutPanelTitleVisualization.ColumnCount = 4;
            this.tbLayoutPanelTitleVisualization.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbLayoutPanelTitleVisualization.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbLayoutPanelTitleVisualization.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbLayoutPanelTitleVisualization.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbLayoutPanelTitleVisualization.Controls.Add(this.btnDelete, 2, 0);
            this.tbLayoutPanelTitleVisualization.Controls.Add(this.btnSave, 1, 0);
            this.tbLayoutPanelTitleVisualization.Controls.Add(this.btnRecord, 0, 0);
            this.tbLayoutPanelTitleVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanelTitleVisualization.Location = new System.Drawing.Point(3, 3);
            this.tbLayoutPanelTitleVisualization.Name = "tbLayoutPanelTitleVisualization";
            this.tbLayoutPanelTitleVisualization.RowCount = 1;
            this.tbLayoutPanelTitleVisualization.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanelTitleVisualization.Size = new System.Drawing.Size(1025, 29);
            this.tbLayoutPanelTitleVisualization.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(156, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(45, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(105, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnRecord
            // 
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecord.Location = new System.Drawing.Point(3, 3);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(96, 23);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            // 
            // pnlCams
            // 
            this.pnlCams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCams.Location = new System.Drawing.Point(3, 38);
            this.pnlCams.Name = "pnlCams";
            this.pnlCams.Size = new System.Drawing.Size(1025, 665);
            this.pnlCams.TabIndex = 1;
            // 
            // RecordingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 712);
            this.Controls.Add(this.tbLayoutPanelMain);
            this.Name = "RecordingForm";
            this.Text = "Recording";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordingForm_FormClosing);
            this.tbLayoutPanelMain.ResumeLayout(false);
            this.tbLayoutPanelSettings.ResumeLayout(false);
            this.tbLayoutPanelCameras.ResumeLayout(false);
            this.tbLayoutPanelTitleCamera.ResumeLayout(false);
            this.tbLayoutPanelTitleCamera.PerformLayout();
            this.tbLayoutPanelParameter.ResumeLayout(false);
            this.tbLayoutPanelParameter.PerformLayout();
            this.tableLayoutPanelExposureTime.ResumeLayout(false);
            this.tableLayoutPanelExposureTime.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExposureTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExposureTime)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImageFormatPixelX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tbLayoutPanelFrameRate.ResumeLayout(false);
            this.tbLayoutPanelFrameRate.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarFrameRate)).EndInit();
            this.tbLayoutPanelSequence.ResumeLayout(false);
            this.tbLayoutPanelSequence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSequence)).EndInit();
            this.tbLayoutPanelSequenceContent.ResumeLayout(false);
            this.tbLayoutPanelSequenceContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPositionTrigger)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tbLayoutPanelVisualization.ResumeLayout(false);
            this.tbLayoutPanelTitleVisualization.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelSettings;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelCameras;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelTitleCamera;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelParameter;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelVisualization;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelTitleVisualization;
        private System.Windows.Forms.Label lbCamera;
        private System.Windows.Forms.TreeView treeViewCameras;
        private System.Windows.Forms.Label lbParameter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbImageFormatX;
        private System.Windows.Forms.NumericUpDown numericUpDownImageFormatPixelX;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lbImageFormatY;
        private System.Windows.Forms.Label lbImageFormat;
        private System.Windows.Forms.ComboBox cbBoxImageFormat;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelFrameRate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbFrameRate;
        private System.Windows.Forms.NumericUpDown numericUpDownFrameRate;
        private System.Windows.Forms.Label lbFrameRateUnits;
        private System.Windows.Forms.TrackBar trBarFrameRate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExposureTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lbExposure;
        private System.Windows.Forms.NumericUpDown numericUpDownExposureTime;
        private System.Windows.Forms.Label lbExposureUnits;
        private System.Windows.Forms.TrackBar trackBarExposureTime;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelSequence;
        private System.Windows.Forms.TrackBar trackBarSequence;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanelSequenceContent;
        private System.Windows.Forms.Label lbSequencePositionTriggerUnits;
        private System.Windows.Forms.Label lbSequencePreTriggerUnits;
        private System.Windows.Forms.Label lbSequence;
        private System.Windows.Forms.NumericUpDown numericUpDownTrigger;
        private System.Windows.Forms.NumericUpDown numericUpDownPreTrigger;
        private System.Windows.Forms.ComboBox cbBoxSequence;
        private System.Windows.Forms.Label lbSequenceTriggerUnits;
        private System.Windows.Forms.Label lbPositinTrigger;
        private System.Windows.Forms.NumericUpDown numericUpDownPositionTrigger;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lbStorage;
        private System.Windows.Forms.ComboBox cbBoxStorage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Panel pnlCams;
    }
}

