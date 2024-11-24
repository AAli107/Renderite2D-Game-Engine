namespace Renderite2D_Game_Engine
{
    partial class Component_Properties
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.componentName_label = new System.Windows.Forms.Label();
            this.IsEnabled_checkbox = new System.Windows.Forms.CheckBox();
            this.deleteComponent_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // componentName_label
            // 
            this.componentName_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.componentName_label.Location = new System.Drawing.Point(3, 5);
            this.componentName_label.Name = "componentName_label";
            this.componentName_label.Size = new System.Drawing.Size(233, 24);
            this.componentName_label.TabIndex = 0;
            this.componentName_label.Text = "Component Name";
            this.componentName_label.UseCompatibleTextRendering = true;
            // 
            // IsEnabled_checkbox
            // 
            this.IsEnabled_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsEnabled_checkbox.AutoSize = true;
            this.IsEnabled_checkbox.Checked = true;
            this.IsEnabled_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsEnabled_checkbox.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsEnabled_checkbox.Location = new System.Drawing.Point(166, 32);
            this.IsEnabled_checkbox.Name = "IsEnabled_checkbox";
            this.IsEnabled_checkbox.Size = new System.Drawing.Size(70, 17);
            this.IsEnabled_checkbox.TabIndex = 1;
            this.IsEnabled_checkbox.Text = "IsEnabled";
            this.IsEnabled_checkbox.UseVisualStyleBackColor = true;
            this.IsEnabled_checkbox.CheckedChanged += new System.EventHandler(this.IsEnabled_checkbox_CheckedChanged);
            // 
            // deleteComponent_button
            // 
            this.deleteComponent_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteComponent_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deleteComponent_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteComponent_button.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteComponent_button.Location = new System.Drawing.Point(113, 28);
            this.deleteComponent_button.Name = "deleteComponent_button";
            this.deleteComponent_button.Size = new System.Drawing.Size(47, 21);
            this.deleteComponent_button.TabIndex = 2;
            this.deleteComponent_button.Text = "Delete";
            this.deleteComponent_button.UseVisualStyleBackColor = false;
            this.deleteComponent_button.Click += new System.EventHandler(this.deleteComponent_button_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 23);
            this.panel1.TabIndex = 3;
            // 
            // Component_Properties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.deleteComponent_button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.IsEnabled_checkbox);
            this.Controls.Add(this.componentName_label);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Component_Properties";
            this.Size = new System.Drawing.Size(240, 84);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox IsEnabled_checkbox;
        private System.Windows.Forms.Button deleteComponent_button;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label componentName_label;
    }
}
