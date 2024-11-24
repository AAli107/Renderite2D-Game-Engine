using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Renderite2D_Game_Engine;

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
    }
}
