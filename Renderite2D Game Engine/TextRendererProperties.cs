﻿using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class TextRendererProperties : Renderite2D_Game_Engine.RendererComponent_Properties
    {
        [Obsolete("Designer only", true)]
        public TextRendererProperties()
        {
            InitializeComponent();
        }
        public TextRendererProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            base.UpdateComponent_(component);

            isStatic_checkBox.Checked = (bool)component.values["isStatic"];
            posX_num.Value = (decimal)Convert.ToDouble(component.values["position.X"]);
            posY_num.Value = (decimal)Convert.ToDouble(component.values["position.Y"]);
            textBox1.Text = (string)component.values["text"];
            if (component.values["color"] is string c)
            {
                var color = (Color)new ColorConverter().ConvertFromString(c);
                colorDialog1.Color = color;
                colorpicker_button.BackColor = color;
            }
            else
            {
                colorDialog1.Color = (Color)component.values["color"];
                colorpicker_button.BackColor = (Color)component.values["color"];
            }
            scale_num.Value = (decimal)Convert.ToDouble(component.values["scale"]);
        }

        public override int GetHeight()
        {
            return 220;
        }

        private void isStatic_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isStatic", isStatic_checkBox.Checked);
        }

        private void posX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("position.X", (double)posX_num.Value);
        }

        private void posY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("position.Y", (double)posY_num.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetComponentValue("text", textBox1.Text);
        }

        private void colorpicker_button_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.SolidColorOnly = false;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorpicker_button.BackColor = colorDialog1.Color;
                SetComponentValue("color", colorDialog1.Color);
            }
        }

        private void scale_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("scale", (double)scale_num.Value);
        }
    }
}