namespace Renderite2D_Game_Engine
{
    partial class TextRendererProperties
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
            this.isStatic_checkBox = new System.Windows.Forms.CheckBox();
            this.scale_num = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.colorpicker_button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.posY_num = new System.Windows.Forms.NumericUpDown();
            this.posX_num = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.isStatic_checkBox);
            this.panel1.Controls.Add(this.scale_num);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.colorpicker_button);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.posX_num);
            this.panel1.Controls.Add(this.posY_num);
            this.panel1.Size = new System.Drawing.Size(234, 161);
            // 
            // componentName_label
            // 
            this.componentName_label.Text = "Text Renderer";
            // 
            // isStatic_checkBox
            // 
            this.isStatic_checkBox.AutoSize = true;
            this.isStatic_checkBox.Checked = true;
            this.isStatic_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isStatic_checkBox.Location = new System.Drawing.Point(3, 3);
            this.isStatic_checkBox.Name = "isStatic_checkBox";
            this.isStatic_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isStatic_checkBox.Size = new System.Drawing.Size(103, 23);
            this.isStatic_checkBox.TabIndex = 59;
            this.isStatic_checkBox.Text = "      ?isStatic";
            this.isStatic_checkBox.UseVisualStyleBackColor = true;
            this.isStatic_checkBox.CheckedChanged += new System.EventHandler(this.isStatic_checkBox_CheckedChanged);
            // 
            // scale_num
            // 
            this.scale_num.AllowDrop = true;
            this.scale_num.DecimalPlaces = 2;
            this.scale_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scale_num.Location = new System.Drawing.Point(91, 118);
            this.scale_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.scale_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.scale_num.Name = "scale_num";
            this.scale_num.Size = new System.Drawing.Size(51, 23);
            this.scale_num.TabIndex = 57;
            this.scale_num.ThousandsSeparator = true;
            this.scale_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scale_num.ValueChanged += new System.EventHandler(this.scale_num_ValueChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 23);
            this.label6.TabIndex = 58;
            this.label6.Text = "scale :";
            // 
            // colorpicker_button
            // 
            this.colorpicker_button.BackColor = System.Drawing.Color.White;
            this.colorpicker_button.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.colorpicker_button.FlatAppearance.BorderSize = 3;
            this.colorpicker_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorpicker_button.Location = new System.Drawing.Point(91, 87);
            this.colorpicker_button.Name = "colorpicker_button";
            this.colorpicker_button.Size = new System.Drawing.Size(74, 25);
            this.colorpicker_button.TabIndex = 56;
            this.colorpicker_button.UseVisualStyleBackColor = false;
            this.colorpicker_button.Click += new System.EventHandler(this.colorpicker_button_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(4, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 55;
            this.label11.Text = "color :";
            // 
            // posY_num
            // 
            this.posY_num.AllowDrop = true;
            this.posY_num.DecimalPlaces = 2;
            this.posY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posY_num.Location = new System.Drawing.Point(178, 29);
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
            this.posY_num.TabIndex = 54;
            this.posY_num.ThousandsSeparator = true;
            this.posY_num.ValueChanged += new System.EventHandler(this.posY_num_ValueChanged);
            // 
            // posX_num
            // 
            this.posX_num.AllowDrop = true;
            this.posX_num.DecimalPlaces = 2;
            this.posX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posX_num.Location = new System.Drawing.Point(91, 29);
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
            this.posX_num.TabIndex = 50;
            this.posX_num.ThousandsSeparator = true;
            this.posX_num.ValueChanged += new System.EventHandler(this.posX_num_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 23);
            this.label8.TabIndex = 53;
            this.label8.Text = "Y :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "X :";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 23);
            this.label9.TabIndex = 51;
            this.label9.Text = "pos :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 60;
            this.label1.Text = "text :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(91, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 22);
            this.textBox1.TabIndex = 61;
            this.textBox1.Text = "Default Text";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TextRendererProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Name = "TextRendererProperties";
            this.Size = new System.Drawing.Size(238, 220);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isStatic_checkBox;
        private System.Windows.Forms.NumericUpDown scale_num;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button colorpicker_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown posX_num;
        private System.Windows.Forms.NumericUpDown posY_num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
