using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public string ToLevelScript()
        {
            string configTemplateDir = "Engine Resources\\Script Templates\\LevelScriptTemplate.cs";
            if (File.Exists(configTemplateDir))
            {
                string script = File.ReadAllText(configTemplateDir);

                string beginScript = "";
                beginScript += "BackgroundColor = Color.FromArgb(" + backgroundColor.A + ", " + backgroundColor.R + ", " + backgroundColor.G + ", " + backgroundColor.B + ");\r\n";
                // TODO : Insert Game Object instantiation
                script = script.Replace("// __begin_code__", beginScript);

                script = script.Replace("Color.White; // __background_texture_color__", "Color.FromArgb(" + backgroundTextureTint.A + ", " + backgroundTextureTint.R + ", " + backgroundTextureTint.G + ", " + backgroundTextureTint.B + ");");

                script = script.Replace("__bg_texture_path_name__", backgroundTexture);

                return script;
            }
            return null;
        }
    }
}
