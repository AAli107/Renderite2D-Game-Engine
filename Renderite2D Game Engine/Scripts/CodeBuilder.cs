using Microsoft.CSharp;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderite2D_Game_Engine.Scripts
{
    public static class CodeBuilder
    {
        private static bool IsValidIdentifier(string str)
        {
            return new CSharpCodeProvider().IsValidIdentifier(str);
        }

        public static string InsertClassNameToScript(string script, string __class_name__)
        {
            return script.Replace("__class_name__", SanitizeClassName(__class_name__));
        }

        public static string SanitizeClassName(string name)
        {
            if (IsValidIdentifier(name))
                return name;

            name = name.Trim().Replace(" ", "_");

            if (name.Length > 0 && !char.IsLetter(name[0]) && name[0] != '_' && name[0] != '@')
                name = '_' + (name.Length > 1 ? name.Substring(1) : "");

            string name2 = "";
            char[] disallowedChars = """ \|!#$%&/()=?»«@£§€{}.-:;"'<>,`~*[] """.Trim(' ').ToCharArray();
            for (int i = 0; i < name.Length; i++)
            {
                if (i != 0 && disallowedChars.Contains(name[i]))
                    name2 += '_';
                else name2 += name[i];
            }
            name = name2;

            if (!IsValidIdentifier(name))
                name = "@" + name;

            return name;
        }

        public static string ProjectDataToGameConfigScript(Project projectData)
        {
            string configTemplateDir = "Engine Resources\\Script Templates\\GameConfigTemplate.cs";
            if (File.Exists(configTemplateDir))
            {
                string script = File.ReadAllText(configTemplateDir);
                script = script.Replace("__resolutionX__", projectData.resolutionX.ToString());
                script = script.Replace("__resolutionY__", projectData.resolutionY.ToString());
                script = script.Replace("__vSyncEnabled__", projectData.vSyncEnabled ? "VSyncMode.On" : "VSyncMode.Off");
                script = script.Replace("__isWindowResizeable__", projectData.isWindowResizeable ? "WindowBorder.Resizable" : "WindowBorder.Fixed");
                script = script.Replace("__windowTitle__", projectData.windowTitle);
                script = script.Replace("__fixedUpdateFrequency__", projectData.fixedUpdateFrequency.ToString());
                string winstate = projectData.windowState switch
                {
                    1 => "WindowState.Minimized",
                    2 => "WindowState.Maximized",
                    3 => "WindowState.Fullscreen",
                    _ => "WindowState.Normal",
                };
                script = script.Replace("__windowState__", winstate);
                script = script.Replace("__startingLevel__", "new " + SanitizeClassName(Path.GetFileNameWithoutExtension(projectData.startingLevel)) + "()");
                script = script.Replace("__drawColliders__", projectData.drawColliders.ToString().ToLower());
                script = script.Replace("__allowAltEnter__", projectData.allowAltEnter.ToString().ToLower());
                return script;
            }
            return null;
        }

        public static string LevelDataToLevelScript(Level levelData)
        {
            string configTemplateDir = "Engine Resources\\Script Templates\\LevelScriptTemplate.cs";
            if (File.Exists(configTemplateDir))
            {
                string script = File.ReadAllText(configTemplateDir);

                string beginScript = "";
                beginScript += "BackgroundColor = Color.FromArgb(" +
                    levelData.backgroundColor.A + ", " + levelData.backgroundColor.R + ", " + levelData.backgroundColor.G + ", " + levelData.backgroundColor.B + ");\r\n";
                
                foreach (var gameObject in levelData.gameObjects.Values)
                {
                    // TODO : Insert Game Object instantiation code
                }
                script = script.Replace("// __begin_code__", beginScript);

                script = script.Replace("Color.White; // __background_texture_color__", "Color.FromArgb(" +
                    levelData.backgroundTextureTint.A + ", " + levelData.backgroundTextureTint.R + ", " + levelData.backgroundTextureTint.G + ", " + levelData.backgroundTextureTint.B + ");");

                script = script.Replace("__bg_texture_path_name__", levelData.backgroundTexture);

                return script;
            }
            return null;
        }
    }
}
