using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct LevelObject
    {
        public string objectType;
        public double x;
        public double y;
        public double scaleX;
        public double scaleY;
        public Dictionary<string, LevelComponent> components;
        public bool isEnabled;

        public LevelObject()
        {
            x = 0;
            y = 0;
            scaleX = 1; 
            scaleY = 1;
            components = new();
            isEnabled = true;
        }

        public LevelObject(string objectType, double x, double y, double scaleX, double scaleY, Dictionary<string, LevelComponent> components, bool isEnabled = true)
        {
            this.objectType = objectType;
            this.x = x;
            this.y = y;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
            this.components = components;
            this.isEnabled = isEnabled;
        }

        public override bool Equals(object obj)
        {
            if (obj is LevelObject levelObject)
            {
                if (components.Count != levelObject.components.Count) return false;

                foreach (var keys in components.Keys)
                {
                    if (!levelObject.components.ContainsKey(keys))
                        return false;
                }

                foreach (var keys in levelObject.components.Keys)
                {
                    if (!components.ContainsKey(keys))
                        return false;
                }

                foreach (var keyValue in components)
                {
                    if (!levelObject.components[keyValue.Key].Equals(keyValue.Value))
                        return false;
                }

                return
                    objectType == levelObject.objectType &&
                    x == levelObject.x &&
                    y == levelObject.y &&
                    scaleX == levelObject.scaleX &&
                    scaleY == levelObject.scaleY &&
                    isEnabled == levelObject.isEnabled;
            }
            return false;
        }
    }
}
