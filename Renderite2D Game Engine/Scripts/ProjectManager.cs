using Newtonsoft.Json;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine.Scripts
{
    public static class ProjectManager
    {
        public static bool IsProjectOpen { get; private set; }
        public static bool IsOpeningProject { get; private set; }
        public static bool IsProjectChanged 
        { get { return !CurrentLevelData.Equals(originalLevelData) || !ProjectData.Equals(originalProjectData); } }
        public static string ProjectName { get; private set; }
        public static string ProjectPath { get; private set; }
        public static string ProjectParentFolder { get; private set; }
        public static string CurrentLevelPath { get; private set; }
        public static Project ProjectData { get; private set; }
        public static Level CurrentLevelData { get; private set; }


        private static Project originalProjectData;
        private static Level originalLevelData;
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
                originalLevelData = JsonConvert.DeserializeObject<Level>(File.ReadAllText(levelPath), settings);
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
                originalProjectData = JsonConvert.DeserializeObject<Project>(File.ReadAllText(projectPath), settings);
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

        public static bool CloseProject()
        {
            if (IsProjectOpen)
            {
                bool allowClosure = true;
                if (IsProjectChanged)
                {
                    DialogResult result = MessageBox.Show("Do you want to save your project before Leaving?",
                        ProjectName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            allowClosure = true;
                            SaveProjectFiles();
                            break;
                        case DialogResult.No:
                            allowClosure = true;
                            break;
                        case DialogResult.Cancel:
                            allowClosure = false;
                            break;
                    }
                }
                if (allowClosure)
                {
                    IsProjectOpen = false;
                    ProjectPath = null;
                    ProjectName = null;
                    ProjectParentFolder = null;
                    CurrentLevelPath = null;
                    ProjectData = default;
                    CurrentLevelData = default;
                    originalLevelData = default;
                    originalProjectData = default;
                    return true;
                }
            }
            return false;
        }

        public static void SaveProjectFiles()
        {
            if (IsProjectOpen)
            {
                ProgressWindow pwSave = new();
                pwSave.Show();
                pwSave.Refresh();
                try {
                    string projectJson = string.Empty;
                    string levelJson = string.Empty;
                    JsonSerializerSettings settings = null;
                    pwSave.Refresh();

                    for (int i = 0; i < 7; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                projectJson = JsonConvert.SerializeObject(ProjectData, Formatting.Indented);
                                break;
                            case 1:
                                levelJson = JsonConvert.SerializeObject(CurrentLevelData, Formatting.Indented);
                                break;
                            case 2:
                                File.WriteAllText(ProjectPath, projectJson);
                                break;
                            case 3:
                                File.WriteAllText(CurrentLevelPath, levelJson);
                                break;
                            case 4:
                                settings = new JsonSerializerSettings()
                                {
                                    MissingMemberHandling = MissingMemberHandling.Error,
                                };
                                break;
                            case 5: 
                                originalLevelData = JsonConvert.DeserializeObject<Level>(levelJson, settings);
                                break;
                            case 6:
                                originalProjectData = JsonConvert.DeserializeObject<Project>(projectJson, settings);
                                break;
                        }
                        pwSave.Refresh();
                        Thread.Sleep(1);
                    }
                    pwSave.Close();
                } 
                catch (Exception ex)
                {
                    pwSave.Close();
                    MessageBox.Show("Failed to Save Project...\n\n" + ex.Message, "Save Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                        ProgressWindow pwOpen = new();
                        pwOpen.UpdateEvent += PwOpen_UpdateEvent;
                        DialogResult dr = pwOpen.ShowDialog(parentWindow);
                        pwOpen.UpdateEvent -= PwOpen_UpdateEvent;

                        if (dr == DialogResult.OK)
                            new LevelEditor().Show();
                        else MessageBox.Show("Failed to Load Project...", "Loading Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                IsOpeningProject = false;
            }
        }

        private static void PwOpen_UpdateEvent(ProgressWindow obj)
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
