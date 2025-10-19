//pbr.fs
#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

// IBL
// material parameters
uniform sampler2D showtexture; //40

void main()
{		
    // material properties
    FragColor = vec4(texture(showtexture, TexCoords).rgb, 1.0);
}