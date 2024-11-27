using System;
using System.IO;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct Project
    {
        public int resolutionX;
        public int resolutionY;
        public bool vSyncEnabled;
        public bool isWindowResizeable;
        public string windowTitle;
        public double fixedUpdateFrequency;
        public int windowState;
        public string startingLevel;
        public bool drawColliders;
        public bool allowAltEnter;

        public Project()
        {
            resolutionX = 1280;
            resolutionY = 720;
            vSyncEnabled = true;
            isWindowResizeable = true;
            windowTitle = "Renderite2D Game";
            fixedUpdateFrequency = 60;
            windowState = 0;
            startingLevel = "SampleLevel";
            drawColliders = false;
            allowAltEnter = true;
        }

        public Project(int resolutionX, int resolutionY, bool vSyncEnabled, bool isWindowResizeable, 
            string windowTitle, double fixedUpdateFrequency, int windowState, string startingLevel, 
            bool drawColliders, bool allowAltEnter)
        {
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.vSyncEnabled = vSyncEnabled;
            this.isWindowResizeable = isWindowResizeable;
            this.windowTitle = windowTitle;
            this.fixedUpdateFrequency = fixedUpdateFrequency;
            this.windowState = windowState;
            this.startingLevel = startingLevel;
            this.drawColliders = drawColliders;
            this.allowAltEnter = allowAltEnter;
        }

        public Project(Project project)
        {
            resolutionX = project.resolutionX;
            resolutionY = project.resolutionY;
            vSyncEnabled = project.vSyncEnabled;
            isWindowResizeable = project.isWindowResizeable;
            windowTitle = project.windowTitle;
            fixedUpdateFrequency = project.fixedUpdateFrequency;
            windowState = project.windowState;
            startingLevel = project.startingLevel;
            drawColliders = project.drawColliders;
            allowAltEnter = project.allowAltEnter;
        }

        public override bool Equals(object obj)
        {
            if (obj is Project project)
            {
                return
                    resolutionX == project.resolutionX &&
                    resolutionY == project.resolutionY &&
                    vSyncEnabled == project.vSyncEnabled &&
                    isWindowResizeable == project.isWindowResizeable &&
                    windowTitle == project.windowTitle &&
                    fixedUpdateFrequency == project.fixedUpdateFrequency &&
                    windowState == project.windowState &&
                    startingLevel == project.startingLevel &&
                    drawColliders == project.drawColliders &&
                    allowAltEnter == project.allowAltEnter;
            }
            return false;
        }

        public string ToGameConfigScript()
        {
            string configTemplateDir = "Engine Resources\\Script Templates\\GameConfigTemplate.cs";
            if (File.Exists(configTemplateDir))
            {
                string script = File.ReadAllText(configTemplateDir);
                script = script.Replace("__resolutionX__", resolutionX.ToString());
                script = script.Replace("__resolutionY__", resolutionY.ToString());
                script = script.Replace("__vSyncEnabled__", vSyncEnabled ? "VSyncMode.On" : "VSyncMode.Off");
                script = script.Replace("__isWindowResizeable__", isWindowResizeable ? "WindowBorder.Resizable" : "WindowBorder.Fixed");
                script = script.Replace("__windowTitle__", windowTitle);
                script = script.Replace("__fixedUpdateFrequency__", fixedUpdateFrequency.ToString());
                string winstate = windowState switch
                {
                    1 => "WindowState.Minimized",
                    2 => "WindowState.Maximized",
                    3 => "WindowState.Fullscreen",
                    _ => "WindowState.Normal",
                };
                script = script.Replace("__windowState__", winstate);
                script = script.Replace("__startingLevel__", "new " + CreateDialog.SanitizeClassName(Path.GetFileNameWithoutExtension(startingLevel)) + "()");
                script = script.Replace("__drawColliders__", drawColliders.ToString().ToLower());
                script = script.Replace("__allowAltEnter__", allowAltEnter.ToString().ToLower());
                return script;
            }
            return null;
        }
    }
}
