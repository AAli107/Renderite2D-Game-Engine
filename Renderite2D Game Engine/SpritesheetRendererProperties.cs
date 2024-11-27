using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class SpritesheetRendererProperties : Renderite2D_Game_Engine.RendererComponent_Properties
    {
        [Obsolete("Designer only", true)]
        public SpritesheetRendererProperties()
        {
            InitializeComponent();
        }

        public SpritesheetRendererProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
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
            isCentered_checkBox.Checked = (bool)component.values["isCentered"];
            index_num.Value = Convert.ToInt32(component.values["index"]);
            divisions_num.Value = Convert.ToInt32(component.values["divisions"]);
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
            var foundTex = ((string)component.values["texture"]).Replace("Assets\\Game Assets\\", "");
            texture_combobox.SelectedItem = texture_combobox.Items.Contains(foundTex) ? foundTex : "|None|";
        }

        public override int GetHeight()
        {
            return 360;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void isCentered_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isCentered", isCentered_checkBox.Checked);
        }

        private void index_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("index", (int)index_num.Value);
        }

        private void divisions_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("divisions", (int)divisions_num.Value);
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

        private void texture_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComponentValue("texture", (texture_combobox.SelectedItem != null && (string)texture_combobox.SelectedItem != "|None|") ? "Assets\\Game Assets\\" + ((string)texture_combobox.SelectedItem) : "");
        }
    }
}
