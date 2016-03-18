
Shader "Tondöv/Unlit Multitexture"

{

    //

    Properties {

        _Masks         	("Masks", 2D) = "white" {}

        _MainTex     	("Texture 1", 2D) = "white" {}
        _SecondTex     	("Texture 2", 2D) = "clear" {}
        _ThirdTex     	("Texture 3", 2D) = "clear" {}
        _FourthTex     	("Texture 4", 2D) = "clear" {}
        _FifthTex     	("Texture 5", 2D) = "clear" {}


        _Cutoff     	("Alpha cutoff", Range(0,1)) = 0.5


        _UseSecond    	("Use Mask 1",    	Float) = 0
        _UseThird    	("Use Mask 2",    	Float) = 0
        _UseFourth    	("Use Mask 3",    	Float) = 0
        _UseFifth    	("Use Mask 4",    	Float) = 0

        [Toggle]    _BlendType    ("Replace Masked",    Float) = 0



        _LightStrength     ("Emission Strength", Range(0,1)) = 1


        _Color        ("Color Override",Color) = (1,1,1,1)

        [Toggle]    _OverrideType    ("Multiply Averride",    Float) = 1


        _M1r        ("Mask 1.r Color",Color) = (1,1,1,1)
        _M1g        ("Mask 1.g Color",Color) = (1,1,1,1)
        _M1b        ("Mask 1.b Color",Color) = (1,1,1,1)


        _M2r        ("Mask 2.r Color",Color) = (1,1,1,1)
        _M2g        ("Mask 2.g Color",Color) = (1,1,1,1)
        _M2b        ("Mask 2.b Color",Color) = (1,1,1,1)


        _M3r        ("Mask 3.r Color",Color) = (1,1,1,1)
        _M3g        ("Mask 3.g Color",Color) = (1,1,1,1)
        _M3b        ("Mask 3.b Color",Color) = (1,1,1,1)


        _M4r        ("Mask 4.r Color",Color) = (1,1,1,1)
        _M4g        ("Mask 4.g Color",Color) = (1,1,1,1)
        _M4b        ("Mask 4.b Color",Color) = (1,1,1,1)


        _M5r        ("Mask 5.r Color",Color) = (1,1,1,1)
        _M5g        ("Mask 5.g Color",Color) = (1,1,1,1)
        _M5b        ("Mask 5.b Color",Color) = (1,1,1,1)




        //[Toggle]    _TwoSided    ("Culling",Float) = 0

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


                sampler2D _MainTex, _SecondTex, _ThirdTex, _FourthTex, _FifthTex, _Masks;
                float4 _MainTex_ST;
                fixed _Cutoff, _UseSecond, _UseThird, _UseFourth, _UseFifth, _OverrideType, _LightStrength, _BlendType;
                float4 _M1r, _M1g, _M1b,        _M2r,_M2g,_M2b,        _M3r, _M3g, _M3b,            _M4r, _M4g, _M4b,        _M5r, _M5g, _M5b;
                float4 _Color;


                v2f vert (appdata_t v)

                {

                    v2f o;

                    o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                    UNITY_TRANSFER_FOG(o,o.vertex);

                    return o;

                }

                

                fixed4 frag (v2f i) : SV_Target{
                    fixed4 m     = tex2D(_Masks, i.texcoord);
                    fixed4 mainCol = tex2D(_MainTex, i.texcoord);
                    mainCol *= _M1r;
                    fixed4 col     = mainCol;

                    if(_UseSecond){
                        fixed4 col2 = tex2D(_SecondTex, i.texcoord);
                        float4 colMix = col2.r * _M2r;
                        colMix.a = col2.a;
                        colMix = lerp(colMix, _M2g, col2.g);
                        colMix = lerp(colMix, _M2b, col2.b);
                        col2 = colMix;

                        if(!_BlendType) col2 = lerp(mainCol, col2, col2.a);
                        col = lerp(col, col2,m.r);

                    }


                    if(_UseThird){
                        fixed4 col3 = tex2D(_ThirdTex, i.texcoord);
                        float4 colMix = col3.r * _M3r;
                        colMix.a = col3.a;
                        colMix = lerp(colMix, _M3g, col3.g);
                        colMix = lerp(colMix, _M3b, col3.b);
                        col3 = colMix;

                        if(!_BlendType) col3 = lerp(mainCol, col3, col3.a);
                        col = lerp(col, col3,m.g);
                    }


                    if(_UseFourth){
                        fixed4 col4 = tex2D(_FourthTex, i.texcoord);
                        float4 colMix = col4.r * _M4r;
                        colMix.a = col4.a;
                        colMix = lerp(colMix, _M4g, col4.g);
                        colMix = lerp(colMix, _M4b, col4.b);
                        col4 = colMix;

                        if(!_BlendType) col4 = lerp(mainCol, col4, col4.a);
                        col = lerp(col, col4,m.b);
                    }


                    if(_UseFifth){
                        fixed4 col5 = tex2D(_FifthTex, i.texcoord);
                        float4 colMix = col5.r * _M5r;
                        colMix.a = col5.a;
                        colMix = lerp(colMix, _M5g, col5.g);
                        colMix = lerp(colMix, _M5b, col5.b);
                        col5 = colMix;

                        if(!_BlendType) col5 = lerp(mainCol, col5, col5.a);
                        col = lerp(col, col5,m.a);
                    }


                    _Color.a = col.a;
                    if(_OverrideType)col.rgb = lerp(col.rgb, _Color.rgb * col.rgb,_LightStrength);
                    else col.rgb += _Color.rgb * _LightStrength;

                    clip(col.a - _Cutoff);
                    UNITY_APPLY_FOG(i.fogCoord, col);
                    return col;

                }

            ENDCG

        }
		
    }
CustomEditor  "UnlitMultitextureInspector"

}



