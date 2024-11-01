#version 330 core

uniform vec4 uColor;
uniform sampler2D uTexture;

in vec2 texCoords;

out vec4 FragColor;

void main() // Will set the fragment color using uColor and uTexture multiplied together GPU-side
{
	FragColor = texture(uTexture, texCoords) * uColor;
}