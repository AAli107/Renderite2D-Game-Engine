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
    public partial class AnimatedSpriteRendererProperties : Renderite2D_Game_Engine.RendererComponent_Properties
    {
        [Obsolete("Designer only", true)]
        public AnimatedSpriteRendererProperties()
        {
            InitializeComponent();
        }

        public AnimatedSpriteRendererProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            base.UpdateComponent_(component);

            TimePerFrame_num.Value = (decimal)Convert.ToDouble(component.values["TimePerFrame"]);
            EndFrameIndex_num.Value = Convert.ToInt32(component.values["EndFrameIndex"]);
            IsPlaying_checkBox.Checked = (bool)component.values["IsPlaying"];
            PlayReverse_checkBox.Checked = (bool)component.values["PlayReverse"];
        }

        public override int GetHeight()
        {
            return 203;
        }

        private void TimePerFrame_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("TimePerFrame", (double)TimePerFrame_num.Value);
        }

        private void EndFrameIndex_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("EndFrameIndex", (int)EndFrameIndex_num.Value);
        }

        private void IsPlaying_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("IsPlaying", IsPlaying_checkBox.Checked);
        }

        private void PlayReverse_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("PlayReverse", PlayReverse_checkBox.Checked);
        }
    }
}
