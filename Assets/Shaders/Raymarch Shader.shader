Shader "Unlit/Raymarch Shader"
{
    Properties
    {
        power("Power", float) = 1.0
        darkness("Darkness", float) = 1.0
        blackAndWhite("BlackAndWhite", float) = 1.0
        colorAMix("ColorAMix", Color) = (1, 1, 1, 1)
        colorBMix("ColorBMix", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };

            struct Ray
            {
                float3 origin;
                float3 direction;
            };

            float4x4 _CameraInverseProjection;
            float3 _LightDirection;

            float power;
            float darkness;
            float blackAndWhite;
            float3 colourAMix;
            float3 colourBMix;

            static const float epsilon = 0.001f;
            static const float maxDst = 200;
            static const int maxStepCount = 250;

            Ray CreateRay(float3 origin, float3 direction)
            {
                Ray ray;
                ray.origin = origin;
                ray.direction = direction;
                return ray;
            }

            Ray CreateCameraRay(float2 uv)
            {
                float3 origin = mul(unity_CameraToWorld, float4(0, 0, 0, 1)).xyz;
                float3 direction = mul(_CameraInverseProjection, float4(uv, 0, 1)).xyz;
                direction = mul(unity_CameraToWorld, float4(direction, 0)).xyz;
                direction = normalize(direction);
                return CreateRay(origin, direction);
            }

            // Mandelbulb distance estimation:
            // http://blog.hvidtfeldts.net/index.php/2011/09/distance-estimated-3d-fractals-v-the-mandelbulb-different-de-approximations/
            float2 SceneInfo(float3 position)
            {
                float3 z = position;
                float dr = 1.0;
                float r = 0.0;
                int iterations = 0;
                for(int i = 0; i < 15; i++)
                {
                    iterations = i;
                    r = length(z);
                    if(r > 2)
                    {
                        break;
                    }
                    // convert to polar coordinates
                    float theta = acos(z.z / r);
                    float phi = atan2(z.y, z.x);
                    dr = pow(r, power - 1.0) * power * dr + 1.0;
                    // scale and rotate the point
                    float zr = pow(r, power);
                    theta = theta * power;
                    phi = phi * power;
                    // convert back to cartesian coordinates
                    z = zr * float3(sin(theta) * cos(phi), sin(phi) * sin(theta), cos(theta));
                    z += position;
                }
                float dst = 0.5 * log(r) * r / dr;
                return float2(iterations, dst * 1);
            }

            float3 EstimateNormal(float3 p)
            {
                float x = SceneInfo(float3(p.x + epsilon, p.y, p.z)).y - SceneInfo(float3(p.x - epsilon, p.y, p.z)).y;
                float y = SceneInfo(float3(p.x, p.y + epsilon, p.z)).y - SceneInfo(float3(p.x, p.y - epsilon, p.z)).y;
                float z = SceneInfo(float3(p.x, p.y, p.z + epsilon)).y - SceneInfo(float3(p.x, p.y, p.z - epsilon)).y;
                return normalize(float3(x, y, z));
            }

            v2f vert (appdata IN)
            {
                v2f OUT;
                OUT.position = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;
                return OUT;
            }

            float4 frag (v2f IN) : SV_Target
            {
                float4 col = float4(1, 1, 1, 1);
                float2 uv = IN.uv;
                // Background gradient
                float4 result = lerp(float4(51, 3, 20, 1),float4(16, 6, 28, 1),uv.y) / 255.0;
                // Raymarching:
                Ray ray = CreateCameraRay(uv * 2 - 1);
                float rayDst = 0;
                int marchSteps = 0;
                while(rayDst < maxDst && marchSteps < maxStepCount)
                {
                    marchSteps++;
                    float2 sceneInfo = SceneInfo(ray.origin);
                    float dst = sceneInfo.y;
                    // Ray has hit a surface
                    if(dst <= epsilon)
                    {
                        float escapeIterations = sceneInfo.x;
                        float3 normal = EstimateNormal(ray.origin - ray.direction * epsilon * 2);
                        float colourA = saturate(dot(normal * 0.5 + 0.5, -_LightDirection));
                        float colourB = saturate(escapeIterations / 16.0);
                        float3 colourMix = saturate(colourA * colourAMix + colourB * colourBMix);
                        result = float4(colourMix.xyz, 1);
                        break;
                    }
                    ray.origin += ray.direction * dst;
                    rayDst += dst;
                }
                float rim = marchSteps / darkness;
                col = lerp(result, 1, blackAndWhite) * rim;
                return col;
            }
            ENDCG
        }
    }
}
