﻿using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Renderite2D_Project.Renderite2D;
using Renderite2D_Project.Renderite2D.Components;
using Renderite2D_Project.Renderite2D.Graphics;
using System;
using System.Drawing;

namespace Renderite2D_Project
{
    public class SampleLevel : Level
    {
        Texture nTex;
        GameObject gameObjectTest;
        GameObject gameObjectTest2;
        PhysicsComponent pc;
        ColliderComponent cc;
        AudioComponent ac;

        public override void Begin()
        {
            nTex = new("Assets/Game Assets/neutral.png");
            gameObjectTest = new(new Vector2d(500, 0));
            pc = gameObjectTest.AddComponent<PhysicsComponent>();
            cc = gameObjectTest.AddComponent<ColliderComponent>();
            ac = gameObjectTest.AddComponent<AudioComponent>();
            ac.FilePath = "Assets/Game Assets/pick.wav";
            gameObjectTest2 = new(new Vector2d(500, 600));
            var cc2 = gameObjectTest2.AddComponent<ColliderComponent>();
            cc2.transform.scale = new Vector2d(5, 1);
            Game.World.Instantiate(gameObjectTest);
            Game.World.Instantiate(gameObjectTest2);
        }

        public override void Update()
        {
            if (Input.IsKeyDown(Keys.Up)) { Game.Time.TimeScale += Game.Time.DeltaTime; }
            if (Input.IsKeyDown(Keys.Down)) { Game.Time.TimeScale -= Game.Time.DeltaTime; }

            if (Input.IsKeyPressed(Keys.P)) Game.LoadLevel(new SampleLevel());

            if (Input.IsKeyPressed(Keys.Space)) { pc.Velocity = new Vector2d(pc.Velocity.X, -20); }


            if (Input.IsKeyPressed(Keys.Enter))
            {
                //Game.AudioPlayer.PlaySound("Assets/Game Assets/pick.wav");
                ac.Play(true);
            }
            if (Input.IsKeyPressed(Keys.Slash))
                ac.StopLooping();
        }

        public override void FixedUpdate()
        {
            BackgroundColor = Color.FromArgb((int)((Math.Sin(Game.Time.TimeSinceLevelStart) + 1) * 128) / 2, (int)((Math.Sin(Game.Time.TimeSinceLevelStart * 0.67) + 1) * 128) / 2, (int)((Math.Sin(Game.Time.TimeSinceLevelStart * 0.33) + 1) * 128) / 2);

            if (Input.IsKeyDown(Keys.W)) { pc.AddVelocity(-Vector2d.UnitY); }
            if (Input.IsKeyDown(Keys.A)) { pc.AddVelocity(-Vector2d.UnitX); }
            if (Input.IsKeyDown(Keys.S)) { pc.AddVelocity(Vector2d.UnitY); }
            if (Input.IsKeyDown(Keys.D)) { pc.AddVelocity(Vector2d.UnitX); }
        }

        public override void Draw(Game.Shapes gfx)
        {
            var v = new Vector2d(gameObjectTest.transform.position.X, gameObjectTest.transform.position.Y);
            gfx.DrawRectangle(v - cc.GetHalfSize(), new Vector2d(100, 100), Color4.White, nTex);
            gfx.DrawQuad(new Vector2d(100, 100), new Vector2d(200, 100), new Vector2d(100, 200), new Vector2d(200, 200), Color4.Yellow);
            gfx.DrawLine(v, new Vector2d(150, 150), Color4.Violet, (float)Math.Sin(Game.Time.TimeSinceLevelStart) * 25f);
            gfx.DrawTriangle(new Vector2d(800, 200), new Vector2d(700, 200), new Vector2d(600, 300), Color4.Magenta);
            gfx.DrawPixel(new Vector2i(320, 240), Color4.Red);
            gfx.DrawPoint(new Vector2i(350, 240), Color4.Lime, (float)Math.Sin(Game.Time.TimeSinceLevelStart) * 10f);
            gfx.DrawText(Vector2d.Zero, Math.Round(Game.Time.FPS) + " FPS", Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 28, "Time Since Level start = " + Game.Time.TimeSinceLevelStart, Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 56, "TimeScale = " + Game.Time.TimeScale, Color4.Red, 1);
        }
    }
}
