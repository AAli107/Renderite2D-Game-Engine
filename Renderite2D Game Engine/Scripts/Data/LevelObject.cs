using System;
using System.Collections.Generic;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct LevelObject
    {
        public double x;
        public double y;
        public List<LevelComponent> components;
        public bool isEnabled;

        public LevelObject(double x, double y, List<LevelComponent> components, bool isEnabled = true)
        {
            this.x = x;
            this.y = y;
            this.components = components;
            this.isEnabled = isEnabled;
        }
    }
}
