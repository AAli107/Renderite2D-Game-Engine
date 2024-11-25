namespace Renderite2D_Game_Engine
{
    partial class AnimatedSpriteRendererProperties
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
            this.PlayReverse_checkBox = new System.Windows.Forms.CheckBox();
            this.IsPlaying_checkBox = new System.Windows.Forms.CheckBox();
            this.EndFrameIndex_num = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.TimePerFrame_num = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndFrameIndex_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimePerFrame_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PlayReverse_checkBox);
            this.panel1.Controls.Add(this.IsPlaying_checkBox);
            this.panel1.Controls.Add(this.EndFrameIndex_num);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.TimePerFrame_num);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Size = new System.Drawing.Size(234, 443);
            this.panel1.Controls.SetChildIndex(this.label14, 0);
            this.panel1.Controls.SetChildIndex(this.TimePerFrame_num, 0);
            this.panel1.Controls.SetChildIndex(this.label13, 0);
            this.panel1.Controls.SetChildIndex(this.EndFrameIndex_num, 0);
            this.panel1.Controls.SetChildIndex(this.IsPlaying_checkBox, 0);
            this.panel1.Controls.SetChildIndex(this.PlayReverse_checkBox, 0);
            // 
            // componentName_label
            // 
            this.componentName_label.Text = "Animated Sprite Renderer";
            // 
            // PlayReverse_checkBox
            // 
            this.PlayReverse_checkBox.AutoSize = true;
            this.PlayReverse_checkBox.Location = new System.Drawing.Point(10, 395);
            this.PlayReverse_checkBox.Name = "PlayReverse_checkBox";
            this.PlayReverse_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayReverse_checkBox.Size = new System.Drawing.Size(127, 23);
            this.PlayReverse_checkBox.TabIndex = 40;
            this.PlayReverse_checkBox.Text = "   ?Play Reverse";
            this.PlayReverse_checkBox.UseVisualStyleBackColor = true;
            this.PlayReverse_checkBox.CheckedChanged += new System.EventHandler(this.PlayReverse_checkBox_CheckedChanged);
            // 
            // IsPlaying_checkBox
            // 
            this.IsPlaying_checkBox.AutoSize = true;
            this.IsPlaying_checkBox.Checked = true;
            this.IsPlaying_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsPlaying_checkBox.Location = new System.Drawing.Point(12, 366);
            this.IsPlaying_checkBox.Name = "IsPlaying_checkBox";
            this.IsPlaying_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IsPlaying_checkBox.Size = new System.Drawing.Size(125, 23);
            this.IsPlaying_checkBox.TabIndex = 39;
            this.IsPlaying_checkBox.Text = "         ?Is Playing";
            this.IsPlaying_checkBox.UseVisualStyleBackColor = true;
            this.IsPlaying_checkBox.CheckedChanged += new System.EventHandler(this.IsPlaying_checkBox_CheckedChanged);
            // 
            // EndFrameIndex_num
            // 
            this.EndFrameIndex_num.AllowDrop = true;
            this.EndFrameIndex_num.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndFrameIndex_num.Location = new System.Drawing.Point(149, 336);
            this.EndFrameIndex_num.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.EndFrameIndex_num.Name = "EndFrameIndex_num";
            this.EndFrameIndex_num.Size = new System.Drawing.Size(74, 27);
            this.EndFrameIndex_num.TabIndex = 38;
            this.EndFrameIndex_num.ThousandsSeparator = true;
            this.EndFrameIndex_num.ValueChanged += new System.EventHandler(this.EndFrameIndex_num_ValueChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(11, 338);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 25);
            this.label13.TabIndex = 37;
            this.label13.Text = "Last Frame Index :";
            // 
            // TimePerFrame_num
            // 
            this.TimePerFrame_num.AllowDrop = true;
            this.TimePerFrame_num.DecimalPlaces = 3;
            this.TimePerFrame_num.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimePerFrame_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TimePerFrame_num.Location = new System.Drawing.Point(138, 303);
            this.TimePerFrame_num.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.TimePerFrame_num.Name = "TimePerFrame_num";
            this.TimePerFrame_num.Size = new System.Drawing.Size(85, 27);
            this.TimePerFrame_num.TabIndex = 36;
            this.TimePerFrame_num.ThousandsSeparator = true;
            this.TimePerFrame_num.Value = new decimal(new int[] {
            -265639253,
            77756284,
            9035,
            1572864});
            this.TimePerFrame_num.ValueChanged += new System.EventHandler(this.TimePerFrame_num_ValueChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(11, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 25);
            this.label14.TabIndex = 35;
            this.label14.Text = "Seconds/Frame :";
            // 
            // AnimatedSpriteRendererProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Name = "AnimatedSpriteRendererProperties";
            this.Size = new System.Drawing.Size(236, 500);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndFrameIndex_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimePerFrame_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox PlayReverse_checkBox;
        private System.Windows.Forms.CheckBox IsPlaying_checkBox;
        private System.Windows.Forms.NumericUpDown EndFrameIndex_num;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown TimePerFrame_num;
        private System.Windows.Forms.Label label14;
    }
}
