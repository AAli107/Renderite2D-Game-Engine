namespace Renderite2D_Game_Engine
{
    partial class PhysicsComponentProperties
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.isAirborne_checkBox = new System.Windows.Forms.CheckBox();
            this.gravityEnabled_checkBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.friction_num = new System.Windows.Forms.NumericUpDown();
            this.mass_num = new System.Windows.Forms.NumericUpDown();
            this.gravityMultiplier_num = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friction_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mass_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravityMultiplier_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gravityMultiplier_num);
            this.panel1.Controls.Add(this.mass_num);
            this.panel1.Controls.Add(this.friction_num);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gravityEnabled_checkBox);
            this.panel1.Controls.Add(this.isAirborne_checkBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Size = new System.Drawing.Size(234, 196);
            // 
            // componentName_label
            // 
            this.componentName_label.Text = "Physics Component";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "mass :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "friction :";
            // 
            // isAirborne_checkBox
            // 
            this.isAirborne_checkBox.AutoSize = true;
            this.isAirborne_checkBox.Checked = true;
            this.isAirborne_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAirborne_checkBox.Location = new System.Drawing.Point(12, 83);
            this.isAirborne_checkBox.Name = "isAirborne_checkBox";
            this.isAirborne_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isAirborne_checkBox.Size = new System.Drawing.Size(151, 23);
            this.isAirborne_checkBox.TabIndex = 8;
            this.isAirborne_checkBox.Text = "                ?isAirborne";
            this.isAirborne_checkBox.UseVisualStyleBackColor = true;
            this.isAirborne_checkBox.CheckedChanged += new System.EventHandler(this.isAirborne_checkBox_CheckedChanged);
            // 
            // gravityEnabled_checkBox
            // 
            this.gravityEnabled_checkBox.AutoSize = true;
            this.gravityEnabled_checkBox.Checked = true;
            this.gravityEnabled_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gravityEnabled_checkBox.Location = new System.Drawing.Point(12, 122);
            this.gravityEnabled_checkBox.Name = "gravityEnabled_checkBox";
            this.gravityEnabled_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gravityEnabled_checkBox.Size = new System.Drawing.Size(149, 23);
            this.gravityEnabled_checkBox.TabIndex = 9;
            this.gravityEnabled_checkBox.Text = "    ?gravityEnabled";
            this.gravityEnabled_checkBox.UseVisualStyleBackColor = true;
            this.gravityEnabled_checkBox.CheckedChanged += new System.EventHandler(this.gravityEnabled_checkBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(14, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "gravityMultiplier :";
            // 
            // friction_num
            // 
            this.friction_num.AllowDrop = true;
            this.friction_num.DecimalPlaces = 2;
            this.friction_num.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friction_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.friction_num.Location = new System.Drawing.Point(149, 46);
            this.friction_num.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.friction_num.Name = "friction_num";
            this.friction_num.Size = new System.Drawing.Size(66, 27);
            this.friction_num.TabIndex = 19;
            this.friction_num.ThousandsSeparator = true;
            this.friction_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.friction_num.ValueChanged += new System.EventHandler(this.friction_num_ValueChanged);
            // 
            // mass_num
            // 
            this.mass_num.AllowDrop = true;
            this.mass_num.DecimalPlaces = 2;
            this.mass_num.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mass_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.mass_num.Location = new System.Drawing.Point(149, 9);
            this.mass_num.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.mass_num.Name = "mass_num";
            this.mass_num.Size = new System.Drawing.Size(66, 27);
            this.mass_num.TabIndex = 20;
            this.mass_num.ThousandsSeparator = true;
            this.mass_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mass_num.ValueChanged += new System.EventHandler(this.mass_num_ValueChanged);
            // 
            // gravityMultiplier_num
            // 
            this.gravityMultiplier_num.AllowDrop = true;
            this.gravityMultiplier_num.DecimalPlaces = 2;
            this.gravityMultiplier_num.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gravityMultiplier_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gravityMultiplier_num.Location = new System.Drawing.Point(149, 158);
            this.gravityMultiplier_num.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.gravityMultiplier_num.Name = "gravityMultiplier_num";
            this.gravityMultiplier_num.Size = new System.Drawing.Size(66, 27);
            this.gravityMultiplier_num.TabIndex = 21;
            this.gravityMultiplier_num.ThousandsSeparator = true;
            this.gravityMultiplier_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gravityMultiplier_num.ValueChanged += new System.EventHandler(this.gravityMultiplier_num_ValueChanged);
            // 
            // PhysicsComponentProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Name = "PhysicsComponentProperties";
            this.Size = new System.Drawing.Size(238, 255);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friction_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mass_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravityMultiplier_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox isAirborne_checkBox;
        private System.Windows.Forms.CheckBox gravityEnabled_checkBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown friction_num;
        private System.Windows.Forms.NumericUpDown mass_num;
        private System.Windows.Forms.NumericUpDown gravityMultiplier_num;
    }
}
