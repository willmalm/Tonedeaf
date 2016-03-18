Shader "Tondöv/Unlit Animated" {
		Properties {
        _MainTex     	("Texture 1", 2D) = "white" {}
        
        _Cutoff     	("Alpha cutoff", Range(0,1)) = 0.5
        
        _Color        	("Color A",Color) = (1,1,1,1)
        _SecondColor    ("Color B",Color) = (1,1,1,1)
        
        _LowPass     	("Low Pass", Range(0,1)) 	= 0.1
        _HighPass     	("High Pass", Range(0,1)) 	= 0.15
        
        
        _XScroll1 ( "X Scroll Speed 1", Float ) = 1
        _YScroll1 ( "Y Scroll Speed 1", Float ) = 1
        _XScroll2 ( "X Scroll Speed 2", Float ) = 1
        _YScroll2 ( "Y Scroll Speed 2", Float ) = 1
        _XScroll3 ( "X Scroll Speed 3", Float ) = 1
        _YScroll3 ( "Y Scroll Speed 3", Float ) = 1
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


                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed _Cutoff, _LowPass, _HighPass;
                float4 _Color,_SecondColor;
				float extraMask;
				
				float _XScroll1, _YScroll1,		_XScroll2,_YScroll2,		_XScroll3,_YScroll3;

                v2f vert (appdata_t v)

                {

                    v2f o;
                    

                    o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                    UNITY_TRANSFER_FOG(o,o.vertex);

                    return o;

                }

                

                fixed4 frag (v2f i) : SV_Target{
                    fixed4 mainCol 		= tex2D(_MainTex, i.texcoord + + fixed2(_Time.y * _XScroll1,(_Time.y * _YScroll1)));
                    mainCol.g			= tex2D(_MainTex, (i.texcoord.xy + fixed2(_Time.y * _XScroll2,(_Time.y * _YScroll2)))).g;
                    mainCol.b			= tex2D(_MainTex, (i.texcoord.xy + fixed2(_Time.y * _XScroll3,(_Time.y * _YScroll3)))).b;
                    //mainCol = moveCol;
					
					
					
					mainCol.rgb = (1,1,1) * (mainCol.r * mainCol.g * mainCol.b);
                    mainCol.rgb = lerp(_Color,_SecondColor, mainCol.g);

					float bw = (mainCol.r + mainCol.g + mainCol.b)/3;

					if(bw < _LowPass) 	mainCol = lerp(mainCol,_Color,pow(bw+_LowPass,0.5f));
					if(bw > _HighPass) 	mainCol = lerp(mainCol,_SecondColor,pow(bw-_HighPass,0.5f));
					
                    clip(mainCol.a - _Cutoff);
                    UNITY_APPLY_FOG(i.fogCoord, col);
                    return mainCol;

                }

            ENDCG

        }
		
    }

}