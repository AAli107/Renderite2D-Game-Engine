using OpenTK.Mathematics;

namespace Renderite2D_Project.Renderite2D.Graphics
{
    public struct Font
    {
        // The order the font texture must have to display properly
        public static readonly char[] characterSheet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-=_+[]{}\\|;:'\".,<>/?`~ ".ToCharArray();
        public static readonly Font defaultFont = new(); // Returns the default font

        public string fontPath = "Assets/Engine Assets/default_font.png"; // Default font texture path
        public Vector2 charSize = new(16, 32); // The dimension of a single character within the font texture

        public Font() { } // Default constructor for the default font

        // This is to load a new font of your own
        public Font(string fontPath, Vector2i charSize)
        {
            this.fontPath = fontPath;
            this.charSize = charSize;
        }
    }
}
