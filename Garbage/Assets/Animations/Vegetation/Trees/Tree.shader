Shader "Anarchy/Tree" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_EdgeLength ("Edge length", Range(2,64)) = 15

		//_Direction		("Direction", Vector) = (1,0,0,1)
		_XStrength		("X Strength",Range(-1,1)) = 1
		_YStrength		("Y Strength",Range(-1,1)) = 0
		_WindDistance 	("Wind Distance", Range(0.01,50)) = 5
		_WindSpeed 		("Wind Speed", Range(0,10)) = 1
		_HardnessMultiplier 		("Hardness Multiplier", Range(0,1)) = 0.2
		_Hardness 		("Hardness", 2D) = "white" {}
	}
	SubShader {
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		LOD 200
		Lighting Off


		CGPROGRAM
		#pragma surface surf Standard  noforwardadd alphatest:_Cutoff vertex:disp tessellate:tessEdge nolightmap

		#pragma target 2.0
		#include "Tessellation.cginc"


		sampler2D _MainTex,_Hardness;
		uniform float _XStrength,_YStrength,_WindDistance,_WindSpeed,_HardnessMultiplier;

		struct Input {
			float2 uv_MainTex;
		};
		struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

		float _EdgeLength;
        float4 tessEdge (appdata v0, appdata v1, appdata v2){return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);}

         void disp (inout appdata v)
            {
               // float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * (_Displacement);
               // d-=_Displacement*0.5f;
               // v.vertex.xyz += v.normal * d;


               float3 worldPos = mul(_Object2World,v.vertex.xyz);
					float3 oldPos = worldPos;
					float hardness = tex2Dlod(_Hardness, float4(v.texcoord.xy,0,0)).r;
					hardness = 1-hardness;
					worldPos/=_WindDistance;
					worldPos.x = (sin(worldPos.x + worldPos.y*worldPos.z + _Time.w*_WindSpeed + worldPos.z*10 + hardness*3) + sin(worldPos.x/2 + _WindDistance + _Time.w*_WindSpeed*0.34f + hardness))/2;
					worldPos.y = (sin(worldPos.y + worldPos.x*worldPos.z + _Time.w*_WindSpeed + worldPos.z*10 + hardness*3) + sin(worldPos.y/2 + _WindDistance + _Time.w*_WindSpeed*0.34f + hardness))/2;
					//worldPos.z = (sin(worldPos.z + worldPos.x*worldPos.y + _Time.w*_WindSpeed) + sin(worldPos.z/2 + _WindDistance + _Time.w*_WindSpeed*0.34f))/2;

					worldPos.x *= _XStrength;
					worldPos.y *= _YStrength;
					//worldPos.z *= _Direction.z;

					worldPos *= _HardnessMultiplier;

					worldPos = mul(_World2Object,worldPos);

					//float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r
					hardness = 1-hardness;
					v.vertex.xyz += worldPos * hardness;
            }


		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = 0;
			o.Occlusion = 0;
			o.Metallic = 0;
			o.Smoothness = 1;
			o.Emission = c.rgb;
			o.Alpha = 1;
			clip(c.a - 0.5);
		}
		ENDCG
	}
	//FallBack "Diffuse"								ACTIVATE EITHER FOR CAST SHADOWS
	//Fallback "Transparent/Cutout/VertexLit"
}
