using System;

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
    }
}
