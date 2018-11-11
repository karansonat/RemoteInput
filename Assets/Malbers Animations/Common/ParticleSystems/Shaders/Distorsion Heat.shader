// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Malbers/Distorsion"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_Normal("Normal", 2D) = "bump" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		_Intensity("Intensity", Float) = 0.1
		_Mask("Mask", 2D) = "white" {}
	}

	Category 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane"  }
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off
		
		SubShader
		{
			GrabPass{ }

			Pass {
			
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0
				#pragma multi_compile_particles
				#pragma multi_compile_fog
				


				#include "UnityCG.cginc"

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					#ifdef SOFTPARTICLES_ON
					float4 projPos : TEXCOORD2;
					#endif
					float4 ase_texcoord3 : TEXCOORD3;
				};
				
				uniform sampler2D _MainTex;
				uniform fixed4 _TintColor;
				uniform float4 _MainTex_ST;
				uniform sampler2D_float _CameraDepthTexture;
				uniform float _InvFade;
				uniform sampler2D _GrabTexture;
				uniform sampler2D _Normal;
				uniform float4 _Normal_ST;
				uniform float _Intensity;
				uniform sampler2D _Mask;
				uniform float4 _Mask_ST;

				v2f vert ( appdata_t v  )
				{
					v2f o;
					float4 clipPos = UnityObjectToClipPos(v.vertex);
					float4 screenPos = ComputeScreenPos(clipPos);
					o.ase_texcoord3 = screenPos;
					

					o.vertex.xyz +=  float3( 0, 0, 0 ) ;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef SOFTPARTICLES_ON
						o.projPos = ComputeScreenPos (o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.texcoord = v.texcoord;
					o.texcoord.xy = TRANSFORM_TEX(v.texcoord,_MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag ( v2f i  ) : SV_Target
				{
					#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
						float partZ = i.projPos.z;
						float fade = saturate (_InvFade * (sceneZ-partZ));
						i.color.a *= fade;
					#endif

					float4 screenPos = i.ase_texcoord3;
					float4 screenPos10 = screenPos;
					#if UNITY_UV_STARTS_AT_TOP
					float scale10 = -1.0;
					#else
					float scale10 = 1.0;
					#endif
					float halfPosW10 = screenPos10.w * 0.5;
					screenPos10.y = ( screenPos10.y - halfPosW10 ) * _ProjectionParams.x* scale10 + halfPosW10;
					screenPos10.xyzw /= screenPos10.w;
					float2 uv_Normal = i.texcoord * _Normal_ST.xy + _Normal_ST.zw;
					float4 screenColor12 = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD( ( screenPos10 + float4( ( UnpackNormal( tex2D( _Normal, uv_Normal ) ) * _Intensity ) , 0.0 ) ) ) );
					float2 uv_Mask = i.texcoord * _Mask_ST.xy + _Mask_ST.zw;
					float4 tex2DNode5 = tex2D( _Mask, uv_Mask );
					float4 appendResult1 = (float4(( (i.color).rgba * (screenColor12).rgba * float4( (_TintColor).rgb , 0.0 ) ).xyz , ( tex2DNode5.r * (_TintColor).a * tex2DNode5.r * i.color.a )));
					

					fixed4 col = appendResult1;
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
				ENDCG 
			}
		}	
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13401
30;199;1782;926;1434.17;97.87808;1;True;True
Node;AmplifyShaderEditor.SamplerNode;17;-1360,178;Float;True;Property;_Normal;Normal;1;0;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;18;-1300.243,389.0539;Float;False;Property;_Intensity;Intensity;2;0;0.1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.GrabScreenPosition;10;-1351,-45;Float;False;0;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-1013.243,227.0539;Float;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0.0,0,0;False;1;FLOAT3
Node;AmplifyShaderEditor.SimpleAddOpNode;11;-981,-34;Float;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.ScreenColorNode;12;-769,-60;Float;False;Global;_GrabScreen0;Grab Screen 0;1;0;Object;-1;False;1;0;FLOAT4;0,0,0,0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;16;-983,390;Float;False;_TintColor;0;1;COLOR
Node;AmplifyShaderEditor.VertexColorNode;6;-801,-252;Float;False;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SwizzleNode;21;-706.2428,428.0539;Float;False;FLOAT;3;1;2;3;1;0;COLOR;0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;5;-563,525;Float;True;Property;_Mask;Mask;0;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.VertexColorNode;2;-231,390;Float;False;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SwizzleNode;13;-577,-75;Float;False;FLOAT4;0;1;2;3;1;0;COLOR;0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.SwizzleNode;8;-579,-187;Float;False;FLOAT4;0;1;2;3;1;0;COLOR;0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.SwizzleNode;20;-741.2428,171.0539;Float;False;FLOAT3;0;1;2;3;1;0;COLOR;0,0,0,0;False;1;FLOAT3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-285,221;Float;False;4;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-379,-110;Float;False;3;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT3;0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.DynamicAppendNode;1;-194,-3;Float;False;FLOAT4;4;0;FLOAT3;0,0,0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.TemplateMasterNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;5;Malbers/Distorsion;0b6a9f8b4f707c74ca64c0be8e590de0;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;19;0;17;0
WireConnection;19;1;18;0
WireConnection;11;0;10;0
WireConnection;11;1;19;0
WireConnection;12;0;11;0
WireConnection;21;0;16;0
WireConnection;13;0;12;0
WireConnection;8;0;6;0
WireConnection;20;0;16;0
WireConnection;3;0;5;1
WireConnection;3;1;21;0
WireConnection;3;2;5;1
WireConnection;3;3;2;4
WireConnection;9;0;8;0
WireConnection;9;1;13;0
WireConnection;9;2;20;0
WireConnection;1;0;9;0
WireConnection;1;3;3;0
WireConnection;0;0;1;0
ASEEND*/
//CHKSM=ABB79DBC0D2644BECAD2C778796D45626258F9CC