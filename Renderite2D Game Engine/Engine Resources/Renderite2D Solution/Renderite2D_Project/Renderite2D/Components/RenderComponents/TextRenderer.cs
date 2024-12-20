using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class TextRenderer : RenderComponent
    {
        public Vector2d position = Vector2d.Zero;
        public object text = "Default Text";
        public Color4 color = Color4.White;
        public float scale = 1.0f;
        public bool isStatic = true;

        public TextRenderer(GameObject parent) : base(parent)
        {
            drawType = Game.DrawType.Text;
        }

        public override void Update()
        {
            parameters = new object[5]
            {
                (position * Parent.transform.scale) + Parent.transform.position,
                text,
                color,
                scale,
                isStatic
            };
            base.Update();
        }
    }
}
