using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class Component_Properties : UserControl
    {
        public string componentId = "";
        protected readonly LevelEditor levelEditor;

        public Component_Properties(LevelEditor levelEditor, string componentId)
        {
            InitializeComponent();
            this.componentId = componentId;
            this.levelEditor = levelEditor ?? throw new Exception("Error: Missing access to Level Editor!");
        }

        public void UpdateComponent()
        {
            if (ProjectManager.IsProjectOpen && levelEditor.gameObject_listBox.SelectedItem != null)
            {
                string objectKey = (string)levelEditor.gameObject_listBox.SelectedItem;
                if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(objectKey) &&
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components.ContainsKey(componentId))
                {
                    var component = ProjectManager.CurrentLevelData.gameObjects[objectKey].components[componentId];
                    IsEnabled_checkbox.Checked = component.isEnabled;
                    UpdateComponent_(component);
                }
            }
        }


        private void deleteComponent_button_Click(object sender, EventArgs e)
        {
            if (ProjectManager.IsProjectOpen && levelEditor.gameObject_listBox.SelectedItem != null)
            {
                string objectKey = (string)levelEditor.gameObject_listBox.SelectedItem;
                if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(objectKey) &&
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components.ContainsKey(componentId))
                {
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components.Remove(componentId);
                }
                levelEditor.UpdatePropertiesPanel();
            }
        }

        private void IsEnabled_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ProjectManager.IsProjectOpen && levelEditor.gameObject_listBox.SelectedItem != null)
            {
                string objectKey = (string)levelEditor.gameObject_listBox.SelectedItem;
                if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(objectKey) &&
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components.ContainsKey(componentId))
                {
                    var component = ProjectManager.CurrentLevelData.gameObjects[objectKey].components[componentId];
                    component.isEnabled = IsEnabled_checkbox.Checked;
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components[componentId] = component;
                }
                levelEditor.UpdateViewport();
            }
        }

        private void Component_Properties_Load(object sender, EventArgs e)
        {
            UpdateComponent();
        }

        protected void SetComponentValue(string valueId, object value)
        {
            if (ProjectManager.IsProjectOpen && levelEditor.gameObject_listBox.SelectedItem != null)
            {
                string objectKey = (string)levelEditor.gameObject_listBox.SelectedItem;
                if (ProjectManager.CurrentLevelData.gameObjects.ContainsKey(objectKey) &&
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components.ContainsKey(componentId))
                {
                    var component = ProjectManager.CurrentLevelData.gameObjects[objectKey].components[componentId];
                    component.values[valueId] = value;
                    ProjectManager.CurrentLevelData.gameObjects[objectKey].components[componentId] = component;
                }
                levelEditor.UpdateViewport();
            }
        }
    }
}
