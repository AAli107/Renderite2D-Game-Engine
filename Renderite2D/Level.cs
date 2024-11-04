namespace Renderite2D_Project.Renderite2D
{
    public abstract class Level
    {
        /// <summary>
        /// The game's main window
        /// </summary>
        protected readonly Game win = Program.GameWindow;

        /// <summary>
        /// The Background color of the level
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Gets executed when the Level starts
        /// </summary>
        public virtual void Begin() { }

        /// <summary>
        /// Gets executed every frame while the level is loaded
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Gets executed a fixed amount of times per second while the level is loaded
        /// </summary>
        public virtual void FixedUpdate() { }

        /// <summary>
        /// All rendering functions must be placed here
        /// </summary>
        public virtual void Draw(Game.Shapes gfx) { }

        /// <summary>
        /// Gets executed when the level ends or unloaded
        /// </summary>
        public virtual void End() { }
    }
}