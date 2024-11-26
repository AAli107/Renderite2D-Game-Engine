namespace Renderite2D_Game_Engine
{
    partial class CreateDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDialog));
            this.title_label = new System.Windows.Forms.Label();
            this.nameInput_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.create_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title_label.Font = new System.Drawing.Font("Corbel", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(12, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(280, 52);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "Create";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameInput_textbox
            // 
            this.nameInput_textbox.Location = new System.Drawing.Point(36, 94);
            this.nameInput_textbox.Name = "nameInput_textbox";
            this.nameInput_textbox.Size = new System.Drawing.Size(236, 27);
            this.nameInput_textbox.TabIndex = 1;
            this.nameInput_textbox.Text = "file_name";
            this.nameInput_textbox.TextChanged += new System.EventHandler(this.nameInput_textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name :";
            // 
            // create_btn
            // 
            this.create_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.create_btn.Location = new System.Drawing.Point(36, 150);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(102, 39);
            this.create_btn.TabIndex = 3;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = false;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.cancel_btn.Location = new System.Drawing.Point(170, 150);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(102, 39);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // CreateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(304, 201);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameInput_textbox);
            this.Controls.Add(this.title_label);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateDialog";
            this.Text = "Renderite2D Game Engine - Create";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.TextBox nameInput_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}