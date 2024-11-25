using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class LineRendererProperties : Renderite2D_Game_Engine.RendererComponent_Properties
    {
        [Obsolete("Designer only", true)]
        public LineRendererProperties()
        {
            InitializeComponent();
        }
        public LineRendererProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            base.UpdateComponent_(component);

            isStatic_checkBox.Checked = (bool)component.values["isStatic"];
            posAX_num.Value = (decimal)Convert.ToDouble(component.values["pointA.X"]);
            posAY_num.Value = (decimal)Convert.ToDouble(component.values["pointA.Y"]);
            posBX_num.Value = (decimal)Convert.ToDouble(component.values["pointB.X"]);
            posBY_num.Value = (decimal)Convert.ToDouble(component.values["pointB.Y"]);
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
            width_num.Value = (decimal)Convert.ToDouble(component.values["width"]);
        }

        public override int GetHeight()
        {
            return 223;
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

        private void isStatic_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isStatic", isStatic_checkBox.Checked);
        }

        private void posAX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointA.X", (double)posAX_num.Value);
        }

        private void posAY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointA.Y", (double)posAY_num.Value);
        }

        private void posBX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointB.X", (double)posBX_num.Value);
        }

        private void posBY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointB.Y", (double)posBY_num.Value);
        }

        private void width_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("width", (double)width_num.Value);
        }
    }
}
