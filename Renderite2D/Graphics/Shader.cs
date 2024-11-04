using OpenTK.Graphics.OpenGL4;

namespace Renderite2D_Project.Renderite2D.Graphics
{
    public class Shader : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public readonly int shaderHandle;
        public readonly int vertArrayObj;
        public readonly int vertBufferObj;

        public Shader(string vertPath, string fragPath)
        {
            try
            {
                // Will create and bind the vertex array object
                vertArrayObj = GL.GenVertexArray();
                GL.BindVertexArray(vertArrayObj);

                // Will create and bind the vertex buffer object
                vertBufferObj = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, vertBufferObj);

                // Loads and compiles vertex shader
                int vertShader = GL.CreateShader(ShaderType.VertexShader);
                GL.ShaderSource(vertShader, File.ReadAllText(vertPath));
                GL.CompileShader(vertShader);

                // Loads and compiles fragment shader
                int fragShader = GL.CreateShader(ShaderType.FragmentShader);
                GL.ShaderSource(fragShader, File.ReadAllText(fragPath));
                GL.CompileShader(fragShader);

                // makes the shader program attach the vert and frag shader to it
                shaderHandle = GL.CreateProgram();
                GL.AttachShader(shaderHandle, vertShader);
                GL.AttachShader(shaderHandle, fragShader);
                GL.LinkProgram(shaderHandle);

                // Shader cleanup
                GL.DetachShader(shaderHandle, vertShader);
                GL.DetachShader(shaderHandle, fragShader);
                GL.DeleteShader(fragShader);
                GL.DeleteShader(vertShader);
            }
            catch (Exception e) // Displays error message when any exception is thrown
            {
                if (MessageBox.Show
                (
                    "[Message] " + e.Message + "\n\n" +
                    "[Source] " + e.Source + "\n\n" +
                    "[Stack Trace]\n" + e.StackTrace,
                "Shader Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    Program.EndGame();
            }
        }

        ~Shader() // Destructing Shader object will dispose the GL program first
        {
            Dispose();
        }

        /// <summary>
        /// Shader Program disposal
        /// </summary>
        public void Dispose()
        {
            if (!IsDisposed)
            {
                GL.DeleteBuffer(vertBufferObj);
                GL.DeleteVertexArray(vertArrayObj);
                GL.DeleteProgram(shaderHandle);
                IsDisposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public void UseProgram()
        {
            GL.UseProgram(shaderHandle);
        }
    }
}
