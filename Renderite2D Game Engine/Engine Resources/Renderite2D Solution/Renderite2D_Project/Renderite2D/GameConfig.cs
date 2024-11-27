using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace Renderite2D_Project.Renderite2D
{
    public struct GameConfig
    {
        public Vector2i clientResolution = new(1280, 720);
        public VSyncMode vSyncEnabled = VSyncMode.On;
        public WindowBorder windowBorder = WindowBorder.Resizable;
        public string windowTitle = "Renderite2D Game";
        public double fixedUpdateFrequency = 60;
        public WindowState windowState = WindowState.Normal;
        public Level startingLevel = null;
        public bool drawColliders = false;
        public bool allowAltEnter = true;

        public GameConfig() { }

        public GameConfig(Vector2i clientResolution, VSyncMode vSyncEnabled, WindowBorder windowBorder, 
            string windowTitle, double fixedUpdateFrequency, WindowState windowState, Level startingLevel)
        {
            this.clientResolution = clientResolution;
            this.vSyncEnabled = vSyncEnabled;
            this.windowBorder = windowBorder;
            this.windowTitle = windowTitle;
            this.fixedUpdateFrequency = fixedUpdateFrequency;
            this.windowState = windowState;
            this.startingLevel = startingLevel;
        }
    }
}
