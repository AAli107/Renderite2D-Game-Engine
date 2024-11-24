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
    public partial class PhysicsComponentProperties : Renderite2D_Game_Engine.Component_Properties
    {
        [Obsolete("Designer only", true)]
        public PhysicsComponentProperties()
        {
            InitializeComponent();
        }

        public PhysicsComponentProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            mass_num.Value = (decimal)Convert.ToDouble(component.values["mass"]);
            friction_num.Value = (decimal)Convert.ToDouble(component.values["friction"]);
            isAirborne_checkBox.Checked = (bool)component.values["isAirborne"];
            gravityEnabled_checkBox.Checked = (bool)component.values["gravityEnabled"];
            gravityMultiplier_num.Value = (decimal)Convert.ToDouble(component.values["gravityMultiplier"]);
        }

        public override int GetHeight()
        {
            return 255;
        }

        private void mass_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("mass", (double)mass_num.Value);
        }

        private void friction_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("friction", (double)friction_num.Value);
        }

        private void isAirborne_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("isAirborne", isAirborne_checkBox.Checked);
        }

        private void gravityEnabled_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentValue("gravityEnabled", gravityEnabled_checkBox.Checked);
        }

        private void gravityMultiplier_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("gravityMultiplier", (double)gravityMultiplier_num.Value);
        }
    }
}
