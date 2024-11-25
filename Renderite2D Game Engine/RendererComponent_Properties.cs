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
    public partial class RendererComponent_Properties : Renderite2D_Game_Engine.Component_Properties
    {
        [Obsolete("Designer only", true)]
        public RendererComponent_Properties()
        {
            InitializeComponent();
        }

        public RendererComponent_Properties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            layer_num.Value = Convert.ToByte(component.values["layer"]);
        }

        private void mass_num_ValueChanged(object sender, EventArgs e)
        {
            SetComponentValue("layer", (byte)layer_num.Value);
        }
    }
}
