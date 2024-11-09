using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D.Components
{
    public class PhysicsComponent : Component
    {
        /// <summary>
        /// velocity of the game object
        /// </summary>
        public Vector2d Velocity { get; set; }
        /// <summary>
        /// The mass of the game object
        /// </summary>
        public float mass = 10f;
        /// <summary>
        /// movement friction that slows down the game object the higher the value
        /// </summary>
        public float friction = 0.1f;
        /// <summary>
        /// controls the behavior of the friction applied to the game object so that it behaves like it's airborne when true
        /// </summary>
        public bool isAirborne = true;
        /// <summary>
        /// Controls whether the game object has gravity or not
        /// </summary>
        public bool gravityEnabled = true;
        /// <summary>
        /// controls the direction of gravity
        /// </summary>
        public Vector2d gravityVector = Vector2.UnitY;
        /// <summary>
        /// controls the strength of gravity affecting the game object
        /// </summary>
        public float gravityMultiplier = 1;

        public PhysicsComponent(GameObject parent) : base(parent) { }

        public override void FixedUpdate()
        {
            // Will not apply physics if the physics component is disabled
            if (!IsEnabled) return;

            // Applies gravity to the game object
            if (gravityEnabled) 
                Velocity += gravityVector * gravityMultiplier;

            // Manipulates velocity based on friction and mass
            Velocity *= 1 / (((isAirborne ? (friction * (1 / mass)) : friction) + 1) >= 1 ? ((isAirborne ? (friction * (1 / mass)) : friction) + 1) : 1);

            // Applies velocity by moving the game object
            Parent.transform.position += Velocity;
        }

        /// <summary>
        /// Adds the specified velocity over the existing velocity of the game object
        /// </summary>
        /// <param name="velocity"></param>
        public void AddVelocity(Vector2d velocity)
        {
            if (!IsEnabled) return;
            Velocity += velocity;
        }

        public override void Update() { }
    }
}
