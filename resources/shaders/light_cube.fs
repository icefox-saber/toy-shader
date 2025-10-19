#version 330 core

out vec4 FragColor;

uniform float lightIntensity;
uniform vec3 lightColor;

void main(void) {
    
  //gl_FragColor = vec4(1,1,1, 1.0);
  FragColor = vec4(lightColor * lightIntensity, 1.0);
}