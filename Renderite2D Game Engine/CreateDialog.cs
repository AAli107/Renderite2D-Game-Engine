using Microsoft.CSharp;
using Newtonsoft.Json;
using Renderite2D_Game_Engine.Scripts;
using Renderite2D_Game_Engine.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class CreateDialog : Form
    {
        public string fileName = "";

        readonly AssetType assetType;
        readonly string[] fileEntries;
        readonly string currentDirectory;

        public CreateDialog(AssetType assetType, string currentDirectory)
        {
            InitializeComponent();
            this.assetType = assetType;
            this.currentDirectory = currentDirectory;

            title_label.Text = assetType switch
            {
                AssetType.Folder => "Create Folder",
                AssetType.Level => "Create Level",
                AssetType.EmptyClass => "Create Empty Class",
                AssetType.CustomScript => "Create Script",
                AssetType.GameObjectScript => "Create Game Object",
                AssetType.TopDownCharacter => "Create Topdown Character",
                AssetType.SideScrollerCharacter => "Create Side Scroller Character",
                _ => "Create",
            };

            string[] entries = assetType == AssetType.Folder ? Directory.GetDirectories(currentDirectory) : Directory.GetFiles(currentDirectory);

            fileEntries = new string[entries.Length];
            for (int i = 0; i < entries.Length; i++)
                fileEntries[i] = Path.GetFileNameWithoutExtension(entries[i]);

            string baseName = assetType switch
            {
                AssetType.Folder => "Folder",
                AssetType.Level => "Level",
                AssetType.EmptyClass => "Class",
                AssetType.CustomScript => "Script",
                AssetType.GameObjectScript => "Game Object Script",
                AssetType.TopDownCharacter => "Topdown Character",
                AssetType.SideScrollerCharacter => "Side Scroller Character",
                _ => "",
            };

            int index = 0;
            string inputFileName;

            inputFileName = baseName;
            while (DoesFileExist(inputFileName))
            {
                index++;
                inputFileName = baseName + "_" + index;
            }
            nameInput_textbox.Text = inputFileName;
        }

        private bool DoesInputNameExist()
        {
            return DoesFileExist(fileName);
        }

        private bool DoesFileExist(string fileName)
        {

            return fileEntries.Contains(fileName.Trim());
        }

        private bool ContainsInvalidCharacters()
        {
            string str = fileName;
            for (int i = 0; i < str.Length; i++)
            {
                if (Path.GetInvalidFileNameChars().Contains(str[i]) ||
                    Path.GetInvalidPathChars().Contains(str[i]))
                    return true;
            }
            return false;
        }

        private bool IsNameEmpty()
        {
            return fileName == "";
        }

        private bool IsValidName()
        {
            return !IsNameEmpty() && !DoesInputNameExist() && !ContainsInvalidCharacters() && !IsNameOnlyComposedOfDots();
        }

        bool IsNameOnlyComposedOfDots()
        {
            foreach (char chr in fileName.Replace(" ", "").ToCharArray())
                if (chr != '.') return false;
            return true;
        }

        private void nameInput_textbox_TextChanged(object sender, EventArgs e)
        {
            fileName = nameInput_textbox.Text.Trim();
            nameInput_textbox.ForeColor = IsValidName() ? Color.Black : Color.Red;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        private void CreateDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (IsValidName())
            {
                try
                {
                    if (assetType == AssetType.Folder)
                    {
                        Directory.CreateDirectory(currentDirectory + '\\' + fileName);
                    }
                    else
                    {
                        string fileformat = assetType == AssetType.Level ? ".rdlvl" : ".cs";
                        string fileContents = assetType switch
                        {
                            AssetType.Level => JsonConvert.SerializeObject(new Level(), Formatting.Indented),
                            AssetType.EmptyClass => CodeBuilder.InsertClassNameToScript(GetEmptyClassTemplate(), fileName),
                            AssetType.CustomScript => CodeBuilder.InsertClassNameToScript(GetCustomScriptTemplate(), fileName),
                            AssetType.GameObjectScript => CodeBuilder.InsertClassNameToScript(GetGameObjectTemplate(), fileName),
                            AssetType.SideScrollerCharacter => CodeBuilder.InsertClassNameToScript(GetSideScrollerCharacterTemplate(), fileName),
                            AssetType.TopDownCharacter => CodeBuilder.InsertClassNameToScript(GetTopDownCharacterTemplate(), fileName),
                            _ => "",
                        };
                        File.WriteAllText(currentDirectory + '\\' + fileName + fileformat, fileContents);
                    }
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "[Message] " + ex.Message + "\n\n" +
                        "[Source] " + ex.Source + "\n\n" +
                        "[Stack Trace]\n" + ex.StackTrace,
                    "Exception Caught!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                bool isFolder = assetType == AssetType.Folder;
                string message = "Could not Create " + (isFolder ? "folder" : "file") + "...\n\nFail Reason(s):\n";

                if (IsNameEmpty())
                    message += "- Name is Empty.\n";
                if (DoesInputNameExist())
                    message += "- " + (isFolder ? "Folder" : "File") + " with same name already exists.\n";
                if (ContainsInvalidCharacters())
                    message += "- " + (isFolder ? "Folder" : "File") + " contains invalid characters.\n";
                if (IsNameOnlyComposedOfDots())
                    message += "- " + (isFolder ? "Folder" : "File") + " name only consists of dots.\n";

                MessageBox.Show(message, "Failed To Create!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static string GetEmptyClassTemplate()
        {
            return File.ReadAllText("Engine Resources\\Script Templates\\EmptyClassTemplate.cs");
        }

        public static string GetCustomScriptTemplate()
        {
            return File.ReadAllText("Engine Resources\\Script Templates\\CustomScriptTemplate.cs");
        }

        public static string GetGameObjectTemplate()
        {
            return File.ReadAllText("Engine Resources\\Script Templates\\GameObjectTemplate.cs");
        }

        public static string GetTopDownCharacterTemplate()
        {
            return File.ReadAllText("Engine Resources\\Script Templates\\TopDownCharacterTemplate.cs");
        }

        public static string GetSideScrollerCharacterTemplate()
        {
            return File.ReadAllText("Engine Resources\\Script Templates\\SideScrollerCharacterTemplate.cs");
        }

        private void nameInput_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                create_btn_Click(create_btn, new EventArgs());
        }
    }

    public enum AssetType
    {
        None,
        Folder,
        Level,
        EmptyClass,
        CustomScript,
        GameObjectScript,
        TopDownCharacter,
        SideScrollerCharacter,
    }
}
