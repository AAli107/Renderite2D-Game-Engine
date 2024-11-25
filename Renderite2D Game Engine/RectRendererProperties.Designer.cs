namespace Renderite2D_Game_Engine
{
    partial class RectRendererProperties
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.texture_combobox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.colorpicker_button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.scaleY_num = new System.Windows.Forms.NumericUpDown();
            this.scaleX_num = new System.Windows.Forms.NumericUpDown();
            this.posY_num = new System.Windows.Forms.NumericUpDown();
            this.posX_num = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.isCentered_checkBox = new System.Windows.Forms.CheckBox();
            this.isStatic_checkBox = new System.Windows.Forms.CheckBox();
            this.isOutline_checkBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.isOutline_checkBox);
            this.panel1.Controls.Add(this.texture_combobox);
            this.panel1.Controls.Add(this.isStatic_checkBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.isCentered_checkBox);
            this.panel1.Controls.Add(this.colorpicker_button);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Size = new System.Drawing.Size(234, 257);
            // 
            // componentName_label
            // 
            this.componentName_label.Text = "Rect Renderer";
            // 
            // texture_combobox
            // 
            this.texture_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.texture_combobox.FormattingEnabled = true;
            this.texture_combobox.Location = new System.Drawing.Point(104, 204);
            this.texture_combobox.Name = "texture_combobox";
            this.texture_combobox.Size = new System.Drawing.Size(129, 27);
            this.texture_combobox.TabIndex = 37;
            this.texture_combobox.SelectedIndexChanged += new System.EventHandler(this.texture_combobox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 35;
            this.label12.Text = "texture :";
            // 
            // colorpicker_button
            // 
            this.colorpicker_button.BackColor = System.Drawing.Color.White;
            this.colorpicker_button.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.colorpicker_button.FlatAppearance.BorderSize = 3;
            this.colorpicker_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorpicker_button.Location = new System.Drawing.Point(104, 173);
            this.colorpicker_button.Name = "colorpicker_button";
            this.colorpicker_button.Size = new System.Drawing.Size(74, 25);
            this.colorpicker_button.TabIndex = 41;
            this.colorpicker_button.UseVisualStyleBackColor = false;
            this.colorpicker_button.Click += new System.EventHandler(this.colorpicker_button_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(4, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 40;
            this.label11.Text = "color :";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.scaleY_num);
            this.panel4.Controls.Add(this.scaleX_num);
            this.panel4.Controls.Add(this.posY_num);
            this.panel4.Controls.Add(this.posX_num);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(3, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 77);
            this.panel4.TabIndex = 36;
            // 
            // scaleY_num
            // 
            this.scaleY_num.AllowDrop = true;
            this.scaleY_num.DecimalPlaces = 2;
            this.scaleY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleY_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleY_num.Location = new System.Drawing.Point(175, 45);
            this.scaleY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.scaleY_num.Name = "scaleY_num";
            this.scaleY_num.Size = new System.Drawing.Size(51, 23);
            this.scaleY_num.TabIndex = 17;
            this.scaleY_num.ThousandsSeparator = true;
            this.scaleY_num.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scaleY_num.ValueChanged += new System.EventHandler(this.scaleY_num_ValueChanged);
            // 
            // scaleX_num
            // 
            this.scaleX_num.AllowDrop = true;
            this.scaleX_num.DecimalPlaces = 2;
            this.scaleX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleX_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleX_num.Location = new System.Drawing.Point(88, 45);
            this.scaleX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.scaleX_num.Name = "scaleX_num";
            this.scaleX_num.Size = new System.Drawing.Size(51, 23);
            this.scaleX_num.TabIndex = 16;
            this.scaleX_num.ThousandsSeparator = true;
            this.scaleX_num.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scaleX_num.ValueChanged += new System.EventHandler(this.scaleX_num_ValueChanged);
            // 
            // posY_num
            // 
            this.posY_num.AllowDrop = true;
            this.posY_num.DecimalPlaces = 2;
            this.posY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posY_num.Location = new System.Drawing.Point(175, 19);
            this.posY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posY_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posY_num.Name = "posY_num";
            this.posY_num.Size = new System.Drawing.Size(51, 23);
            this.posY_num.TabIndex = 15;
            this.posY_num.ThousandsSeparator = true;
            this.posY_num.ValueChanged += new System.EventHandler(this.posY_num_ValueChanged);
            // 
            // posX_num
            // 
            this.posX_num.AllowDrop = true;
            this.posX_num.DecimalPlaces = 2;
            this.posX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posX_num.Location = new System.Drawing.Point(88, 19);
            this.posX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posX_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posX_num.Name = "posX_num";
            this.posX_num.Size = new System.Drawing.Size(51, 23);
            this.posX_num.TabIndex = 1;
            this.posX_num.ThousandsSeparator = true;
            this.posX_num.ValueChanged += new System.EventHandler(this.posX_num_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(149, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Y :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(149, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Y :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "X :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "X :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scale :";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "Position :";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "transform";
            // 
            // isCentered_checkBox
            // 
            this.isCentered_checkBox.AutoSize = true;
            this.isCentered_checkBox.Checked = true;
            this.isCentered_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isCentered_checkBox.Location = new System.Drawing.Point(3, 32);
            this.isCentered_checkBox.Name = "isCentered_checkBox";
            this.isCentered_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isCentered_checkBox.Size = new System.Drawing.Size(115, 23);
            this.isCentered_checkBox.TabIndex = 39;
            this.isCentered_checkBox.Text = "   ?isCentered";
            this.isCentered_checkBox.UseVisualStyleBackColor = true;
            this.isCentered_checkBox.CheckedChanged += new System.EventHandler(this.isCentered_checkBox_CheckedChanged);
            // 
            // isStatic_checkBox
            // 
            this.isStatic_checkBox.AutoSize = true;
            this.isStatic_checkBox.Location = new System.Drawing.Point(3, 3);
            this.isStatic_checkBox.Name = "isStatic_checkBox";
            this.isStatic_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isStatic_checkBox.Size = new System.Drawing.Size(115, 23);
            this.isStatic_checkBox.TabIndex = 38;
            this.isStatic_checkBox.Text = "          ?isStatic";
            this.isStatic_checkBox.UseVisualStyleBackColor = true;
            this.isStatic_checkBox.CheckedChanged += new System.EventHandler(this.isStatic_checkBox_CheckedChanged);
            // 
            // isOutline_checkBox
            // 
            this.isOutline_checkBox.AutoSize = true;
            this.isOutline_checkBox.Location = new System.Drawing.Point(3, 61);
            this.isOutline_checkBox.Name = "isOutline_checkBox";
            this.isOutline_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isOutline_checkBox.Size = new System.Drawing.Size(116, 23);
            this.isOutline_checkBox.TabIndex = 42;
            this.isOutline_checkBox.Text = "       ?isOutline";
            this.isOutline_checkBox.UseVisualStyleBackColor = true;
            this.isOutline_checkBox.CheckedChanged += new System.EventHandler(this.isOutline_checkBox_CheckedChanged);
            // 
            // RectRendererProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Name = "RectRendererProperties";
            this.Size = new System.Drawing.Size(238, 316);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scaleY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox isOutline_checkBox;
        private System.Windows.Forms.ComboBox texture_combobox;
        private System.Windows.Forms.CheckBox isStatic_checkBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox isCentered_checkBox;
        private System.Windows.Forms.Button colorpicker_button;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown scaleY_num;
        private System.Windows.Forms.NumericUpDown scaleX_num;
        private System.Windows.Forms.NumericUpDown posY_num;
        private System.Windows.Forms.NumericUpDown posX_num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
