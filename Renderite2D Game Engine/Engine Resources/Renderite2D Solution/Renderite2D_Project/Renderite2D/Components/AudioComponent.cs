using System.IO;

namespace Renderite2D_Project.Renderite2D.Components
{
    public class AudioComponent : Component
    {
        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (File.Exists(value))
                { 
                    filePath = value;
                    Game.AudioPlayer.PreloadSound(filePath);
                }
            }
        }
        public float Volume 
        { 
            get { return volume; }
            set { volume = value < 0 ? 0 : value; } 
        }

        string filePath = string.Empty;
        float volume = 1f;
        double timeSincePlay = 0;
        double audioLength = 0;
        bool looping = false;

        public AudioComponent(GameObject parent) : base(parent) { }

        public override void FixedUpdate() 
        {
            if (looping)
            {
                if (timeSincePlay >= audioLength)
                    Play(looping);

                timeSincePlay += Game.Time.FixedDeltaTime;
            }
        }

        public void Play(bool loopAudio = false)
        {
            looping = loopAudio;
            timeSincePlay = 0;
            audioLength = Game.AudioPlayer.PlaySound(FilePath, Volume);
        }

        public void StopLooping()
        {
            looping = false;
        }

        public bool IsLooping()
        {
            return looping;
        }

        public override void Update() { }
    }
}
