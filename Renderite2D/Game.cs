using NAudio.Wave;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Renderite2D_Project.Renderite2D.Components;
using Renderite2D_Project.Renderite2D.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Renderite2D_Project.Renderite2D
{
    public class Game : GameWindow
    {
        public static Camera MainCamera { get; set; }

        Shader shader = null;
        Shapes gfx = null;
        Level currentLevel;
        RunningLevel runningLevel;
        double timeSinceStart = 0;
        Graphics.Font currentFont = new();
        double timeScale = 1.0;
        double fixedUpdateAccumulatedTime = 0.0;
        double targetFrametime;
        readonly List<DrawInstance>[] drawLayers = new List<DrawInstance>[256];

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) :
            base(gameWindowSettings, nativeWindowSettings) { }

        public static void LoadLevel(Level level, Camera newCamera = null)
        {
            if (level == null) return;                  // level will not be loaded if the specified level is null

            Program.GameWindow.currentLevel?.End();     // Executes the End() method of the current level
            Time.TimeScale = 1.0;                       // Resets Time Scale to 1
            MainCamera = newCamera ?? new Camera();     // Sets up the camera
            Program.GameWindow.runningLevel = new();    // Running Level is cleared
            Program.GameWindow.currentLevel = level;    // The given level is set
            Program.GameWindow.currentLevel?.Begin();   // Executes the Begin() method in the newly loaded level
        }

        protected override void OnLoad()
        {
            Time.FixedUpdateFrequency = 60;

            base.OnLoad();
            ClientSize = new Vector2i(1280, 720);
            AspectRatio = (16, 9);
            CenterWindow();
            WindowBorder = WindowBorder.Resizable;
            Title = "Renderite2D Game";

            for (int i = 0; i < drawLayers.Length; i++)
                drawLayers[i] = new();

            // Clears window before it starts
            GL.ClearColor(Color.Black);
            SwapBuffers();

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
            runningLevel.PerFrameUpdate();
            currentLevel?.Update();

            timeSinceStart += UpdateTime;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            // Pre-rendering setup
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            currentLevel?.Draw(gfx);

            for (int i = 0; i < drawLayers.Length; i++)
            {
                for (int j = 0; j < drawLayers[i].Count; j++)
                    drawLayers[i][j].Draw();
                drawLayers[i].Clear();
            }

            GameObject[] _gameObjects = new GameObject[runningLevel.gameObjects.Count];
            runningLevel.gameObjects.Values.CopyTo(_gameObjects, 0);
            foreach (GameObject obj in _gameObjects)
            {
                 if (!obj.IsEnabled) continue;
            
                 foreach (ColliderComponent cc in obj.GetComponents<ColliderComponent>())
                 {
                     if (!cc.IsEnabled) continue;
            
                     var hb = cc.GetHitbox();
                     gfx.DrawRectOutline(hb.Center - hb.HalfSize, hb.Size, cc.isSolidCollision ? Color4.White : Color4.Blue);
                 }
            }

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

        private void DrawShape_(DrawType drawType, object[] parameters, byte layer = 0)
        {
            drawLayers[layer].Add(new DrawInstance(drawType, parameters));
        }

        public static void DrawShape(DrawType drawType, object[] parameters, byte layer = 0)
        {
            Program.GameWindow.DrawShape_(drawType, parameters, layer);
        }

        public class DrawInstance
        {
            private static readonly Shapes gfx = Program.GameWindow.gfx;

            public DrawType drawType;
            public object[] parameters;

            public DrawInstance(DrawType drawType, object[] parameters)
            {
                this.drawType = drawType;
                this.parameters = parameters;
            }

            public void Draw()
            {
                switch (drawType)
                {
                    case DrawType.Rectangle:
                        gfx.DrawRectangle((Vector2d)parameters[0], (Vector2d)parameters[1],
                            (Color4)parameters[2], (Texture)parameters[3], (bool)parameters[4]);
                        break;
                    case DrawType.Quad:
                        gfx.DrawQuad((Vector2d)parameters[0], (Vector2d)parameters[1], (Vector2d)parameters[2], (Vector2d)parameters[3], 
                            (Color4)parameters[4], (Texture)parameters[5], (bool)parameters[6]);
                        break;
                    case DrawType.Rectangle_Spritesheet:
                        gfx.DrawRectangleSpriteSheet((Vector2d)parameters[0], (Vector2d)parameters[1],
                            (Color4)parameters[2], (Texture)parameters[3], (int)parameters[4], (int)parameters[5], (bool)parameters[6]);
                        break;
                    case DrawType.Quad_Spritesheet:
                        gfx.DrawQuadSpriteSheet((Vector2d)parameters[0], (Vector2d)parameters[1], (Vector2d)parameters[2], (Vector2d)parameters[3],
                            (Color4)parameters[4], (Texture)parameters[5], (int)parameters[6], (int)parameters[7], (bool)parameters[8]);
                        break;
                    case DrawType.Line:
                        gfx.DrawLine((Vector2d)parameters[0], (Vector2d)parameters[1],
                            (Color4)parameters[2], (float)parameters[3], (bool)parameters[4]);
                        break;
                    case DrawType.Triangle:
                        gfx.DrawTriangle((Vector2d)parameters[0], (Vector2d)parameters[1], (Vector2d)parameters[2],
                            (Color4)parameters[3], (Texture)parameters[4], (bool)parameters[5]);
                        break;
                    case DrawType.Text:
                        gfx.DrawText((Vector2d)parameters[0], parameters[1], (Color4)parameters[2], (float)parameters[3], (bool)parameters[4]);
                        break;
                    case DrawType.Pixel:
                        gfx.DrawPixel((Vector2i)parameters[0], (Color4)parameters[1]);
                        break;
                    case DrawType.Point:
                        gfx.DrawPoint((Vector2d)parameters[0], (Color4)parameters[1], (float)parameters[2], (bool)parameters[3]);
                        break;
                    case DrawType.Rectangle_Outline:
                        gfx.DrawRectOutline((Vector2d)parameters[0], (Vector2d)parameters[1],
                            (Color4)parameters[2], (bool)parameters[3]);
                        break;
                    default:
                        break;
                }
            }
        }

        public enum DrawType
        {
            Rectangle,
            Quad,
            Rectangle_Spritesheet,
            Quad_Spritesheet,
            Line,
            Triangle,
            Text,
            Pixel,
            Point,
            Rectangle_Outline
        }

        public class World
        {
            private static readonly Game win = Program.GameWindow;

            public static string Instantiate(GameObject gameObject)
            {
                string guid = Guid.NewGuid().ToString();
                win.runningLevel.gameObjects.Add(guid, gameObject);
                return guid;
            }

            public static void Destroy(string guid)
            {
                if (win.runningLevel.gameObjects.ContainsKey(guid))
                    win.runningLevel.gameObjects.Remove(guid);
            }

            public static void Destroy(GameObject gameObject)
            {
                if (win.runningLevel.gameObjects.ContainsValue(gameObject))
                {
                    var keys = new string[win.runningLevel.gameObjects.Count];
                    win.runningLevel.gameObjects.Keys.CopyTo(keys, 0);

                    var values = new GameObject[win.runningLevel.gameObjects.Count];
                    win.runningLevel.gameObjects.Values.CopyTo(values, 0);

                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (values[i] == gameObject)
                        {
                            win.runningLevel.gameObjects.Remove(keys[i]);
                            break;
                        }
                    }
                }
            }

            public static GameObject GetGameObjectByGuid(string guid)
            {
                if (win.runningLevel.gameObjects.ContainsKey(guid))
                    return win.runningLevel.gameObjects[guid];
                return null;
            }

            public static string GetGuidOfGameObject(GameObject gameObject)
            {
                if (win.runningLevel.gameObjects.ContainsValue(gameObject))
                {
                    var keys = new string[win.runningLevel.gameObjects.Count];
                    win.runningLevel.gameObjects.Keys.CopyTo(keys, 0);

                    var values = new GameObject[win.runningLevel.gameObjects.Count];
                    win.runningLevel.gameObjects.Values.CopyTo(values, 0);

                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (values[i] == gameObject)
                            return keys[i];
                    }
                }
                return null;
            }

            public static int GetGameObjectCount()
            {
                return win.runningLevel.gameObjects.Count;
            }

            public static GameObject[] GetAllGameObjects()
            {
                var gameObjects = new GameObject[win.runningLevel.gameObjects.Count];
                win.runningLevel.gameObjects.Values.CopyTo(gameObjects, 0);
                return gameObjects;
            }
        }

        protected struct RunningLevel
        {
            public double TimeSinceLevelStart { get; private set; }
            public Dictionary<string, GameObject> gameObjects = new();

            public RunningLevel() 
            {
                AudioPlayer.StopAllSounds();
                TimeSinceLevelStart = 0.0;
            }

            public void PerFrameUpdate()
            {
                foreach (var gameObject in gameObjects.Values)
                {
                    if (gameObject == null || !gameObject.IsEnabled) continue;
                    var components = gameObject.GetAllComponents();
                    for (int i = 0; i < components.Length; i++)
                    {
                        if (!components[i].IsEnabled) continue;
                        components[i].Update();
                    }
                }
            }

            public void UpdateRunningLevel()
            {
                foreach (var gameObject in gameObjects.Values)
                {
                    if (gameObject == null || !gameObject.IsEnabled) continue;
                    gameObject.Update();
                }
                TimeSinceLevelStart += Time.FixedDeltaTime * Time.TimeScale;
            }
        }

        public static class AudioPlayer
        {
            private static readonly List<WaveOutEvent> waveOutEvents = new();

            public static double PreloadSound(string filePath)
            {
                if (!System.IO.File.Exists(filePath)) return -1.0;

                var output = new WaveOutEvent();
                var audioReader = new AudioFileReader(filePath);
                try
                {
                    output.Init(audioReader);
                }
                catch (Exception) { return -1.0; }
                waveOutEvents.Add(output);
                return audioReader.TotalTime.TotalSeconds;
            }

            public static double PlaySound(string filePath, float volume = 1.0f)
            {
                if (!System.IO.File.Exists(filePath)) return -1.0;

                var output = new WaveOutEvent();
                var audioReader = new AudioFileReader(filePath);
                try
                {
                    output.Init(audioReader);
                }
                catch (Exception) { return -1.0; }
                output.Volume = volume;
                output.Play();
                waveOutEvents.Add(output);
                return audioReader.TotalTime.TotalSeconds;
            }

            public static void StopAllSounds()
            {
                foreach (var output in waveOutEvents)
                {
                    output.Stop();
                    output.Dispose();
                }
                waveOutEvents.Clear();
            }

            public static int AudioCount()
            {
                return waveOutEvents.Count;
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

                if (!isStatic)
                    position -= MainCamera.Transform.position - new Vector2d(960, 540);

                Vector2 v = new((float)position.X / 960 - 1f, (float)-position.Y / 540 + 1f);
                Vector2 v2 = new((float)(position.X + dimension.X) / 960 - 1f, ((float)-(position.Y + dimension.Y)) / 540 + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    v.X, v.Y,   0f, 0f,
                    v2.X, v.Y,  1f, 0f,
                    v.X, v2.Y,  0f, 1f,
                    v2.X, v2.Y, 1f, 1f,
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

                if (!isStatic)
                {
                    a -= MainCamera.Transform.position - new Vector2d(960, 540);
                    b -= MainCamera.Transform.position - new Vector2d(960, 540);
                    c -= MainCamera.Transform.position - new Vector2d(960, 540);
                    d -= MainCamera.Transform.position - new Vector2d(960, 540);
                }
                Vector2 va = new((float)a.X / 960 - 1f, (float)-a.Y / 540 + 1f);
                Vector2 vb = new((float)b.X / 960 - 1f, (float)-b.Y / 540 + 1f);
                Vector2 vc = new((float)c.X / 960 - 1f, (float)-c.Y / 540 + 1f);
                Vector2 vd = new((float)d.X / 960 - 1f, (float)-d.Y / 540 + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    va.X, va.Y, 0f, 0f,
                    vb.X, vb.Y, 1f, 0f,
                    vc.X, vc.Y, 0f, 1f,
                    vd.X, vd.Y, 1f, 1f,
                };

                // Binds the data
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4); // Draws shape on screen based on data currently bound

                Texture.Unbind(); // Unbinds the currently bound texture
            }

            public void DrawRectangleSpriteSheet(Vector2d position, Vector2d dimension, Color4 color, Texture spriteSheet, int index, int divisions, bool isStatic = false)
            {
                DrawQuadSpriteSheet(position, position + (Vector2d.UnitX * dimension), position + (Vector2d.UnitY * dimension), position + dimension, color, spriteSheet, index, divisions, isStatic);
            }

            public void DrawQuadSpriteSheet(Vector2d a, Vector2d b, Vector2d c, Vector2d d, Color4 color, Texture spriteSheet, int index, int divisions, bool isStatic = false)
            {
                if (divisions <= 0 || divisions <= 0) return;

                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                spriteSheet.Bind(); // will make use of this texture by binding it

                if (!isStatic)
                {
                    a -= MainCamera.Transform.position - new Vector2d(960, 540);
                    b -= MainCamera.Transform.position - new Vector2d(960, 540);
                    c -= MainCamera.Transform.position - new Vector2d(960, 540);
                    d -= MainCamera.Transform.position - new Vector2d(960, 540);
                }
                Vector2 va = new((float)a.X / 960 - 1f, (float)-a.Y / 540 + 1f);
                Vector2 vb = new((float)b.X / 960 - 1f, (float)-b.Y / 540 + 1f);
                Vector2 vc = new((float)c.X / 960 - 1f, (float)-c.Y / 540 + 1f);
                Vector2 vd = new((float)d.X / 960 - 1f, (float)-d.Y / 540 + 1f);

                float normalizedUv = 1f / divisions; // calculates the normalized size of the texture atlas

                // Calculates the UV x and y of the texture based on the index
                float uvY = index / divisions;
                float uvX = (index - (uvY * divisions)) * normalizedUv;
                uvY = 1f - (1f - (uvY * normalizedUv) - normalizedUv);

                // Specify the vertex data for quad
                float[] vertices = {
                    va.X, va.Y, uvX + (normalizedUv * 0f), uvY - (normalizedUv * 1f),
                    vb.X, vb.Y, uvX + (normalizedUv * 1f), uvY - (normalizedUv * 1f),
                    vc.X, vc.Y, uvX + (normalizedUv * 0f), uvY - (normalizedUv * 0f),
                    vd.X, vd.Y, uvX + (normalizedUv * 1f), uvY - (normalizedUv * 0f),
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

                    if (!isStatic)
                    {
                        a -= MainCamera.Transform.position - new Vector2d(960, 540);
                        b -= MainCamera.Transform.position - new Vector2d(960, 540);
                    }

                    // Specify the vertex data for quad
                    float[] vertices = {
                        (float)a.X / 960 - 1f, (float)-a.Y / 540 + 1f, 1.0f, 1.0f,
                        (float)b.X / 960 - 1f, (float)-b.Y / 540 + 1f, 0.0f, 1.0f,
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

                if (!isStatic)
                {
                    a -= MainCamera.Transform.position - new Vector2d(960, 540);
                    b -= MainCamera.Transform.position - new Vector2d(960, 540);
                    c -= MainCamera.Transform.position - new Vector2d(960, 540);
                }

                Vector2 va = new((float)a.X / 960 - 1f, (float)-a.Y / 540 + 1f);
                Vector2 vb = new((float)b.X / 960 - 1f, (float)-b.Y / 540 + 1f);
                Vector2 vc = new((float)c.X / 960 - 1f, (float)-c.Y / 540 + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    va.X, va.Y, 0.0f, 0.0f,
                    vb.X, vb.Y, 1.0f, 0.0f,
                    vc.X, vc.Y, 0.0f, 1.0f,
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
                if (!isStatic)
                    position -= MainCamera.Transform.position - new Vector2d(960, 540);

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

            public void DrawRectOutline(Vector2d position, Vector2d dimension, Color4 color, bool isStatic = false)
            {
                // Sends the shape color into the GPU-side and store it in uColor variable
                GL.Uniform4(GL.GetUniformLocation(win.shader.shaderHandle, "uColor"), color);

                // Set the texture uniform in the shader
                GL.Uniform1(GL.GetUniformLocation(win.shader.shaderHandle, "uTexture"), 0);

                Texture.White.Bind(); // will add a white texture so that color will show properly

                if (!isStatic)
                    position -= MainCamera.Transform.position - new Vector2d(960, 540);

                Vector2 v = new((float)position.X / 960 - 1f, (float)-position.Y / 540 + 1f);
                Vector2 v2 = new((float)(position.X + dimension.X) / 960 - 1f, ((float)-(position.Y + dimension.Y)) / 540 + 1f);

                // Specify the vertex data for quad
                float[] vertices = {
                    v.X, v.Y, 1.0f, 1.0f,
                    v2.X, v.Y, 0.0f, 1.0f,
                    v2.X, v2.Y, 0.0f, 0.0f,
                    v.X, v2.Y, 1.0f, 0.0f,
                };

                // Binds the data
                GL.BindBuffer(BufferTarget.ArrayBuffer, win.shader.vertBufferObj);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.DynamicDraw);

                GL.DrawArrays(PrimitiveType.LineLoop, 0, 4); // Draws shape on screen based on data currently bound

                Texture.Unbind(); // Unbinds the currently bound texture
            }
        }
    }
}
