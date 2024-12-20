using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class PointRenderer : RenderComponent
    {
        public Vector2d position = Vector2d.Zero;
        public Color4 color = Color4.White;
        public float size = 1f;
        public bool isStatic = false;

        public PointRenderer(GameObject parent) : base(parent) 
        {
            drawType = Game.DrawType.Point;
        }

        public override void Update()
        {
            parameters = new object[4] 
            {
                (position * Parent.transform.position) + Parent.transform.position, 
                color, 
                size, 
                isStatic 
            };
            base.Update();
        }
    }
}
