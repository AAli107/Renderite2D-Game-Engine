namespace Renderite2D_Game_Engine
{
    partial class Create_New_Project
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.browse_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.projectName_txt = new System.Windows.Forms.TextBox();
            this.folderPath_txt = new System.Windows.Forms.TextBox();
            this.create_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 657);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.browse_btn);
            this.panel2.Controls.Add(this.cancel_btn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.projectName_txt);
            this.panel2.Controls.Add(this.folderPath_txt);
            this.panel2.Controls.Add(this.create_btn);
            this.panel2.Location = new System.Drawing.Point(357, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 206);
            this.panel2.TabIndex = 1;
            // 
            // browse_btn
            // 
            this.browse_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browse_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.browse_btn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.browse_btn.FlatAppearance.BorderSize = 2;
            this.browse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_btn.ForeColor = System.Drawing.Color.White;
            this.browse_btn.Location = new System.Drawing.Point(345, 116);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(147, 36);
            this.browse_btn.TabIndex = 9;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = false;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel_btn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.cancel_btn.FlatAppearance.BorderSize = 2;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.ForeColor = System.Drawing.Color.White;
            this.cancel_btn.Location = new System.Drawing.Point(266, 158);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(226, 36);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Project Name :";
            // 
            // projectName_txt
            // 
            this.projectName_txt.AllowDrop = true;
            this.projectName_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectName_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.projectName_txt.ForeColor = System.Drawing.Color.White;
            this.projectName_txt.Location = new System.Drawing.Point(148, 25);
            this.projectName_txt.Name = "projectName_txt";
            this.projectName_txt.Size = new System.Drawing.Size(344, 33);
            this.projectName_txt.TabIndex = 5;
            this.projectName_txt.TextChanged += new System.EventHandler(this.projectName_txt_TextChanged);
            // 
            // folderPath_txt
            // 
            this.folderPath_txt.AllowDrop = true;
            this.folderPath_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderPath_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.folderPath_txt.ForeColor = System.Drawing.Color.White;
            this.folderPath_txt.Location = new System.Drawing.Point(8, 119);
            this.folderPath_txt.Name = "folderPath_txt";
            this.folderPath_txt.Size = new System.Drawing.Size(331, 33);
            this.folderPath_txt.TabIndex = 6;
            this.folderPath_txt.Text = "C:\\Users\\User123\\Documents\\Renderite2DProjects\\ProjectName";
            this.folderPath_txt.TextChanged += new System.EventHandler(this.folderPath_txt_TextChanged);
            // 
            // create_btn
            // 
            this.create_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.create_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.create_btn.Enabled = false;
            this.create_btn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.create_btn.FlatAppearance.BorderSize = 2;
            this.create_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create_btn.ForeColor = System.Drawing.Color.White;
            this.create_btn.Location = new System.Drawing.Point(8, 158);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(217, 36);
            this.create_btn.TabIndex = 4;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = false;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(421, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Project";
            // 
            // Create_New_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Create_New_Project";
            this.Text = "Renderite2D Game Engine - Create New Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Create_New_Project_FormClosed);
            this.Load += new System.EventHandler(this.Create_New_Project_Load);
            this.Shown += new System.EventHandler(this.Create_New_Project_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox folderPath_txt;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projectName_txt;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button browse_btn;
    }
}
