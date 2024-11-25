namespace Renderite2D_Game_Engine
{
    partial class RendererComponent_Properties
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
            this.layer_num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.layer_num)).BeginInit();
            this.SuspendLayout();
            // 
            // layer_num
            // 
            this.layer_num.AllowDrop = true;
            this.layer_num.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layer_num.Location = new System.Drawing.Point(40, 28);
            this.layer_num.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.layer_num.Name = "layer_num";
            this.layer_num.Size = new System.Drawing.Size(43, 22);
            this.layer_num.TabIndex = 22;
            this.layer_num.ThousandsSeparator = true;
            this.layer_num.ValueChanged += new System.EventHandler(this.mass_num_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "layer :";
            // 
            // RendererComponent_Properties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.Controls.Add(this.layer_num);
            this.Controls.Add(this.label3);
            this.Name = "RendererComponent_Properties";
            this.Controls.SetChildIndex(this.componentName_label, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.layer_num, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layer_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown layer_num;
        private System.Windows.Forms.Label label3;
    }
}
