using System;
using System.Collections.Generic;
using System.Linq;

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

        public override bool Equals(object obj)
        {
            if (obj is LevelComponent component)
            {
                var t = this;
                bool gameObjectDictionaryEqual = values.Count == component.values.Count &&
                   values.Keys.All(k => component.values.ContainsKey(k) && component.values[k].Equals(t.values[k]));

                return 
                    componentType == component.componentType &&
                    gameObjectDictionaryEqual &&
                    isEnabled == component.isEnabled;
            }
            return false;
        }
    }
}
