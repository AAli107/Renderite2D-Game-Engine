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
                if (values.Count != component.values.Count) return false;

                foreach (var keys in values.Keys)
                {
                    if (!component.values.ContainsKey(keys))
                        return false;
                }

                foreach (var keys in component.values.Keys)
                {
                    if (!values.ContainsKey(keys))
                        return false;
                }

                foreach (var keyValue in values)
                {
                    if (!component.values[keyValue.Key].Equals(keyValue.Value))
                        return false;
                }

                return 
                    componentType == component.componentType &&
                    isEnabled == component.isEnabled;
            }
            return false;
        }
    }
}
