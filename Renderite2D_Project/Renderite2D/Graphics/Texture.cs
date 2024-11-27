using OpenTK.Graphics.OpenGL4;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Renderite2D_Project.Renderite2D.Graphics
{
    public class Texture
    {
        public static readonly Texture White = new();
        public static readonly Texture MissingTexture = new(string.Empty);

        public int TextureInt { get; private set; }
        public bool IsMissingTexture { get; private set; }

        public Texture()
        {
            MakeTexture("", Color.White);
        }

        public Texture(Color c)
        {
            MakeTexture("", c);
        }

        public Texture(string path)
        {
            MakeTexture(path);
        }

        /// <summary>
        /// Loads / Creates the texture
        /// </summary>
        /// <param name="texturePath"></param>
        /// <param name="c"></param>
        private void MakeTexture(string texturePath, Color? c = null)
        {
            Bitmap bm;

            if (c == null) // If color is not specified, it will load a missing texture
            {
                bm = new(2, 2);
                bm.SetPixel(0, 0, Color.Magenta);
                bm.SetPixel(0, 1, Color.Black);
                bm.SetPixel(1, 0, Color.Black);
                bm.SetPixel(1, 1, Color.Magenta);
            }
            else
            {
                bm = new(1, 1);
                bm.SetPixel(0, 0, c.Value);
            }

            // Will load texture into a bitmap
            if (File.Exists(texturePath))
                bm = new Bitmap(texturePath);
            else IsMissingTexture = true;

            // Generates the texture int
            TextureInt = GL.GenTexture();

            // Bind the texture and set its parameters
            GL.BindTexture(TextureTarget.Texture2D, TextureInt);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bm.Width, bm.Height, 0, PixelFormat.Bgra, PixelType.Float, IntPtr.Zero);
                
            // Reads bitmap data and convert it into a byte array
            System.Drawing.Imaging.BitmapData bmpData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), 
                System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] data = new byte[bmpData.Stride * bmpData.Height];
            Marshal.Copy(bmpData.Scan0, data, 0, data.Length);
            bm.UnlockBits(bmpData);

            // Inserts texture data
            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bm.Width, bm.Height, PixelFormat.Bgra, PixelType.UnsignedByte, data);
            
            // Bitmap object disposal
            bm.Dispose();

            // Set texture parameters (texture filter and wrapping)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            // Bind the texture
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        /// <summary>
        /// Makes the whatever is being drawn to bind to this texture and use it.
        /// </summary>
        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, TextureInt);
        }

        /// <summary>
        /// Would unbind whatever texture is currently bound.
        /// </summary>
        public static void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        /// <summary>
        /// Returns a newly instantiated texture with the specified color.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Texture FromColor(Color c)
        {
            return new(c);
        }
    }
}
