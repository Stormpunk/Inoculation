Shader "Custom/GooShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _GooTex ("Goo Texture", 2D) = "white" { }
        _Speed ("Spread Speed", Range(0, 1)) = 0.1
        _DistortionStrength ("Distortion Strength", Range(0, 1)) = 0.2
        _GooDepth ("Goo Depth", Range(0, 1)) = 0.1
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _GooTex;
        fixed _Speed;
        fixed _DistortionStrength;
        fixed _GooDepth;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
          // Sample the base texture
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

    // Sample the goo texture for spreading effect
    float2 uvGoo = IN.uv_MainTex + _Time.y * _Speed;
    fixed4 gooSample = tex2D(_GooTex, uvGoo);

    // Apply distortion based on the goo texture
    float2 distortion = gooSample.rg * 2.0 - 1.0;
    IN.uv_MainTex += distortion * _DistortionStrength;

    // Blend the base color with the gooey effect
    o.Albedo = lerp(c.rgb, gooSample.rgb, gooSample.a);
    o.Alpha = max(c.a, gooSample.a);

    // Apply dimension by modifying the normal vector based on the goo depth
    o.Normal = normalize(o.Normal + float3(distortion.x, distortion.y, _GooDepth));
        }
        ENDCG
    }
    FallBack "Diffuse"
}