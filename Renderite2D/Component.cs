namespace Renderite2D_Project.Renderite2D
{
    public abstract class Component
    {
        public GameObject Parent { get; private set; }

        public bool IsEnabled { get { return isEnabled; } set { isEnabled = value; } }

        bool isEnabled = true;

        public Component(GameObject parent)
        {
            Parent = parent;
        }

        public abstract void FixedUpdate();
    }
}
