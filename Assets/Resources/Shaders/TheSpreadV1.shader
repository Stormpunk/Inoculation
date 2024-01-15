Shader "Unlit/TheSpreadV1"
{
   Properties {
        _MainTex ("Base Texture", 2D) = "white" { }
        _BumpMap ("Bump Map", 2D) = "bump" {}
        _GrowTexture ("Grow Texture", 2D) = "white" { }
        _GrowBumpMap("Grow Bump Map" , 2D) = "bump" {}
        _GrowPattern("Grow Pattern", 2D) = "white" {}
        _GrowSpeed ("Grow Speed", Range (0, 1)) = 0.1
        _GrowPosition ("Grow Position", Vector) = (0.5, 0.5, 0, 0)
    }

    SubShader {
        Tags { "RenderType"="Opaque" "Queue" = "Overlay"}
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _GrowTexture;
        fixed4 _GrowPosition;
        fixed _GrowSpeed;
        sampler2D _BumpMap;
        sampler2D _GrowPattern;

        struct Input {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_GrowPattern;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            // Sample base texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            half4 normalMap = tex2D(_BumpMap, IN.uv_BumpMap);
            // Calculate distance from the grow position
            fixed distance = length(IN.uv_MainTex - _GrowPosition.xy);

            fixed4 noiseSample = tex2D(_GrowPattern, IN.uv_GrowPattern);

            // Calculate the amount to grow based on distance and speed
            fixed growAmount = smoothstep(1.0, 0.0, distance * _GrowSpeed);

            // Sample grow texture
            fixed4 growColor = tex2D(_GrowTexture, IN.uv_MainTex);

            fixed4 oldColor = tex2D(_MainTex, IN.uv_MainTex);

            growColor.a *= -1 * noiseSample.a;

            // Mix base color and grow texture based on grow amount
            o.Albedo = lerp(c.rgb, growColor.rgb, growAmount);
            o.Alpha = max(oldColor.a, growColor.a);
            //adjust the alpha values so the growtexture doesn't replace it'
            o.Normal = UnpackNormal(normalMap);
        }
        ENDCG
    }
    }