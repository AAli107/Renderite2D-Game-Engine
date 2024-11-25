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
    public partial class RectRendererProperties : Renderite2D_Game_Engine.RendererComponent_Properties
    {
        [Obsolete("Designer only", true)]
        public RectRendererProperties()
        {
            InitializeComponent();
        }
        public RectRendererProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            base.UpdateComponent_(component);

            texture_combobox.Items.Clear();
            foreach (string file in
                Directory.EnumerateFiles(ProjectManager.AssetsPath, "*.*", SearchOption.AllDirectories))
            {
                if (LevelEditor.IsImageFile(file))
                    texture_combobox.Items.Add(file.Replace('/', '\\').Replace(
                        (ProjectManager.AssetsPath.Replace('/', '\\')) + "\\", ""));
            }

            isStatic_checkBox.Checked = (bool)component.values["isStatic"];
            isCentered_checkBox.Checked = (bool)component.values["isCentered"];
            isOutline_checkBox.Checked = (bool)component.values["isOutline"];
            posX_num.Value = (decimal)Convert.ToDouble(component.values["position.X"]);
            posY_num.Value = (decimal)Convert.ToDouble(component.values["position.Y"]);
            scaleX_num.Value = (decimal)Convert.ToDouble(component.values["dimension.X"]);
            scaleY_num.Value = (decimal)Convert.ToDouble(component.values["dimension.Y"]);
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
            texture_combobox.SelectedItem = ((string)component.values["texture"]).Replace("Assets\\Game Assets\\", "");
        }

        public override int GetHeight()
        {
            return 316;
        }
        private void isStatic_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isStatic", isStatic_checkBox.Checked);
        }

        private void isCentered_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isCentered", isCentered_checkBox.Checked);
        }

        private void isOutline_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isOutline", isOutline_checkBox.Checked);
        }

        private void posX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("position.X", (double)posX_num.Value);
        }

        private void posY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("position.Y", (double)posY_num.Value);
        }

        private void scaleX_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("dimension.X", (double)scaleX_num.Value);
        }

        private void scaleY_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("dimension.Y", (double)scaleY_num.Value);
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
            SetComponentValue("texture", texture_combobox.SelectedItem != null ? "Assets\\Game Assets\\" + ((string)texture_combobox.SelectedItem) : "");
        }
    }
}
