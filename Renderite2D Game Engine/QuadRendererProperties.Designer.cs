namespace Renderite2D_Game_Engine
{
    partial class QuadRendererProperties
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
            this.colorpicker_button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.posBY_num = new System.Windows.Forms.NumericUpDown();
            this.posBX_num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.posAY_num = new System.Windows.Forms.NumericUpDown();
            this.posAX_num = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.posDY_num = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.posDX_num = new System.Windows.Forms.NumericUpDown();
            this.posCX_num = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.posCY_num = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.texture_combobox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posBY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posBX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posAY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posAX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posCX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posCY_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.texture_combobox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.posDY_num);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.posDX_num);
            this.panel1.Controls.Add(this.posCX_num);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.posCY_num);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.isStatic_checkBox);
            this.panel1.Controls.Add(this.colorpicker_button);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.posBY_num);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.posBX_num);
            this.panel1.Controls.Add(this.posAX_num);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.posAY_num);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Size = new System.Drawing.Size(234, 221);
            // 
            // componentName_label
            // 
            this.componentName_label.Text = "Quad Renderer";
            // 
            // isStatic_checkBox
            // 
            this.isStatic_checkBox.AutoSize = true;
            this.isStatic_checkBox.Location = new System.Drawing.Point(3, 3);
            this.isStatic_checkBox.Name = "isStatic_checkBox";
            this.isStatic_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isStatic_checkBox.Size = new System.Drawing.Size(103, 23);
            this.isStatic_checkBox.TabIndex = 52;
            this.isStatic_checkBox.Text = "      ?isStatic";
            this.isStatic_checkBox.UseVisualStyleBackColor = true;
            this.isStatic_checkBox.CheckedChanged += new System.EventHandler(this.isStatic_checkBox_CheckedChanged);
            // 
            // colorpicker_button
            // 
            this.colorpicker_button.BackColor = System.Drawing.Color.White;
            this.colorpicker_button.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.colorpicker_button.FlatAppearance.BorderSize = 3;
            this.colorpicker_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorpicker_button.Location = new System.Drawing.Point(91, 145);
            this.colorpicker_button.Name = "colorpicker_button";
            this.colorpicker_button.Size = new System.Drawing.Size(74, 25);
            this.colorpicker_button.TabIndex = 51;
            this.colorpicker_button.UseVisualStyleBackColor = false;
            this.colorpicker_button.Click += new System.EventHandler(this.colorpicker_button_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(4, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 50;
            this.label11.Text = "color :";
            // 
            // posBY_num
            // 
            this.posBY_num.AllowDrop = true;
            this.posBY_num.DecimalPlaces = 2;
            this.posBY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posBY_num.Location = new System.Drawing.Point(178, 58);
            this.posBY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posBY_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posBY_num.Name = "posBY_num";
            this.posBY_num.Size = new System.Drawing.Size(51, 23);
            this.posBY_num.TabIndex = 49;
            this.posBY_num.ThousandsSeparator = true;
            this.posBY_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.posBY_num.ValueChanged += new System.EventHandler(this.posBY_num_ValueChanged);
            // 
            // posBX_num
            // 
            this.posBX_num.AllowDrop = true;
            this.posBX_num.DecimalPlaces = 2;
            this.posBX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posBX_num.Location = new System.Drawing.Point(91, 58);
            this.posBX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posBX_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posBX_num.Name = "posBX_num";
            this.posBX_num.Size = new System.Drawing.Size(51, 23);
            this.posBX_num.TabIndex = 45;
            this.posBX_num.ThousandsSeparator = true;
            this.posBX_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.posBX_num.ValueChanged += new System.EventHandler(this.posBX_num_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Y :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "X :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 23);
            this.label4.TabIndex = 46;
            this.label4.Text = "pointB :";
            // 
            // posAY_num
            // 
            this.posAY_num.AllowDrop = true;
            this.posAY_num.DecimalPlaces = 2;
            this.posAY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posAY_num.Location = new System.Drawing.Point(178, 29);
            this.posAY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posAY_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posAY_num.Name = "posAY_num";
            this.posAY_num.Size = new System.Drawing.Size(51, 23);
            this.posAY_num.TabIndex = 44;
            this.posAY_num.ThousandsSeparator = true;
            this.posAY_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.posAY_num.ValueChanged += new System.EventHandler(this.posAY_num_ValueChanged);
            // 
            // posAX_num
            // 
            this.posAX_num.AllowDrop = true;
            this.posAX_num.DecimalPlaces = 2;
            this.posAX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posAX_num.Location = new System.Drawing.Point(91, 29);
            this.posAX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posAX_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posAX_num.Name = "posAX_num";
            this.posAX_num.Size = new System.Drawing.Size(51, 23);
            this.posAX_num.TabIndex = 40;
            this.posAX_num.ThousandsSeparator = true;
            this.posAX_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.posAX_num.ValueChanged += new System.EventHandler(this.posAX_num_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 23);
            this.label8.TabIndex = 43;
            this.label8.Text = "Y :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 23);
            this.label5.TabIndex = 42;
            this.label5.Text = "X :";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 23);
            this.label9.TabIndex = 41;
            this.label9.Text = "pointA :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 23);
            this.label6.TabIndex = 55;
            this.label6.Text = "X :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 23);
            this.label7.TabIndex = 54;
            this.label7.Text = "pointC :";
            // 
            // posDY_num
            // 
            this.posDY_num.AllowDrop = true;
            this.posDY_num.DecimalPlaces = 2;
            this.posDY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posDY_num.Location = new System.Drawing.Point(178, 116);
            this.posDY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posDY_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posDY_num.Name = "posDY_num";
            this.posDY_num.Size = new System.Drawing.Size(51, 23);
            this.posDY_num.TabIndex = 62;
            this.posDY_num.ThousandsSeparator = true;
            this.posDY_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.posDY_num.ValueChanged += new System.EventHandler(this.posDY_num_ValueChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(152, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 23);
            this.label10.TabIndex = 56;
            this.label10.Text = "Y :";
            // 
            // posDX_num
            // 
            this.posDX_num.AllowDrop = true;
            this.posDX_num.DecimalPlaces = 2;
            this.posDX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posDX_num.Location = new System.Drawing.Point(91, 116);
            this.posDX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posDX_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posDX_num.Name = "posDX_num";
            this.posDX_num.Size = new System.Drawing.Size(51, 23);
            this.posDX_num.TabIndex = 58;
            this.posDX_num.ThousandsSeparator = true;
            this.posDX_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.posDX_num.ValueChanged += new System.EventHandler(this.posDX_num_ValueChanged);
            // 
            // posCX_num
            // 
            this.posCX_num.AllowDrop = true;
            this.posCX_num.DecimalPlaces = 2;
            this.posCX_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posCX_num.Location = new System.Drawing.Point(91, 87);
            this.posCX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posCX_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posCX_num.Name = "posCX_num";
            this.posCX_num.Size = new System.Drawing.Size(51, 23);
            this.posCX_num.TabIndex = 53;
            this.posCX_num.ThousandsSeparator = true;
            this.posCX_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.posCX_num.ValueChanged += new System.EventHandler(this.posCX_num_ValueChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(152, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 23);
            this.label12.TabIndex = 61;
            this.label12.Text = "Y :";
            // 
            // posCY_num
            // 
            this.posCY_num.AllowDrop = true;
            this.posCY_num.DecimalPlaces = 2;
            this.posCY_num.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posCY_num.Location = new System.Drawing.Point(178, 87);
            this.posCY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.posCY_num.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.posCY_num.Name = "posCY_num";
            this.posCY_num.Size = new System.Drawing.Size(51, 23);
            this.posCY_num.TabIndex = 57;
            this.posCY_num.ThousandsSeparator = true;
            this.posCY_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.posCY_num.ValueChanged += new System.EventHandler(this.posCY_num_ValueChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(65, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 23);
            this.label13.TabIndex = 60;
            this.label13.Text = "X :";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 23);
            this.label14.TabIndex = 59;
            this.label14.Text = "pointD :";
            // 
            // texture_combobox
            // 
            this.texture_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.texture_combobox.FormattingEnabled = true;
            this.texture_combobox.Location = new System.Drawing.Point(91, 176);
            this.texture_combobox.Name = "texture_combobox";
            this.texture_combobox.Size = new System.Drawing.Size(138, 27);
            this.texture_combobox.TabIndex = 64;
            this.texture_combobox.SelectedIndexChanged += new System.EventHandler(this.texture_combobox_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 180);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 63;
            this.label15.Text = "texture :";
            // 
            // QuadRendererProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Name = "QuadRendererProperties";
            this.Size = new System.Drawing.Size(238, 280);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posBY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posBX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posAY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posAX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posCX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posCY_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isStatic_checkBox;
        private System.Windows.Forms.Button colorpicker_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown posBY_num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown posBX_num;
        private System.Windows.Forms.NumericUpDown posAX_num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown posAY_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown posDY_num;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown posDX_num;
        private System.Windows.Forms.NumericUpDown posCX_num;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown posCY_num;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox texture_combobox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
