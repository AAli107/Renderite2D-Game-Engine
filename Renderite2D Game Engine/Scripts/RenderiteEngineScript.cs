using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Renderite2D_Game_Engine.Scripts
{
    public static class RenderiteEngineScript
    {
        public static void ExecuteLine(string line, string project_name, string path)
        {
            string[] lineTokens = line.Trim().Replace("project_name", project_name).Split(' ');
            string parameter = string.Empty;

            for (int i = 1; i < lineTokens.Length; i++)
                parameter += lineTokens[i] + " ";
            parameter = parameter.Trim(new char[] { ' ', '\"' });


            switch (lineTokens[0])
            {
                case "CreateDir":
                    {
                        Directory.CreateDirectory(path + '/' + parameter);
                    }
                    break;
                case "CreateProject":
                    {
                        string projectJson = JsonConvert.SerializeObject(new Project(), Formatting.Indented);
                        File.WriteAllText(path + '/' + parameter + ".rdrt", projectJson);
                    }
                    break;
                case "CreateLevel":
                    {
                        string levelJson = JsonConvert.SerializeObject(new Level(), Formatting.Indented);
                        File.WriteAllText(path + '/' + parameter + ".json", levelJson);
                    }
                    break;
            }
        }
    }
}
