namespace Recording
{
    partial class RecordSettingsSequenceForm
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
            this.lbRoot = new System.Windows.Forms.Label();
            this.txBoxRoot = new System.Windows.Forms.TextBox();
            this.btnRoot = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.Controls.Add(this.lbOutputFormat, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cBoxOutputFormat, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbRoot, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txBoxRoot, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnRoot, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(457, 158);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lbOutputFormat
            // 
            this.lbOutputFormat.AutoSize = true;
            this.lbOutputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutputFormat.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbOutputFormat.Location = new System.Drawing.Point(3, 0);
            this.lbOutputFormat.Name = "lbOutputFormat";
            this.lbOutputFormat.Size = new System.Drawing.Size(156, 79);
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
            "M_MIL",
            "M_PNG"});
            this.cBoxOutputFormat.Location = new System.Drawing.Point(165, 29);
            this.cBoxOutputFormat.Name = "cBoxOutputFormat";
            this.cBoxOutputFormat.Size = new System.Drawing.Size(237, 25);
            this.cBoxOutputFormat.TabIndex = 1;
            // 
            // lbRoot
            // 
            this.lbRoot.AutoSize = true;
            this.lbRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoot.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbRoot.Location = new System.Drawing.Point(3, 79);
            this.lbRoot.Name = "lbRoot";
            this.lbRoot.Size = new System.Drawing.Size(156, 79);
            this.lbRoot.TabIndex = 8;
            this.lbRoot.Text = "Seleccionar Carpeta:";
            this.lbRoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txBoxRoot
            // 
            this.txBoxRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txBoxRoot.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txBoxRoot.Location = new System.Drawing.Point(165, 106);
            this.txBoxRoot.Name = "txBoxRoot";
            this.txBoxRoot.Size = new System.Drawing.Size(237, 25);
            this.txBoxRoot.TabIndex = 9;
            // 
            // btnRoot
            // 
            this.btnRoot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRoot.BackgroundImage = global::Recording.Properties.Resources.camera_on;
            this.btnRoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoot.ForeColor = System.Drawing.Color.Transparent;
            this.btnRoot.Location = new System.Drawing.Point(408, 107);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(35, 23);
            this.btnRoot.TabIndex = 10;
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // RecordSettingsSequenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 158);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "RecordSettingsSequenceForm";
            this.Text = "RecordSettingsSequenceForm";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbOutputFormat;
        private System.Windows.Forms.ComboBox cBoxOutputFormat;
        private System.Windows.Forms.Label lbRoot;
        private System.Windows.Forms.TextBox txBoxRoot;
        private System.Windows.Forms.Button btnRoot;
    }
}