Shader "Custom/FloorColors" {
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
                    float3 worldPos : TEXCOORD0;
                };

                float4 _ColorA;
                float4 _ColorB;
                float4 _ColorC;
                float _LerpSpeed;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    float zPos = i.worldPos.z;
                    int colorIndex = (int)(zPos / 20.0);
                    int numColors = 3;
                    float3 lerpedColor;

                    if (colorIndex % numColors == 0) {
                        lerpedColor = lerp(_ColorA.rgb, _ColorB.rgb, frac(zPos / 20.0) * _LerpSpeed);
                    }
                     else if (colorIndex % numColors == 1) {
                      lerpedColor = lerp(_ColorB.rgb, _ColorC.rgb, frac(zPos / 20.0) * _LerpSpeed);
                      }
                    else {
                     lerpedColor = lerp(_ColorC.rgb, _ColorA.rgb, frac(zPos / 20.0) * _LerpSpeed);
                    }

                    return float4(lerpedColor, 1);
                    }
                ENDCG
                }
    }
}
