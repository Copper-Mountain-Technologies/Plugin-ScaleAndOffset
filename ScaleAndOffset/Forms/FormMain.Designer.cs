namespace ScaleAndOffset
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.readyTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonScaleAndOffsetTrace = new System.Windows.Forms.Button();
            this.labelTrace = new System.Windows.Forms.Label();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.comboBoxTrace = new System.Windows.Forms.ComboBox();
            this.labelChannel = new System.Windows.Forms.Label();
            this.upDownScale = new System.Windows.Forms.NumericUpDown();
            this.labelScale = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.upDownOffset = new System.Windows.Forms.NumericUpDown();
            this.buttonTrigger = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelVnaInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxScaleAndOffset = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.upDownScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownOffset)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxScaleAndOffset.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // readyTimer
            // 
            this.readyTimer.Interval = 1000;
            this.readyTimer.Tick += new System.EventHandler(this.readyTimer_Tick);
            // 
            // buttonScaleAndOffsetTrace
            // 
            this.buttonScaleAndOffsetTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScaleAndOffsetTrace.Location = new System.Drawing.Point(6, 56);
            this.buttonScaleAndOffsetTrace.Name = "buttonScaleAndOffsetTrace";
            this.buttonScaleAndOffsetTrace.Size = new System.Drawing.Size(248, 35);
            this.buttonScaleAndOffsetTrace.TabIndex = 7;
            this.buttonScaleAndOffsetTrace.Text = "Scale and Offset &Trace";
            this.buttonScaleAndOffsetTrace.UseVisualStyleBackColor = true;
            this.buttonScaleAndOffsetTrace.Click += new System.EventHandler(this.scaleAndOffsetResultButton_Click);
            // 
            // labelTrace
            // 
            this.labelTrace.AutoSize = true;
            this.labelTrace.Location = new System.Drawing.Point(11, 59);
            this.labelTrace.Name = "labelTrace";
            this.labelTrace.Size = new System.Drawing.Size(38, 13);
            this.labelTrace.TabIndex = 3;
            this.labelTrace.Text = "&Trace:";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(12, 29);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(166, 21);
            this.comboBoxChannel.TabIndex = 1;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.chanComboBox_SelectedIndexChanged);
            // 
            // comboBoxTrace
            // 
            this.comboBoxTrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrace.FormattingEnabled = true;
            this.comboBoxTrace.Location = new System.Drawing.Point(12, 75);
            this.comboBoxTrace.Name = "comboBoxTrace";
            this.comboBoxTrace.Size = new System.Drawing.Size(260, 21);
            this.comboBoxTrace.TabIndex = 3;
            this.comboBoxTrace.SelectedIndexChanged += new System.EventHandler(this.traceComboBox_SelectedIndexChanged);
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(11, 13);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(49, 13);
            this.labelChannel.TabIndex = 1;
            this.labelChannel.Text = "&Channel:";
            // 
            // upDownScale
            // 
            this.upDownScale.DecimalPlaces = 3;
            this.upDownScale.Location = new System.Drawing.Point(6, 28);
            this.upDownScale.Margin = new System.Windows.Forms.Padding(2);
            this.upDownScale.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.upDownScale.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.upDownScale.Name = "upDownScale";
            this.upDownScale.Size = new System.Drawing.Size(115, 20);
            this.upDownScale.TabIndex = 5;
            this.upDownScale.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(5, 12);
            this.labelScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(37, 13);
            this.labelScale.TabIndex = 5;
            this.labelScale.Text = "&Scale:";
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(136, 12);
            this.labelOffset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(38, 13);
            this.labelOffset.TabIndex = 6;
            this.labelOffset.Text = "&Offset:";
            // 
            // upDownOffset
            // 
            this.upDownOffset.DecimalPlaces = 3;
            this.upDownOffset.Location = new System.Drawing.Point(139, 28);
            this.upDownOffset.Margin = new System.Windows.Forms.Padding(2);
            this.upDownOffset.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.upDownOffset.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.upDownOffset.Name = "upDownOffset";
            this.upDownOffset.Size = new System.Drawing.Size(115, 20);
            this.upDownOffset.TabIndex = 6;
            this.upDownOffset.ValueChanged += new System.EventHandler(this.offsetUpDown_ValueChanged);
            // 
            // buttonTrigger
            // 
            this.buttonTrigger.Location = new System.Drawing.Point(183, 28);
            this.buttonTrigger.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrigger.Name = "buttonTrigger";
            this.buttonTrigger.Size = new System.Drawing.Size(89, 23);
            this.buttonTrigger.TabIndex = 2;
            this.buttonTrigger.Text = "Tri&gger";
            this.buttonTrigger.UseVisualStyleBackColor = true;
            this.buttonTrigger.Click += new System.EventHandler(this.singleTriggerButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVnaInfo,
            this.toolStripStatusLabelSpacer,
            this.toolStripStatusLabelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 210);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 28;
            // 
            // toolStripStatusLabelVnaInfo
            // 
            this.toolStripStatusLabelVnaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVnaInfo.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVnaInfo.Name = "toolStripStatusLabelVnaInfo";
            this.toolStripStatusLabelVnaInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripStatusLabelVnaInfo.Size = new System.Drawing.Size(27, 17);
            this.toolStripStatusLabelVnaInfo.Text = "     ";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(206, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabelVersion.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelVersion.Text = "v ---";
            this.toolStripStatusLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxScaleAndOffset);
            this.panelMain.Controls.Add(this.comboBoxChannel);
            this.panelMain.Controls.Add(this.buttonTrigger);
            this.panelMain.Controls.Add(this.labelChannel);
            this.panelMain.Controls.Add(this.comboBoxTrace);
            this.panelMain.Controls.Add(this.labelTrace);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(284, 232);
            this.panelMain.TabIndex = 36;
            // 
            // groupBoxScaleAndOffset
            // 
            this.groupBoxScaleAndOffset.Controls.Add(this.upDownScale);
            this.groupBoxScaleAndOffset.Controls.Add(this.labelScale);
            this.groupBoxScaleAndOffset.Controls.Add(this.buttonScaleAndOffsetTrace);
            this.groupBoxScaleAndOffset.Controls.Add(this.labelOffset);
            this.groupBoxScaleAndOffset.Controls.Add(this.upDownOffset);
            this.groupBoxScaleAndOffset.Location = new System.Drawing.Point(12, 102);
            this.groupBoxScaleAndOffset.Name = "groupBoxScaleAndOffset";
            this.groupBoxScaleAndOffset.Size = new System.Drawing.Size(260, 100);
            this.groupBoxScaleAndOffset.TabIndex = 4;
            this.groupBoxScaleAndOffset.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 232);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "< application title goes here >";
            ((System.ComponentModel.ISupportInitialize)(this.upDownScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownOffset)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxScaleAndOffset.ResumeLayout(false);
            this.groupBoxScaleAndOffset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer readyTimer;
        private System.Windows.Forms.Button buttonScaleAndOffsetTrace;
        private System.Windows.Forms.Label labelTrace;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.ComboBox comboBoxTrace;
        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.NumericUpDown upDownScale;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.NumericUpDown upDownOffset;
        private System.Windows.Forms.Button buttonTrigger;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVnaInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxScaleAndOffset;
    }
}

