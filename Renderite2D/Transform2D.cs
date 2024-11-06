using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D
{
    public struct Transform2D
    {
        public Vector2d position = Vector2d.Zero;
        public float rotation = 0.0f;
        public Vector2d scale = Vector2d.One;

        public Transform2D() { }
    }
}
