using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D;
using Renderite2D_Project.Renderite2D.Graphics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing;
using System;

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
            if (Input.IsKeyDown(Keys.Up)) { Game.Time.TimeScale += Game.Time.DeltaTime; }
            if (Input.IsKeyDown(Keys.Down)) { Game.Time.TimeScale -= Game.Time.DeltaTime; }

            if (Input.IsKeyPressed(Keys.P)) Game.LoadLevel(new SampleLevel());
        }

        public override void FixedUpdate()
        {
            BackgroundColor = Color.FromArgb((int)((System.Math.Sin(Game.Time.TimeSinceLevelStart) + 1) * 128), (int)((Math.Sin(Game.Time.TimeSinceLevelStart * 0.67) + 1) * 128), (int)((Math.Sin(Game.Time.TimeSinceLevelStart * 0.33) + 1) * 128));

            if (Input.IsKeyDown(Keys.W)) { y--; }
            if (Input.IsKeyDown(Keys.A)) { x--; }
            if (Input.IsKeyDown(Keys.S)) { y++; }
            if (Input.IsKeyDown(Keys.D)) { x++; }
        }

        public override void Draw(Game.Shapes gfx)
        {
            gfx.DrawRectangle(new Vector2d(x, y), new Vector2d(100, 100), Color4.Aqua, false);
            gfx.DrawQuad(new Vector2d(x, y), new Vector2d(200, 100), new Vector2d(100, 200), new Vector2d(200, 200), Color4.Red, nTex, false);
            gfx.DrawLine(new Vector2d(x, y), new Vector2d(200, 200), Color4.Yellow, (float)Math.Sin(Game.Time.TimeSinceLevelStart) * 100f, false);
            gfx.DrawTriangle(new Vector2d(x, y), new Vector2d(300, 200), new Vector2d(200, 300), Color4.Magenta, false);
            gfx.DrawPixel(new Vector2i((int)x + 320, (int)y + 240), Color4.Lime);
            gfx.DrawPoint(new Vector2i((int)x + 350, (int)y + 240), Color4.Lime, (float)Math.Sin(Game.Time.TimeSinceLevelStart) * 10f);
            gfx.DrawText(Vector2d.Zero, Math.Round(Game.Time.FPS) + " FPS", Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 28, "Time Since Level start = " + Game.Time.TimeSinceLevelStart, Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 56, "TimeScale = " + Game.Time.TimeScale, Color4.Red, 1);
        }
    }
}
