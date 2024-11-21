using Renderite2D_Game_Engine.Scripts;
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
        public Dictionary<string, Control> levelObjectControls = new();
        public UserInteraction userInteraction;
        public (string name, LevelObject obj)? ClipboardObject 
        {
            get { return clipboardObject; }
            set
            {
                clipboardObject = value;
                pasteObjectToolStripMenuItem.Enabled = ClipboardObject != null;
            }
        }

        (int x, int y) currentMousePos = new(0, 0); 
        (double x, double y) viewportPos = new(0, 0);
        (int x, int y) objectOffset = new(0, 0);
        string objectName = string.Empty;
        (string name, LevelObject obj)? clipboardObject = null;

        public LevelEditor()
        {
            InitializeComponent();
            UpdatePropertiesPanel();
            UpdateViewport();
            ClipboardObject = null;
        }

        public bool AddGameObject(string name, LevelObject gameObject)
        {
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(name.Trim())) return false;
            ProjectManager.CurrentLevelData.gameObjects.Add(name.Trim(), gameObject);
            UpdateGameObjectList();
            return true;
        }

        public bool RemoveGameObject(string name)
        {
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(name.Trim())) return false;
            ProjectManager.CurrentLevelData.gameObjects.Remove(name.Trim()); 
            UpdateGameObjectList();
            return true;
        }

        public void UpdateGameObjectList()
        {
            string[] items = new string[gameObject_listBox.Items.Count];
            gameObject_listBox.Items.CopyTo(items, 0);

            foreach (string name in items)
                if (!ProjectManager.CurrentLevelData.gameObjects.ContainsKey(name))
                    gameObject_listBox.Items.Remove(name);

            foreach (string name in ProjectManager.CurrentLevelData.gameObjects.Keys)
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
            if (ProjectManager.CloseProject())
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
                if (!ProjectManager.CurrentLevelData.gameObjects.ContainsKey(key) ||
                    Math.Abs(ProjectManager.CurrentLevelData.gameObjects[key].x - ViewportPos.x) > levelViewport_panel.Width / 2 ||
                    Math.Abs(ProjectManager.CurrentLevelData.gameObjects[key].y - ViewportPos.y) > levelViewport_panel.Height / 2 ||
                    !ProjectManager.CurrentLevelData.gameObjects[key].isEnabled)
                {
                    levelObjectControls[key].MouseDown -= P_MouseDown;
                    P_MouseUp(levelObjectControls[key], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    levelObjectControls[key].MouseUp -= P_MouseUp;
                    levelObjectControls[key].MouseMove -= P_MouseMove;
                    levelViewport_panel.Controls.Remove(levelObjectControls[key]);
                    levelObjectControls.Remove(key);
                }
            }
            foreach (var item in ProjectManager.CurrentLevelData.gameObjects)
            {
                if (Math.Abs(item.Value.x - ViewportPos.x) < levelViewport_panel.Width / 2 &&
                    Math.Abs(item.Value.y - ViewportPos.y) < levelViewport_panel.Height / 2)
                {
                    var scaleX = (int)(item.Value.scaleX * 50);
                    var scaleY = (int)(item.Value.scaleY * 50);

                    if (!levelObjectControls.ContainsKey(item.Key))
                    {
                        if (ProjectManager.CurrentLevelData.gameObjects[item.Key].isEnabled)
                        {
                            var p = new Panel()
                            {
                                Width = scaleX,
                                Height = scaleY,
                                BackColor = Color.Transparent,
                                ForeColor = item.Key == (string)gameObject_listBox.SelectedItem ?
                                    Color.FromArgb(128, 255, 128, 0) : Color.White,
                                Location = new Point
                                (
                                    (int)item.Value.x + (levelViewport_panel.Width / 2) - (int)ViewportPos.x - (scaleX / 2),
                                    (int)item.Value.y + (levelViewport_panel.Height / 2) - (int)ViewportPos.y - (scaleY / 2)
                                ),
                                BorderStyle = item.Key == (string)gameObject_listBox.SelectedItem ? BorderStyle.Fixed3D : BorderStyle.FixedSingle,
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
                        Panel panel = levelObjectControls[item.Key] as Panel;
                        panel.Width = scaleX;
                        panel.Height = scaleY;
                        panel.BackColor = Color.Transparent;
                        panel.ForeColor = item.Key == (string)gameObject_listBox.SelectedItem ?
                            Color.FromArgb(128, 255, 128, 0) : Color.White;
                        panel.Location = new Point
                        (
                            (int)item.Value.x + (levelViewport_panel.Width / 2) - (int)ViewportPos.x - (scaleX / 2),
                            (int)item.Value.y + (levelViewport_panel.Height / 2) - (int)ViewportPos.y - (scaleY / 2)
                        );
                        panel.BorderStyle = item.Key == (string)gameObject_listBox.SelectedItem ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
                    }
                }
            }
            viewportCoords_label.Text = "Looking at " + new Vector2((float)viewportPos.x, (float)viewportPos.y).ToString();
        }

        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (userInteraction == UserInteraction.Object_Drag)
            {
                if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(objectName))
                {
                    var obj = ProjectManager.CurrentLevelData.gameObjects[objectName];
                    obj.x = (e.X + levelObjectControls[objectName].Location.X) - (levelViewport_panel.Width / 2) + (int)ViewportPos.x - objectOffset.x + ((int)(obj.scaleX * 50) / 2);
                    obj.y = (e.Y + levelObjectControls[objectName].Location.Y) - (levelViewport_panel.Height / 2) + (int)ViewportPos.y - objectOffset.y + ((int)(obj.scaleY * 50) / 2);
                    ProjectManager.CurrentLevelData.gameObjects[objectName] = obj;
                }
                else
                {
                    objectOffset = new(0, 0);
                    objectName = string.Empty;
                    userInteraction = UserInteraction.None;
                }
                UpdatePropertiesPanel();
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
            while (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(gameObjectName))
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
                gameObjectIsEnabled_checkbox.CheckState = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem].isEnabled ? CheckState.Checked : CheckState.Unchecked;
                posX_num.Value = (decimal)ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem].x;
                posY_num.Value = (decimal)ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem].y;
                scaleX_num.Value = (decimal)ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem].scaleX;
                scaleY_num.Value = (decimal)ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem].scaleY;
            }
        }

        public bool IsValidSelection()
        {
            foreach (string item in ProjectManager.CurrentLevelData.gameObjects.Keys)
            {
                if (item == (string)gameObject_listBox.SelectedItem)
                    return true;
            }
            return false;
        }

        private void gameObjectIsEnabled_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            var obj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
            obj.isEnabled = gameObjectIsEnabled_checkbox.Checked;
            ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem] = obj;
            UpdateViewport();
        }

        private void posX_num_ValueChanged(object sender, EventArgs e)
        {
            var obj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
            obj.x = (double)posX_num.Value;
            ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem] = obj;
            UpdateViewport();
        }

        private void posY_num_ValueChanged(object sender, EventArgs e)
        {
            var obj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
            obj.y = (double)posY_num.Value;
            ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem] = obj;
            UpdateViewport();
        }

        private void scaleX_num_ValueChanged(object sender, EventArgs e)
        {
            var obj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
            obj.scaleX = (double)scaleX_num.Value;
            ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem] = obj;
            UpdateViewport();
        }

        private void scaleY_num_ValueChanged(object sender, EventArgs e)
        {
            var obj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
            obj.scaleY = (double)scaleY_num.Value;
            ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem] = obj;
            UpdateViewport();
        }

        private void deleteGameObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsValidSelection())
            {
                ProjectManager.CurrentLevelData.gameObjects.Remove((string)gameObject_listBox.SelectedItem);
                gameObject_listBox.SelectedIndex = -1;
                UpdateGameObjectList();
            }
        }

        private void copyObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsValidSelection())
            {
                var name = (string)gameObject_listBox.SelectedItem;
                ClipboardObject = new (name, ProjectManager.CurrentLevelData.gameObjects[name]);
            }
        }

        private void pasteObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClipboardObject != null)
            {
                string gameObjectBaseName = ClipboardObject.Value.name;
                int index = 0;
                string gameObjectName;

                gameObjectName = gameObjectBaseName;
                while (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(gameObjectName))
                {
                    index++;
                    gameObjectName = gameObjectBaseName + "_" + index;
                }
                LevelObject obj = ClipboardObject.Value.obj;
                obj.x = viewportPos.x;
                obj.y = viewportPos.y;
                AddGameObject(gameObjectName, obj);
                UpdateViewport();
                gameObject_listBox.SelectedIndex = gameObject_listBox.Items.IndexOf(gameObjectName);
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectManager.SelectAndOpenProject(this);
        }
    }

    public enum UserInteraction
    {
        None,
        Moving,
        Object_Drag,
    }
}
