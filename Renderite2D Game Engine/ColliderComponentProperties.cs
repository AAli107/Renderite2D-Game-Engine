using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class ColliderComponentProperties : Renderite2D_Game_Engine.Component_Properties
    {
        public ColliderComponentProperties(string gameObjectName, int componentIndex) : 
            base(gameObjectName, componentIndex)
        {
            InitializeComponent();
        }
    }
}
