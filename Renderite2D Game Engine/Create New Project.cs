using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class Create_New_Project : Renderite2D_Game_Engine.BaseForm
    {
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
    }
}
