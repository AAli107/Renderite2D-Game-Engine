﻿namespace Renderite2D_Game_Engine
{
    partial class ProgressWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressWindow));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.MarqueeAnimationSpeed = 16;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(280, 26);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 50;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(12, 46);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ProgressWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(304, 81);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 120);
            this.Name = "ProgressWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Wait...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgressWindow_FormClosed);
            this.Shown += new System.EventHandler(this.ProgressWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancel_btn;
    }
}