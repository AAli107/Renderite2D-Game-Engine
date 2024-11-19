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
        public Dictionary<string, Control> levelObjectControls = new();
        public bool isMoving;

        (int x, int y) currentMousePos = new(0, 0); 
        (double x, double y) viewportPos = new(0, 0);

        public LevelEditor()
        {
            InitializeComponent();
            levelData = new();
            AddGameObject("Game Object", new LevelObject());
            AddGameObject("Game Object_1", new LevelObject("GameObject", 100, 100, 2, 1, new()));
            UpdateViewport();
        }

        public bool AddGameObject(string name, LevelObject gameObject)
        {
            if (levelData.gameObjects.ContainsKey(name.Trim())) return false;
            levelData.gameObjects.Add(name.Trim(), gameObject);
            UpdateGameObjectList();
            return true;
        }

        public bool RemoveGameObject(string name)
        {
            if (levelData.gameObjects.ContainsKey(name.Trim())) return false;
            levelData.gameObjects.Remove(name.Trim()); 
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
            string[] controlKeys = new string[levelObjectControls.Count];
            levelObjectControls.Keys.CopyTo(controlKeys, 0);
            foreach (var key in controlKeys)
            {
                if (!levelData.gameObjects.ContainsKey(key) ||
                    Math.Abs(levelData.gameObjects[key].x - ViewportPos.x) > levelViewport_panel.Width / 2 ||
                    Math.Abs(levelData.gameObjects[key].y - ViewportPos.y) > levelViewport_panel.Height / 2)
                {
                    levelViewport_panel.Controls.Remove(levelObjectControls[key]);
                    levelObjectControls.Remove(key);
                }
            }
            foreach (var item in levelData.gameObjects)
            {
                if (Math.Abs(item.Value.x - ViewportPos.x) < levelViewport_panel.Width / 2 &&
                    Math.Abs(item.Value.y - ViewportPos.y) < levelViewport_panel.Height / 2)
                {
                    if (!levelObjectControls.ContainsKey(item.Key))
                    {
                        var p = new Panel()
                        {
                            Width = (int)item.Value.scaleX * 50,
                            Height = (int)item.Value.scaleY * 50,
                            Location = new Point
                            (
                                (int)item.Value.x + (levelViewport_panel.Width / 2) - (int)ViewportPos.x,
                                (int)item.Value.y + (levelViewport_panel.Height / 2) - (int)ViewportPos.y
                            ),
                            BorderStyle = BorderStyle.Fixed3D,
                            BackColor = Color.Transparent
                        };
                        levelObjectControls.Add(item.Key, p);
                        levelViewport_panel.Controls.Add(p);
                    }
                    else
                    {
                        var control = levelObjectControls[item.Key];
                        control.Width = (int)item.Value.scaleX * 50;
                        control.Height = (int)item.Value.scaleY * 50;
                        control.Location = new Point
                        (
                            (int)item.Value.x + (levelViewport_panel.Width / 2) - (int)ViewportPos.x,
                            (int)item.Value.y + (levelViewport_panel.Height / 2) - (int)ViewportPos.y
                        );
                    }
                }
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

        private void addObject_btn_Click(object sender, EventArgs e)
        {
            string gameObjectBaseName = "Game Object";
            int index = 0;
            string gameObjectName;

            gameObjectName = gameObjectBaseName;
            while (levelData.gameObjects.ContainsKey(gameObjectName))
            {
                index++;
                gameObjectName = gameObjectBaseName + "_" + index;
            }
            AddGameObject(gameObjectName, new LevelObject("GameObject", ViewportPos.x, ViewportPos.y, 1, 1, new()));
            UpdateViewport();
        }
    }

}
