namespace Renderite2D_Project.Renderite2D
{
    public abstract class Component
    {
        public bool IsEnabled { get { return isEnabled; } set { isEnabled = value; } }

        bool isEnabled = true;

        public abstract void Update();
    }
}
