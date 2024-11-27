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
        readonly Texture __background_texture__ = 
            new("__bg_texture_path_name__");
        readonly Color __background_texture_color__ = 
            Color.White; // __background_texture_color__

        public override void Begin()
        {
            // __begin_code__
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
                gfx.DrawRectangle(new(0,0),new(1920,1080),
                    __background_texture_color__, __background_texture__, true);
            // __draw_code__
        }

        public override void End()
        {
            // __end_code__
        }
    }
}
