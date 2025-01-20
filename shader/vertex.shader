#version 330 core

layout (location = 0) in vec3 aPosition; // (x, y, z)
layout (location = 1) in vec2 aTexCoord; // (u, v)

uniform mat4 projection;
uniform mat4 transformation;

out vec2 TexCoord; // Pass to fragment shader

void main()

{       
    gl_Position = projection * transformation * vec4(aPosition, 1.0f);

    // Forward UVs
    TexCoord = aTexCoord;
}