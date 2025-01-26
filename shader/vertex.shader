#version 330 core

layout (location = 0) in vec3 aPosition; // the position variable has attribute position 0
layout (location = 1) in vec2 vertexUVCoord;; // the position variable has attribute position 0

uniform mat4 projection;
uniform mat4 transformation;

out vec2 textureCoord;

void main()
{
    gl_Position = projection * transformation * vec4(aPosition, 1.0f); //add projection and transformation  * vec4(aPosition, 1.0f);
    textureCoord = vertexUVCoord;
}