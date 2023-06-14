Shader "Custom/ColorLerp" {
    Properties{
        _ColorA("Color A", Color) = (1, 0, 0, 1)
        _ColorB("Color B", Color) = (0, 1, 0, 1)
        _ColorC("Color C", Color) = (0, 0, 1, 1)
        _LerpSpeed("Lerp Speed", Range(0, 1)) = 0.5
    }

        SubShader{
            Tags { "Queue" = "Transparent" }
            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                };

                float4 _ColorA;
                float4 _ColorB;
                float4 _ColorC;
                float _LerpSpeed;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    float3 lerpedColor = lerp(_ColorA.rgb, _ColorB.rgb, sin(_Time.y * _LerpSpeed));
                    float4 finalColor = lerp(float4(lerpedColor, 1), _ColorC, sin(_Time.y * _LerpSpeed));
                    return finalColor;
                }
                ENDCG
            }
    }
}
