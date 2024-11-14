using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Components;
using System;

namespace Renderite2D_Project.Renderite2D.Game_Features.Game_Objects.Characters
{
    public class TopDownCharacter : Character
    {
        private const double deg2rad = 0.01745329251994329576923690768489;

        public Vector2d Forward { get { return Vector2d.Transform(-Vector2d.UnitY, Quaterniond.FromEulerAngles(0, 0, lookRotation * deg2rad)).Normalized(); } }
        public Vector2d Right { get { return Vector2d.Transform(-Vector2d.UnitY, Quaterniond.FromEulerAngles(0, 0, (lookRotation + 90) * deg2rad)).Normalized(); } }
        public float LookRotation { get { return lookRotation; } set => lookRotation = value % 360f; }

        private float lookRotation = 0f;

        public TopDownCharacter() : base() { }

        public TopDownCharacter(Vector2d position) : base(position) { }

        public TopDownCharacter(Transform2D transform) : base(transform) { }

        protected override void Construct()
        {
            base.Construct();
            physics = AddComponent<PhysicsComponent>();
            physics.isAirborne = false;
            physics.gravityEnabled = false;
            physics.gravityVector = Vector2d.Zero;
            physics.gravityMultiplier = 0f;
        }
    }
}
