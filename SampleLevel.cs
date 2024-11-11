using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Renderite2D_Project.Renderite2D;
using Renderite2D_Project.Renderite2D.Components;
using Renderite2D_Project.Renderite2D.Components.RenderComponents;
using Renderite2D_Project.Renderite2D.Game_Features.Game_Objects.Characters;
using Renderite2D_Project.Renderite2D.Graphics;
using System;
using System.Drawing;

namespace Renderite2D_Project
{
    public class SampleLevel : Level
    {
        Texture nTex;
        Texture spriteSheetTex;
        SideScrollerCharacter player;
        GameObject gameObjectTest2;
        PhysicsComponent pc;
        AudioComponent ac;
        AnimatedSpriteRenderer asr;

        public override void Begin()
        {
            nTex = new("Assets/Game Assets/neutral.png");
            spriteSheetTex = new("Assets/Game Assets/spritesheet.png");
            player = new(new Vector2d(500, 0))
            {
                JumpCount = 2
            };
            pc = player.GetComponent<PhysicsComponent>();
            ac = player.AddComponent<AudioComponent>();
            ac.FilePath = "Assets/Game Assets/pick.wav";
            asr = player.AddComponent<AnimatedSpriteRenderer>();
            asr.texture = spriteSheetTex;
            asr.divisions = 3;
            asr.layer = 1;
            asr.EndFrameIndex = 5;
            gameObjectTest2 = new(new Vector2d(500, 600));
            var cc2 = gameObjectTest2.AddComponent<ColliderComponent>();
            cc2.transform.scale = new Vector2d(5, 1);
            var tr2 = gameObjectTest2.AddComponent<TriangleRenderer>();
            tr2.pointA = new Vector2d(-50, -100);
            tr2.pointC = new Vector2d(-100, 50);
            tr2.color = Color4.Gray;
            var txr = gameObjectTest2.AddComponent<TextRenderer>();
            txr.text = "Hello World!";
            txr.isStatic = false;
            Game.World.Instantiate(player);
            Game.World.Instantiate(gameObjectTest2);
        }

        public override void Update()
        {
            if (Input.IsKeyDown(Keys.Up)) { Game.Time.TimeScale += Game.Time.DeltaTime; }
            if (Input.IsKeyDown(Keys.Down)) { Game.Time.TimeScale -= Game.Time.DeltaTime; }

            if (Input.IsKeyPressed(Keys.P)) Game.LoadLevel(new SampleLevel());

            if (Input.IsKeyPressed(Keys.Space))
            {
                if (player.CanJump)
                    ac.Play();
                player.Jump();
            }
            if (Input.IsKeyDown(Keys.LeftAlt) && Input.IsKeyPressed(Keys.Enter))
            {
                Program.GameWindow.WindowState = Program.GameWindow.WindowState == OpenTK.Windowing.Common.WindowState.Fullscreen ?
                    OpenTK.Windowing.Common.WindowState.Normal : OpenTK.Windowing.Common.WindowState.Fullscreen;
            }

            if (Input.IsKeyPressed(Keys.V))
            {
                player.Damage(1);
            }
            if (Input.IsKeyPressed(Keys.H))
            {
                player.Heal(1);
            }


            Game.MainCamera.Transform = player.transform;
        }

        public override void FixedUpdate()
        {
            BackgroundColor = Color.FromArgb((int)((Math.Sin(Game.Time.TimeSinceLevelStart) + 1) * 128) / 2, (int)((Math.Sin(Game.Time.TimeSinceLevelStart * 0.67) + 1) * 128) / 2, (int)((Math.Sin(Game.Time.TimeSinceLevelStart * 0.33) + 1) * 128) / 2);

            if (Input.IsKeyDown(Keys.W)) { pc.AddVelocity(-Vector2d.UnitX); }
            if (Input.IsKeyDown(Keys.S)) { pc.AddVelocity(Vector2d.UnitX); }
            if (Input.IsKeyDown(Keys.A)) { pc.AddVelocity(-Vector2d.UnitX); }
            if (Input.IsKeyDown(Keys.D)) { pc.AddVelocity(Vector2d.UnitX); }
        }

        public override void Draw(Game.Shapes gfx)
        {
            var v = new Vector2d(player.transform.position.X, player.transform.position.Y);
            
            Game.DrawShape(Game.DrawType.Text, new object[] { v + new Vector2d(100, 200), "Layer 2", Color4.Orange, 4f, false}, 1);
            Game.DrawShape(Game.DrawType.Text, new object[] { new Vector2d(200, 200), "Layered Drawing", Color4.Cyan, 4f, false}, 0);

            gfx.DrawQuad(new Vector2d(300, 300), new Vector2d(500, 300), new Vector2d(300, 500), new Vector2d(500, 500), Color4.White, spriteSheetTex);
            gfx.DrawQuad(new Vector2d(100, 100), new Vector2d(200, 100), new Vector2d(100, 200), new Vector2d(200, 200), Color4.Yellow, nTex);
            gfx.DrawLine(v, new Vector2d(150, 150), Color4.Violet, (float)Math.Sin(Game.Time.TimeSinceLevelStart) * 25f);
            gfx.DrawText(Vector2d.Zero, Math.Round(Game.Time.FPS) + " FPS", Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 28, "Time Since Level start = " + Game.Time.TimeSinceLevelStart, Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 56, "TimeScale = " + Game.Time.TimeScale, Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 84, "MouseScreenPos = " + Input.MouseScreenPos, Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 112, "MouseWorldPos = " + Input.MouseWorldPos, Color4.Red, 1);
            gfx.DrawText(Vector2d.UnitY * 140, "Health = " + player.Health, Color4.Red, 1);
        }
    }
}
