using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class LevelEditor : Renderite2D_Game_Engine.BaseForm
    {
        const double scaleVal = 2;

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

        (int x, int y) currentMousePosViewport = new(0, 0); 
        (int x, int y) currentMousePosAssets = new(0, 0); 
        (double x, double y) viewportPos = new(0, 0);
        (int x, int y) objectOffset = new(0, 0);
        string objectName = string.Empty;
        (string name, LevelObject obj)? clipboardObject = null;
        readonly Dictionary<string, (bool isDirectory, string name, Point location)> currentDirContents = new();
        bool isDraggingAsset = false;

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
            UpdateWinTitle();
            ClipboardObject = null;

            ContextMenu assetsPanelCm = new(new MenuItem[] 
            {
                new("Paste"),
                new("Refresh"),
            });
            assetsPanelCm.MenuItems[0].Click += Asset_Paste_Click;
            assetsPanelCm.MenuItems[1].Click += Asset_Refresh_Click;
            assetsPanelCm.Popup += AssetsPanelCm_Popup;

            assets_panel.ContextMenu = assetsPanelCm;
        }

        private void Asset_Refresh_Click(object sender, EventArgs e)
        {
            UpdateAssetDirectory();
        }

        private void AssetsPanelCm_Popup(object sender, EventArgs e)
        {
            if (sender is ContextMenu cm)
            {
                cm.MenuItems[0].Enabled = Clipboard.ContainsFileDropList();
            }
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
                    ContextMenu = new(new MenuItem[]
                    {
                        new("Open")
                        {
                            Name = keys[cdc_index]
                        },
                        new("Show in Explorer")
                        {
                            Name = keys[cdc_index]
                        },
                        new("Copy")
                        {
                            Name = keys[cdc_index]
                        },
                        new("Paste")
                        {
                            Name = keys[cdc_index],
                        },
                        new("Refresh")
                        {
                            Name = keys[cdc_index],
                        },
                        new("Delete")
                        {
                            Name = keys[cdc_index]
                        },
                    }),
                };
                entry_panel.DoubleClick += Entry_panel_DoubleClick;
                entry_panel.MouseDown += Entry_panel_MouseDown;
                entry_panel.MouseMove += Entry_panel_MouseMove;
                entry_panel.MouseUp += Entry_panel_MouseUp;
                entry_panel.ContextMenu.Popup += Asset_ContextMenu_Popup;
                entry_panel.ContextMenu.MenuItems[0].Click += Asset_Open_Click;
                entry_panel.ContextMenu.MenuItems[1].Click += Asset_SIE_Click;
                entry_panel.ContextMenu.MenuItems[2].Click += Asset_Copy_Click;
                entry_panel.ContextMenu.MenuItems[3].Click += Asset_Paste_Click;
                entry_panel.ContextMenu.MenuItems[4].Click += Asset_Refresh_Click;
                entry_panel.ContextMenu.MenuItems[5].Click += Asset_Delete_Click;

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

        private void Asset_ContextMenu_Popup(object sender, EventArgs e)
        {
            if (sender is ContextMenu cm)
            {
                cm.MenuItems[3].Enabled = Clipboard.ContainsFileDropList();
            }
        }

        private void Asset_Paste_Click(object sender, EventArgs e)
        {
            var f = Clipboard.GetFileDropList();
            if (f != null && f.Count > 0)
            {
                string dir = ProjectManager.AssetsPath + '\\' + assetBrowserPath;

                string sourcePath = f[0].Replace('/', '\\');
                string targetPath = (dir + '\\' + Path.GetFileName(f[0])).Replace('/', '\\');

                if (targetPath == sourcePath) return;

                if (File.Exists(sourcePath) && !File.Exists(targetPath))
                {
                    File.WriteAllText(targetPath, File.ReadAllText(sourcePath));
                } 
                else if (Directory.Exists(sourcePath) && !Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);

                    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));

                    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", System.IO.SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                }
                UpdateAssetDirectory();
            }
        }

        private void Asset_Copy_Click(object sender, EventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                Clipboard.SetFileDropList(new StringCollection { menuItem.Name });
            }
        }

        private void Entry_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Panel p)
            {
                if (e.Button == MouseButtons.Left && isDraggingAsset)
                {
                    float closestDist = float.MaxValue;
                    string closestName = "";
                    foreach (var item in currentDirContents)
                    {
                        if (item.Key == p.Name) continue;

                        float dist = Vector2.Distance(new(p.Location.X, p.Location.Y), new(item.Value.location.X + 32, item.Value.location.Y + 32));
                        if (dist < closestDist)
                        {
                            closestDist = dist;
                            closestName = item.Key;
                        }
                    }

                    var closestPoint = currentDirContents[closestName].location;

                    (double xDistAbs, double yDistAbs) = (Math.Abs(p.Location.X - (closestPoint.X + 32)), Math.Abs(p.Location.Y - (closestPoint.Y + 32)));

                    if (xDistAbs < 32 && yDistAbs < 32 && Directory.Exists(closestName))
                    {
                        if (Directory.Exists(p.Name) || File.Exists(p.Name))
                        {
                            Directory.Move(p.Name, closestName + '\\' + Path.GetFileName(p.Name));
                        }
                    }

                    isDraggingAsset = false;
                    UpdateAssetDirectory();
                }
            }
        }

        private void Entry_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Panel p)
            {
                double deltaMag = Math.Sqrt(Math.Pow(currentMousePosAssets.x - e.Location.X, 2) + Math.Pow(currentMousePosAssets.y - e.Location.Y, 2));

                if (e.Button == MouseButtons.Left && deltaMag > 1 && !isDraggingAsset)
                {
                    isDraggingAsset = true;
                }
                if (e.Button == MouseButtons.Left && isDraggingAsset)
                {
                    p.Location = new Point(e.X + p.Location.X, e.Y + p.Location.Y);
                    p.BackColor = Color.FromArgb(50, Color.LightBlue);
                }

                currentMousePosAssets = new(e.Location.X, e.Location.Y);
            }
        }

        private void Entry_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel p)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.BringToFront();
                }
            }
        }

        private void Asset_Delete_Click(object sender, EventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                if (!File.Exists(menuItem.Name) && !Directory.Exists(menuItem.Name)) return;

                if (IsLevelFile(menuItem.Name) && menuItem.Name.Replace('/', '\\') == ProjectManager.CurrentLevelPath.Replace('/', '\\'))
                {
                    MessageBox.Show("You cannot delete a currently open Level!", "Failed Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this Asset?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (File.Exists(menuItem.Name))
                        FileSystem.DeleteFile(menuItem.Name, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    else FileSystem.DeleteDirectory(menuItem.Name, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    UpdateAssetDirectory();
                }
            }
        }

        private void Asset_SIE_Click(object sender, EventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string p = Path.GetDirectoryName(menuItem.Name);
                if (Directory.Exists(p))
                    Process.Start(p);
            }
        }

        private void Asset_Open_Click(object sender, EventArgs e)
        {
            if (sender is MenuItem menuItem)
                OpenAsset(menuItem.Name);
        }

        private void Entry_panel_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Panel p)
                OpenAsset(p.Name);
        }

        public void OpenAsset(string path)
        {
            if (File.Exists(path))
            {
                if (path.EndsWith(".rdlvl"))
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
                        var (success, exception) = ProjectManager.LoadLevel(path);
                        if (success)
                        {
                            objectOffset = new(0, 0);
                            objectName = string.Empty;
                            userInteraction = UserInteraction.None;
                            viewportPos = new(0, 0);

                            UpdateGameObjectList();
                            UpdatePropertiesPanel();
                            UpdateViewport(); 
                            UpdateWinTitle();
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
                else Process.Start(path);
            }
            else if (Directory.Exists(path))
            {
                assetBrowserPath = path.Replace(ProjectManager.AssetsPath, "").Replace('/', '\\').Trim('\\');
                UpdateAssetDirectory();
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
            levelViewport_panel.BackColor = ProjectManager.CurrentLevelData.backgroundColor;
            foreach (var key in controlKeys)
            {
                if (!ProjectManager.CurrentLevelData.gameObjects.ContainsKey(key) ||
                    Math.Abs((ProjectManager.CurrentLevelData.gameObjects[key].x / scaleVal) - ViewportPos.x) > levelViewport_panel.Width / 2 ||
                    Math.Abs((ProjectManager.CurrentLevelData.gameObjects[key].y / scaleVal) - ViewportPos.y) > levelViewport_panel.Height / 2 ||
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
                if (Math.Abs((item.Value.x / scaleVal) - ViewportPos.x) < levelViewport_panel.Width / 2 &&
                    Math.Abs((item.Value.y / scaleVal) - ViewportPos.y) < levelViewport_panel.Height / 2)
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
                                    (int)(item.Value.x / scaleVal) + (levelViewport_panel.Width / 2) - (int)ViewportPos.x - (scaleX / 2),
                                    (int)(item.Value.y / scaleVal) + (levelViewport_panel.Height / 2) - (int)ViewportPos.y - (scaleY / 2)
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
                            (int)(item.Value.x / scaleVal) + (levelViewport_panel.Width / 2) - (int)ViewportPos.x - (scaleX / 2),
                            (int)(item.Value.y / scaleVal) + (levelViewport_panel.Height / 2) - (int)ViewportPos.y - (scaleY / 2)
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
                    obj.x = ((e.X * scaleVal) + (levelObjectControls[objectName].Location.X * scaleVal)) - ((levelViewport_panel.Width / 2)  * scaleVal) + (int)(ViewportPos.x * scaleVal) - (objectOffset.x * scaleVal) + (((int)(obj.scaleX * 50) / 2) * scaleVal);
                    obj.y = ((e.Y * scaleVal) + (levelObjectControls[objectName].Location.Y * scaleVal)) - ((levelViewport_panel.Height / 2) * scaleVal) + (int)(ViewportPos.y * scaleVal) - (objectOffset.y * scaleVal) + (((int)(obj.scaleY * 50) / 2) * scaleVal);
                    ProjectManager.CurrentLevelData.gameObjects[objectName] = obj;
                }
                else
                {
                    objectOffset = new(0, 0);
                    objectName = string.Empty;
                    userInteraction = UserInteraction.None;
                }
                UpdatePropertiesPanel(false);
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
                userInteraction = UserInteraction.Moving;
            else gameObject_listBox.SelectedIndex = -1;
        }

        private void levelViewport_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (userInteraction == UserInteraction.Moving)
                userInteraction = UserInteraction.None;
        }

        private void levelViewport_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (userInteraction == UserInteraction.Moving)
            {
                (double x, double y) deltaDir = new(
                    currentMousePosViewport.x - e.Location.X,
                    currentMousePosViewport.y - e.Location.Y
                );

                ViewportPos = new(ViewportPos.x + deltaDir.x, ViewportPos.y + deltaDir.y);
            }
            currentMousePosViewport = new(e.Location.X, e.Location.Y);
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
            AddGameObject(gameObjectName, new LevelObject("GameObject", ViewportPos.x * scaleVal, ViewportPos.y * scaleVal, 1, 1, new()));
            UpdateViewport();
        }

        private void gameObject_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePropertiesPanel();
            UpdateViewport();
        }

        public void UpdatePropertiesPanel(bool updateComponents = true)
        {
            bool validSelection = IsValidSelection();
            properties_panel.Visible = validSelection;
            if (validSelection)
            {
                var selectedObj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
                gameObjectName_label.Text = (string)gameObject_listBox.SelectedItem;
                gameObjectType_comboBox.SelectedItem = selectedObj.objectType;
                gameObjectIsEnabled_checkbox.CheckState = selectedObj.isEnabled ? CheckState.Checked : CheckState.Unchecked;
                posX_num.Value = (decimal)selectedObj.x;
                posY_num.Value = (decimal)selectedObj.y;
                scaleX_num.Value = (decimal)selectedObj.scaleX;
                scaleY_num.Value = (decimal)selectedObj.scaleY;

                if (updateComponents)
                {
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
                            case "SpritesheetRenderer":
                                componentPanel = new SpritesheetRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "AnimatedSpriteRenderer":
                                componentPanel = new AnimatedSpriteRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "LineRenderer":
                                componentPanel = new LineRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "PointRenderer":
                                componentPanel = new PointRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "QuadRenderer":
                                componentPanel = new QuadRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "QuadSpritesheetRenderer":
                                componentPanel = new QuadSpritesheetRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "TextRenderer":
                                componentPanel = new TextRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "TriangleRenderer":
                                componentPanel = new TriangleRendererProperties(this, item.Key) { Location = loc, };
                                break;
                            case "RectRenderer":
                                componentPanel = new RectRendererProperties(this, item.Key) { Location = loc, };
                                break;

                        }

                        if (componentPanel == null) continue;

                        height += componentPanel.GetHeight() + 16;

                        componentsPanel.Controls.Add(componentPanel);
                        index++;
                    }
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
                ClipboardObject = new (name, JsonConvert.DeserializeObject<LevelObject>(JsonConvert.SerializeObject(ProjectManager.CurrentLevelData.gameObjects[name])));
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
                obj.x = viewportPos.x * scaleVal;
                obj.y = viewportPos.y * scaleVal;
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
                    { "friction", 0.1 }
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
                    { "Volume", 1.0 },
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
                    { "mass", 10.0 },
                    { "friction", 0.1 },
                    { "isAirborne", true },
                    { "gravityEnabled", true },
                    { "gravityMultiplier", 1.0 },
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

        private void spritesheetRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "isCentered", true },
                    { "index", 0 },
                    { "divisions", 2 },
                    { "position.X", 0.0 },
                    { "position.Y", 0.0 },
                    { "dimension.X", 100.0 },
                    { "dimension.Y", 100.0 },
                    { "color", Color.White },
                    { "texture", "" },
                };

                AddComponentToObject("SpritesheetRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void animatedSpriteRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "isCentered", true },
                    { "index", 0 },
                    { "divisions", 2 },
                    { "position.X", 0.0 },
                    { "position.Y", 0.0 },
                    { "dimension.X", 100.0 },
                    { "dimension.Y", 100.0 },
                    { "color", Color.White },
                    { "texture", "" },
                    { "TimePerFrame", 1.0 / ProjectManager.ProjectData.fixedUpdateFrequency * 10.0 },
                    { "EndFrameIndex", 0 },
                    { "IsPlaying", true },
                    { "PlayReverse", false },
                };

                AddComponentToObject("AnimatedSpriteRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void lineRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "pointA.X", -50.0 },
                    { "pointA.Y", -50.0 },
                    { "pointB.X", 50.0 },
                    { "pointB.Y", 50.0 },
                    { "color", Color.White },
                    { "width", 1.0 },
                };

                AddComponentToObject("LineRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void pointRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "position.X", 0.0 },
                    { "position.Y", 0.0 },
                    { "color", Color.White },
                    { "size", 1.0 },
                };

                AddComponentToObject("PointRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void quadRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "pointA.X", -50.0 },
                    { "pointA.Y", -50.0 },
                    { "pointB.X", 50.0 },
                    { "pointB.Y", -50.0 },
                    { "pointC.X", -50.0 },
                    { "pointC.Y", 50.0 },
                    { "pointD.X", 50.0 },
                    { "pointD.Y", 50.0 },
                    { "color", Color.White },
                    { "texture", "" },
                };

                AddComponentToObject("QuadRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void quadSpritesheetRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "index", 0 },
                    { "divisions", 2 },
                    { "pointA.X", -50.0 },
                    { "pointA.Y", -50.0 },
                    { "pointB.X", 50.0 },
                    { "pointB.Y", -50.0 },
                    { "pointC.X", -50.0 },
                    { "pointC.Y", 50.0 },
                    { "pointD.X", 50.0 },
                    { "pointD.Y", 50.0 },
                    { "color", Color.White },
                    { "texture", "" },
                };

                AddComponentToObject("QuadSpritesheetRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void textRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", true },
                    { "position.X", 0.0 },
                    { "position.Y", 0.0 },
                    { "text", "Default Text" },
                    { "color", Color.White },
                    { "scale", 1.0 },
                };

                AddComponentToObject("TextRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void triangleRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "pointA.X", -50.0 },
                    { "pointA.Y", -50.0 },
                    { "pointB.X", 50.0 },
                    { "pointB.Y", -50.0 },
                    { "pointC.X", -50.0 },
                    { "pointC.Y", 50.0 },
                    { "color", Color.White },
                    { "texture", "" },
                };

                AddComponentToObject("TriangleRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        private void rectRendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedObjName = (string)gameObject_listBox.SelectedItem;
            if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(selectedObjName))
            {
                Dictionary<string, object> values = new()
                {
                    { "layer", (byte)0 },
                    { "isStatic", false },
                    { "isCentered", true },
                    { "isOutline", false },
                    { "position.X", 0.0 },
                    { "position.Y", 0.0 },
                    { "dimension.X", 100.0 },
                    { "dimension.Y", 100.0 },
                    { "color", Color.White },
                    { "texture", "" },
                };

                AddComponentToObject("RectRenderer", selectedObjName, values);
                UpdatePropertiesPanel();
            }
        }

        public void OpenCreateDialog(AssetType assetType)
        {
            if (new CreateDialog(assetType, ProjectManager.AssetsPath + '\\' + assetBrowserPath).ShowDialog() == DialogResult.OK)
            {
                UpdateAssetDirectory();
            }
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.Folder);
        }

        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.Level);
        }

        private void emptyClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.EmptyClass);
        }

        private void customScriptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.CustomScript);
        }

        private void gameObjectScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.GameObjectScript);
        }

        private void topdownCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.TopDownCharacter);
        }

        private void sideScrollerCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateDialog(AssetType.SideScrollerCharacter);
        }

        private void levelSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new LevelSettings().ShowDialog() == DialogResult.OK)
            {
                UpdateViewport();
            }
        }

        private void buildGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var (success, buildMessages, _) = CodeBuilder.BuildProject(true);
            MessageBox.Show(buildMessages, success ? "Success!" : "Failed!", MessageBoxButtons.OK,
                success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void runGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var (success, buildMessages, exePath) = CodeBuilder.BuildProject(true);

            if (!success) MessageBox.Show(buildMessages, "Failed!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!File.Exists(exePath)) 
                    MessageBox.Show("Game executable file not found.", "Failed!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        WorkingDirectory = Path.GetDirectoryName(exePath),
                    });
            }
        }

        private void exportSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new() { Description = "Select folder to put your generated Solution Project..." };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbd.SelectedPath)) return;

                string targetPath = Path.Combine(fbd.SelectedPath, "Solution Folder");

                var (success, buildMessages, sourcePath) = CodeBuilder.BuildProject(false, false);
                if (success)
                {
                    if (Directory.Exists(sourcePath))
                    {
                        if (Directory.Exists(targetPath))
                            Directory.Delete(targetPath, true);

                        Directory.CreateDirectory(targetPath);

                        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
                            Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));

                        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", System.IO.SearchOption.AllDirectories))
                            File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                    else MessageBox.Show("Failed to Export Solution", "Failed!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show(buildMessages, "Failed!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new() { Description = "Select folder to put your game build..." };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbd.SelectedPath)) return;

                var (success, buildMessages, outPath) = CodeBuilder.BuildProject(false, true);
                string targetPath = Path.Combine(fbd.SelectedPath, "Exported Game");
                string sourcePath = Path.GetDirectoryName(outPath);

                if (success)
                {
                    if (Directory.Exists(sourcePath))
                    {
                        if (Directory.Exists(targetPath))
                            Directory.Delete(targetPath, true);

                        Directory.CreateDirectory(targetPath);

                        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
                            Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));

                        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", System.IO.SearchOption.AllDirectories))
                            File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                    else MessageBox.Show("Failed to Export Game", "Failed!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show(buildMessages, "Failed!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateWinTitle()
        {
            Text = "Renderite2D Game Engine - " + ProjectManager.ProjectName + " - " + Path.GetFileName(ProjectManager.CurrentLevelPath);
        }

        private void exportAsBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new() { Filter = "Archives Files|*.zip", FileName = "Backup.zip", };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                ProjectManager.SaveProjectFiles(this);
                ZipFile.CreateFromDirectory(Path.GetDirectoryName(ProjectManager.ProjectPath), fd.FileName, CompressionLevel.Optimal, true);
            }
        }

        private void gameObjectType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsValidSelection() && gameObjectType_comboBox.SelectedIndex != -1)
            {
                var selectedObj = ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem];
                selectedObj.objectType = gameObjectType_comboBox.SelectedItem.ToString();
                ProjectManager.CurrentLevelData.gameObjects[(string)gameObject_listBox.SelectedItem] = selectedObj;
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
