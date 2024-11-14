namespace Renderite2D_Game_Engine
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exit_btn = new System.Windows.Forms.Button();
            this.openProject_btn = new System.Windows.Forms.Button();
            this.newProject_btn = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Logo);
            this.panel1.Location = new System.Drawing.Point(22, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 633);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.exit_btn);
            this.panel2.Controls.Add(this.openProject_btn);
            this.panel2.Controls.Add(this.newProject_btn);
            this.panel2.Location = new System.Drawing.Point(515, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 213);
            this.panel2.TabIndex = 2;
            // 
            // exit_btn
            // 
            this.exit_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.exit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit_btn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.exit_btn.FlatAppearance.BorderSize = 2;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.ForeColor = System.Drawing.Color.White;
            this.exit_btn.Location = new System.Drawing.Point(7, 139);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(172, 55);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // openProject_btn
            // 
            this.openProject_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.openProject_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openProject_btn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.openProject_btn.FlatAppearance.BorderSize = 2;
            this.openProject_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openProject_btn.ForeColor = System.Drawing.Color.White;
            this.openProject_btn.Location = new System.Drawing.Point(7, 78);
            this.openProject_btn.Name = "openProject_btn";
            this.openProject_btn.Size = new System.Drawing.Size(172, 55);
            this.openProject_btn.TabIndex = 2;
            this.openProject_btn.Text = "Open Project";
            this.openProject_btn.UseVisualStyleBackColor = false;
            // 
            // newProject_btn
            // 
            this.newProject_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.newProject_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newProject_btn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.newProject_btn.FlatAppearance.BorderSize = 2;
            this.newProject_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newProject_btn.ForeColor = System.Drawing.Color.White;
            this.newProject_btn.Location = new System.Drawing.Point(7, 17);
            this.newProject_btn.Name = "newProject_btn";
            this.newProject_btn.Size = new System.Drawing.Size(172, 55);
            this.newProject_btn.TabIndex = 1;
            this.newProject_btn.Text = "New Project";
            this.newProject_btn.UseVisualStyleBackColor = false;
            this.newProject_btn.Click += new System.EventHandler(this.newProject_btn_Click);
            // 
            // Logo
            // 
            this.Logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Logo.Image = global::Renderite2D_Game_Engine.Properties.Resources.Renderite2D_title;
            this.Logo.InitialImage = null;
            this.Logo.Location = new System.Drawing.Point(237, 24);
            this.Logo.Margin = new System.Windows.Forms.Padding(6);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(737, 180);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "Home";
            this.Text = "Renderite2D Game Engine - Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button newProject_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button openProject_btn;
    }
}

