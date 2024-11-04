using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using Renderite2D_Project.Renderite2D.Graphics;

namespace Renderite2D_Project.Renderite2D
{
    public class GameWin : GameWindow
    {
        public double FPS { get { return 1 / UpdateTime; } }
        public double TimeSinceStart { get; private set; }

        Shader shader = null;
        Shapes gfx = null;
        Color bgColor = Color.Black;

        float x = 100;
        float y = 100;
        Texture nTex;
        public GameWin(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) { }

        protected override void OnLoad()
        {
            base.OnLoad();
            ClientSize = new Vector2i(1280, 720);
            AspectRatio = (16, 9);
            CenterWindow();
            WindowBorder = WindowBorder.Fixed;
            Title = "Renderite2D Game";

            shader = new("Assets/Engine Assets/vertexShader.vert", "Assets/Engine Assets/fragmentShader.frag");
            gfx = new();

            nTex = new("Assets/Game Assets/neutral.png");

            GL.UseProgram(shader.shaderHandle);
            GL.BindVertexArray(shader.vertArrayObj);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, sizeof(float) * 4, 0);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, sizeof(float) * 4, sizeof(float) * 2);

            // Adds support for transparency for textures
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.W)) { y--; }
            if (IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A)) { x--; }
            if (IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.S)) { y++; }
            if (IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D)) { x++; }
            Console.WriteLine(Math.Round(FPS) + " FPS");
            TimeSinceStart += UpdateTime;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            // Pre-rendering setup
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            gfx.DrawRectangle(new Vector2d(x, y), new Vector2d(100, 100), Color4.Aqua, false);
            gfx.DrawQuad(new Vector2d(x, y), new Vector2d(200, 100), new Vector2d(100, 200), new Vector2d(200, 200), Color4.Red, nTex, false);
            gfx.DrawLine(new Vector2d(x, y), new Vector2d(200, 200), Color4.Yellow, (float)Math.Sin(TimeSinceStart) * 100f, false);
            gfx.DrawTriangle(new Vector2d(x, y), new Vector2d(300, 200), new Vector2d(200, 300), Color4.Magenta, false);
            gfx.DrawPixel(new Vector2i((int)x + 320, (int)y + 240), Color4.Lime);
            gfx.DrawPoint(new Vector2i((int)x + 350, (int)y + 240), Color4.Lime, (float)Math.Sin(TimeSinceStart) * 10f);

            // Post-Rendering Clear and swap buffer with background color
            GL.ClearColor(bgColor);
            SwapBuffers();
        }

        protected override void OnUnload()
        {
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

        private class Shapes
        {
            private readonly GameWin win = Program.GameWindow;

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

            public void DrawText(Vector2d position, object str, Color4 color, float scale = 1f, bool isStatic = false)
            {
                // TODO : Unimplemented function
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
