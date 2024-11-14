using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class SpritesheetRenderer : RenderComponent
    {
        public bool isStatic = false;
        public bool isCentered = true;
        public int index = 0;
        public int divisions = 2;
        public Vector2d position = Vector2d.Zero;
        public Vector2d dimension = new(100, 100);
        public Color4 color = Color4.White;
        public Texture texture = Texture.White;

        public SpritesheetRenderer(GameObject parent) : base(parent) 
        {
            drawType = Game.DrawType.Rectangle_Spritesheet;
        }

        public override void Update()
        {
            if (divisions < 1) divisions = 1;

            parameters = new object[7] 
            { 
                position + Parent.transform.position - (isCentered ? dimension * 0.5 : Vector2d.Zero),
                dimension,
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
