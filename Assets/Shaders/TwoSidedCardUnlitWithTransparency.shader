Shader "Custom/TwoSidedCardUnlitWithTransparency"
{
    Properties
    {
        _FrontTex ("Front Texture", 2D) = "white" {}
        _BackTex ("Back Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Pass
        {
            Name "FORWARD"
            Tags { "LightMode"="Always" }

            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            Lighting Off

            // Front and Back sides
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _FrontTex;
            sampler2D _BackTex;

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldNormal = mul((float3x3)unity_ObjectToWorld, v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                bool isFrontFacing = i.worldNormal.z > 0;

                // Sample the appropriate texture (front or back)
                fixed4 color = isFrontFacing ? tex2D(_FrontTex, i.uv) : tex2D(_BackTex, i.uv);

                // Check if the texture has transparency
                if (color.a < 0.1) 
                {
                    discard;  // Discard nearly fully transparent pixels
                }

                // Return the color, ensuring transparency works
                return color;
            }
            ENDCG
        }
    }
    
    // Fallback for unsupported hardware
    Fallback "Unlit/Texture"
}
