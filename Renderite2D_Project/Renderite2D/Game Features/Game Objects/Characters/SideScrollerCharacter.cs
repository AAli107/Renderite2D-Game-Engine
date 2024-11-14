using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Components;

namespace Renderite2D_Project.Renderite2D.Game_Features.Game_Objects.Characters
{
    public class SideScrollerCharacter : Character
    {
        public double JumpStrength { get { return jumpStrength; } set => jumpStrength = value < 0 ? 0 : value; }
        public int JumpCount { get { return jumpCount; } set => jumpCount = value < -1 ? -1 : value; }
        public int JumpsLeft { get { return jumpN; } set => jumpN = value < 0 ? 0 : (value > jumpCount ? jumpCount : value); }
        public bool IsGrounded { get { return isGrounded; } }
        public bool CanJump { get { return IsAlive && (JumpsLeft > 0 || JumpCount == -1); } }
        
        private double jumpStrength = 20;
        private int jumpCount = 1;
        private int jumpN = 1;
        private bool isGrounded = false;

        private ColliderComponent groundCollider;

        public SideScrollerCharacter() : base() { }
        public SideScrollerCharacter(Vector2d position) : base(position) { }
        public SideScrollerCharacter(Transform2D transform) : base(transform) { }

        protected override void Construct()
        {
            base.Construct();
            physics = AddComponent<PhysicsComponent>();
            groundCollider = AddComponent<ColliderComponent>();
            groundCollider.isSolidCollision = false;
        }

        protected override void Update_()
        {
            base.Update_();

            if (groundCollider != null && collider != null)
            {
                groundCollider.transform.scale = new Vector2d(collider.transform.scale.X * 0.99, 0.001);
                groundCollider.transform.position.Y = ((transform.scale.Y * collider.transform.scale.Y * 100 * 0.999) / 2d) + 1;
                isGrounded = groundCollider.IsOverlapping();
            } else isGrounded = true;

            if (IsGrounded) jumpN = JumpCount;
        }

        public void Jump()
        {
            if (CanJump)
            {
                Move(new Vector2d(physics.Velocity.X, -JumpStrength), true);
                jumpN = jumpN - 1 < 0 ? 0 : jumpN - 1;
            }
        }
    }
}
