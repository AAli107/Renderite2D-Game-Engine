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
        public string backgroundTexture;
        public Color backgroundTextureTint;
        public Dictionary<string, LevelObject> gameObjects;

        public Level()
        {
            backgroundColor = Color.Black;
            backgroundTexture = "";
            backgroundTextureTint = Color.White;
            gameObjects = new();
        }

        public Level(Color backgroundColor, Dictionary<string, LevelObject> gameObjects, string backgroundTexture, Color backgroundTextureTint)
        {
            this.backgroundColor = backgroundColor;
            this.gameObjects = gameObjects;
            this.backgroundTexture = backgroundTexture;
            this.backgroundTextureTint = backgroundTextureTint;
        }

        public Level(Level levelData)
        {
            backgroundColor = levelData.backgroundColor;
            backgroundTexture = levelData.backgroundTexture;
            backgroundTextureTint = levelData.backgroundTextureTint;
            gameObjects = new();
            foreach (var item in levelData.gameObjects)
                gameObjects.Add(item.Key, item.Value);
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
