#version 330 core

uniform vec3 color; // A UNIFORM
out vec4 fragColor;
in vec2 textureCoord;
uniform int useColor;
uniform sampler2D textureUnit;

void main()
{
	if(useColor != 0)
	{
		fragColor = vec4(color, 1.0);
	}
	else
	{
		fragColor = texture(textureUnit, textureCoord);
	}
} 