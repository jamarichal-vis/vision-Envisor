namespace Recording
{
    partial class RecordSettingsVideoForm
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbOutputFormat = new System.Windows.Forms.Label();
            this.cBoxOutputFormat = new System.Windows.Forms.ComboBox();
            this.ckBoxFps = new System.Windows.Forms.CheckBox();
            this.numericUpDownFps = new System.Windows.Forms.NumericUpDown();
            this.lbUnitsFps = new System.Windows.Forms.Label();
            this.ckBoxStopRecord = new System.Windows.Forms.CheckBox();
            this.numericUpDownStopRecord = new System.Windows.Forms.NumericUpDown();
            this.cBoxUnitsStopRecord = new System.Windows.Forms.ComboBox();
            this.lbRoot = new System.Windows.Forms.Label();
            this.txBoxRoot = new System.Windows.Forms.TextBox();
            this.btnRoot = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.lbOutputFormat, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cBoxOutputFormat, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ckBoxFps, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownFps, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbUnitsFps, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.ckBoxStopRecord, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownStopRecord, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.cBoxUnitsStopRecord, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbRoot, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txBoxRoot, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnRoot, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(615, 240);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // lbOutputFormat
            // 
            this.lbOutputFormat.AutoSize = true;
            this.lbOutputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutputFormat.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbOutputFormat.Location = new System.Drawing.Point(4, 0);
            this.lbOutputFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOutputFormat.Name = "lbOutputFormat";
            this.lbOutputFormat.Size = new System.Drawing.Size(197, 60);
            this.lbOutputFormat.TabIndex = 0;
            this.lbOutputFormat.Text = "Formato de salida:";
            this.lbOutputFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxOutputFormat
            // 
            this.cBoxOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxOutputFormat.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cBoxOutputFormat.FormattingEnabled = true;
            this.cBoxOutputFormat.Items.AddRange(new object[] {
            "M_FILE_FORMAT_AVI",
            "M_FILE_FORMAT_H264",
            "M_FILE_FORMAT_MP4"});
            this.cBoxOutputFormat.Location = new System.Drawing.Point(209, 15);
            this.cBoxOutputFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxOutputFormat.Name = "cBoxOutputFormat";
            this.cBoxOutputFormat.Size = new System.Drawing.Size(197, 29);
            this.cBoxOutputFormat.TabIndex = 1;
            // 
            // ckBoxFps
            // 
            this.ckBoxFps.AutoSize = true;
            this.ckBoxFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckBoxFps.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ckBoxFps.Location = new System.Drawing.Point(4, 64);
            this.ckBoxFps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckBoxFps.Name = "ckBoxFps";
            this.ckBoxFps.Size = new System.Drawing.Size(197, 52);
            this.ckBoxFps.TabIndex = 2;
            this.ckBoxFps.Text = "Fijar Velocidad de Grabación:";
            this.ckBoxFps.UseVisualStyleBackColor = true;
            this.ckBoxFps.CheckedChanged += new System.EventHandler(this.ckBoxFps_CheckedChanged);
            // 
            // numericUpDownFps
            // 
            this.numericUpDownFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFps.Location = new System.Drawing.Point(209, 79);
            this.numericUpDownFps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownFps.Name = "numericUpDownFps";
            this.numericUpDownFps.Size = new System.Drawing.Size(197, 22);
            this.numericUpDownFps.TabIndex = 3;
            // 
            // lbUnitsFps
            // 
            this.lbUnitsFps.AutoSize = true;
            this.lbUnitsFps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnitsFps.Location = new System.Drawing.Point(414, 60);
            this.lbUnitsFps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnitsFps.Name = "lbUnitsFps";
            this.lbUnitsFps.Size = new System.Drawing.Size(197, 60);
            this.lbUnitsFps.TabIndex = 4;
            this.lbUnitsFps.Text = "fps";
            this.lbUnitsFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckBoxStopRecord
            // 
            this.ckBoxStopRecord.AutoSize = true;
            this.ckBoxStopRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckBoxStopRecord.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ckBoxStopRecord.Location = new System.Drawing.Point(4, 124);
            this.ckBoxStopRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckBoxStopRecord.Name = "ckBoxStopRecord";
            this.ckBoxStopRecord.Size = new System.Drawing.Size(197, 52);
            this.ckBoxStopRecord.TabIndex = 5;
            this.ckBoxStopRecord.Text = "Parar Grabación:";
            this.ckBoxStopRecord.UseVisualStyleBackColor = true;
            this.ckBoxStopRecord.CheckedChanged += new System.EventHandler(this.ckBoxStopRecord_CheckedChanged);
            // 
            // numericUpDownStopRecord
            // 
            this.numericUpDownStopRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownStopRecord.Location = new System.Drawing.Point(209, 139);
            this.numericUpDownStopRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownStopRecord.Name = "numericUpDownStopRecord";
            this.numericUpDownStopRecord.Size = new System.Drawing.Size(197, 22);
            this.numericUpDownStopRecord.TabIndex = 6;
            // 
            // cBoxUnitsStopRecord
            // 
            this.cBoxUnitsStopRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxUnitsStopRecord.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cBoxUnitsStopRecord.FormattingEnabled = true;
            this.cBoxUnitsStopRecord.Items.AddRange(new object[] {
            "Segundos",
            "Minutos",
            "Horas"});
            this.cBoxUnitsStopRecord.Location = new System.Drawing.Point(414, 135);
            this.cBoxUnitsStopRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxUnitsStopRecord.Name = "cBoxUnitsStopRecord";
            this.cBoxUnitsStopRecord.Size = new System.Drawing.Size(197, 29);
            this.cBoxUnitsStopRecord.TabIndex = 7;
            // 
            // lbRoot
            // 
            this.lbRoot.AutoSize = true;
            this.lbRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoot.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbRoot.Location = new System.Drawing.Point(4, 180);
            this.lbRoot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRoot.Name = "lbRoot";
            this.lbRoot.Size = new System.Drawing.Size(197, 60);
            this.lbRoot.TabIndex = 8;
            this.lbRoot.Text = "Seleccionar Carpeta:";
            this.lbRoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txBoxRoot
            // 
            this.txBoxRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txBoxRoot.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txBoxRoot.Location = new System.Drawing.Point(209, 195);
            this.txBoxRoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txBoxRoot.Name = "txBoxRoot";
            this.txBoxRoot.Size = new System.Drawing.Size(197, 29);
            this.txBoxRoot.TabIndex = 9;
            // 
            // btnRoot
            // 
            this.btnRoot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRoot.BackgroundImage = global::Recording.Properties.Resources.camera_on;
            this.btnRoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoot.ForeColor = System.Drawing.Color.Transparent;
            this.btnRoot.Location = new System.Drawing.Point(414, 196);
            this.btnRoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(47, 28);
            this.btnRoot.TabIndex = 10;
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // RecordSettingsVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 240);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RecordSettingsVideoForm";
            this.Text = "RecordSettingsVideoForm";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbOutputFormat;
        private System.Windows.Forms.ComboBox cBoxOutputFormat;
        private System.Windows.Forms.CheckBox ckBoxFps;
        private System.Windows.Forms.NumericUpDown numericUpDownFps;
        private System.Windows.Forms.Label lbUnitsFps;
        private System.Windows.Forms.CheckBox ckBoxStopRecord;
        private System.Windows.Forms.NumericUpDown numericUpDownStopRecord;
        private System.Windows.Forms.ComboBox cBoxUnitsStopRecord;
        private System.Windows.Forms.Label lbRoot;
        private System.Windows.Forms.TextBox txBoxRoot;
        private System.Windows.Forms.Button btnRoot;
    }
}