namespace Renderite2D_Game_Engine
{
    partial class ProjectSettingsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSettingsMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.vSyncEnabled = new System.Windows.Forms.CheckBox();
            this.isWindowResizeable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.drawColliders = new System.Windows.Forms.CheckBox();
            this.allowAltEnter = new System.Windows.Forms.CheckBox();
            this.resolutionX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.resolutionY = new System.Windows.Forms.NumericUpDown();
            this.windowTitle = new System.Windows.Forms.TextBox();
            this.fixedUpdateFrequency = new System.Windows.Forms.NumericUpDown();
            this.windowState = new System.Windows.Forms.ComboBox();
            this.startingLevel = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedUpdateFrequency)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution :";
            // 
            // vSyncEnabled
            // 
            this.vSyncEnabled.AutoSize = true;
            this.vSyncEnabled.Checked = true;
            this.vSyncEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vSyncEnabled.Location = new System.Drawing.Point(26, 75);
            this.vSyncEnabled.Name = "vSyncEnabled";
            this.vSyncEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vSyncEnabled.Size = new System.Drawing.Size(188, 23);
            this.vSyncEnabled.TabIndex = 1;
            this.vSyncEnabled.Text = "                     : Enable VSync";
            this.vSyncEnabled.UseVisualStyleBackColor = true;
            this.vSyncEnabled.CheckedChanged += new System.EventHandler(this.vSyncEnabled_CheckedChanged);
            // 
            // isWindowResizeable
            // 
            this.isWindowResizeable.AutoSize = true;
            this.isWindowResizeable.Checked = true;
            this.isWindowResizeable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isWindowResizeable.Location = new System.Drawing.Point(26, 125);
            this.isWindowResizeable.Name = "isWindowResizeable";
            this.isWindowResizeable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isWindowResizeable.Size = new System.Drawing.Size(187, 23);
            this.isWindowResizeable.TabIndex = 2;
            this.isWindowResizeable.Text = "        : Resizeable Window";
            this.isWindowResizeable.UseVisualStyleBackColor = true;
            this.isWindowResizeable.CheckedChanged += new System.EventHandler(this.isWindowResizeable_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Window Title :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Game Update Frequency :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Window State :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Starting Level :";
            // 
            // drawColliders
            // 
            this.drawColliders.AutoSize = true;
            this.drawColliders.Checked = true;
            this.drawColliders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawColliders.Location = new System.Drawing.Point(350, 125);
            this.drawColliders.Name = "drawColliders";
            this.drawColliders.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.drawColliders.Size = new System.Drawing.Size(163, 23);
            this.drawColliders.TabIndex = 7;
            this.drawColliders.Text = "           : Draw Colliders";
            this.drawColliders.UseVisualStyleBackColor = true;
            this.drawColliders.CheckedChanged += new System.EventHandler(this.drawColliders_CheckedChanged);
            // 
            // allowAltEnter
            // 
            this.allowAltEnter.AutoSize = true;
            this.allowAltEnter.Checked = true;
            this.allowAltEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowAltEnter.Location = new System.Drawing.Point(350, 171);
            this.allowAltEnter.Name = "allowAltEnter";
            this.allowAltEnter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.allowAltEnter.Size = new System.Drawing.Size(163, 23);
            this.allowAltEnter.TabIndex = 8;
            this.allowAltEnter.Text = "        : Allow Alt+Enter";
            this.allowAltEnter.UseVisualStyleBackColor = true;
            this.allowAltEnter.CheckedChanged += new System.EventHandler(this.allowAltEnter_CheckedChanged);
            // 
            // resolutionX
            // 
            this.resolutionX.Location = new System.Drawing.Point(132, 33);
            this.resolutionX.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.resolutionX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resolutionX.Name = "resolutionX";
            this.resolutionX.Size = new System.Drawing.Size(61, 27);
            this.resolutionX.TabIndex = 9;
            this.resolutionX.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.resolutionX.ValueChanged += new System.EventHandler(this.resolutionX_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "x";
            // 
            // resolutionY
            // 
            this.resolutionY.Location = new System.Drawing.Point(218, 33);
            this.resolutionY.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.resolutionY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resolutionY.Name = "resolutionY";
            this.resolutionY.Size = new System.Drawing.Size(61, 27);
            this.resolutionY.TabIndex = 11;
            this.resolutionY.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.resolutionY.ValueChanged += new System.EventHandler(this.resolutionY_ValueChanged);
            // 
            // windowTitle
            // 
            this.windowTitle.Location = new System.Drawing.Point(137, 169);
            this.windowTitle.Name = "windowTitle";
            this.windowTitle.Size = new System.Drawing.Size(142, 27);
            this.windowTitle.TabIndex = 12;
            this.windowTitle.TextChanged += new System.EventHandler(this.windowTitle_TextChanged);
            // 
            // fixedUpdateFrequency
            // 
            this.fixedUpdateFrequency.Location = new System.Drawing.Point(218, 223);
            this.fixedUpdateFrequency.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.fixedUpdateFrequency.Name = "fixedUpdateFrequency";
            this.fixedUpdateFrequency.Size = new System.Drawing.Size(61, 27);
            this.fixedUpdateFrequency.TabIndex = 13;
            this.fixedUpdateFrequency.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.fixedUpdateFrequency.ValueChanged += new System.EventHandler(this.fixedUpdateFrequency_ValueChanged);
            // 
            // windowState
            // 
            this.windowState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowState.FormattingEnabled = true;
            this.windowState.Items.AddRange(new object[] {
            "Normal",
            "Minimized",
            "Maximized",
            "Fullscreen"});
            this.windowState.Location = new System.Drawing.Point(491, 33);
            this.windowState.Name = "windowState";
            this.windowState.Size = new System.Drawing.Size(121, 27);
            this.windowState.TabIndex = 15;
            this.windowState.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // startingLevel
            // 
            this.startingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingLevel.FormattingEnabled = true;
            this.startingLevel.Items.AddRange(new object[] {
            "SampleLevel"});
            this.startingLevel.Location = new System.Drawing.Point(491, 72);
            this.startingLevel.Name = "startingLevel";
            this.startingLevel.Size = new System.Drawing.Size(121, 27);
            this.startingLevel.TabIndex = 16;
            this.startingLevel.SelectedIndexChanged += new System.EventHandler(this.isWindowResizeable_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 271);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(624, 50);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(8);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(81, 30);
            this.toolStripMenuItem1.Text = "Cancel";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Margin = new System.Windows.Forms.Padding(8);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(74, 30);
            this.toolStripMenuItem2.Text = "Apply";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ProjectSettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.startingLevel);
            this.Controls.Add(this.windowState);
            this.Controls.Add(this.fixedUpdateFrequency);
            this.Controls.Add(this.windowTitle);
            this.Controls.Add(this.resolutionY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.resolutionX);
            this.Controls.Add(this.allowAltEnter);
            this.Controls.Add(this.drawColliders);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.isWindowResizeable);
            this.Controls.Add(this.vSyncEnabled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectSettingsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renderite2D Game Engine - Project Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.resolutionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedUpdateFrequency)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox vSyncEnabled;
        private System.Windows.Forms.CheckBox isWindowResizeable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox drawColliders;
        private System.Windows.Forms.CheckBox allowAltEnter;
        private System.Windows.Forms.NumericUpDown resolutionX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown resolutionY;
        private System.Windows.Forms.TextBox windowTitle;
        private System.Windows.Forms.NumericUpDown fixedUpdateFrequency;
        private System.Windows.Forms.ComboBox windowState;
        private System.Windows.Forms.ComboBox startingLevel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}