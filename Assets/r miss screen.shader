Shader "Video/iwaredScreen" {
    Properties {
        _MainTex ("Emissive (RGB)", 2D) = "white" {}
        _Emission ("Emission Scale", Range(0, 1)) = 1
        [Toggle(APPLY_GAMMA)] _ApplyGamma("Apply Gamma", Range(0, 1)) = 0
    }
    SubShader {
        Tags { "RenderType"="Transparent" }
        LOD 200

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma target 3.0
            #pragma shader_feature _EMISSION

            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Emission;
            bool _ApplyGamma;

            v2f vert(appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 e = tex2D(_MainTex, i.uv);
                half4 outputColor = half4(0, 0, 0, e.a);

                if (e.g <= 0.30 && e.r >= 0.3 && e.b <= 0.30) {
                    discard; // 純緑のピクセルの場合は透明にする
                }

                if (_ApplyGamma) {
                    e.rgb = pow(e.rgb, 2.2);
                }

                outputColor.rgb += e.rgb * _Emission;
                return outputColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "RealtimeEmissiveGammaGUI"
}
