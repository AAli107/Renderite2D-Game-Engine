using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Renderite2D_Game_Engine;
using Renderite2D_Game_Engine.Scripts.Data;

namespace Renderite2D_Game_Engine
{
    public partial class ColliderComponentProperties : Component_Properties
    {
        public ColliderComponentProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        public override int GetHeight()
        {
            return 230;
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            posX_num.Value = (decimal)(double)component.values["transform.position.X"];
            posY_num.Value = (decimal)(double)component.values["transform.position.Y"];
            scaleX_num.Value = (decimal)(double)component.values["transform.scale.X"];
            scaleY_num.Value = (decimal)(double)component.values["transform.scale.Y"];
            isSolidCollision_checkBox.Checked = (bool)component.values["isSolidCollision"];
            friction_num.Value = (decimal)(float)component.values["friction"];
        }

        private void posX_num_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
