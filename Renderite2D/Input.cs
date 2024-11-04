namespace Renderite2D_Project.Renderite2D
{
    public static class Input
    {
        /// <summary>
        /// Returns a bool value that will indicate whether a key is being held down.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys key)
        {
            return Program.GameWindow.IsKeyDown(key);
        }

        /// <summary>
        /// Returns a bool value that will indicate whether a key is currently not being held down.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyUp(OpenTK.Windowing.GraphicsLibraryFramework.Keys key)
        {
            return Program.GameWindow.IsKeyReleased(key);
        }

        /// <summary>
        /// Will return true when the specified key is currently pressed, but was not in the previous frame.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyPressed(OpenTK.Windowing.GraphicsLibraryFramework.Keys key)
        {
            return Program.GameWindow.IsKeyPressed(key);
        }
    }
}
