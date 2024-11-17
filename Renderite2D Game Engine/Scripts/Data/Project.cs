using System;

namespace Renderite2D_Game_Engine.Scripts.Data
{
    [Serializable]
    public struct Project
    {
        public int resolutionX = 1280;
        public int resolutionY = 720;
        public bool vSyncEnabled = true;
        public bool isWindowResizeable = true;
        public string windowTitle = "Renderite2D Game";
        public double fixedUpdateFrequency = 60;
        public int windowState = 0;
        public string startingLevel = "SampleLevel";
        public bool drawColliders = false;
        public bool allowAltEnter = true;

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
    }
}
