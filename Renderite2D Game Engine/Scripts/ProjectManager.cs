using Newtonsoft.Json;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine.Scripts
{
    public static class ProjectManager
    {
        public static bool IsProjectOpen { get; private set; }
        public static string ProjectName { get; private set; }
        public static string ProjectPath { get; private set; }
        public static string CurrentLevelPath { get; private set; }
        public static Project ProjectData { get; private set; }
        public static Level CurrentLevelData { get; private set; }

        public static bool LoadLevel(string levelPath)
        {
            if (!IsProjectOpen) return false;

            try {
                var settings = new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                };
                CurrentLevelData = JsonConvert.DeserializeObject<Level>(File.ReadAllText(levelPath), settings);
                CurrentLevelPath = levelPath;
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid or Corrupt Level File...\n" + ex.Message,
                    "Level Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool LoadProject(string projectPath)
        {
            try
            {
                var settings = new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                };
                ProjectData = JsonConvert.DeserializeObject<Project>(File.ReadAllText(projectPath), settings);
                ProjectPath = projectPath;
                ProjectName = Path.GetFileNameWithoutExtension(projectPath);
                IsProjectOpen = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid or Corrupt Level File...\n" + ex.Message,
                    "Level Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CloseProject()
        {
            if (IsProjectOpen)
            {
                IsProjectOpen = false;
                ProjectName = null;
                ProjectPath = null;
                CurrentLevelPath = null;
                ProjectData = default;
                CurrentLevelData = default;
            }
        }

    }
}
