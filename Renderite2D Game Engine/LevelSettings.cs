using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class LevelSettings : Form
    {
        Level levelData;

        public LevelSettings()
        {
            InitializeComponent();

            texture_combobox.Items.Clear();
            texture_combobox.Items.Add("|None|");
            foreach (string file in
                Directory.EnumerateFiles(ProjectManager.AssetsPath, "*.*", SearchOption.AllDirectories))
            {
                if (LevelEditor.IsImageFile(file))
                    texture_combobox.Items.Add(file.Replace('/', '\\').Replace(
                        (ProjectManager.AssetsPath.Replace('/', '\\')) + "\\", ""));
            }

            if (ProjectManager.IsProjectOpen)
            {
                levelData = new(ProjectManager.CurrentLevelData);

                texture_combobox.SelectedItem = texture_combobox.Items.Contains(levelData.backgroundTexture.Replace("Assets\\Game Assets\\", "")) ? levelData.backgroundTexture.Replace("Assets\\Game Assets\\", "") : "|None|";
                colorpicker_button.BackColor = levelData.backgroundColor;
                colorpicker_button2.BackColor = levelData.backgroundTextureTint;
            }
        }

        public (DialogResult dialogResult, Color color) PickColor(bool solidColorOnly = false)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.SolidColorOnly = solidColorOnly;

            return (colorDialog1.ShowDialog(), colorDialog1.Color);
        }

        private void colorpicker_button_Click(object sender, EventArgs e)
        {
            var (dialogResult, color) = PickColor(true);
            if (dialogResult == DialogResult.OK)
            {
                colorpicker_button.BackColor = color;
                levelData.backgroundColor = color;
            }
        }

        private void colorpicker_button2_Click(object sender, EventArgs e)
        {
            var (dialogResult, color) = PickColor(false);
            if (dialogResult == DialogResult.OK)
            {
                colorpicker_button2.BackColor = color;
                levelData.backgroundTextureTint = color;
            }
        }

        private void texture_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            levelData.backgroundTexture = (texture_combobox.SelectedItem != null && (string)texture_combobox.SelectedItem != "|None|") ? "Assets\\Game Assets\\" + ((string)texture_combobox.SelectedItem) : "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        private void LevelSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ProjectManager.IsProjectOpen)
            {
                ProjectManager.SetLevelData(levelData);
                DialogResult = DialogResult.OK;
            } 
            else DialogResult = DialogResult.Cancel;
        }
    }
}
