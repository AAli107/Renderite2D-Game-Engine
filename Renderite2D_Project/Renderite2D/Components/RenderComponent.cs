using static Renderite2D_Project.Renderite2D.Game;

namespace Renderite2D_Project.Renderite2D.Components
{
    public abstract class RenderComponent : Component
    {
        public byte layer = 0;

        protected DrawType drawType;
        protected object[] parameters;

        public RenderComponent(GameObject parent) : base(parent) { }

        public override void FixedUpdate() { }

        public override void Update()
        {
            if (parameters == null) return;
            DrawShape(drawType, parameters, layer);
        }
    }
}
