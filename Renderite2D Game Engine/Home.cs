using Newtonsoft.Json;
using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class Home : BaseForm
    {
        int k = 0;

        public Home()
        {
            InitializeComponent();
            WinFormController.startingForm = this;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            WinFormController.startingForm ??= this;

            if (!Directory.Exists(WinFormController.projectsFolder))
                Directory.CreateDirectory(WinFormController.projectsFolder);

            openFileDialog.Title = "Open Renderite2D Project";
            openFileDialog.Filter = "Renderite2D Project file (*.rdrt)|*.rdrt";
            openFileDialog.InitialDirectory = WinFormController.projectsFolder.Replace('/', '\\');
        }

        private void newProject_btn_Click(object sender, EventArgs e)
        {
            new Create_New_Project().Show();
        }

        private void openProject_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var settings = new JsonSerializerSettings()
                    {
                        MissingMemberHandling = MissingMemberHandling.Error,
                    };
                    var p = JsonConvert.DeserializeObject<Project>(File.ReadAllText(openFileDialog.FileName), settings);

                    ProgressWindow pw = new();
                    pw.UpdateEvent += Pw_UpdateEvent;
                    DialogResult dr = pw.ShowDialog(this);
                    pw.UpdateEvent -= Pw_UpdateEvent;

                    if (dr == DialogResult.OK)
                        new LevelEditor().Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid or Corrupt Project File...\n" + ex.Message, 
                        "Project Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void Pw_UpdateEvent(ProgressWindow obj)
        {
            // TODO : Load in the project


            if (k > 100) // Test code for finishing
            {
                obj.Finish();
                k = 0;
            }
            k++;
        }
    }
}
