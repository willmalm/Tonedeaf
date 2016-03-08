Shader "Anarchy/Particles/Piss" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Noise", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "Queue"="AlphaTest" "RenderType"="Opaque" }
		LOD 200
		Cull off
		CGPROGRAM

		//#pragma surface surf Standard fullforwardshadows alphatest:_Cutoff addshadows
		#pragma surface surf Standard 	alphatest:_Cutoff addshadow

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 color : COLOR;
		};






		float GetNoise(float2 uv, float seed){
			float4 n1;
			n1.r = tex2D(_MainTex, uv + float2(seed,		0)			+ 0.1);
			n1.g = tex2D(_MainTex, uv + float2(-seed,		0)			- 0.23);
			n1.b = tex2D(_MainTex, uv + float2(0,			seed)		+ 0.644);
			n1.a = tex2D(_MainTex, uv + float2(0,			-seed)		+ 0.874);
			return (n1.r + n1.g + n1.b + n1.a)*0.25;
		}

		float GetRadial(float2 uv){
			float n = length((uv*2)-1);
			return 1-clamp(n,0,1);
		}

		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float n = GetNoise(IN.uv_MainTex, _Time.x*0.7 + IN.color.a*3.14);
			float bigN = GetNoise((IN.uv_MainTex+34)*0.3, _Time.x*0.7 + 54);
			float radial = GetRadial(IN.uv_MainTex);
			//radial = lerp(1-radial,radial,IN.color.a);
			fixed4 c =  lerp(n,1,0.5) * _Color;
			o.Albedo = 0;
			o.Emission = c.rgb * IN.color.rgb;

			o.Smoothness = 0;
			o.Metallic = 0;
			o.Alpha = clamp(n * IN.color.a * bigN * bigN *100,0,1);
			o.Alpha *= radial*IN.color.a*bigN*n;
			//o.Occlusion = n*bigN*n;
		}
		ENDCG
	}
	FallBack "Transparent/Cutout/VertexLit"
}