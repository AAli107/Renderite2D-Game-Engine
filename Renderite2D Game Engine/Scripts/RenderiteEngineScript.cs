using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine.Scripts
{
    public static class RenderiteEngineScript
    {
        public static (bool success, Exception exception) ExecuteLine(string line, string project_name, string path)
        {
            string[] lineTokens = line.Trim().Replace("project_name", project_name).Split(' ');
            string parameter = string.Empty;

            for (int i = 1; i < lineTokens.Length; i++)
                parameter += lineTokens[i] + " ";
            parameter = parameter.Trim(new char[] { ' ', '\"' });


            switch (lineTokens[0])
            {
                case "CreateDir":
                    try {
                        Directory.CreateDirectory(path + '/' + parameter);
                        return (true, null);
                    } catch (Exception ex) { return (false, ex); }
                case "CreateProject":
                    try {
                        string projectJson = JsonConvert.SerializeObject(new Project(), Formatting.Indented);
                        File.WriteAllText(path + '/' + parameter + ".rdrt", projectJson);
                        return (true, null);
                    } catch (Exception ex) { return (false, ex); }
                case "CreateLevel":
                    try {
                        string levelJson = JsonConvert.SerializeObject(new Level(), Formatting.Indented);
                        File.WriteAllText(path + '/' + parameter + ".rdlvl", levelJson);
                        return (true, null);
                    } catch (Exception ex) { return (false, ex); }
                case "LoadProject":
                    return ProjectManager.LoadProject(path + '/' + parameter + ".rdrt");
                case "LoadLevel":
                    return ProjectManager.LoadLevel(path + '/' + parameter + ".rdlvl");
                case "LoadStartLevel":
                    {
                        if (ProjectManager.IsProjectOpen)
                            return ProjectManager.LoadLevel (
                                path + '/' + project_name + "/Assets/" + ProjectManager.ProjectData.startingLevel + ".rdlvl"
                            );
                        return (false, new Exception("Error: Project not Open"));
                    }
            }
            return (false, new Exception("Error: Invalid instruction"));
        }
    }
}
