#version 330 core
		
layout (location = 0) in vec2 aPosition;
layout (location = 1) in vec2 aTexCoord;
		
out vec2 texCoords;
		
void main() // Sets the positions and texture coordinates GPU-side
{
   gl_Position = vec4(aPosition, 0.0, 1.0);
   texCoords = aTexCoord;
}