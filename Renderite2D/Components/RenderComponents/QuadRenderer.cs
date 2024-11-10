using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class QuadRenderer : RenderComponent
    {
        public Vector2d pointA = new(-50, -50);
        public Vector2d pointB = new(50, -50);
        public Vector2d pointC = new(-50, 50);
        public Vector2d pointD = new(50, 50);
        public Color4 color = Color4.White;
        public Texture texture = Texture.White;
        public bool isStatic = false;

        public QuadRenderer(GameObject parent) : base(parent) 
        {
            drawType = Game.DrawType.Quad;
        }

        public override void Update()
        {
            parameters = new object[7] 
            {
                pointA + Parent.transform.position, 
                pointB + Parent.transform.position, 
                pointC + Parent.transform.position, 
                pointD + Parent.transform.position, 
                color, 
                texture, 
                isStatic 
            };
            base.Update();
        }
    }
}
