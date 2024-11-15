using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct LevelComponent
    {
        public string componentType;
        public Dictionary<string, object> values;
        public bool isEnabled;

        public LevelComponent(string componentType, Dictionary<string, object> values, bool isEnabled = true)
        {
            this.componentType = componentType;
            this.values = values;
            this.isEnabled = isEnabled;
        }
    }
}
