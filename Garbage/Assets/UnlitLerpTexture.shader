Shader "Tondöv/Unlit Lerp Texture" {
	Properties {

        _Mask         	("Mask", 2D) = "white" {}

        _MainTex     	("Texture 1", 2D) = "white" {}
        _SecondTex     	("Texture 2", 2D) = "clear" {}


        _Cutoff     	("Alpha cutoff", Range(0,1)) = 0.5
		_Lerp			("Lerp Value", Range(0,1)) = 0.5

        _Color        	("Color A",Color) = (1,1,1,1)
        _SecondColor    ("Color B",Color) = (1,1,1,1)
        
        [Toggle]    _CutLerp    ("CutLerp",    Float) = 1
    }

    SubShader {

        Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}

        LOD 200


        Lighting Off


        Pass {  

            CGPROGRAM

                #pragma vertex vert

                #pragma fragment frag

                #pragma multi_compile_fog

                

                #include "UnityCG.cginc"


                struct appdata_t {

                    float4 vertex : POSITION;

                    float2 texcoord : TEXCOORD0;

                };


                struct v2f {

                    float4 vertex : SV_POSITION;

                    half2 texcoord : TEXCOORD0;

                    UNITY_FOG_COORDS(1)

                };


                sampler2D _MainTex, _SecondTex, _Mask;
                float4 _MainTex_ST;
                fixed _Cutoff,_Lerp,_CutLerp;
                float4 _Color,_SecondColor;
				float extraMask;

                v2f vert (appdata_t v)

                {

                    v2f o;

                    o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                    UNITY_TRANSFER_FOG(o,o.vertex);

                    return o;

                }

                

                fixed4 frag (v2f i) : SV_Target{
                    fixed4 m     		= tex2D(_Mask, i.texcoord);
                    fixed4 mainCol 		= tex2D(_MainTex, i.texcoord);
                    mainCol *= _Color;
                    fixed4 secondCol	= tex2D(_SecondTex, i.texcoord);
                    secondCol *= _SecondColor;
                    
                    fixed bw = (m.r + m.g + m.b)/3;
                    extraMask = pow(_Lerp,2);
                    
                    if(_CutLerp){
                    	if(1 - bw < _Lerp) extraMask += (m * _Lerp);
                    }
                    else extraMask += (bw * bw * _Lerp);
                    
                    extraMask = clamp(extraMask,0,1);
                    mainCol = lerp(mainCol, secondCol, extraMask);

                  

                    clip(mainCol.a - _Cutoff);
                    UNITY_APPLY_FOG(i.fogCoord, col);
                    return mainCol;

                }

            ENDCG

        }
		
    }

}

