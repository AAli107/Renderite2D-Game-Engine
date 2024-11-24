using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
        public string assetBrowserPath = "";

        (int x, int y) currentMousePos = new(0, 0); 
        (double x, double y) viewportPos = new(0, 0);
        (int x, int y) objectOffset = new(0, 0);
        string objectName = string.Empty;
        (string name, LevelObject obj)? clipboardObject = null;
        readonly Dictionary<string, (bool isDirectory, string name, Point location)> currentDirContents = new();

        public LevelEditor()
        {
            if (!ProjectManager.IsProjectOpen || ProjectManager.CurrentLevelData.gameObjects == null)
            {
                CloseAndGoHome();
                return;
            }
            InitializeComponent();
            UpdateGameObjectList();
            UpdatePropertiesPanel();
            UpdateAssetDirectory();
            UpdateViewport();
            ClipboardObject = null;
        }


        public void UpdateAssetDirectory()
        {
            if (assets_panel.Width == 0) return;

            string dir = ProjectManager.AssetsPath + '\\' + assetBrowserPath;

            if (!Directory.Exists(dir))
            {
                assetBrowserPath = string.Empty;
                dir = ProjectManager.AssetsPath + '\\' + assetBrowserPath;
            }

            string[] p = ("Assets/" + assetBrowserPath).Replace('\\', '/').Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            currentAssetPath_menuStrip.Items.Clear();
            for (int i = 0; i < p.Length; i++)
            {
                var pathSegment = new ToolStripMenuItem(p[i] + "    /")
                {
                    ForeColor = Color.White,
                    Font = new Font(Font.FontFamily, 16, FontStyle.Regular),
                    Margin = new Padding(0, 0, 0, 0),
                    Name = p[i],
                };
                pathSegment.Click += PathSegment_Click;
                currentAssetPath_menuStrip.Items.Add(pathSegment);
            }

            {
                currentDirContents.Clear();
                var dirs = Directory.EnumerateDirectories(dir);
                var files = Directory.EnumerateFiles(dir);
                var entries = dirs.Concat(files).ToArray();
                int i = 0;
                foreach (var entry in entries)
                {
                    currentDirContents.Add(entry, new(dirs.Contains(entry), entry.Replace(dir, "").Trim('\\'), 
                        new (
                            ((i % (assets_panel.Width / 80)) * 80) + 8,
                            (i / (assets_panel.Width / 80)) * 80
                        )));
                    i++;
                }
            }

            assets_panel.Controls.Clear();

            (bool isDirectory, string name, Point location)[] values = new (bool isDirectory, string name, Point location)[currentDirContents.Values.Count];
            currentDirContents.Values.CopyTo(values, 0);
            var keys = currentDirContents.Keys.ToArray();
            int cdc_index = 0;
            foreach (var (isDirectory, name, location) in values)
            {
                Panel entry_panel = new() 
                {
                    Location = location,
                    Width = 64,
                    Height = 64,
                    BackColor = Color.Transparent,
                    BackgroundImage =
                    isDirectory ? Properties.Resources.icon_folder : (
                    IsImageFile(name) ? Properties.Resources.icon_picture : (
                    IsScriptFile(name) ? Properties.Resources.icon_code : (
                    IsLevelFile(name) ? Properties.Resources.icon_level : (
                    IsAudioFile(name) ? Properties.Resources.icon_audio :
                    Properties.Resources.icon_file)))),
                    Name = keys[cdc_index],
                };
                entry_panel.DoubleClick += Entry_panel_DoubleClick;
                assets_panel.Controls.Add(entry_panel);
                assets_panel.Controls.Add(
                    new Label() {
                        AutoSize = false,
                        Location = new Point(entry_panel.Location.X - (isDirectory ? 10 : 8), entry_panel.Location.Y + 64),
                        Width = 80,
                        Height = 24,
                        Font = new Font(Font.FontFamily, 8, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        UseCompatibleTextRendering = true,
                        Text = name.Trim(),
                        ForeColor = Color.White,
                        BackColor = Color.Transparent,
                    }
                );
                cdc_index++;
            }

            assets_panel.AutoScroll = false;
            assets_panel.HorizontalScroll.Enabled = false;
            assets_panel.HorizontalScroll.Visible = false;
            assets_panel.HorizontalScroll.Maximum = 0;
            assets_panel.VerticalScroll.Enabled = true;
            assets_panel.VerticalScroll.Visible = true;
            assets_panel.AutoScroll = true;
        }

        private void Entry_panel_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Panel p)
            {
                if (File.Exists(p.Name))
                {
                    if (p.Name.EndsWith(".rdlvl"))
                    {
                        bool allowLevelChange = true;
                        if (ProjectManager.IsProjectChanged)
                        {
                            DialogResult result = MessageBox.Show("Do you want to save your project before Leaving?",
                                ProjectManager.ProjectName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                            switch (result)
                            {
                                case DialogResult.Yes:
                                    allowLevelChange = true;
                                    ProjectManager.SaveProjectFiles(this);
                                    break;
                                case DialogResult.No:
                                    allowLevelChange = true;
                                    break;
                                case DialogResult.Cancel:
                                    allowLevelChange = false;
                                    break;
                            }
                        }
                        if (allowLevelChange)
                        {
                            var (success, exception) = ProjectManager.LoadLevel(p.Name);
                            if (success)
                            {
                                objectOffset = new(0, 0);
                                objectName = string.Empty;
                                userInteraction = UserInteraction.None;

                                UpdateGameObjectList();
                                UpdatePropertiesPanel();
                                UpdateViewport();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "[Message] " + exception.Message + "\n\n" +
                                    "[Source] " + exception.Source + "\n\n" +
                                    "[Stack Trace]\n" + exception.StackTrace,
                                    "Exception Caught!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else Process.Start(p.Name);
                } 
                else if (Directory.Exists(p.Name))
                {
                    assetBrowserPath = p.Name.Replace(ProjectManager.AssetsPath, "").Replace('/', '\\').Trim('\\');
                    UpdateAssetDirectory();
                }

            }
        }

        private void PathSegment_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string localPath = "";
                for (int i = 0; i < currentAssetPath_menuStrip.Items.Count; i++)
                {
                    if (i > 0)
                        localPath += currentAssetPath_menuStrip.Items[i].Name + '/';
                    if (currentAssetPath_menuStrip.Items[i].Name == tsmi.Name)
                        break;
                }
                assetBrowserPath = localPath;
                UpdateAssetDirectory();
            }
        }

        public static bool IsAudioFile(string path)
        {
            return
                path.EndsWith(".mp3") ||
                path.EndsWith(".wav");
        }

        public static bool IsLevelFile(string path)
        {
            return path.EndsWith(".rdlvl");
        }

        public static bool IsScriptFile(string path)
        {
            return path.EndsWith(".cs");
        }

        public static bool IsImageFile(string path)
        {
            return 
                path.EndsWith(".png")   ||
                path.EndsWith(".jpg")   ||
                path.EndsWith(".jpeg")  ||
                path.EndsWith(".bmp");
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
            if (ProjectManager.CloseProject(this))
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
                var selectedObj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
                gameObjectName_label.Text = (string)gameObject_listBox.SelectedItem;
                gameObjectIsEnabled_checkbox.CheckState = selectedObj.isEnabled ? CheckState.Checked : CheckState.Unchecked;
                posX_num.Value = (decimal)selectedObj.x;
                posY_num.Value = (decimal)selectedObj.y;
                scaleX_num.Value = (decimal)selectedObj.scaleX;
                scaleY_num.Value = (decimal)selectedObj.scaleY;

                componentsPanel.Controls.Clear();

                int index = 0;
                int height = 0;
                foreach (var item in selectedObj.components.ToArray())
                {
                    Component_Properties componentPanel = null;
                    
                    Point loc = new(8, height);

                    switch (item.Value.componentType)
                    {
                        case "ColliderComponent":
                            componentPanel = new ColliderComponentProperties(this, item.Key) { Location = loc, };
                            break;
                        case "AudioComponent":
                            componentPanel = new AudioComponentProperties(this, item.Key) { Location = loc, };
                            break;
                        case "PhysicsComponent":
                            componentPanel = new PhysicsComponentProperties(this, item.Key) { Location = loc, };
                            break;
                        case "ScriptComponent":
                            componentPanel = new ScriptComponentProperties(this, item.Key) { Location = loc, };
                            break;
                    }

                    if (componentPanel == null) continue;

                    height += componentPanel.GetHeight() + 16;

                    componentsPanel.Controls.Add(componentPanel);
                    index++;
                }
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

        private void LevelEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsClosingForms)
                e.Cancel = !ProjectManager.CloseProject(this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProjectFiles(this);
        }

        private void projectSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectSettingsMenu().ShowDialog(this);
        }

        private void assets_panel_Resize(object sender, EventArgs e)
        {
            if (assets_panel.Width == 0) return;

            bool shouldUpdate = false;

            int i = 0;
            foreach (var item in currentDirContents.Values)
            {
                if (item.location != new Point(
                            ((i % (assets_panel.Width / 80)) * 80) + 8,
                            (i / (assets_panel.Width / 80)) * 80
                        )
                    )
                {
                    shouldUpdate = true; 
                    break;
                }
                i++;
            }

            if (shouldUpdate)
                UpdateAssetDirectory();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileD = new()
            {
                Filter = "All files (*.*)|*.*",
                Title = "Import Asset Files",
                Multiselect = true
            };

            if (fileD.ShowDialog(this) == DialogResult.OK)
            {
                for (int i = 0; i < fileD.FileNames.Length; i++)
                {
                    try
                    {
                        string importFilePath = (ProjectManager.AssetsPath + '\\' + assetBrowserPath + '\\' + 
                            Path.GetFileName(fileD.FileNames[i])).Replace('/', '\\');

                        File.Copy(fileD.FileNames[i], importFilePath, true);
                        UpdateAssetDirectory();
                    } 
                    catch (Exception ex) 
                    {
                        MessageBox.Show(
                            "[Message] " + ex.Message + "\n\n" +
                            "[Source] " + ex.Source + "\n\n" +
                            "[Stack Trace]\n" + ex.StackTrace,
                            "Exception Caught!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public string AddComponentToObject(string componentType, string objectName, Dictionary<string, object> values)
        {
            values ??= new();

            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(objectName))
            {
                var obj = ProjectManager.CurrentLevelData.gameObjects[objectName];
                string id = Guid.NewGuid().ToString();
                values.Add("isEnabled", true);
                obj.components.Add(id, new LevelComponent(componentType, values));
                return id;
            }
            return null;
        }

        private void colliderComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "transform.position.X", 0.0 },
                    { "transform.position.Y", 0.0 },
                    { "transform.scale.X", 1.0 },
                    { "transform.scale.Y", 1.0 },
                    { "isSolidCollision", true },
                    { "friction", 0.1f }
                };

                AddComponentToObject("ColliderComponent", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void properties_panel_Resize(object sender, EventArgs e)
        {
            UpdatePropertiesPanel();
        }

        private void audioComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "FilePath", "" },
                    { "Volume", 1.0f },
                };

                AddComponentToObject("AudioComponent", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void physicsComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "mass", 10f },
                    { "friction", 0.1f },
                    { "isAirborne", true },
                    { "gravityEnabled", true },
                    { "gravityMultiplier", 1f },
                };

                AddComponentToObject("PhysicsComponent", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void customScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "ScriptClass", "" },
                };

                AddComponentToObject("ScriptComponent", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }
    }

    public enum UserInteraction
    {
        None,
        Moving,
        Object_Drag,
    }
}
