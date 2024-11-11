using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D
{
    public struct Transform2D
    {
        public Vector2d position = Vector2d.Zero;
        public Vector2d scale = Vector2d.One;

        public Transform2D() { }
        public Transform2D(Vector2d position, Vector2d scale) 
        {
            this.position = position;
            this.scale = scale;
        }

        public Transform2D(Vector2d position)
        {
            this.position = position;
        }
    }
}
