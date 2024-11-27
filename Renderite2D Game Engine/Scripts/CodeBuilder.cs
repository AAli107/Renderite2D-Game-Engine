using Microsoft.CSharp;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine.Scripts
{
    public static class CodeBuilder
    {
        public static readonly string levelPreName = "_Lvl_";

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
                script = script.Replace("__startingLevel__", "new " + SanitizeClassName(levelPreName + Path.GetFileNameWithoutExtension(projectData.startingLevel)) + "()");
                script = script.Replace("__drawColliders__", projectData.drawColliders.ToString().ToLower());
                script = script.Replace("__allowAltEnter__", projectData.allowAltEnter.ToString().ToLower());
                return script;
            }
            return null;
        }

        public static string LevelDataToLevelScript(Level levelData, string levelName)
        {
            string configTemplateDir = "Engine Resources\\Script Templates\\LevelScriptTemplate.cs";
            if (File.Exists(configTemplateDir))
            {
                string script = File.ReadAllText(configTemplateDir);

                script = script.Replace("__level_name__", SanitizeClassName(levelPreName + levelName));

                script = script.Replace("Color.White; // __background_texture_color__", "Color.FromArgb(" +
                    levelData.backgroundTextureTint.A + ", " + levelData.backgroundTextureTint.R + ", " + levelData.backgroundTextureTint.G + ", " + levelData.backgroundTextureTint.B + ");");

                script = script.Replace("__bg_texture_path_name__", levelData.backgroundTexture.Replace("\'", "\\'").Replace("\"", "\\\"").Replace("\\", "\\\\"));

                string beginScript = "";
                beginScript += "BackgroundColor = Color.FromArgb(" +
                    levelData.backgroundColor.A + ", " + levelData.backgroundColor.R + ", " + levelData.backgroundColor.G + ", " + levelData.backgroundColor.B + ");\r\n";
                string singleIndent = "    ";
                string indent1 = singleIndent + singleIndent + singleIndent;
                string indent2 = indent1 + singleIndent;
                string indent3 = indent2 + singleIndent;
                foreach (LevelObject gameObject in levelData.gameObjects.Values)
                {
                    beginScript += indent1 + "{\r\n";
                    beginScript += indent2 + "var gameObject = new " + gameObject.objectType + "(new Transform2D(new(" + gameObject.x + ", " + gameObject.y + "), new(" + gameObject.scaleX + ", " + gameObject.scaleY + ")))\r\n";
                    beginScript += indent2 + "{\r\n";
                    beginScript += indent3 + "IsEnabled = " + gameObject.isEnabled.ToString().ToLower() + ",\r\n";
                    beginScript += indent2 + "};\r\n";
                    foreach (LevelComponent component in gameObject.components.Values)
                    {
                        if (component.componentType == "ScriptComponent" && (!component.values.ContainsKey("ScriptClass") || component.values["ScriptClass"].ToString() == "")) continue;

                        string componentType = (component.componentType == "ScriptComponent" ? component.values["ScriptClass"].ToString() : component.componentType);
                        beginScript += indent2 + "{\r\n";
                        beginScript += indent3 + "var component = gameObject.AddComponent<" + componentType + ">();\r\n";
                        beginScript += indent3 + "component.IsEnabled = " + component.isEnabled.ToString().ToLower() + ";\r\n";
                        foreach (var item in component.values)
                        {
                            // TODO : Insert code for component values
                            if (component.componentType == "ScriptComponent") break;

                            string val = "";
                            if (item.Key == "color")
                            {
                                Color c;
                                if (item.Value is string cStr)
                                    c = (Color)new ColorConverter().ConvertFromString(cStr);
                                else c = (Color)item.Value;
                                val = "Color.FromArgb(" + c.A + ", " + c.R + ", " + c.G + ", " + c.B + ")";
                            }
                            else if (item.Key == "texture")
                            {

                                string path = item.Value.ToString()
                                        .Replace("\'", "\\'")
                                        .Replace("\"", "\\\"")
                                        .Replace("\\", "\\\\");
                                if (path.Length > 0)
                                    path = '\"' + path + '\"';
                                val = "new Texture(" + path + ")";
                            }
                            else if (item.Value is float || 
                                item.Key == "friction" || 
                                item.Key == "mass" ||
                                item.Key == "scale" ||
                                item.Key == "width")
                            {
                                val = item.Value.ToString() + "f";
                            }
                            else if (item.Value is bool)
                            {
                                val = item.Value.ToString().ToLower();
                            }
                            else if (item.Value is string || item.Value is char)
                            {
                                string quoteSymbol = item.Value is string ? "\"" : "\'";
                                val = quoteSymbol + 
                                    item.Value.ToString()
                                    .Replace("\'", "\\'")
                                    .Replace("\"", "\\\"")
                                    .Replace("\\", "\\\\")
                                    + quoteSymbol;
                            }
                            else
                            {
                                val = item.Value.ToString();
                            }

                            beginScript += indent3 + "component." + item.Key + " = " + val + ";\r\n";
                        }
                        beginScript += indent2 + "}\r\n";
                    }
                    beginScript += indent2 + "Game.World.Instantiate(gameObject);\r\n";
                    beginScript += indent1 + "}\r\n";
                }
                script = script.Replace("// __begin_code__", beginScript);

                return script;
            }
            return null;
        }
    }
}
