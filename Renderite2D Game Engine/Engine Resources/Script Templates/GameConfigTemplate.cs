using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace Renderite2D_Project.Renderite2D
{
    public struct GameConfig
    {
        public Vector2i clientResolution = new(__resolutionX__, __resolutionY__);
        public VSyncMode vSyncEnabled = __vSyncEnabled__;
        public WindowBorder windowBorder = __isWindowResizeable__;
        public string windowTitle = "__windowTitle__";
        public double fixedUpdateFrequency = __fixedUpdateFrequency__;
        public WindowState windowState = __windowState__;
        public Level startingLevel = __startingLevel__;
        public bool drawColliders = __drawColliders__;
        public bool allowAltEnter = __allowAltEnter__;

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
