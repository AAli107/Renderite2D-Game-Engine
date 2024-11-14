using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class RectRenderer : RenderComponent
    {
        public bool isOutline = false;
        public bool isStatic = false;
        public bool isCentered = true;
        public Vector2d position = Vector2d.Zero;
        public Vector2d dimension = new(100, 100);
        public Color4 color = Color4.White;
        public Texture texture = Texture.White;

        public RectRenderer(GameObject parent) : base(parent) { }

        public override void Update()
        {
            drawType = isOutline ? Game.DrawType.Rectangle_Outline : Game.DrawType.Rectangle;
            parameters = isOutline ?
                new object[] { position + Parent.transform.position - (isCentered ? dimension * 0.5 : Vector2d.Zero), dimension, color, isStatic } :
                new object[] { position + Parent.transform.position - (isCentered ? dimension * 0.5 : Vector2d.Zero), dimension, color, texture, isStatic };
            base.Update();
        }
    }
}
