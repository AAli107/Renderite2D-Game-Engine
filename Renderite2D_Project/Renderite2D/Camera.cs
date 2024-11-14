using Microsoft.VisualBasic.Logging;
using OpenTK.Mathematics;
using System;
using System.Drawing;

namespace Renderite2D_Project.Renderite2D
{
    public class Camera
    {
        public Transform2D Transform 
        { 
            get {  return transform; }
            set 
            {
                Vector2d pos = lockedToBounds ? 
                    Vector2d.Clamp(
                        value.position, 
                        new Vector2d(bounds.X, bounds.Y), 
                        new Vector2d(bounds.Width, bounds.Height)) 
                    : value.position;

                transform = value;
                transform.position = pos;
            }
        }

        Transform2D transform;
        bool lockedToBounds;
        RectangleF bounds;

        public Camera()
        {
            transform = new Transform2D();
            Constructor();
        }

        public Camera(Transform2D transform)
        {
            this.transform = transform;
            Constructor();
        }

        public Camera(Vector2d position)
        {
            transform.position = position;
            Constructor();
        }

        private void Constructor()
        {
            bounds = new RectangleF(new PointF(0, 0), new SizeF(1920, 1080));
            lockedToBounds = false;
        }

        public bool SetCameraBound(Vector2d start, Vector2d width, bool enableBounds = false)
        {
            if (start.X < width.X && start.Y < width.Y)
            {
                bounds = new RectangleF(new PointF((float)start.X, (float)start.Y), new SizeF((float)width.X, (float)width.Y));
                lockedToBounds = enableBounds;
                return true;
            }
            return false;
        }
    }
}
