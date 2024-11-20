using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class Component_Properties : UserControl
    {
        public string gameObjectName = "";
        public int componentIndex = -1;

        public Component_Properties()
        {
            InitializeComponent();
        }
    }
}
