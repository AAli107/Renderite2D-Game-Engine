using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct Level
    {
        public Color backgroundColor;
        public Dictionary<string, LevelObject> gameObjects;

        public Level()
        {
            backgroundColor = Color.Black;
            gameObjects = new();
        }

        public Level(Color backgroundColor, Dictionary<string, LevelObject> gameObjects)
        {
            this.backgroundColor = backgroundColor;
            this.gameObjects = gameObjects;
        }

        public override bool Equals(object obj)
        {
            if (obj is Level level)
            {
                var t = this;
                 bool gameObjectDictionaryEqual = gameObjects.Count == level.gameObjects.Count &&
                    gameObjects.Keys.All(k => level.gameObjects.ContainsKey(k) && level.gameObjects[k].Equals(t.gameObjects[k]));

                return backgroundColor == level.backgroundColor && gameObjectDictionaryEqual;
            }
            return false;
        }
    }
}
