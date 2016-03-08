Shader "Anarchy/Particles/Candle Light" {	//Builds upon the framework built by Unity. If you want to do this yourself, take a look at the default shaders!
Properties {
	_Color		("Highlight Color", Color) 	= (1,1,1,1)
	_MainTex 	("Particle Texture", 2D) 	= "white" {}
	_NoiseTex 	("Noise Texture", 2D) 		= "black" {}
	_Speed		("Speed",Float)				= 1
	_NoiseSize	("Noise Size",Float)		= 1
}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha One
	ColorMask RGB
	Cull Off Lighting Off ZWrite Off
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _Color;
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_FOG_COORDS(1)
			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			sampler2D_float _CameraDepthTexture;

			float Radial(float2 p){
				float n = distance(float2(1,1),p*2);
				return clamp(1-n,0,1);
			}

			uniform float _Speed,_NoiseSize;
			sampler _NoiseTex;


			//Main code---------------------------
			fixed4 frag (v2f i) : SV_Target
			{
				float4 noise;
				noise.r = tex2D(_NoiseTex,_NoiseSize*i.texcoord+float2((_Time.x*_Speed),(_Time.x*_Speed)) ).r;
				noise.g = tex2D(_NoiseTex,_NoiseSize*i.texcoord+float2(-(_Time.x*_Speed),(_Time.x*_Speed)) ).g;
				noise.b = tex2D(_NoiseTex,_NoiseSize*i.texcoord+float2(0,-(_Time.x*_Speed)) ).b;
				noise.a = tex2D(_NoiseTex,_NoiseSize*i.texcoord+float2(0,-(_Time.x*_Speed*1.7554)) ).b;

				float4 noise2;
				noise2.r = tex2D(_NoiseTex,1.743+3.123	*_NoiseSize*i.texcoord+float2((_Time.x*_Speed),(_Time.x*_Speed)) ).r;
				noise2.g = tex2D(_NoiseTex,-1.743+3.123	*_NoiseSize*i.texcoord+float2(-(_Time.x*_Speed),(_Time.x*_Speed)) ).g;
				noise2.b = tex2D(_NoiseTex,1.743+3.123	*_NoiseSize*i.texcoord+float2(0,-(_Time.x*_Speed)) ).b;
				noise2.a = tex2D(_NoiseTex,-1.743+3.123	*_NoiseSize*i.texcoord+float2(0,-(_Time.x*_Speed*1.7554)) ).b;

				float noiseTotal = (noise.r + noise.g + noise.b + noise.a)*0.25;

				float2 shifted = float2(	(((noise.r + noise.b + noise.a)*0.33)*2 + ((noise2.g + noise2.b + noise2.a)*0.33))*0.33,
											(((noise.g + noise.b + noise.a)*0.33)*2 + ((noise2.r + noise2.b + noise2.a)*0.33))*0.33);

				float radial = Radial(i.texcoord);
				fixed4 tex = tex2D(_MainTex, i.texcoord + ((shifted*float2(i.texcoord.y+0.5,1)) - 0.5)*(1-pow(1-radial,2)));

				fixed4 col = 2.0f * i.color * _Color * tex;


				//col += pow(radial,2)*_Color;
				UNITY_APPLY_FOG_COLOR(i.fogCoord, col, fixed4(0,0,0,0)); // fog towards black due to our blend mode
				return col;
			}
			ENDCG 
		}
	}	
}
}
