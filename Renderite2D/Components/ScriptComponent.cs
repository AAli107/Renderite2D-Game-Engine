namespace Renderite2D_Project.Renderite2D.Components
{
    public abstract class ScriptComponent : Component
    {
        public ScriptComponent(GameObject parent) : base(parent)
        {
            Start();
        }
        ~ScriptComponent()
        {
            End();
        }

        public abstract void Start();
        public abstract void End();

    }
}
