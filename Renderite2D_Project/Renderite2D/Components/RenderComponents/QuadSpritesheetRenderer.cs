using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class QuadSpritesheetRenderer : RenderComponent
    {
        public bool isStatic = false;
        public int index = 0;
        public int divisions = 2; 
        public Vector2d pointA = new(-50, -50);
        public Vector2d pointB = new(50, -50);
        public Vector2d pointC = new(-50, 50);
        public Vector2d pointD = new(50, 50);
        public Color4 color = Color4.White;
        public Texture texture = Texture.White;

        public QuadSpritesheetRenderer(GameObject parent) : base(parent) 
        {
            drawType = Game.DrawType.Quad_Spritesheet;
        }

        public override void Update()
        {
            if (divisions < 1) divisions = 1;

            parameters = new object[9] 
            {
                (pointA * Parent.transform.scale) + Parent.transform.position,
                (pointB * Parent.transform.scale) + Parent.transform.position,
                (pointC * Parent.transform.scale) + Parent.transform.position,
                (pointD * Parent.transform.scale) + Parent.transform.position,
                color,
                texture,
                index,
                divisions,
                isStatic
            };
            base.Update();
        }
    }
}
