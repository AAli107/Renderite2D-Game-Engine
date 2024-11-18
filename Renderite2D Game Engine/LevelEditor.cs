using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class LevelEditor : Renderite2D_Game_Engine.BaseForm
    {
        public (double x, double y) ViewportPos 
        { 
            get { return viewportPos; }
            set
            {
                viewportPos = value;
                UpdateViewport();
            }
        }
        public Level levelData;
        public bool isMoving;

        (int x, int y) currentMousePos = new(0, 0); 
        (double x, double y) viewportPos = new(0, 0);

        public LevelEditor()
        {
            InitializeComponent();
            levelData = new();
            AddGameObject("Game Object 1", new LevelObject());
            AddGameObject("Game Object 2", new LevelObject("GameObject", 100, 100, 2, 1, new()));
            UpdateViewport();
        }

        public bool AddGameObject(string name, LevelObject gameObject)
        {
            if (levelData.gameObjects.ContainsKey(name)) return false;
            levelData.gameObjects.Add(name, gameObject);
            UpdateGameObjectList();
            return true;
        }

        public bool RemoveGameObject(string name)
        {
            if (levelData.gameObjects.ContainsKey(name)) return false;
            levelData.gameObjects.Remove(name); 
            UpdateGameObjectList();
            return true;
        }

        public void UpdateGameObjectList()
        {
            gameObject_listBox.Items.Clear();

            foreach (string name in levelData.gameObjects.Keys)
                gameObject_listBox.Items.Add(name);
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
                if (item == viewportGUI_panel) continue;
                levelViewport_panel.Controls.Remove(item);
            }
            foreach (LevelObject obj in levelData.gameObjects.Values)
            {
                if (Math.Abs(obj.x - ViewportPos.x) > levelViewport_panel.Width / 2 ||
                    Math.Abs(obj.y - ViewportPos.y) > levelViewport_panel.Height / 2
                    ) continue;
                levelViewport_panel.Controls.Add(new Panel()
                {
                    Width = (int)obj.scaleX * 50,
                    Height = (int)obj.scaleY * 50,
                    Location = new Point
                    (
                        (int)obj.x + (levelViewport_panel.Width / 2) - (int)ViewportPos.x,
                        (int)obj.y + (levelViewport_panel.Height / 2) - (int)ViewportPos.y
                    ),
                    BorderStyle = BorderStyle.Fixed3D,
                });
            }
            viewportCoords_label.Text = "Looking at " + new Vector2((float)viewportPos.x, (float)viewportPos.y).ToString();
        }

        private void levelViewport_panel_Resize(object sender, EventArgs e)
        {
            UpdateViewport();
        }

        private void levelViewport_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isMoving = true;
                Console.Beep(1500, 10);
            }
        }

        private void levelViewport_panel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
            if (e.Button == MouseButtons.Middle)
                Console.Beep(1000, 10);
        }

        private void levelViewport_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                (double x, double y) deltaDir = new(
                    currentMousePos.x - e.Location.X,
                    currentMousePos.y - e.Location.Y
                );

                ViewportPos = new(ViewportPos.x + deltaDir.x, ViewportPos.y + deltaDir.y);
            }
            currentMousePos = new(e.Location.X, e.Location.Y);
        }
    }

}
