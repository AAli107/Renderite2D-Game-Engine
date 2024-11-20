namespace Renderite2D_Game_Engine
{
    partial class ColliderComponentProperties
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.isSolidCollision_checkBox = new System.Windows.Forms.CheckBox();
            this.friction_num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friction_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.friction_num);
            this.panel1.Controls.Add(this.isSolidCollision_checkBox);
            this.panel1.Size = new System.Drawing.Size(234, 171);
            // 
            // componentName_label
            // 
            this.componentName_label.Text = "ColliderComponent";
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
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 77);
            this.panel4.TabIndex = 4;
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
            1,
            0,
            0,
            0});
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
            1,
            0,
            0,
            0});
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
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Position :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "transform";
            // 
            // isSolidCollision_checkBox
            // 
            this.isSolidCollision_checkBox.AutoSize = true;
            this.isSolidCollision_checkBox.Checked = true;
            this.isSolidCollision_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isSolidCollision_checkBox.Location = new System.Drawing.Point(10, 95);
            this.isSolidCollision_checkBox.Name = "isSolidCollision_checkBox";
            this.isSolidCollision_checkBox.Size = new System.Drawing.Size(130, 23);
            this.isSolidCollision_checkBox.TabIndex = 0;
            this.isSolidCollision_checkBox.Text = "isSolidCollision";
            this.isSolidCollision_checkBox.UseVisualStyleBackColor = true;
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
            this.friction_num.Location = new System.Drawing.Point(77, 131);
            this.friction_num.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.friction_num.Name = "friction_num";
            this.friction_num.Size = new System.Drawing.Size(63, 27);
            this.friction_num.TabIndex = 18;
            this.friction_num.ThousandsSeparator = true;
            this.friction_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "friction :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ColliderComponentProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Controls.Add(this.panel4);
            this.Name = "ColliderComponentProperties";
            this.Size = new System.Drawing.Size(238, 230);
            this.Controls.SetChildIndex(this.componentName_label, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scaleY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friction_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isSolidCollision_checkBox;
        private System.Windows.Forms.NumericUpDown friction_num;
        private System.Windows.Forms.Label label1;
    }
}
