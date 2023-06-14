Shader "Custom/LerpShader"
{
    Properties
    {
        _Color1("Color 1", Color) = (1, 0, 0, 1)
        _Color2("Color 2", Color) = (0, 0, 1, 1)
        _Speed("Speed", Range(0, 10)) = 1
    }

        SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color1;
            float4 _Color2;
            float _Speed;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5); // Centre du Gameobject
                float dist = distance(i.uv, center); // Distance entre le pixel actuel et le centre

                // Mouvement du lerp en fonction du temps
                float time = _Time.y * _Speed;
                float offset = sin(time) * 0.5 + 0.5; // Utilisation de sin pour créer une animation fluide entre 0 et 1

                // Interpolation linéaire entre les deux couleurs basée sur la distance au centre et le mouvement du lerp
                fixed4 lerpedColor = lerp(_Color1, _Color2, saturate(dist * 2 - offset));

                return lerpedColor;
            }
            ENDCG
        }
    }
}
