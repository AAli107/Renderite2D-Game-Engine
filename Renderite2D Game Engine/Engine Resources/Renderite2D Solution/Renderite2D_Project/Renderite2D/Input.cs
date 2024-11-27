using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Renderite2D_Project.Renderite2D
{
    public static class Input
    {
        /// <summary>
        /// The position of the mouse in the window
        /// </summary>
        public static Vector2d MouseScreenPos { get { return Program.GameWindow.MousePosition / (Program.GameWindow.ClientSize / new Vector2d(1920, 1080)); } }
        
        /// <summary>
        /// The position of the mouse within the world
        /// </summary>
        public static Vector2d MouseWorldPos { get { return (Program.GameWindow.MousePosition / (Program.GameWindow.ClientSize / new Vector2d(1920, 1080))) + new Vector2d(Game.MainCamera.Transform.position.X - 960, Game.MainCamera.Transform.position.Y - 540); } }

        /// <summary>
        /// Returns a bool value that will indicate whether a key is being held down.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyDown(Keys key)
        {
            return Program.GameWindow.IsKeyDown(key);
        }

        /// <summary>
        /// Returns a bool value that will indicate whether a key is currently not being held down.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyUp(Keys key)
        {
            return Program.GameWindow.IsKeyReleased(key);
        }

        /// <summary>
        /// Will return true when the specified key is currently pressed, but was not in the previous frame.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyPressed(Keys key)
        {
            return Program.GameWindow.IsKeyPressed(key);
        }

        /// <summary>
        /// Will return true when this button is currently down.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool IsMouseButtonDown(MouseButton button)
        {
            return Program.GameWindow.IsMouseButtonDown(button);
        }

        /// <summary>
        /// Returns true when the specified mouse button is released in the current frame but pressed in the previous frame.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool IsMouseButtonUp(MouseButton button)
        {
            return Program.GameWindow.IsMouseButtonReleased(button);
        }

        /// <summary>
        /// Returns true when the specified mouse button is pressed in the current frame but released in the previous frame.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool IsMouseButtonPressed(MouseButton button)
        {
            return Program.GameWindow.IsMouseButtonPressed(button);
        }
    }
}
