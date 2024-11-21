using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class ProjectSettingsMenu : Form
    {
        Project projectData;
        string[] foundLevels;

        public ProjectSettingsMenu()
        {
            InitializeComponent();
            if (ProjectManager.IsProjectOpen)
            {
                projectData = new(ProjectManager.ProjectData);

                foundLevels = Directory.GetFiles(ProjectManager.AssetsPath, "*.rdlvl", SearchOption.AllDirectories);

                startingLevel.Items.Clear();
                Uri uriAssets = new((ProjectManager.AssetsPath + '\\').Replace('/', '\\'));
                foreach (string level in foundLevels)
                {
                    string lvl = Path.ChangeExtension(Uri.UnescapeDataString(uriAssets.MakeRelativeUri( new Uri(level)).ToString()), "");
                    lvl = lvl.Remove(lvl.Length - 1);
                    startingLevel.Items.Add(lvl);
                }
                var ve = projectData.vSyncEnabled;
                var rx = projectData.resolutionX;
                var ry = projectData.resolutionY;
                var wr = projectData.isWindowResizeable;
                var wt = projectData.windowTitle;
                var uf = projectData.fixedUpdateFrequency;
                var ws = projectData.windowState;
                var sl = projectData.startingLevel;
                var dc = projectData.drawColliders;
                var ae = projectData.allowAltEnter;
                resolutionX.Value = rx;
                resolutionY.Value = ry;
                vSyncEnabled.Checked = ve;
                isWindowResizeable.Checked = wr;
                windowTitle.Text = wt;
                fixedUpdateFrequency.Value = (decimal)uf;
                windowState.SelectedIndex = ws;
                startingLevel.SelectedItem = sl;
                drawColliders.Checked = dc;
                allowAltEnter.Checked = ae;

                InsertProjectData();
            }
            else
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InsertProjectData();
            ProjectManager.SetProjectData(projectData);
            DialogResult = DialogResult.OK;
            Close();
        }

        void InsertProjectData()
        {
            projectData.resolutionX = (int)resolutionX.Value;
            projectData.resolutionY = (int)resolutionY.Value;
            projectData.vSyncEnabled = vSyncEnabled.Checked;
            projectData.isWindowResizeable = isWindowResizeable.Checked;
            projectData.windowTitle = windowTitle.Text;
            projectData.fixedUpdateFrequency = (double)fixedUpdateFrequency.Value;
            projectData.windowState = windowState.SelectedIndex;
            projectData.startingLevel = (string)startingLevel.SelectedItem;
            projectData.drawColliders = drawColliders.Checked;
            projectData.allowAltEnter = allowAltEnter.Checked;
        }

        private void resolutionX_ValueChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void resolutionY_ValueChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void vSyncEnabled_CheckedChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void isWindowResizeable_CheckedChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void windowTitle_TextChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void fixedUpdateFrequency_ValueChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void startingLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void drawColliders_CheckedChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }

        private void allowAltEnter_CheckedChanged(object sender, EventArgs e)
        {
            InsertProjectData();
        }
    }
}
