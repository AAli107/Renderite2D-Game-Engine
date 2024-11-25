using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class LineRenderer : RenderComponent
    {
        public bool isStatic = false;
        public Vector2d pointA = new(-50, -50);
        public Vector2d pointB = new(50, 50);
        public Color4 color = Color4.White;
        public float width = 1f;

        public LineRenderer(GameObject parent) : base(parent) 
        {
            drawType = Game.DrawType.Line;
        }

        public override void Update()
        {
            parameters = new object[5] 
            {
                pointA + Parent.transform.position, 
                pointB + Parent.transform.position,
                color, 
                width, 
                isStatic 
            };
            base.Update();
        }
    }
}
