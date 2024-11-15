using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class Home : BaseForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (WinFormController.startingForm == null)
                WinFormController.startingForm = this;

            if (!Directory.Exists(WinFormController.projectsFolder))
                Directory.CreateDirectory(WinFormController.projectsFolder);

            folderBrowserDialog.SelectedPath = WinFormController.projectsFolder;
        }

        private void newProject_btn_Click(object sender, EventArgs e)
        {
            new Create_New_Project().Show();
        }

        private void openProject_btn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                // TODO : Open Project
                new LevelEditor().Show();
            }
        }
    }
}
