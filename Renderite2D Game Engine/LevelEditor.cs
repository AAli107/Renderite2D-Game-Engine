using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class LevelEditor : Renderite2D_Game_Engine.BaseForm
    {
        public (double x, double y) viewportPos = new(0, 0);
        public Level levelData;

        public LevelEditor()
        {
            InitializeComponent();
            levelData = new();
            levelData.gameObjects.Add(new LevelObject());
            UpdateViewport();
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LevelEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!IsClosingForms)
                Application.Exit();
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAndGoHome();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Create_New_Project().Show(this);
        }

        public void UpdateViewport()
        {
            //levelViewport_panel.Controls;
            Control[] controls = new Control[levelViewport_panel.Controls.Count];
            levelViewport_panel.Controls.CopyTo(controls, 0);
            foreach (Control item in controls)
            {
                if (item == addObject_btn) continue;
                levelViewport_panel.Controls.Remove(item);
            }
            foreach (LevelObject obj in levelData.gameObjects)
            {
                levelViewport_panel.Controls.Add(new Panel()
                {
                    Width = (int)obj.scaleX * 50,
                    Height = (int)obj.scaleY * 50,
                    Location = new Point
                    (
                        (int)obj.x + (levelViewport_panel.Width / 2) - (int)viewportPos.x,
                        (int)obj.y + (levelViewport_panel.Height / 2) - (int)viewportPos.y
                    ),
                    BorderStyle = BorderStyle.FixedSingle,
                });
            }
        }

        private void levelViewport_panel_Resize(object sender, EventArgs e)
        {
            UpdateViewport();
        }
    }

}
