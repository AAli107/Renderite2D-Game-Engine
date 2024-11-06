using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using Renderite2D_Project.Renderite2D.Graphics;
using System.Drawing;
using System;

namespace Renderite2D_Project.Renderite2D
{
    public class Game : GameWindow
    {
        /// <summary>
        /// Fixed frequency of updates the game will run at
        /// </summary>

        Shader shader = null;
        Shapes gfx = null;
        Level currentLevel;
        RunningLevel runningLevel;
        double timeSinceStart = 0;
        Graphics.Font currentFont = new();
        double timeScale = 1.0;
        double fixedUpdateAccumulatedTime = 0.0;
        double targetFrametime;

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) :
            base(gameWindowSettings, nativeWindowSettings) { }

        public static void LoadLevel(Level level)
        {
            if (level == null) return;

            Program.GameWindow.currentLevel?.End(); // Executes the End() method of the current level
            Program.GameWindow.runningLevel = new(); // Running Level is cleared
            Program.GameWindow.currentLevel = level; // The given level is set
            Program.GameWindow.currentLevel?.Begin(); // Executes the Begin() method in the newly loaded level
        }

        protected override void OnLoad()
        {
            Time.FixedUpdateFrequency = 60;

            base.OnLoad();
            ClientSize = new Vector2i(1280, 720);
            AspectRatio = (16, 9);
            CenterWindow();
            WindowBorder = WindowBorder.Fixed;
            Title = "Renderite2D Game";

            shader = new("Assets/Engine Assets/vertexShader.vert", "Assets/Engine Assets/fragmentShader.frag");
            gfx = new();

            GL.UseProgram(shader.shaderHandle);
            GL.BindVertexArray(shader.vertArrayObj);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, sizeof(float) * 4, 0);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, sizeof(float) * 4, sizeof(float) * 2);

            // Adds support for transparency for textures
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            LoadLevel(new SampleLevel());
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (timeScale > 0)
            {
                fixedUpdateAccumulatedTime += UpdateTime;
                while (fixedUpdateAccumulatedTime >= targetFrametime / timeScale)
                {
                    runningLevel.UpdateRunningLevel();
                    currentLevel?.FixedUpdate();
                    fixedUpdateAccumulatedTime -= targetFrametime / timeScale;
                }
            }

            currentLevel?.Update();

            timeSinceStart += UpdateTime;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            // Pre-rendering setup
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            currentLevel?.Draw(gfx);

            // Post-Rendering Clear and swap buffer with background color
            GL.ClearColor(currentLevel != null ? currentLevel.BackgroundColor : Color.Black);
            SwapBuffers();
        }

        protected override void OnUnload()
        {
            currentLevel?.End();
            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            shader.Dispose(); // Will dispose shader data
            base.OnUnload();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            // Will fix the game's viewport whenever the window resizes
            GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
        }

        public struct RunningLevel
        {
            public double TimeSinceLevelStart { get; private set; }

            public RunningLevel() 
            {
                TimeSinceLevelStart = 0.0;
            }

            public void UpdateRunningLevel()
            {
                TimeSinceLevelStart += Time.FixedDeltaTime * Time.TimeScale;
            }
        }

        public class Time
        {
            private static readonly Game win = Program.GameWindow;

            public static double DeltaTime { get { return win.UpdateTime; } }
            public static double FixedDeltaTime { get { return win.targetFrametime; } }
            public static double FPS { get { return 1 / win.UpdateTime; } }
            public static double TimeSinceStart { get { return win.timeSinceStart; } }
            public static double TimeSinceLevelStart { get { return win.runningLevel.TimeSinceLevelStart; } }
            public static double TimeScale { get { return win.timeScale; } set { win.timeScale = value < 0 ? 0 : value; } }
            public static double FixedUpdateFrequency { get { return 1 / win.targetFrametime; } set { win.targetFrametime = 1 / (value < 0 ? 0 : value); } }
        }

        public class Shapes
        {
            private readonly Game win = Program.GameWindow;
            private readonly Texture fontTexture = new (Program.GameWindow.currentFont.fontPath);

            public void DrawRectangle(Vector2d position, Vector2d dimension, Color4 color, Texture texture, bool isStatic = false)
            {
                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                texture.Bind(); // will make use of this texture by binding it

                Vector2 v = new((float)position.X / (win.ClientSize.X * 0.5f) - 1f, (float)-position.Y / (win.ClientSize.Y * 0.5f) + 1f);
                Vector2 v2 = new((float)(position.X + dimension.X) / (win.ClientSize.X * 0.5f) - 1f, ((float)-(position.Y + dimension.Y)) / (win.ClientSize.Y * 0.5f) + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    v.X, v.Y, 1.0f, 1.0f,
                    v2.X, v.Y, 0.0f, 1.0f,
                    v.X, v2.Y, 1.0f, 0.0f,
                    v2.X, v2.Y, 0.0f, 0.0f,
                };

                // Binds the data
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4); // Draws shape on screen based on data currently bound

                Texture.Unbind(); // Unbinds the currently bound texture
            }

            public void DrawRectangle(Vector2d position, Vector2d dimension, Color4 color, bool isStatic = false)
            {
                DrawRectangle(position, dimension, color, Texture.White, isStatic);
            }

            public void DrawQuad(Vector2d a, Vector2d b, Vector2d c, Vector2d d, Color4 color, Texture texture, bool isStatic = false)
            {
                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                texture.Bind(); // will make use of this texture by binding it

                Vector2 va = new((float)a.X / (win.ClientSize.X * 0.5f) - 1f, (float)-a.Y / (win.ClientSize.Y * 0.5f) + 1f);
                Vector2 vb = new((float)b.X / (win.ClientSize.X * 0.5f) - 1f, (float)-b.Y / (win.ClientSize.Y * 0.5f) + 1f);
                Vector2 vc = new((float)c.X / (win.ClientSize.X * 0.5f) - 1f, (float)-c.Y / (win.ClientSize.Y * 0.5f) + 1f);
                Vector2 vd = new((float)d.X / (win.ClientSize.X * 0.5f) - 1f, (float)-d.Y / (win.ClientSize.Y * 0.5f) + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    va.X, va.Y, 1.0f, 1.0f,
                    vb.X, vb.Y, 0.0f, 1.0f,
                    vc.X, vc.Y, 1.0f, 0.0f,
                    vd.X, vd.Y, 0.0f, 0.0f,
                };

                // Binds the data
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4); // Draws shape on screen based on data currently bound

                Texture.Unbind(); // Unbinds the currently bound texture
            }

            public void DrawQuad(Vector2d a, Vector2d b, Vector2d c, Vector2d d, Color4 color, bool isStatic = false)
            {
                DrawQuad(a, b, c, d, color, Texture.White, isStatic);
            }

            public void DrawLine(Vector2d a, Vector2d b, Color4 color, float width = 1f, bool isStatic = false)
            {
                width = MathF.Abs(width); // Will allow negative widths to be drawn properly

                if (width == 0) return; // No lines will be rendered if width is zero
                else if (width <= 1) // Will draw a line with a width of 1 pixel
                {
                    // Sends the shape color into the GPU-side and store it in uColor variable
                    GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                    // Set the texture uniform in the shader
                    GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                    Texture.White.Bind(); // will add a white texture so that color will show properly

                    // Specify the vertex data for quad
                    float[] vertices = {
                        (float)a.X / (win.ClientSize.X * 0.5f) - 1f, (float)-a.Y / (win.ClientSize.Y * 0.5f) + 1f, 1.0f, 1.0f,
                        (float)b.X / (win.ClientSize.X * 0.5f) - 1f, (float)-b.Y / (win.ClientSize.Y * 0.5f) + 1f, 0.0f, 1.0f,
                    };

                    // Binds the data
                    GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                    GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                    GL.DrawArrays(PrimitiveType.Lines, 0, 2); // Draws shape on screen based on data currently bound

                    Texture.Unbind(); // Unbinds the currently bound texture
                }
                else // Will draw a thick line if width is greater than 1
                {
                    // Calculate the half-width offset
                    Vector2d offset = (float)width * 0.5f * (b - a).Normalized().PerpendicularLeft;

                    // Draws Line using DrawQuad
                    DrawQuad(
                        a - offset,
                        a + offset,
                        b - offset,
                        b + offset, 
                        color);
                }
            }

            public void DrawTriangle(Vector2d a, Vector2d b, Vector2d c, Color4 color, Texture texture, bool isStatic = false)
            {
                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                texture.Bind(); // will make use of this texture by binding it

                Vector2 va = new((float)a.X / (win.ClientSize.X * 0.5f) - 1f, (float)-a.Y / (win.ClientSize.Y * 0.5f) + 1f);
                Vector2 vb = new((float)b.X / (win.ClientSize.X * 0.5f) - 1f, (float)-b.Y / (win.ClientSize.Y * 0.5f) + 1f);
                Vector2 vc = new((float)c.X / (win.ClientSize.X * 0.5f) - 1f, (float)-c.Y / (win.ClientSize.Y * 0.5f) + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    va.X, va.Y, 1.0f, 1.0f,
                    vb.X, vb.Y, 0.0f, 1.0f,
                    vc.X, vc.Y, 1.0f, 0.0f,
                };

                // Binds the data
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 3); // Draws shape on screen based on data currently bound

                Texture.Unbind(); // Unbinds the currently bound texture
            }

            public void DrawTriangle(Vector2d a, Vector2d b, Vector2d c, Color4 color, bool isStatic = false)
            {
                DrawTriangle(a, b, c, color, Texture.White, isStatic);
            }

            public void DrawText(Vector2d position, object obj, Color4 color, float scale = 1f, bool isStatic = true)
            {
                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                fontTexture.Bind(); // will make use of the font's texture by binding it

                string str = obj?.ToString(); // Converts whatever is passed into a string

                // Loop through the string characters to draw text
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Equals('\n') && i + 1 < str.Length)
                    {
                        // If it encounter a '\n' it will break to a new line
                        DrawText(position + new Vector2d(0, win.currentFont.charSize.Y * scale), str[(i + 1)..], color, scale, isStatic);
                        return;
                    }
                    // Draw an individual character on the screen from the given string
                    BufferCharacter(position + new Vector2d(win.currentFont.charSize.X * i * scale, 0), str[i], scale, isStatic);
                }

                Texture.Unbind(); // Unbinds the currently bound texture
            }

            private void BufferCharacter(Vector2d position, char character, float scale = 1, bool isStatic = true)
            {
                Vector2d charVec = win.currentFont.charSize * scale; // This will multiply the size of the font with the scale to get different sized character

                int charCount = Graphics.Font.characterSheet.Length; // How many characters in the character sheet char array
                int charIndex = Array.IndexOf(Graphics.Font.characterSheet, character);

                // Specify the vertex data for the quad of the triangle
                // The UV of the quad is also calculated to choose between the character within the texture to draw
                float[] vertices = {
                    (float)position.X / 960 - 1f, (float)-position.Y / 540 + 1f,
                    (1.0f / charCount) * charIndex, 0.0f,

                    (float)(position.X + charVec.X) / 960 - 1f, (float)-position.Y / 540 + 1f,
                    (1.0f / charCount) * charIndex + (1.0f / charCount), 0.0f,

                    (float)position.X / 960 - 1f, (float)-(position.Y + charVec.Y) / 540 + 1f,
                    (1.0f / charCount) * charIndex, 1.0f,

                    (float)(position.X + charVec.X) / 960 - 1f, (float)-(position.Y + charVec.Y ) / 540 + 1f,
                    (1.0f / charCount) * charIndex + (1.0f / charCount), 1.0f
                };

                // Bind the vertices array
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                // Draw the character quad
                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
            }

            public void DrawPixel(Vector2i position, Color4 color)
            {
                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                Texture.White.Bind(); // will add a white texture so that color will show properly

                // Specify the vertex data for quad
                float[] vertices = { position.X / (win.ClientSize.X * 0.5f) - 1f, -position.Y / (win.ClientSize.Y * 0.5f) + 1f, 1.0f, 1.0f };

                // Binds the data
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.Points, 0, 1); // Draws shape on screen based on data currently bound

                Texture.Unbind(); // Unbinds the currently bound texture
            }

            public void DrawPoint(Vector2d position, Color4 color, float size = 1, bool isStatic = false)
            {
                if (size == 0) return;
                Vector2d vSize = Vector2d.One * size;
                DrawRectangle(position - Vector2d.UnitX - vSize, vSize * 2, color, isStatic);
            }
        }
    }
}
