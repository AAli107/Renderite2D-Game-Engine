using System;
using System.Collections.Generic;
using System.Drawing;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct Level
    {
        public Color backgroundColor;
        public List<LevelObject> gameObjects;

        public Level()
        {
            backgroundColor = Color.Black;
            gameObjects = new();
        }

        public Level(Color backgroundColor, List<LevelObject> gameObjects)
        {
            this.backgroundColor = backgroundColor;
            this.gameObjects = gameObjects;
        }
    }
}
