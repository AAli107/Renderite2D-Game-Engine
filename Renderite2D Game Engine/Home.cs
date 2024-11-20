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

        }

        private void newProject_btn_Click(object sender, EventArgs e)
        {
            new Create_New_Project().Show();
        }

        private void openProject_btn_Click(object sender, EventArgs e)
        {
            ProjectManager.SelectAndOpenProject(this);
        }
    }
}
