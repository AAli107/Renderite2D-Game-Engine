using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Renderite2D_Project.Renderite2D;
using Renderite2D_Project.Renderite2D.Components;
using Renderite2D_Project.Renderite2D.Components.RenderComponents;
using Renderite2D_Project.Renderite2D.Game_Features;
using Renderite2D_Project.Renderite2D.Game_Features.Game_Objects;
using Renderite2D_Project.Renderite2D.Game_Features.Game_Objects.Characters;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project
{
    public class __class_name__ : ScriptComponent
    {
        public __class_name__(GameObject parent) : base(parent) { }
        
        public override void Start()
        {
            // Is called when script is first loaded (constructor)
        }
        
        public override void Update()
        {
            // Is called once per frame
        }
        
        public override void FixedUpdate()
        {
            // Is called fixed amount of times per second
            
        }
        
        public override void End()
        {
            // Is called when script is unloaded (destructor)
        }
    }
}
