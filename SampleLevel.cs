using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project
{
    public class SampleLevel : Level
    {
        float x = 100;
        float y = 100;
        Texture nTex;

        public override void Begin()
        {
            nTex = new("Assets/Game Assets/neutral.png");
        }

        public override void Update()
        {
            BackgroundColor = Color.FromArgb((int)((Math.Sin(Game.Time.TimeSinceStart) + 1) * 128), (int)((Math.Sin(Game.Time.TimeSinceStart * 0.67) + 1) * 128), (int)((Math.Sin(Game.Time.TimeSinceStart * 0.33) + 1) * 128));

            if (Input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.W)) { y--; }
            if (Input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A)) { x--; }
            if (Input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.S)) { y++; }
            if (Input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D)) { x++; }
        }

        public override void Draw(Game.Shapes gfx)
        {
            gfx.DrawRectangle(new Vector2d(x, y), new Vector2d(100, 100), Color4.Aqua, false);
            gfx.DrawQuad(new Vector2d(x, y), new Vector2d(200, 100), new Vector2d(100, 200), new Vector2d(200, 200), Color4.Red, nTex, false);
            gfx.DrawLine(new Vector2d(x, y), new Vector2d(200, 200), Color4.Yellow, (float)Math.Sin(Game.Time.TimeSinceStart) * 100f, false);
            gfx.DrawTriangle(new Vector2d(x, y), new Vector2d(300, 200), new Vector2d(200, 300), Color4.Magenta, false);
            gfx.DrawPixel(new Vector2i((int)x + 320, (int)y + 240), Color4.Lime);
            gfx.DrawPoint(new Vector2i((int)x + 350, (int)y + 240), Color4.Lime, (float)Math.Sin(Game.Time.TimeSinceStart) * 10f);
            gfx.DrawText(Vector2d.Zero, Math.Round(Game.Time.FPS) + " FPS", Color4.Red, 1);
        }
    }
}
