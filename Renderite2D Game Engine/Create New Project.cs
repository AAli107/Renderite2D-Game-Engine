using Renderite2D_Game_Engine.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class Create_New_Project : Renderite2D_Game_Engine.BaseForm
    {
        int projectCodeIndex = 0;
        public readonly string[] createProjectCode =
        { 
            $$""" CreateDir "project_name"                        """,
            $$""" CreateDir "project_name/Assets"                 """,
            $$""" CreateDir "project_name/Build"                  """,
            $$""" CreateProject "project_name/project_name"       """,
            $$""" CreateLevel "project_name/Assets/SampleLevel"   """,
        };

        public Create_New_Project()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            CloseAndGoToPreviousForm();
        }

        private void Create_New_Project_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!IsClosingForms)
                Application.Exit();
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            folderPath_txt.Text = folderBrowserDialog.SelectedPath;
        }

        private void Create_New_Project_Load(object sender, EventArgs e)
        {
            folderPath_txt.Text = WinFormController.projectsFolder;
            folderBrowserDialog.SelectedPath = WinFormController.projectsFolder;
        }

        private void projectName_txt_TextChanged(object sender, EventArgs e)
        {
            UpdateCreateButton();
        }

        bool DoesStringContainInvalidChars(string str)
        {
            foreach (char c in str.ToCharArray())
                if (new string(Path.GetInvalidFileNameChars()).Contains(c)) return true;
            return false;
        }

        bool IsStringOnlyComposedOfChar(string str, char c)
        {
            foreach (char chr in str.ToCharArray())
                if (chr != c) return false;
            return true;
        }

        bool DoesProjectExist(string projectName)
        {
            if (!Directory.Exists(folderPath_txt.Text)) return false;

            foreach (string project in Directory.GetDirectories(folderPath_txt.Text))
            {
                var p = project.Replace('\\', '/').Split('/').LastOrDefault();
                if (p == projectName)
                    foreach (var files in Directory.GetFiles(project))
                        if (files.EndsWith(p + ".rdrt")) return true;
            }
            return false;
        }

        void UpdateCreateButton()
        {
            create_btn.Enabled = CreateClickCondition();
        }

        bool CreateClickCondition()
        {
            return 
                !string.IsNullOrEmpty(projectName_txt.Text) &&
                !string.IsNullOrWhiteSpace(projectName_txt.Text) &&
                !DoesStringContainInvalidChars(projectName_txt.Text) &&
                !IsStringOnlyComposedOfChar(projectName_txt.Text.Replace(" ", ""), '.') &&
                !DoesProjectExist(projectName_txt.Text) &&
                !Directory.Exists(folderPath_txt.Text + "/" + projectName_txt.Text) &&
                 Directory.Exists(folderPath_txt.Text);
        }

        private void Create_New_Project_Shown(object sender, EventArgs e)
        {
            UpdateCreateButton();
        }

        private void folderPath_txt_TextChanged(object sender, EventArgs e)
        {
            UpdateCreateButton();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (CreateClickCondition())
            {
                ProgressWindow pw = new ProgressWindow();
                pw.UpdateEvent += Pw_UpdateEvent;
                DialogResult dr = pw.ShowDialog(this);
                pw.UpdateEvent -= Pw_UpdateEvent;

                if (dr == DialogResult.OK)
                    new LevelEditor().Show();
            }
            else UpdateCreateButton();
        }

        private void Pw_UpdateEvent(ProgressWindow obj)
        {
            if (projectCodeIndex < createProjectCode.Length)
            {
                RenderiteEngineScript.ExecuteLine(createProjectCode[projectCodeIndex], projectName_txt.Text, folderPath_txt.Text);
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
