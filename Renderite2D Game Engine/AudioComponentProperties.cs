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
    public partial class AudioComponentProperties : Renderite2D_Game_Engine.Component_Properties
    {
        [Obsolete("Designer only", true)]
        public AudioComponentProperties()
        {
            InitializeComponent();
        }

        public AudioComponentProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("|None|");
            foreach (string file in 
                Directory.EnumerateFiles(ProjectManager.AssetsPath, "*.*", SearchOption.AllDirectories))
            {
                if (LevelEditor.IsAudioFile(file))
                    comboBox1.Items.Add(file.Replace('/', '\\').Replace(
                        (ProjectManager.AssetsPath.Replace('/', '\\')) + "\\", ""));
            }

            trackBar1.Value = (int)(Convert.ToDouble(component.values["Volume"]) * 100);

            var foundAudio = ((string)component.values["FilePath"]).Replace("Assets\\Game Assets\\", "");
            comboBox1.SelectedItem = comboBox1.Items.Contains(foundAudio) ? foundAudio : "|None|";
            
            UpdateVolumeText();
        }

        public override int GetHeight()
        {
            return 167;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateVolumeText();
            SetComponentValue("Volume", trackBar1.Value / 100.0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComponentValue("FilePath", (comboBox1.SelectedItem != null && (string)comboBox1.SelectedItem != "|None|") ? "Assets\\Game Assets\\" + ((string)comboBox1.SelectedItem) : "");
        }

        private void UpdateVolumeText()
        {
            volumePercentLabel.Text = trackBar1.Value + "%";
        }
    }
}
