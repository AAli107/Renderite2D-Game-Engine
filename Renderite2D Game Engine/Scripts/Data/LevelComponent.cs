using System;
using System.Collections.Generic;

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
