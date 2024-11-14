namespace Renderite2D_Project.Renderite2D.Components.RenderComponents
{
    public class AnimatedSpriteRenderer : SpritesheetRenderer
    {
        public double TimePerFrame {  
            get
            {
                return timePerFrame;
            }
            set
            {
                timePerFrame = value < 0 ? 0 : value;
            }
        }
        public int EndFrameIndex { get { return endFrameIndex; } set { endFrameIndex = value < 0 ? 0 : value; } }
        public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
        public bool PlayReverse { get; set; }

        private double timePerFrame = Game.Time.FixedDeltaTime * 10;
        private double animTime = 0;
        private int endFrameIndex = 0;
        private bool isPlaying = true;

        public AnimatedSpriteRenderer(GameObject parent) : base(parent) { }

        public override void FixedUpdate()
        {
            if (IsPlaying)
            {
                if (animTime >= timePerFrame)
                {
                    animTime = 0;
                    index = PlayReverse ? 
                        (index <= 0 ? endFrameIndex : index - 1) : 
                        (index >= endFrameIndex ? 0 : index + 1);
                }
                animTime += Game.Time.FixedDeltaTime;
            }
            else animTime = 0;
        }
    }
}
