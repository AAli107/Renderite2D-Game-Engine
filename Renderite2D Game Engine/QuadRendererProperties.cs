using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class QuadRendererProperties : Renderite2D_Game_Engine.RendererComponent_Properties
    {
        [Obsolete("Designer only", true)]
        public QuadRendererProperties()
        {
            InitializeComponent();
        }
        public QuadRendererProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            base.UpdateComponent_(component);

            texture_combobox.Items.Clear();
            texture_combobox.Items.Add("|None|");
            foreach (string file in
                Directory.EnumerateFiles(ProjectManager.AssetsPath, "*.*", SearchOption.AllDirectories))
            {
                if (LevelEditor.IsImageFile(file))
                    texture_combobox.Items.Add(file.Replace('/', '\\').Replace(
                        (ProjectManager.AssetsPath.Replace('/', '\\')) + "\\", ""));
            }

            isStatic_checkBox.Checked = (bool)component.values["isStatic"];
            posAX_num.Value = (decimal)Convert.ToDouble(component.values["pointA.X"]);
            posAY_num.Value = (decimal)Convert.ToDouble(component.values["pointA.Y"]);
            posBX_num.Value = (decimal)Convert.ToDouble(component.values["pointB.X"]);
            posBY_num.Value = (decimal)Convert.ToDouble(component.values["pointB.Y"]);
            posCX_num.Value = (decimal)Convert.ToDouble(component.values["pointC.X"]);
            posCY_num.Value = (decimal)Convert.ToDouble(component.values["pointC.Y"]);
            posDX_num.Value = (decimal)Convert.ToDouble(component.values["pointD.X"]);
            posDY_num.Value = (decimal)Convert.ToDouble(component.values["pointD.Y"]);
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
            var foundTex = ((string)component.values["texture"]).Replace("Assets\\Game Assets\\", "");
            texture_combobox.SelectedItem = texture_combobox.Items.Contains(foundTex) ? foundTex : "|None|";
        }

        public override int GetHeight()
        {
            return 280;
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

        private void posCX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointC.X", (double)posCX_num.Value);
        }

        private void posCY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointC.Y", (double)posCY_num.Value);
        }

        private void posDX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointD.X", (double)posDX_num.Value);
        }

        private void posDY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("pointD.Y", (double)posDY_num.Value);
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

        private void texture_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComponentValue("texture", (texture_combobox.SelectedItem != null && (string)texture_combobox.SelectedItem != "|None|") ? "Assets\\Game Assets\\" + ((string)texture_combobox.SelectedItem) : "");
        }
    }
}
