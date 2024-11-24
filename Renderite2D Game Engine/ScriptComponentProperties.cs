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
            return 185;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
                textBox1.Text = textBox1.Text.Replace(" ", "").Trim();

            bool characterCheck = true;
            if (textBox1.Text.Length > 1)
            {
                for (int i = 1; i < textBox1.Text.Length; i++)
                {
                    if (!char.IsLetterOrDigit(textBox1.Text[i]))
                    {
                        characterCheck = false;
                        break;
                    }
                }
            }

            if (textBox1.Text.Length == 0 || 
                ((char.IsLetter(textBox1.Text[0]) || textBox1.Text[0] == '_' || textBox1.Text[0] == '@') && characterCheck && 
                textBox1.Text != "ScriptComponent")) 
                    SetComponentValue("ScriptClass", textBox1.Text);
        }
    }
}
