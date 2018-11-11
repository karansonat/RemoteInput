// Upgrade NOTE: upgraded instancing buffer 'MalbersColor4x2' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Malbers/Color4x2"
{
	Properties
	{
		_Color1("Color 1", Color) = (1,0.1544118,0.1544118,0.397)
		_Color2("Color 2", Color) = (1,0.1544118,0.8017241,0.334)
		_Color3("Color 3", Color) = (0.2535501,0.1544118,1,0.228)
		_Color4("Color 4", Color) = (0.1544118,0.5451319,1,0.472)
		_Color5("Color 5", Color) = (0.9533468,1,0.1544118,0.353)
		_Color6("Color 6", Color) = (0.8483773,1,0.1544118,0.341)
		_Color7("Color 7", Color) = (0.1544118,0.6151115,1,0.316)
		_Color8("Color 8", Color) = (0.4849697,0.5008695,0.5073529,0.484)
		_Smoothness("Smoothness", Range( 0 , 1)) = 1
		_Metallic("Metallic", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _Metallic;
		uniform float _Smoothness;

		UNITY_INSTANCING_BUFFER_START(MalbersColor4x2)
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color1)
#define _Color1_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color2)
#define _Color2_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color3)
#define _Color3_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color4)
#define _Color4_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color5)
#define _Color5_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color6)
#define _Color6_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color7)
#define _Color7_arr MalbersColor4x2
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color8)
#define _Color8_arr MalbersColor4x2
		UNITY_INSTANCING_BUFFER_END(MalbersColor4x2)

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 _Color1_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color1_arr, _Color1);
			float temp_output_3_0_g128 = 1.0;
			float temp_output_7_0_g128 = 4.0;
			float temp_output_9_0_g128 = 2.0;
			float temp_output_8_0_g128 = 2.0;
			float4 _Color2_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color2_arr, _Color2);
			float temp_output_3_0_g127 = 2.0;
			float temp_output_7_0_g127 = 4.0;
			float temp_output_9_0_g127 = 2.0;
			float temp_output_8_0_g127 = 2.0;
			float4 _Color3_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color3_arr, _Color3);
			float temp_output_3_0_g129 = 3.0;
			float temp_output_7_0_g129 = 4.0;
			float temp_output_9_0_g129 = 2.0;
			float temp_output_8_0_g129 = 2.0;
			float4 _Color4_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color4_arr, _Color4);
			float temp_output_3_0_g130 = 4.0;
			float temp_output_7_0_g130 = 4.0;
			float temp_output_9_0_g130 = 2.0;
			float temp_output_8_0_g130 = 2.0;
			float4 _Color5_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color5_arr, _Color5);
			float temp_output_3_0_g126 = 1.0;
			float temp_output_7_0_g126 = 4.0;
			float temp_output_9_0_g126 = 1.0;
			float temp_output_8_0_g126 = 2.0;
			float4 _Color6_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color6_arr, _Color6);
			float temp_output_3_0_g131 = 2.0;
			float temp_output_7_0_g131 = 4.0;
			float temp_output_9_0_g131 = 1.0;
			float temp_output_8_0_g131 = 2.0;
			float4 _Color7_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color7_arr, _Color7);
			float temp_output_3_0_g133 = 3.0;
			float temp_output_7_0_g133 = 4.0;
			float temp_output_9_0_g133 = 1.0;
			float temp_output_8_0_g133 = 2.0;
			float4 _Color8_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color8_arr, _Color8);
			float temp_output_3_0_g132 = 4.0;
			float temp_output_7_0_g132 = 4.0;
			float temp_output_9_0_g132 = 1.0;
			float temp_output_8_0_g132 = 2.0;
			o.Albedo = ( ( ( _Color1_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g128 - 1.0 ) / temp_output_7_0_g128 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g128 / temp_output_7_0_g128 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g128 - 1.0 ) / temp_output_8_0_g128 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g128 / temp_output_8_0_g128 ) ) * 1.0 ) ) ) ) + ( _Color2_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g127 - 1.0 ) / temp_output_7_0_g127 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g127 / temp_output_7_0_g127 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g127 - 1.0 ) / temp_output_8_0_g127 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g127 / temp_output_8_0_g127 ) ) * 1.0 ) ) ) ) + ( _Color3_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g129 - 1.0 ) / temp_output_7_0_g129 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g129 / temp_output_7_0_g129 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g129 - 1.0 ) / temp_output_8_0_g129 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g129 / temp_output_8_0_g129 ) ) * 1.0 ) ) ) ) + ( _Color4_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g130 - 1.0 ) / temp_output_7_0_g130 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g130 / temp_output_7_0_g130 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g130 - 1.0 ) / temp_output_8_0_g130 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g130 / temp_output_8_0_g130 ) ) * 1.0 ) ) ) ) ) + ( ( _Color5_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g126 - 1.0 ) / temp_output_7_0_g126 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g126 / temp_output_7_0_g126 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g126 - 1.0 ) / temp_output_8_0_g126 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g126 / temp_output_8_0_g126 ) ) * 1.0 ) ) ) ) + ( _Color6_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g131 - 1.0 ) / temp_output_7_0_g131 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g131 / temp_output_7_0_g131 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g131 - 1.0 ) / temp_output_8_0_g131 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g131 / temp_output_8_0_g131 ) ) * 1.0 ) ) ) ) + ( _Color7_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g133 - 1.0 ) / temp_output_7_0_g133 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g133 / temp_output_7_0_g133 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g133 - 1.0 ) / temp_output_8_0_g133 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g133 / temp_output_8_0_g133 ) ) * 1.0 ) ) ) ) + ( _Color8_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g132 - 1.0 ) / temp_output_7_0_g132 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g132 / temp_output_7_0_g132 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g132 - 1.0 ) / temp_output_8_0_g132 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g132 / temp_output_8_0_g132 ) ) * 1.0 ) ) ) ) ) ).rgb;
			o.Metallic = _Metallic;
			float4 temp_cast_1 = (_Color1_Instance.a).xxxx;
			float temp_output_3_0_g123 = 1.0;
			float temp_output_7_0_g123 = 4.0;
			float temp_output_9_0_g123 = 2.0;
			float temp_output_8_0_g123 = 2.0;
			float4 temp_cast_2 = (_Color2_Instance.a).xxxx;
			float temp_output_3_0_g121 = 2.0;
			float temp_output_7_0_g121 = 4.0;
			float temp_output_9_0_g121 = 2.0;
			float temp_output_8_0_g121 = 2.0;
			float4 temp_cast_3 = (_Color3_Instance.a).xxxx;
			float temp_output_3_0_g122 = 3.0;
			float temp_output_7_0_g122 = 4.0;
			float temp_output_9_0_g122 = 2.0;
			float temp_output_8_0_g122 = 2.0;
			float4 temp_cast_4 = (_Color4_Instance.a).xxxx;
			float temp_output_3_0_g124 = 4.0;
			float temp_output_7_0_g124 = 4.0;
			float temp_output_9_0_g124 = 2.0;
			float temp_output_8_0_g124 = 2.0;
			float4 temp_cast_5 = (_Color5_Instance.a).xxxx;
			float temp_output_3_0_g120 = 1.0;
			float temp_output_7_0_g120 = 4.0;
			float temp_output_9_0_g120 = 1.0;
			float temp_output_8_0_g120 = 2.0;
			float4 temp_cast_6 = (_Color6_Instance.a).xxxx;
			float temp_output_3_0_g125 = 2.0;
			float temp_output_7_0_g125 = 4.0;
			float temp_output_9_0_g125 = 1.0;
			float temp_output_8_0_g125 = 2.0;
			float4 temp_cast_7 = (_Color7_Instance.a).xxxx;
			float temp_output_3_0_g119 = 3.0;
			float temp_output_7_0_g119 = 4.0;
			float temp_output_9_0_g119 = 1.0;
			float temp_output_8_0_g119 = 2.0;
			float4 temp_cast_8 = (_Color8_Instance.a).xxxx;
			float temp_output_3_0_g118 = 4.0;
			float temp_output_7_0_g118 = 4.0;
			float temp_output_9_0_g118 = 1.0;
			float temp_output_8_0_g118 = 2.0;
			o.Smoothness = ( ( ( ( temp_cast_1 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g123 - 1.0 ) / temp_output_7_0_g123 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g123 / temp_output_7_0_g123 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g123 - 1.0 ) / temp_output_8_0_g123 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g123 / temp_output_8_0_g123 ) ) * 1.0 ) ) ) ) + ( temp_cast_2 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g121 - 1.0 ) / temp_output_7_0_g121 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g121 / temp_output_7_0_g121 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g121 - 1.0 ) / temp_output_8_0_g121 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g121 / temp_output_8_0_g121 ) ) * 1.0 ) ) ) ) + ( temp_cast_3 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g122 - 1.0 ) / temp_output_7_0_g122 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g122 / temp_output_7_0_g122 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g122 - 1.0 ) / temp_output_8_0_g122 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g122 / temp_output_8_0_g122 ) ) * 1.0 ) ) ) ) + ( temp_cast_4 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g124 - 1.0 ) / temp_output_7_0_g124 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g124 / temp_output_7_0_g124 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g124 - 1.0 ) / temp_output_8_0_g124 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g124 / temp_output_8_0_g124 ) ) * 1.0 ) ) ) ) ) + ( ( temp_cast_5 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g120 - 1.0 ) / temp_output_7_0_g120 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g120 / temp_output_7_0_g120 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g120 - 1.0 ) / temp_output_8_0_g120 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g120 / temp_output_8_0_g120 ) ) * 1.0 ) ) ) ) + ( temp_cast_6 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g125 - 1.0 ) / temp_output_7_0_g125 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g125 / temp_output_7_0_g125 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g125 - 1.0 ) / temp_output_8_0_g125 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g125 / temp_output_8_0_g125 ) ) * 1.0 ) ) ) ) + ( temp_cast_7 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g119 - 1.0 ) / temp_output_7_0_g119 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g119 / temp_output_7_0_g119 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g119 - 1.0 ) / temp_output_8_0_g119 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g119 / temp_output_8_0_g119 ) ) * 1.0 ) ) ) ) + ( temp_cast_8 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g118 - 1.0 ) / temp_output_7_0_g118 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g118 / temp_output_7_0_g118 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g118 - 1.0 ) / temp_output_8_0_g118 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g118 / temp_output_8_0_g118 ) ) * 1.0 ) ) ) ) ) ) * _Smoothness ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
