using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using Renderite2D_Project.EngineCode.Graphics;

namespace Renderite2D_Project.EngineCode
{
    public class GameWin : GameWindow
    {
        public double FPS { get { return 1 / UpdateTime; } }

        Shader shader = null;
        Color bgColor = Color.Black;

        float x = 100;
        float y = 100;
        Texture tex;
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
            
            tex = new();

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
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            // Pre-rendering setup
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Draws a pixel
            //if (!(x < 0 || y < 0))
            //{
            //    // Set the ucolor in the shader
            //    GL.Uniform4(GL.GetUniformLocation(shader.shaderHandle, "uColor"), Color4.White);
            //
            //    // Set the texture uniform in the shader
            //    GL.Uniform1(GL.GetUniformLocation(shader.shaderHandle, "uTexture"), 0);
            //
            //    tex.Bind();
            //    // Specify the vertex data for pixel
            //    float[] position = { (float)x / (ClientSize.X * 0.5f) - 1f, (float)-y / (ClientSize.Y * 0.5f) + 1f, 0, 0 };
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, shader.vertBufferObj);
            //    GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * position.Length, position, BufferUsageHint.DynamicDraw);
            //
            //    // Draws the pixel
            //    GL.DrawArrays(PrimitiveType.Points, 0, 1);
            //
            //    Texture.Unbind();
            //}

            // Draws a rect with a texture on screen
            {
                // Set the ucolor in the shader
                GL.Uniform4(GL.GetUniformLocation(shader.shaderHandle, "uColor"), Color4.White);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(shader.shaderHandle, "uTexture"), 0);

                nTex.Bind(); // will use this texture

                Vector2 v = new((float)x / (ClientSize.X * 0.5f) - 1f, (float)-y / (ClientSize.Y * 0.5f) + 1f);
                // Specify the vertex data for quad
                float[] vertices = {
                    v.X + -0.25f, v.Y + 0.25f, 1.0f, 1.0f,
                    v.X + 0.25f, v.Y + 0.25f, 0.0f, 1.0f,
                    v.X + -0.25f, v.Y + -0.25f, 1.0f, 0.0f,
                    v.X + 0.25f, v.Y + -0.25f, 0.0f, 0.0f,
                };

                GL.BindBuffer(BufferTarget.ArrayBuffer, shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);

                Texture.Unbind();
            }

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
    }
}
