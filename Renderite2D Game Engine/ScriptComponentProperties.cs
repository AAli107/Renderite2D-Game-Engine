using Renderite2D_Game_Engine.Scripts;
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
    public partial class ScriptComponentProperties : Renderite2D_Game_Engine.Component_Properties
    {
        [Obsolete("Designer only", true)]
        public ScriptComponentProperties()
        {
            InitializeComponent();
        }

        public ScriptComponentProperties(LevelEditor levelEditor, string componentId) : base(levelEditor, componentId)
        {
            InitializeComponent();
        }

        protected override void UpdateComponent_(LevelComponent component)
        {
            textBox1.Text = (string)component.values["ScriptClass"];
        }

        public override int GetHeight()
        {
            return 198;
        }

        bool IsValidName()
        {
            return
                CodeBuilder.IsValidIdentifier(textBox1.Text.Trim()) &&
                !CodeBuilder.StartsWithLevelPreName(textBox1.Text.Trim());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
                textBox1.Text = textBox1.Text.Replace(" ", "").Trim();

            if (textBox1.Text.Length == 0 || (IsValidName() && textBox1.Text != "ScriptComponent" && textBox1.Text != "Component"))
            {
                SetComponentValue("ScriptClass", textBox1.Text);
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }
    }
}
