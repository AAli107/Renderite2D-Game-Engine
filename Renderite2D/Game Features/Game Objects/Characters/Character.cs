using OpenTK.Mathematics;
using Renderite2D_Project.Renderite2D.Components;
using System;

namespace Renderite2D_Project.Renderite2D.Game_Features.Game_Objects.Characters
{
    public abstract class Character : GameObject
    {
        public static event Action<Character> OnCharacterDeath;
        public static event Action<Character> OnCharacterTickUpdate;
        public static event Action<CharacterHurtArgs> BeforeCharacterHurt;
        public static event Action<CharacterHealArgs> BeforeCharacterHeal;

        public float Health 
        { 
            get { return health; }
            set 
            {
                bool preAlive = IsAlive;
                health = value < 0 ? 0 : (value > maxHealth ? maxHealth : value);
                if (preAlive && !IsAlive)
                    OnCharacterDeath?.Invoke(this);
            }
        }
        public float MaxHealth 
        { 
            get { return maxHealth; }
            set 
            { 
                maxHealth = value < 0 ? 0 : value;
                if (maxHealth < health)
                    health = maxHealth;
            }
        }
        public double IFrames
        {
            get { return iFrames; }
            set => iFrames = value < 0 ? 0 : value;
        }
        public bool Invincibility
        {
            get { return invincibility; }
            set => invincibility = value;
        }

        public bool IsAlive {  get { return health > 0; } }
        public bool IsImmuneToDamage { get { return invincibility || iFrames > 0; } }

        protected ColliderComponent collider = null;
        protected PhysicsComponent physics = null;

        private float health = 0f;
        private float maxHealth = 100f;
        private double iFrames = 0f;
        private bool invincibility = false;

        public Character() : base()
        {
            Construct();
        }

        public Character(Vector2d position) : base(position)
        {
            Construct();
        }

        public Character(Transform2D transform) : base(transform)
        {
            Construct();
        }

        protected virtual void Construct()
        {
            health = maxHealth;
            collider = AddComponent<ColliderComponent>();
        }

        protected override void Update_()
        {
            base.Update_();
            
            if (iFrames > 0)
                iFrames -= Game.Time.FixedDeltaTime;

            OnCharacterTickUpdate?.Invoke(this);
        }

        public void Damage(float amount, double iFrames = 0.5)
        {
            if (IsImmuneToDamage || !IsAlive) return;
            CharacterHurtArgs hurtArgs = new(this, amount, iFrames);
            BeforeCharacterHurt?.Invoke(hurtArgs);
            IFrames = hurtArgs.IFrames;
            Health -= Math.Abs(hurtArgs.Amount);
        }

        public void Heal(float amount)
        {
            if (!IsAlive) return;
            CharacterHealArgs hurtArgs = new(this, amount);
            BeforeCharacterHeal?.Invoke(hurtArgs);
            Health += Math.Abs(hurtArgs.Amount);
        }

        public void Kill()
        {
            Health = 0;
        }

        public void Move(Vector2d direction, double speed)
        {
            if (physics != null && IsAlive)
                physics.AddVelocity(direction.Normalized() * speed);
        }

        public void Move(Vector2d velocity)
        {
            if (physics != null && IsAlive)
                physics.AddVelocity(velocity);
        }
    }

    public class CharacterHurtArgs
    {
        readonly Character character;
        float amount;
        double iFrames;

        public Character Character { get { return character; } }
        public float Amount {  get { return amount; } set { amount = value < 0 ? 0 : value; } }
        public double IFrames {  get { return iFrames; } set { iFrames = value < 0 ? 0 : value; } }

        public CharacterHurtArgs(Character character, float amount, double iFrames)
        {
            this.character = character;
            this.amount = Math.Abs(amount);
            this.iFrames = iFrames;
        }
    }

    public class CharacterHealArgs
    {
        readonly Character character;
        float amount;

        public Character Character { get { return character; } }
        public float Amount { get { return amount; } set { amount = value < 0 ? 0 : value; } }

        public CharacterHealArgs(Character character, float amount)
        {
            this.character = character;
            this.amount = Math.Abs(amount);
        }
    }
}
