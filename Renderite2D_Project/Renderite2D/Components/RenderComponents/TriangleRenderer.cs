using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class TriangleRenderer : RenderComponent
    {
        public Vector2d pointA = new(-50, -50);
        public Vector2d pointB = new(50, -50);
        public Vector2d pointC = new(-50, 50);
        public Color4 color = Color4.White;
        public Texture texture = Texture.White;
        public bool isStatic = false;

        public TriangleRenderer(GameObject parent) : base(parent) 
        {
            drawType = Game.DrawType.Triangle;
        }

        public override void Update()
        {
            parameters = new object[6] 
            {
                (pointA * Parent.transform.scale) + Parent.transform.position, 
                (pointB * Parent.transform.scale) + Parent.transform.position, 
                (pointC * Parent.transform.scale) + Parent.transform.position,
                color, 
                texture, 
                isStatic 
            };
            base.Update();
        }
    }
}
