namespace Renderite2D_Project.Renderite2D
{
    public abstract class Level
    {
        /// <summary>
        /// The game's main window
        /// </summary>
        protected readonly GameWin win = Program.GameWindow;

        /// <summary>
        /// Gets executed when the Level starts
        /// </summary>
        protected virtual void Begin() { }

        /// <summary>
        /// Gets executed every frame while the level is loaded
        /// </summary>
        protected virtual void Update() { }

        /// <summary>
        /// Gets executed a fixed amount of times per second while the level is loaded
        /// </summary>
        protected virtual void FixedUpdate() { }

        /// <summary>
        /// All rendering functions must be placed here
        /// </summary>
        protected virtual void Draw() { }

        /// <summary>
        /// Gets executed when the level ends or unloaded
        /// </summary>
        protected virtual void End() { }
    }
}