119;77;1666;847;1043.417;394.9345;2.503786;True;False
Node;AmplifyShaderEditor.ColorNode;23;-199.8005,-326.2955;Float;False;InstancedProperty;_Color1;Color 1;0;0;Create;True;0;0;False;0;1,0.1544118,0.1544118,0.397;1,0.1544118,0.1544118,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;157;-182.3802,1181.25;Float;False;InstancedProperty;_Color7;Color 7;6;0;Create;True;0;0;False;0;0.1544118,0.6151115,1,0.316;0.1544118,0.6151115,1,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;152;-194.2135,166.9271;Float;False;InstancedProperty;_Color3;Color 3;2;0;Create;True;0;0;False;0;0.2535501,0.1544118,1,0.228;0.2535501,0.1544118,1,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;150;-207.7412,-66.93771;Float;False;InstancedProperty;_Color2;Color 2;1;0;Create;True;0;0;False;0;1,0.1544118,0.8017241,0.334;1,0.1544118,0.8017241,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;156;-195.9079,947.3851;Float;False;InstancedProperty;_Color6;Color 6;5;0;Create;True;0;0;False;0;0.8483773,1,0.1544118,0.341;0.8483773,1,0.1544118,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;158;-183.7895,1424.406;Float;False;InstancedProperty;_Color8;Color 8;7;0;Create;True;0;0;False;0;0.4849697,0.5008695,0.5073529,0.484;0.4849697,0.5008695,0.5073529,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;154;-195.6228,411.2479;Float;False;InstancedProperty;_Color4;Color 4;3;0;Create;True;0;0;False;0;0.1544118,0.5451319,1,0.472;0.1544118,0.5451319,1,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;159;-187.9672,688.0273;Float;False;InstancedProperty;_Color5;Color 5;4;0;Create;True;0;0;False;0;0.9533468,1,0.1544118,0.353;0.9533468,1,0.1544118,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;170;456.565,-65.72902;Float;True;ColorShartSlot;-1;;121;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;169;476.3391,689.236;Float;True;ColorShartSlot;-1;;120;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;171;482.4404,1425.615;Float;True;ColorShartSlot;-1;;118;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;168;470.0929,168.1358;Float;True;ColorShartSlot;-1;;122;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;167;464.5059,-325.0867;Float;True;ColorShartSlot;-1;;123;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;174;468.3983,948.5938;Float;True;ColorShartSlot;-1;;125;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;172;481.9263,1182.458;Float;True;ColorShartSlot;-1;;119;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;173;470.6072,411.2918;Float;True;ColorShartSlot;-1;;124;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;163;127.7504,688.1025;Float;True;ColorShartSlot;-1;;126;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;145;115.9171,-326.2204;Float;True;ColorShartSlot;-1;;128;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;149;107.9764,-66.86263;Float;True;ColorShartSlot;-1;;127;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;176;1116.186,367.1404;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;153;122.0185,410.1585;Float;True;ColorShartSlot;-1;;130;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;160;119.8096,947.4603;Float;True;ColorShartSlot;-1;;131;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;151;121.5042,167.0022;Float;True;ColorShartSlot;-1;;129;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;175;1122.892,595.2336;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;162;133.8517,1424.481;Float;True;ColorShartSlot;-1;;132;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;161;133.3375,1181.325;Float;True;ColorShartSlot;-1;;133;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;2;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;166;1387.967,723.6592;Float;False;Property;_Smoothness;Smoothness;8;0;Create;True;0;0;False;0;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;177;1371.054,508.2005;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;164;1130.732,57.40811;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;146;1124.026,-170.6852;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;155;1378.894,-29.6249;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;178;1695.109,386.3072;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;165;1691.967,238.6589;Float;False;Property;_Metallic;Metallic;9;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2076.697,169.3291;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Malbers/Color4x2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;170;38;150;4
WireConnection;169;38;159;4
WireConnection;171;38;158;4
WireConnection;168;38;152;4
WireConnection;167;38;23;4
WireConnection;174;38;156;4
WireConnection;172;38;157;4
WireConnection;173;38;154;4
WireConnection;163;38;159;0
WireConnection;145;38;23;0
WireConnection;149;38;150;0
WireConnection;176;0;167;0
WireConnection;176;1;170;0
WireConnection;176;2;168;0
WireConnection;176;3;173;0
WireConnection;153;38;154;0
WireConnection;160;38;156;0
WireConnection;151;38;152;0
WireConnection;175;0;169;0
WireConnection;175;1;174;0
WireConnection;175;2;172;0
WireConnection;175;3;171;0
WireConnection;162;38;158;0
WireConnection;161;38;157;0
WireConnection;177;0;176;0
WireConnection;177;1;175;0
WireConnection;164;0;163;0
WireConnection;164;1;160;0
WireConnection;164;2;161;0
WireConnection;164;3;162;0
WireConnection;146;0;145;0
WireConnection;146;1;149;0
WireConnection;146;2;151;0
WireConnection;146;3;153;0
WireConnection;155;0;146;0
WireConnection;155;1;164;0
WireConnection;178;0;177;0
WireConnection;178;1;166;0
WireConnection;0;0;155;0
WireConnection;0;3;165;0
WireConnection;0;4;178;0
ASEEND*/
//CHKSM=72916B7E63F7FD9761D9E3CCBB29D821B21CF83A