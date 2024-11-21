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
                if (gameObjects.Count != level.gameObjects.Count) return false;

                foreach (var keys in gameObjects.Keys)
                {
                    if (!level.gameObjects.ContainsKey(keys))
                        return false;
                }

                foreach (var keys in level.gameObjects.Keys)
                {
                    if (!gameObjects.ContainsKey(keys))
                        return false;
                }

                foreach (var keyValue in gameObjects) 
                {
                    if (!level.gameObjects[keyValue.Key].Equals(keyValue.Value))
                        return false;
                }

                return backgroundColor == level.backgroundColor;
            }
            return false;
        }
    }
}
