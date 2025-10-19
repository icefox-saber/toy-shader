//g_buffer.fs
#version 330 core

layout (location = 0) out vec3 gPosition;
layout (location = 1) out vec3 gNormal;
layout (location = 2) out vec4 galbedo;
layout (location = 3) out vec3 gmetallicRoughness;
layout (location = 4) out vec3 gao;
layout (location = 5) out vec4 gemission;
layout (location = 6) out vec3 gDepth;

in vec2 TexCoords;
in vec3 WorldPos;
in vec3 Normal;

// material parameters
uniform sampler2D albedoMap;//0 default vec3(0.5,0.0,0.0)
uniform sampler2D normalMap;//1 default vec3(0.5,0.5,1.0)
uniform sampler2D metallicRoughnessMap;//2 default vec2(0.0,1.0)
uniform sampler2D aoMap;//3 default 1
uniform sampler2D emissionMap;//4 default vec3(0.0)

vec3 getNormalFromMap()
{
    vec3 tangentNormal = texture(normalMap, TexCoords).xyz * 2.0 - 1.0;

    vec3 Q1  = dFdx(WorldPos);
    vec3 Q2  = dFdy(WorldPos);
    vec2 st1 = dFdx(TexCoords);
    vec2 st2 = dFdy(TexCoords);

    vec3 N   = normalize(Normal);
    vec3 T  = normalize(Q1*st2.t - Q2*st1.t);
    vec3 B  = -normalize(cross(N, T));
    mat3 TBN = mat3(T, B, N);

    return normalize(TBN * tangentNormal);
}

void main()
{    
    // store the fragment position vector in the first gbuffer texture
    gPosition = WorldPos;
    // also store the per-fragment normals into the gbuffer
    gNormal = getNormalFromMap();
    // and the diffuse per-fragment color
    galbedo.rgb = texture(albedoMap, TexCoords).rgb;
    // store metallic and roughness in gbuffer
    gmetallicRoughness.rg = texture(metallicRoughnessMap, TexCoords).rg;
    // store ao
    gao.r = texture(aoMap, TexCoords).r;
    // store emission
    gemission.rgb = texture(emissionMap, TexCoords).rgb;

    // store depth
    gDepth.rgb = vec3(gl_FragCoord.z);
}

