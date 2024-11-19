using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public UserInteraction userInteraction;

        (int x, int y) currentMousePos = new(0, 0); 
        (double x, double y) viewportPos = new(0, 0);
        (int x, int y) objectOffset = new(0, 0);
        string objectName = string.Empty;

        public LevelEditor()
        {
            InitializeComponent();
            levelData = new();
            AddGameObject("Game Object", new LevelObject());
            AddGameObject("Game Object_1", new LevelObject("GameObject", 100, 100, 2, 1, new()));
            UpdatePropertiesPanel();
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
            string[] items = new string[gameObject_listBox.Items.Count];
            gameObject_listBox.Items.CopyTo(items, 0);

            foreach (string name in items)
                if (!levelData.gameObjects.ContainsKey(name))
                    gameObject_listBox.Items.Remove(name);

            foreach (string name in levelData.gameObjects.Keys)
                if (!gameObject_listBox.Items.Contains(name))
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
            string[] controlKeys = new string[levelObjectControls.Count];
            levelObjectControls.Keys.CopyTo(controlKeys, 0);
            foreach (var key in controlKeys)
            {
                if (!levelData.gameObjects.ContainsKey(key) ||
                    Math.Abs(levelData.gameObjects[key].x - ViewportPos.x) > levelViewport_panel.Width / 2 ||
                    Math.Abs(levelData.gameObjects[key].y - ViewportPos.y) > levelViewport_panel.Height / 2 ||
                    !levelData.gameObjects[key].isEnabled)
                {
                    levelObjectControls[key].MouseDown -= P_MouseDown;
                    P_MouseUp(levelObjectControls[key], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    levelObjectControls[key].MouseUp -= P_MouseUp;
                    levelObjectControls[key].MouseMove -= P_MouseMove;
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
                        if (levelData.gameObjects[item.Key].isEnabled)
                        {
                            var p = new Panel()
                            {
                                Width = (int)item.Value.scaleX * 50,
                                Height = (int)item.Value.scaleY * 50,
                                BackColor = item.Key == (string)gameObject_listBox.SelectedItem ?
                                    Color.FromArgb(128, 255, 128, 0) : Color.Transparent,
                                Location = new Point
                                (
                                    (int)item.Value.x + (levelViewport_panel.Width / 2) - (int)ViewportPos.x,
                                    (int)item.Value.y + (levelViewport_panel.Height / 2) - (int)ViewportPos.y
                                ),
                                BorderStyle = BorderStyle.Fixed3D,
                            };
                            p.MouseDown += P_MouseDown;
                            p.MouseUp += P_MouseUp;
                            p.MouseMove += P_MouseMove;
                            levelObjectControls.Add(item.Key, p);
                            levelViewport_panel.Controls.Add(p);
                        }
                    }
                    else
                    {
                        var control = levelObjectControls[item.Key];
                        control.Width = (int)item.Value.scaleX * 50;
                        control.Height = (int)item.Value.scaleY * 50;
                        control.BackColor = item.Key == (string)gameObject_listBox.SelectedItem ?
                            Color.FromArgb(128, 255, 128, 0) : Color.Transparent;
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

        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (userInteraction == UserInteraction.Object_Drag)
            {
                if (levelData.gameObjects.ContainsKey(objectName))
                {
                    var obj = levelData.gameObjects[objectName];
                    obj.x = (e.X + levelObjectControls[objectName].Location.X) - (levelViewport_panel.Width / 2) + (int)ViewportPos.x - objectOffset.x;
                    obj.y = (e.Y + levelObjectControls[objectName].Location.Y) - (levelViewport_panel.Height / 2) + (int)ViewportPos.y - objectOffset.y;
                    levelData.gameObjects[objectName] = obj;
                }
                else
                {
                    objectOffset = new(0, 0);
                    objectName = string.Empty;
                    userInteraction = UserInteraction.None;
                }
                UpdateViewport();
            }
        }

        private void P_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Panel p &&
                userInteraction == UserInteraction.Object_Drag &&
                e.Button == MouseButtons.Left &&
                levelObjectControls.Values.Contains(p))
            {
                objectOffset = new(0,0);
                objectName = string.Empty;
                userInteraction = UserInteraction.None;
            }
        }

        private void P_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel p &&
                userInteraction == UserInteraction.None &&
                e.Button == MouseButtons.Left &&
                levelObjectControls.Values.Contains(p))
            {
                foreach (var item in levelObjectControls)
                {
                    if (item.Value == p)
                    {
                        objectOffset = new(e.X, e.Y);
                        objectName = item.Key;
                        userInteraction = UserInteraction.Object_Drag;
                        if (gameObject_listBox.Items.Contains(item.Key))
                            gameObject_listBox.SelectedIndex = gameObject_listBox.Items.IndexOf(item.Key);
                    }
                }
            }
        }

        private void levelViewport_panel_Resize(object sender, EventArgs e)
        {
            UpdateViewport();
        }

        private void levelViewport_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                userInteraction = UserInteraction.Moving;
                Console.Beep(1500, 10);
            } 
            else gameObject_listBox.SelectedIndex = -1;
        }

        private void levelViewport_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (userInteraction == UserInteraction.Moving)
                userInteraction = UserInteraction.None;
            if (e.Button == MouseButtons.Middle)
                Console.Beep(1000, 10);
        }

        private void levelViewport_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (userInteraction == UserInteraction.Moving)
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

        private void gameObject_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePropertiesPanel();
            UpdateViewport();
        }

        public void UpdatePropertiesPanel()
        {
            bool validSelection = IsValidSelection();
            properties_panel.Visible = validSelection;
            if (validSelection)
            {
                gameObjectName_label.Text = (string)gameObject_listBox.SelectedItem;
                gameObjectIsEnabled_checkbox.CheckState = levelData.gameObjects[(string)gameObject_listBox.SelectedItem].isEnabled ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        public bool IsValidSelection()
        {
            foreach (string item in levelData.gameObjects.Keys)
            {
                if (item == (string)gameObject_listBox.SelectedItem)
                    return true;
            }
            return false;
        }

        private void gameObjectIsEnabled_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            var obj = levelData.gameObjects[(string)gameObject_listBox.SelectedItem];
            obj.isEnabled = gameObjectIsEnabled_checkbox.Checked;
            levelData.gameObjects[(string)gameObject_listBox.SelectedItem] = obj;
            UpdateViewport();
        }
    }

    public enum UserInteraction
    {
        None,
        Moving,
        Object_Drag,
    }
}
