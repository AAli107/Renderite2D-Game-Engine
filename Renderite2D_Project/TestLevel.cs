using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Renderite2D_Project.Renderite2D;
using Renderite2D_Project.Renderite2D.Components;
using Renderite2D_Project.Renderite2D.Components.RenderComponents;
using Renderite2D_Project.Renderite2D.Game_Features.Game_Objects.Characters;
using Renderite2D_Project.Renderite2D.Graphics;


namespace Renderite2D_Project
{
    public class _Lvl_Level1 : Level
    {
        readonly Texture __background_texture__ =
            new("Assets\\Game Assets\\Apple.png");
        readonly Color __background_texture_color__ =
            Color.FromArgb(255, 0, 255, 0);

        public override void Begin()
        {
            BackgroundColor = Color.FromArgb(255, 145, 197, 217);
            {
                var gameObject = new GameObject(new Transform2D(new(215, 380), new(16, 0.7)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0.1f;
                }
                {
                    var component = gameObject.AddComponent<RectRenderer>();
                    component.IsEnabled = true;
                    component.layer = 6;
                    component.isStatic = true;
                    component.isCentered = false;
                    component.isOutline = true;
                    component.position.X = 5;
                    component.position.Y = -5;
                    component.dimension.X = 10430.9;
                    component.dimension.Y = 4004;
                    component.color = Color.FromArgb(255, 0, 0, 255);
                    component.texture = new Texture("Assets\\Game Assets\\Apple.png");
                }
                Game.World.Instantiate(gameObject);
            }
            {
                var gameObject = new GameObject(new Transform2D(new(-57.5, -107.5), new(1, 2)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<LineRenderer>();
                    component.IsEnabled = true;
                    component.layer = 3;
                    component.isStatic = true;
                    component.pointA.X = -45;
                    component.pointA.Y = -55;
                    component.pointB.X = 40;
                    component.pointB.Y = 60;
                    component.color = Color.FromArgb(255, 255, 0, 0);
                    component.width = 6.9f;
                }
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0.1f;
                }
                Game.World.Instantiate(gameObject);
            }
            {
                var gameObject = new GameObject(new Transform2D(new(677.5, 217.5), new(2, 2)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<TextRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = true;
                    component.position.X = 10;
                    component.position.Y = 13;
                    component.text = "Hello World!";
                    component.color = Color.FromArgb(255, 255, 0, 0);
                    component.scale = 4f;
                }
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0.1f;
                }
                Game.World.Instantiate(gameObject);
            }
            {
                var gameObject = new GameObject(new Transform2D(new(422.5, -282.5), new(2, 2)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<AnimatedSpriteRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.isCentered = true;
                    component.index = 0;
                    component.divisions = 2;
                    component.position.X = -6;
                    component.position.Y = 0;
                    component.dimension.X = 100;
                    component.dimension.Y = 100;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture("Assets\\Game Assets\\Apple.png");
                    component.TimePerFrame = 0.166666666666667;
                    component.EndFrameIndex = 0;
                    component.IsPlaying = true;
                    component.PlayReverse = false;
                }
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0.1f;
                }
                Game.World.Instantiate(gameObject);
            }
            {
                var gameObject = new GameObject(new Transform2D(new(155, 232.5), new(1, 1.7)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<PhysicsComponent>();
                    component.IsEnabled = true;
                    component.mass = 10f;
                    component.friction = 0.1f;
                    component.isAirborne = true;
                    component.gravityEnabled = true;
                    component.gravityMultiplier = 1;
                }
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0.1f;
                }
                {
                    var component = gameObject.AddComponent<AudioComponent>();
                    component.IsEnabled = true;
                    component.FilePath = "";
                    component.Volume = 1;
                }
                {
                    var component = gameObject.AddComponent<AnimatedSpriteRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.isCentered = true;
                    component.index = 0;
                    component.divisions = 2;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.dimension.X = 100;
                    component.dimension.Y = 100;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                    component.TimePerFrame = 0.166666666666667;
                    component.EndFrameIndex = 0;
                    component.IsPlaying = true;
                    component.PlayReverse = false;
                }
                {
                    var component = gameObject.AddComponent<LineRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 26;
                    component.pointB.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.width = 1f;
                }
                {
                    var component = gameObject.AddComponent<PointRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.size = 1;
                }
                {
                    var component = gameObject.AddComponent<QuadRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = -50;
                    component.pointC.X = -50;
                    component.pointC.Y = 50;
                    component.pointD.X = 50;
                    component.pointD.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<QuadSpritesheetRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.index = 0;
                    component.divisions = 2;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = -50;
                    component.pointC.X = -50;
                    component.pointC.Y = 50;
                    component.pointD.X = 50;
                    component.pointD.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<SpritesheetRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.isCentered = true;
                    component.index = 0;
                    component.divisions = 2;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.dimension.X = 100;
                    component.dimension.Y = 100;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<TextRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = true;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.text = "Default Text";
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.scale = 1f;
                }
                {
                    var component = gameObject.AddComponent<TriangleRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = -50;
                    component.pointC.X = -50;
                    component.pointC.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                Game.World.Instantiate(gameObject);
            }
            {
                var gameObject = new GameObject(new Transform2D(new(-260, 237.5), new(1, 1.7)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<QuadSpritesheetRenderer>();
                    component.IsEnabled = true;
                    component.layer = 6;
                    component.isStatic = true;
                    component.index = 3;
                    component.divisions = 6;
                    component.pointA.X = -45;
                    component.pointA.Y = -54;
                    component.pointB.X = 46;
                    component.pointB.Y = -48;
                    component.pointC.X = -48;
                    component.pointC.Y = 46;
                    component.pointD.X = 53;
                    component.pointD.Y = 46;
                    component.color = Color.FromArgb(255, 128, 128, 0);
                    component.texture = new Texture("Assets\\Game Assets\\Apple.png");
                }
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0.1f;
                }
                Game.World.Instantiate(gameObject);
            }
            {
                var gameObject = new GameObject(new Transform2D(new(-432.5, -317.5), new(1, 1)))
                {
                    IsEnabled = true,
                };
                {
                    var component = gameObject.AddComponent<PhysicsComponent>();
                    component.IsEnabled = true;
                    component.mass = 0f;
                    component.friction = 0f;
                    component.isAirborne = true;
                    component.gravityEnabled = true;
                    component.gravityMultiplier = 0;
                }
                {
                    var component = gameObject.AddComponent<ColliderComponent>();
                    component.IsEnabled = true;
                    component.transform.position.X = 0;
                    component.transform.position.Y = 0;
                    component.transform.scale.X = 1;
                    component.transform.scale.Y = 1;
                    component.isSolidCollision = true;
                    component.friction = 0f;
                }
                {
                    var component = gameObject.AddComponent<AudioComponent>();
                    component.IsEnabled = true;
                    component.FilePath = "Assets\\Game Assets\\8-bit explosion.wav";
                    component.Volume = 0;
                }
                {
                    var component = gameObject.AddComponent<AnimatedSpriteRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.isCentered = true;
                    component.index = 0;
                    component.divisions = 2;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.dimension.X = 100;
                    component.dimension.Y = 100;
                    component.color = Color.FromArgb(255, 128, 0, 64);
                    component.texture = new Texture("Assets\\Game Assets\\Apple.png");
                    component.TimePerFrame = 0.166666666666667;
                    component.EndFrameIndex = 0;
                    component.IsPlaying = true;
                    component.PlayReverse = false;
                }
                {
                    var component = gameObject.AddComponent<LineRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.width = 1f;
                }
                {
                    var component = gameObject.AddComponent<PointRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.size = 1;
                }
                {
                    var component = gameObject.AddComponent<QuadRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = -50;
                    component.pointC.X = -50;
                    component.pointC.Y = 50;
                    component.pointD.X = 50;
                    component.pointD.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<QuadSpritesheetRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.index = 0;
                    component.divisions = 2;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = -50;
                    component.pointC.X = -50;
                    component.pointC.Y = 50;
                    component.pointD.X = 50;
                    component.pointD.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<RectRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.isCentered = true;
                    component.isOutline = false;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.dimension.X = 100;
                    component.dimension.Y = 100;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<SpritesheetRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.isCentered = true;
                    component.index = 0;
                    component.divisions = 2;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.dimension.X = 100;
                    component.dimension.Y = 100;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                {
                    var component = gameObject.AddComponent<TextRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = true;
                    component.position.X = 0;
                    component.position.Y = 0;
                    component.text = "Default Text";
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.scale = 1f;
                }
                {
                    var component = gameObject.AddComponent<TriangleRenderer>();
                    component.IsEnabled = true;
                    component.layer = 0;
                    component.isStatic = false;
                    component.pointA.X = -50;
                    component.pointA.Y = -50;
                    component.pointB.X = 50;
                    component.pointB.Y = -50;
                    component.pointC.X = -50;
                    component.pointC.Y = 50;
                    component.color = Color.FromArgb(255, 255, 255, 255);
                    component.texture = new Texture();
                }
                Game.World.Instantiate(gameObject);
            }

        }

        public override void Update()
        {
            // __update_code__
        }

        public override void FixedUpdate()
        {
            // __fixed_update_code__
        }

        public override void Draw(Game.Shapes gfx)
        {
            if (__background_texture__ != null && !__background_texture__.IsMissingTexture)
                gfx.DrawRectangle(new(0, 0), new(1920, 1080),
                    __background_texture_color__, __background_texture__, true);
            // __draw_code__
        }

        public override void End()
        {
            // __end_code__
        }
    }
}
