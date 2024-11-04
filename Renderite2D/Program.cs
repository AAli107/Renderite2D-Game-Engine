using OpenTK.Windowing.Desktop;

namespace Renderite2D_Project.Renderite2D
{
    public static class Program
    {
        public static GameWin GameWindow { get; private set; }
        public static void Main()
        {
            // Creates the game window and display it on screen
            using GameWin win = new (new GameWindowSettings(), new NativeWindowSettings());
            GameWindow = win;
            win.Run();
        }

        public static void EndGame()
        {
            GameWindow?.Close();
        }
    }
}