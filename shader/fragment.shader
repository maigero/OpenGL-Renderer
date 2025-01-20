#version 330 core

in vec2 TexCoord; // From vertex shader
uniform sampler2D textureUnit;
uniform bool useTexture;
uniform vec3 color; // Fallback color
out vec4 fragColor;

void main()
{
	if(useTexture)
	{
		fragColor = texture(textureUnit, TexCoord);
	}
	else
	{
		fragColor = vec4(color, 1.0);
	}
	
} 