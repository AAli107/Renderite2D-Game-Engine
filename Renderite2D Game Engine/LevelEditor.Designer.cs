namespace Renderite2D_Game_Engine
{
    partial class LevelEditor
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
            this.levelViewport_panel = new System.Windows.Forms.Panel();
            this.viewportGUI_panel = new System.Windows.Forms.Panel();
            this.viewportCoords_label = new System.Windows.Forms.Label();
            this.addObject_btn = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameObject_listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.assetDirectory_label = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.properties_panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
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
            this.gameObjectIsEnabled_checkbox = new System.Windows.Forms.CheckBox();
            this.gameObjectName_label = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGameObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAndRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.levelViewport_panel.SuspendLayout();
            this.viewportGUI_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.properties_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelViewport_panel
            // 
            this.levelViewport_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelViewport_panel.BackColor = System.Drawing.Color.Black;
            this.levelViewport_panel.Controls.Add(this.viewportGUI_panel);
            this.levelViewport_panel.Location = new System.Drawing.Point(265, 24);
            this.levelViewport_panel.Margin = new System.Windows.Forms.Padding(0);
            this.levelViewport_panel.Name = "levelViewport_panel";
            this.levelViewport_panel.Size = new System.Drawing.Size(729, 389);
            this.levelViewport_panel.TabIndex = 0;
            this.levelViewport_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.levelViewport_panel_MouseDown);
            this.levelViewport_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelViewport_panel_MouseMove);
            this.levelViewport_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.levelViewport_panel_MouseUp);
            this.levelViewport_panel.Resize += new System.EventHandler(this.levelViewport_panel_Resize);
            // 
            // viewportGUI_panel
            // 
            this.viewportGUI_panel.AutoSize = true;
            this.viewportGUI_panel.BackColor = System.Drawing.Color.Gray;
            this.viewportGUI_panel.Controls.Add(this.viewportCoords_label);
            this.viewportGUI_panel.Controls.Add(this.addObject_btn);
            this.viewportGUI_panel.ForeColor = System.Drawing.Color.Transparent;
            this.viewportGUI_panel.Location = new System.Drawing.Point(3, 6);
            this.viewportGUI_panel.Name = "viewportGUI_panel";
            this.viewportGUI_panel.Size = new System.Drawing.Size(219, 36);
            this.viewportGUI_panel.TabIndex = 1;
            // 
            // viewportCoords_label
            // 
            this.viewportCoords_label.AutoSize = true;
            this.viewportCoords_label.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewportCoords_label.Location = new System.Drawing.Point(55, 9);
            this.viewportCoords_label.Name = "viewportCoords_label";
            this.viewportCoords_label.Size = new System.Drawing.Size(90, 19);
            this.viewportCoords_label.TabIndex = 1;
            this.viewportCoords_label.Text = "XY = 124 / 23";
            // 
            // addObject_btn
            // 
            this.addObject_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.addObject_btn.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addObject_btn.Location = new System.Drawing.Point(3, 3);
            this.addObject_btn.Name = "addObject_btn";
            this.addObject_btn.Size = new System.Drawing.Size(46, 30);
            this.addObject_btn.TabIndex = 0;
            this.addObject_btn.Text = "Add";
            this.addObject_btn.UseVisualStyleBackColor = false;
            this.addObject_btn.Click += new System.EventHandler(this.addObject_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.gameObject_listBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 389);
            this.panel1.TabIndex = 1;
            // 
            // gameObject_listBox
            // 
            this.gameObject_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameObject_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.gameObject_listBox.ForeColor = System.Drawing.Color.White;
            this.gameObject_listBox.FormattingEnabled = true;
            this.gameObject_listBox.ItemHeight = 26;
            this.gameObject_listBox.Location = new System.Drawing.Point(10, 35);
            this.gameObject_listBox.Name = "gameObject_listBox";
            this.gameObject_listBox.Size = new System.Drawing.Size(244, 342);
            this.gameObject_listBox.TabIndex = 1;
            this.gameObject_listBox.SelectedIndexChanged += new System.EventHandler(this.gameObject_listBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Objects :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(0, 413);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 271);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel5.Controls.Add(this.assetDirectory_label);
            this.panel5.Controls.Add(this.button9);
            this.panel5.Controls.Add(this.button8);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1264, 52);
            this.panel5.TabIndex = 0;
            // 
            // assetDirectory_label
            // 
            this.assetDirectory_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.assetDirectory_label.AutoSize = true;
            this.assetDirectory_label.Location = new System.Drawing.Point(236, 12);
            this.assetDirectory_label.Name = "assetDirectory_label";
            this.assetDirectory_label.Size = new System.Drawing.Size(241, 26);
            this.assetDirectory_label.TabIndex = 19;
            this.assetDirectory_label.Text = "Assets / Folder / Sub Folder";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button9.FlatAppearance.BorderSize = 2;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(119, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(111, 44);
            this.button9.TabIndex = 18;
            this.button9.Text = "Create";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button8.FlatAppearance.BorderSize = 2;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(2, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(111, 44);
            this.button8.TabIndex = 17;
            this.button8.Text = "Import";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // properties_panel
            // 
            this.properties_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.properties_panel.AutoScroll = true;
            this.properties_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.properties_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.properties_panel.Controls.Add(this.panel3);
            this.properties_panel.Controls.Add(this.gameObjectIsEnabled_checkbox);
            this.properties_panel.Controls.Add(this.gameObjectName_label);
            this.properties_panel.Location = new System.Drawing.Point(994, 24);
            this.properties_panel.Margin = new System.Windows.Forms.Padding(0);
            this.properties_panel.Name = "properties_panel";
            this.properties_panel.Size = new System.Drawing.Size(270, 389);
            this.properties_panel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 354);
            this.panel3.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.Location = new System.Drawing.Point(-2, 93);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(270, 259);
            this.panel6.TabIndex = 1;
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
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 84);
            this.panel4.TabIndex = 0;
            // 
            // scaleY_num
            // 
            this.scaleY_num.AllowDrop = true;
            this.scaleY_num.DecimalPlaces = 2;
            this.scaleY_num.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleY_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleY_num.Location = new System.Drawing.Point(194, 45);
            this.scaleY_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.scaleY_num.Name = "scaleY_num";
            this.scaleY_num.Size = new System.Drawing.Size(58, 26);
            this.scaleY_num.TabIndex = 17;
            this.scaleY_num.ThousandsSeparator = true;
            this.scaleY_num.ValueChanged += new System.EventHandler(this.scaleY_num_ValueChanged);
            // 
            // scaleX_num
            // 
            this.scaleX_num.AllowDrop = true;
            this.scaleX_num.DecimalPlaces = 2;
            this.scaleX_num.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleX_num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleX_num.Location = new System.Drawing.Point(105, 45);
            this.scaleX_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.scaleX_num.Name = "scaleX_num";
            this.scaleX_num.Size = new System.Drawing.Size(57, 26);
            this.scaleX_num.TabIndex = 16;
            this.scaleX_num.ThousandsSeparator = true;
            this.scaleX_num.ValueChanged += new System.EventHandler(this.scaleX_num_ValueChanged);
            // 
            // posY_num
            // 
            this.posY_num.AllowDrop = true;
            this.posY_num.DecimalPlaces = 2;
            this.posY_num.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posY_num.Location = new System.Drawing.Point(194, 19);
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
            this.posY_num.Size = new System.Drawing.Size(58, 26);
            this.posY_num.TabIndex = 15;
            this.posY_num.ThousandsSeparator = true;
            this.posY_num.ValueChanged += new System.EventHandler(this.posY_num_ValueChanged);
            // 
            // posX_num
            // 
            this.posX_num.AllowDrop = true;
            this.posX_num.DecimalPlaces = 2;
            this.posX_num.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posX_num.Location = new System.Drawing.Point(105, 19);
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
            this.posX_num.Size = new System.Drawing.Size(57, 26);
            this.posX_num.TabIndex = 1;
            this.posX_num.ThousandsSeparator = true;
            this.posX_num.ValueChanged += new System.EventHandler(this.posX_num_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(168, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Y :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Y :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "X :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "X :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scale :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label2.Text = "Transform2D";
            // 
            // gameObjectIsEnabled_checkbox
            // 
            this.gameObjectIsEnabled_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameObjectIsEnabled_checkbox.AutoSize = true;
            this.gameObjectIsEnabled_checkbox.Checked = true;
            this.gameObjectIsEnabled_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gameObjectIsEnabled_checkbox.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameObjectIsEnabled_checkbox.Location = new System.Drawing.Point(174, 9);
            this.gameObjectIsEnabled_checkbox.Name = "gameObjectIsEnabled_checkbox";
            this.gameObjectIsEnabled_checkbox.Size = new System.Drawing.Size(93, 23);
            this.gameObjectIsEnabled_checkbox.TabIndex = 2;
            this.gameObjectIsEnabled_checkbox.Text = "IsEnabled";
            this.gameObjectIsEnabled_checkbox.UseVisualStyleBackColor = true;
            this.gameObjectIsEnabled_checkbox.CheckedChanged += new System.EventHandler(this.gameObjectIsEnabled_checkbox_CheckedChanged);
            // 
            // gameObjectName_label
            // 
            this.gameObjectName_label.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameObjectName_label.Location = new System.Drawing.Point(4, 9);
            this.gameObjectName_label.Name = "gameObjectName_label";
            this.gameObjectName_label.Size = new System.Drawing.Size(164, 23);
            this.gameObjectName_label.TabIndex = 0;
            this.gameObjectName_label.Text = "Game Object Name";
            this.gameObjectName_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gameObjectName_label.UseCompatibleTextRendering = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.exportGameToolStripMenuItem,
            this.closeProjectToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.newProjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.openProjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openProjectToolStripMenuItem.Text = "Open";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // exportGameToolStripMenuItem
            // 
            this.exportGameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.exportGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportGameToolStripMenuItem1,
            this.exportSolutionToolStripMenuItem});
            this.exportGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportGameToolStripMenuItem.Name = "exportGameToolStripMenuItem";
            this.exportGameToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exportGameToolStripMenuItem.Text = "Export";
            // 
            // exportGameToolStripMenuItem1
            // 
            this.exportGameToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.exportGameToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.exportGameToolStripMenuItem1.Name = "exportGameToolStripMenuItem1";
            this.exportGameToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportGameToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.exportGameToolStripMenuItem1.Text = "Export Game";
            // 
            // exportSolutionToolStripMenuItem
            // 
            this.exportSolutionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.exportSolutionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportSolutionToolStripMenuItem.Name = "exportSolutionToolStripMenuItem";
            this.exportSolutionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exportSolutionToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.exportSolutionToolStripMenuItem.Text = "Export Solution";
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.closeProjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.closeProjectToolStripMenuItem.Text = "Close Project";
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelSettingsToolStripMenuItem,
            this.projectSettingsToolStripMenuItem,
            this.copyObjectToolStripMenuItem,
            this.pasteObjectToolStripMenuItem,
            this.deleteGameObjectToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // levelSettingsToolStripMenuItem
            // 
            this.levelSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.levelSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.levelSettingsToolStripMenuItem.Name = "levelSettingsToolStripMenuItem";
            this.levelSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.levelSettingsToolStripMenuItem.Text = "Level Settings";
            // 
            // projectSettingsToolStripMenuItem
            // 
            this.projectSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.projectSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.projectSettingsToolStripMenuItem.Name = "projectSettingsToolStripMenuItem";
            this.projectSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.projectSettingsToolStripMenuItem.Text = "Project Settings";
            // 
            // copyObjectToolStripMenuItem
            // 
            this.copyObjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.copyObjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyObjectToolStripMenuItem.Name = "copyObjectToolStripMenuItem";
            this.copyObjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyObjectToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.copyObjectToolStripMenuItem.Text = "Copy Object";
            this.copyObjectToolStripMenuItem.Click += new System.EventHandler(this.copyObjectToolStripMenuItem_Click);
            // 
            // pasteObjectToolStripMenuItem
            // 
            this.pasteObjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.pasteObjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pasteObjectToolStripMenuItem.Name = "pasteObjectToolStripMenuItem";
            this.pasteObjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteObjectToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pasteObjectToolStripMenuItem.Text = "Paste Object";
            this.pasteObjectToolStripMenuItem.Click += new System.EventHandler(this.pasteObjectToolStripMenuItem_Click);
            // 
            // deleteGameObjectToolStripMenuItem
            // 
            this.deleteGameObjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.deleteGameObjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteGameObjectToolStripMenuItem.Name = "deleteGameObjectToolStripMenuItem";
            this.deleteGameObjectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteGameObjectToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteGameObjectToolStripMenuItem.Text = "Delete Object";
            this.deleteGameObjectToolStripMenuItem.Click += new System.EventHandler(this.deleteGameObjectToolStripMenuItem_Click);
            // 
            // buildAndRunToolStripMenuItem
            // 
            this.buildAndRunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runGameToolStripMenuItem,
            this.buildGameToolStripMenuItem});
            this.buildAndRunToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.buildAndRunToolStripMenuItem.Name = "buildAndRunToolStripMenuItem";
            this.buildAndRunToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.buildAndRunToolStripMenuItem.Text = "Build and Run";
            // 
            // runGameToolStripMenuItem
            // 
            this.runGameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.runGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.runGameToolStripMenuItem.Name = "runGameToolStripMenuItem";
            this.runGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runGameToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.runGameToolStripMenuItem.Text = "Run Game";
            // 
            // buildGameToolStripMenuItem
            // 
            this.buildGameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.buildGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.buildGameToolStripMenuItem.Name = "buildGameToolStripMenuItem";
            this.buildGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.buildGameToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.buildGameToolStripMenuItem.Text = "Build Game";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeProgramToolStripMenuItem});
            this.windowsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowsToolStripMenuItem.Text = "Window";
            // 
            // closeProgramToolStripMenuItem
            // 
            this.closeProgramToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.closeProgramToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.closeProgramToolStripMenuItem.Name = "closeProgramToolStripMenuItem";
            this.closeProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeProgramToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.closeProgramToolStripMenuItem.Text = "Close Program";
            this.closeProgramToolStripMenuItem.Click += new System.EventHandler(this.closeProgramToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.buildAndRunToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.properties_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.levelViewport_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LevelEditor";
            this.Text = "Renderite2D Game Engine - Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelEditor_FormClosed);
            this.levelViewport_panel.ResumeLayout(false);
            this.levelViewport_panel.PerformLayout();
            this.viewportGUI_panel.ResumeLayout(false);
            this.viewportGUI_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.properties_panel.ResumeLayout(false);
            this.properties_panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scaleY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX_num)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel levelViewport_panel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel properties_panel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label assetDirectory_label;
        private System.Windows.Forms.Button addObject_btn;
        private System.Windows.Forms.Panel viewportGUI_panel;
        private System.Windows.Forms.Label viewportCoords_label;
        private System.Windows.Forms.ListBox gameObject_listBox;
        private System.Windows.Forms.Label gameObjectName_label;
        private System.Windows.Forms.CheckBox gameObjectIsEnabled_checkbox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown posX_num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown posY_num;
        private System.Windows.Forms.NumericUpDown scaleY_num;
        private System.Windows.Forms.NumericUpDown scaleX_num;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportSolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGameObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAndRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProgramToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}
