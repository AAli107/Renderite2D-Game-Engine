using Microsoft.CSharp;
using Newtonsoft.Json;
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
        public static bool IsBuilding { get; private set; }

        public static readonly string levelPreName = "_Lvl_";

        public static bool StartsWithLevelPreName(string str)
        {
            return str.StartsWith(levelPreName);
        }

        public static bool IsValidIdentifier(string str)
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

        public static (string code, string className) LevelDataToLevelScript(Level levelData, string levelName)
        {
            string configTemplateDir = "Engine Resources\\Script Templates\\LevelScriptTemplate.cs";
            if (File.Exists(configTemplateDir))
            {
                string script = File.ReadAllText(configTemplateDir);
                string className = SanitizeClassName(levelPreName + levelName);

                script = script.Replace("__level_name__", className);

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
                                item.Key == "Volume" ||
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

                return (script, className);
            }
            return (null, null);
        }

        public static (bool success, string buildMessages) BuildSolution(bool isDebug)
        {
            if (IsBuilding) return (false, "Project is already being built");

            IsBuilding = true;

            string sourcePath = "Engine Resources\\Renderite2D Solution";
            string targetPath = ProjectManager.BuildPath + '\\' + (isDebug ? "Debug" : "Release");
            string projectDirPath = targetPath + "\\Renderite2D_Project\\";
            string csprojPath = projectDirPath + "Renderite2D_Project.csproj";
            string gameConfigPath = projectDirPath + "Renderite2D\\GameConfig.cs";

            if (!ProjectManager.IsProjectOpen) return (false, "Project is not open!");
            if (!Directory.Exists(sourcePath)) return (false, "Solution Template does not exist!");

            ProjectManager.SaveProjectFiles();

            var pwBuild = new ProgressWindow();
            pwBuild.Show();

            try
            {
                if (Directory.Exists(targetPath))
                    Directory.Delete(targetPath, true);

                Directory.CreateDirectory(targetPath);

                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));

                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

            } catch (Exception ex) 
            {
                pwBuild.Close();
                IsBuilding = false;
                return (false, "Failed to copy solution template!\n\n" + ex.Message);
            }

            try
            {
                if (isDebug && File.Exists(csprojPath))
                    File.WriteAllText(csprojPath, File.ReadAllText(csprojPath).Replace("<OutputType>WinExe</OutputType>", "<OutputType>Exe</OutputType>"));
            }
            catch (Exception ex)
            {
                pwBuild.Close();
                IsBuilding = false;
                return (false, "Failed to setup '.csproj' configs!\n\n" + ex.Message);
            }

            try
            {
                if (File.Exists(gameConfigPath))
                    File.WriteAllText(gameConfigPath, ProjectDataToGameConfigScript(ProjectManager.ProjectData));
            }
            catch (Exception ex)
            {
                pwBuild.Close();
                IsBuilding = false;
                return (false, "Failed to insert project configs!\n\n" + ex.Message);
            }

            try
            {
                string assetSource = ProjectManager.AssetsPath;
                string destPath = projectDirPath + "Assets\\Game Assets";

                if (Directory.Exists(destPath))
                    Directory.Delete(destPath, true);

                Directory.CreateDirectory(destPath);

                foreach (string dirPath in Directory.GetDirectories(assetSource, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(assetSource, destPath));

                foreach (string newPath in Directory.GetFiles(assetSource, "*.*", SearchOption.AllDirectories))
                    if (!LevelEditor.IsScriptFile(newPath))
                        File.Copy(newPath, newPath.Replace(assetSource, destPath), true);

            }
            catch (Exception ex)
            {
                pwBuild.Close();
                IsBuilding = false;
                return (false, "Failed to copy Assets!\n\n" + ex.Message);
            }


            foreach (string file in
                Directory.EnumerateFiles(ProjectManager.AssetsPath, "*.*", SearchOption.AllDirectories))
            {
                if (LevelEditor.IsScriptFile(file))
                {
                    string fDest = (projectDirPath + file.Replace(ProjectManager.AssetsPath, "")).Replace('/', '\\');
                    string fDir = Path.GetDirectoryName(fDest);
                    if (!Directory.Exists(fDir))
                        Directory.CreateDirectory(fDir);
                    File.Copy(file, fDest, true);
                }
            }

            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Error,
            };

            foreach (string file in
                Directory.EnumerateFiles(ProjectManager.AssetsPath, "*.*", SearchOption.AllDirectories))
            {
                if (LevelEditor.IsLevelFile(file))
                {
                    string levelName = Path.GetFileNameWithoutExtension(file.Replace('/', '\\'));
                    try
                    {
                        Level l = JsonConvert.DeserializeObject<Level>(File.ReadAllText(file.Replace('/', '\\')), settings);

                        var (code, className) = LevelDataToLevelScript(l, levelName);

                        File.WriteAllText(projectDirPath + className + ".cs", code);

                    }
                    catch (Exception ex)
                    {
                        pwBuild.Close();
                        IsBuilding = false;
                        return (false, "Failed to generate level code for level: '" + levelName + ".rdlvl'\n\n" + ex.Message);
                    }
                }
            }

            pwBuild.Close();
            IsBuilding = false;
            return (true, "Built Successfully");
        }
    }
}
