﻿using System;
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
        public List<LevelComponent> components;
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

        public LevelObject(double x, double y, double scaleX, double scaleY, List<LevelComponent> components, bool isEnabled = true)
        {
            this.x = x;
            this.y = y;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
            this.components = components;
            this.isEnabled = isEnabled;
        }
    }
}
