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
        public static bool IsOpeningProject { get; private set; }
        public static bool IsProjectOpen { get; private set; }
        public static string ProjectName { get; private set; }
        public static string ProjectPath { get; private set; }
        public static string ProjectParentFolder { get; private set; }
        public static string CurrentLevelPath { get; private set; }
        public static Project ProjectData { get; private set; }
        public static Level CurrentLevelData { get; private set; }


        private static readonly string[] postLoadProjectCode =
        {
            $$""" LoadStartLevel "" """,
        };
        private static int projectCodeIndex = 0;

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
                ProjectParentFolder = Directory.GetParent(Path.GetDirectoryName(projectPath)).FullName;
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
                ProjectPath = null;
                ProjectName = null;
                ProjectParentFolder = null;
                CurrentLevelPath = null;
                ProjectData = default;
                CurrentLevelData = default;
            }
        }

        public static void SelectAndOpenProject(IWin32Window parentWindow)
        {
            if (!IsOpeningProject)
            {
                IsOpeningProject = true;
                OpenFileDialog openFileDialog = new()
                {
                    Title = "Open Renderite2D Project",
                    Filter = "Renderite2D Project file (*.rdrt)|*.rdrt",
                    InitialDirectory = WinFormController.projectsFolder.Replace('/', '\\')
                };

                if (openFileDialog.ShowDialog(parentWindow) == DialogResult.OK)
                {
                    if (LoadProject(openFileDialog.FileName))
                    {
                        ProgressWindow pw = new();
                        pw.UpdateEvent += Pw_UpdateEvent;
                        DialogResult dr = pw.ShowDialog(parentWindow);
                        pw.UpdateEvent -= Pw_UpdateEvent;

                        if (dr == DialogResult.OK)
                            new LevelEditor().Show();
                        else MessageBox.Show("Failed to Load Project...", "Loading Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                IsOpeningProject = false;
            }
        }

        private static void Pw_UpdateEvent(ProgressWindow obj)
        {
            if (projectCodeIndex < postLoadProjectCode.Length)
            {
                if (!RenderiteEngineScript.ExecuteLine(postLoadProjectCode[projectCodeIndex],
                    ProjectName, ProjectParentFolder))
                {
                    projectCodeIndex = 0;
                    obj.DialogResult = DialogResult.Cancel;
                }

                projectCodeIndex++;
            }
            else
            {
                projectCodeIndex = 0;
                obj.Finish();
            }
        }

    }
}
