// Upgrade NOTE: upgraded instancing buffer 'MalbersColor4x4' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Malbers/Color4x4"
{
	Properties
	{
		_Color1("Color 1", Color) = (1,0.1544118,0.1544118,0.291)
		_Color2("Color 2", Color) = (1,0.1544118,0.8017241,0.253)
		_Color3("Color 3", Color) = (0.2535501,0.1544118,1,0.541)
		_Color4("Color 4", Color) = (0.1544118,0.5451319,1,0.253)
		_Color5("Color 5", Color) = (0.9533468,1,0.1544118,0.553)
		_Color6("Color 6", Color) = (0.2720588,0.1294625,0,0.097)
		_Color7("Color 7", Color) = (0.1544118,0.6151115,1,0.178)
		_Color8("Color 8", Color) = (0.4849697,0.5008695,0.5073529,0.078)
		_Color9("Color 9", Color) = (0.3164301,0,0.7058823,0.134)
		_Color10("Color 10", Color) = (0.362069,0.4411765,0,0.759)
		_Color11("Color 11", Color) = (0.6691177,0.6691177,0.6691177,0.647)
		_Color12("Color 12", Color) = (0.5073529,0.1574544,0,0.128)
		_Color_13("Color_13", Color) = (1,0.5586207,0,0.272)
		_Color_14("Color_14", Color) = (0,0.8025862,0.875,0.047)
		_Color_15("Color_15", Color) = (1,0,0,0.391)
		_Color_16("Color_16", Color) = (0.4080882,0.75,0.4811866,0.134)
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

		UNITY_INSTANCING_BUFFER_START(MalbersColor4x4)
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color1)
#define _Color1_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color2)
#define _Color2_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color3)
#define _Color3_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color4)
#define _Color4_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color5)
#define _Color5_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color6)
#define _Color6_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color7)
#define _Color7_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color8)
#define _Color8_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color9)
#define _Color9_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color10)
#define _Color10_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color11)
#define _Color11_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color12)
#define _Color12_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color_13)
#define _Color_13_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color_14)
#define _Color_14_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color_15)
#define _Color_15_arr MalbersColor4x4
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color_16)
#define _Color_16_arr MalbersColor4x4
		UNITY_INSTANCING_BUFFER_END(MalbersColor4x4)

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 _Color1_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color1_arr, _Color1);
			float temp_output_3_0_g160 = 1.0;
			float temp_output_7_0_g160 = 4.0;
			float temp_output_9_0_g160 = 4.0;
			float temp_output_8_0_g160 = 4.0;
			float4 _Color2_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color2_arr, _Color2);
			float temp_output_3_0_g164 = 2.0;
			float temp_output_7_0_g164 = 4.0;
			float temp_output_9_0_g164 = 4.0;
			float temp_output_8_0_g164 = 4.0;
			float4 _Color3_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color3_arr, _Color3);
			float temp_output_3_0_g163 = 3.0;
			float temp_output_7_0_g163 = 4.0;
			float temp_output_9_0_g163 = 4.0;
			float temp_output_8_0_g163 = 4.0;
			float4 _Color4_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color4_arr, _Color4);
			float temp_output_3_0_g159 = 4.0;
			float temp_output_7_0_g159 = 4.0;
			float temp_output_9_0_g159 = 4.0;
			float temp_output_8_0_g159 = 4.0;
			float4 _Color5_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color5_arr, _Color5);
			float temp_output_3_0_g161 = 1.0;
			float temp_output_7_0_g161 = 4.0;
			float temp_output_9_0_g161 = 3.0;
			float temp_output_8_0_g161 = 4.0;
			float4 _Color6_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color6_arr, _Color6);
			float temp_output_3_0_g162 = 2.0;
			float temp_output_7_0_g162 = 4.0;
			float temp_output_9_0_g162 = 3.0;
			float temp_output_8_0_g162 = 4.0;
			float4 _Color7_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color7_arr, _Color7);
			float temp_output_3_0_g165 = 3.0;
			float temp_output_7_0_g165 = 4.0;
			float temp_output_9_0_g165 = 3.0;
			float temp_output_8_0_g165 = 4.0;
			float4 _Color8_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color8_arr, _Color8);
			float temp_output_3_0_g155 = 4.0;
			float temp_output_7_0_g155 = 4.0;
			float temp_output_9_0_g155 = 3.0;
			float temp_output_8_0_g155 = 4.0;
			float4 _Color9_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color9_arr, _Color9);
			float temp_output_3_0_g156 = 1.0;
			float temp_output_7_0_g156 = 4.0;
			float temp_output_9_0_g156 = 2.0;
			float temp_output_8_0_g156 = 4.0;
			float4 _Color10_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color10_arr, _Color10);
			float temp_output_3_0_g157 = 2.0;
			float temp_output_7_0_g157 = 4.0;
			float temp_output_9_0_g157 = 2.0;
			float temp_output_8_0_g157 = 4.0;
			float4 _Color11_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color11_arr, _Color11);
			float temp_output_3_0_g158 = 3.0;
			float temp_output_7_0_g158 = 4.0;
			float temp_output_9_0_g158 = 2.0;
			float temp_output_8_0_g158 = 4.0;
			float4 _Color12_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color12_arr, _Color12);
			float temp_output_3_0_g154 = 4.0;
			float temp_output_7_0_g154 = 4.0;
			float temp_output_9_0_g154 = 2.0;
			float temp_output_8_0_g154 = 4.0;
			float4 _Color_13_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color_13_arr, _Color_13);
			float temp_output_3_0_g167 = 1.0;
			float temp_output_7_0_g167 = 4.0;
			float temp_output_9_0_g167 = 1.0;
			float temp_output_8_0_g167 = 4.0;
			float4 _Color_14_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color_14_arr, _Color_14);
			float temp_output_3_0_g172 = 2.0;
			float temp_output_7_0_g172 = 4.0;
			float temp_output_9_0_g172 = 1.0;
			float temp_output_8_0_g172 = 4.0;
			float4 _Color_15_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color_15_arr, _Color_15);
			float temp_output_3_0_g173 = 3.0;
			float temp_output_7_0_g173 = 4.0;
			float temp_output_9_0_g173 = 1.0;
			float temp_output_8_0_g173 = 4.0;
			float4 _Color_16_Instance = UNITY_ACCESS_INSTANCED_PROP(_Color_16_arr, _Color_16);
			float temp_output_3_0_g171 = 4.0;
			float temp_output_7_0_g171 = 4.0;
			float temp_output_9_0_g171 = 1.0;
			float temp_output_8_0_g171 = 4.0;
			o.Albedo = ( ( ( _Color1_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g160 - 1.0 ) / temp_output_7_0_g160 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g160 / temp_output_7_0_g160 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g160 - 1.0 ) / temp_output_8_0_g160 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g160 / temp_output_8_0_g160 ) ) * 1.0 ) ) ) ) + ( _Color2_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g164 - 1.0 ) / temp_output_7_0_g164 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g164 / temp_output_7_0_g164 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g164 - 1.0 ) / temp_output_8_0_g164 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g164 / temp_output_8_0_g164 ) ) * 1.0 ) ) ) ) + ( _Color3_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g163 - 1.0 ) / temp_output_7_0_g163 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g163 / temp_output_7_0_g163 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g163 - 1.0 ) / temp_output_8_0_g163 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g163 / temp_output_8_0_g163 ) ) * 1.0 ) ) ) ) + ( _Color4_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g159 - 1.0 ) / temp_output_7_0_g159 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g159 / temp_output_7_0_g159 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g159 - 1.0 ) / temp_output_8_0_g159 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g159 / temp_output_8_0_g159 ) ) * 1.0 ) ) ) ) ) + ( ( _Color5_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g161 - 1.0 ) / temp_output_7_0_g161 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g161 / temp_output_7_0_g161 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g161 - 1.0 ) / temp_output_8_0_g161 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g161 / temp_output_8_0_g161 ) ) * 1.0 ) ) ) ) + ( _Color6_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g162 - 1.0 ) / temp_output_7_0_g162 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g162 / temp_output_7_0_g162 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g162 - 1.0 ) / temp_output_8_0_g162 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g162 / temp_output_8_0_g162 ) ) * 1.0 ) ) ) ) + ( _Color7_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g165 - 1.0 ) / temp_output_7_0_g165 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g165 / temp_output_7_0_g165 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g165 - 1.0 ) / temp_output_8_0_g165 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g165 / temp_output_8_0_g165 ) ) * 1.0 ) ) ) ) + ( _Color8_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g155 - 1.0 ) / temp_output_7_0_g155 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g155 / temp_output_7_0_g155 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g155 - 1.0 ) / temp_output_8_0_g155 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g155 / temp_output_8_0_g155 ) ) * 1.0 ) ) ) ) ) + ( ( _Color9_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g156 - 1.0 ) / temp_output_7_0_g156 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g156 / temp_output_7_0_g156 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g156 - 1.0 ) / temp_output_8_0_g156 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g156 / temp_output_8_0_g156 ) ) * 1.0 ) ) ) ) + ( _Color10_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g157 - 1.0 ) / temp_output_7_0_g157 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g157 / temp_output_7_0_g157 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g157 - 1.0 ) / temp_output_8_0_g157 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g157 / temp_output_8_0_g157 ) ) * 1.0 ) ) ) ) + ( _Color11_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g158 - 1.0 ) / temp_output_7_0_g158 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g158 / temp_output_7_0_g158 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g158 - 1.0 ) / temp_output_8_0_g158 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g158 / temp_output_8_0_g158 ) ) * 1.0 ) ) ) ) + ( _Color12_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g154 - 1.0 ) / temp_output_7_0_g154 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g154 / temp_output_7_0_g154 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g154 - 1.0 ) / temp_output_8_0_g154 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g154 / temp_output_8_0_g154 ) ) * 1.0 ) ) ) ) ) + ( ( _Color_13_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g167 - 1.0 ) / temp_output_7_0_g167 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g167 / temp_output_7_0_g167 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g167 - 1.0 ) / temp_output_8_0_g167 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g167 / temp_output_8_0_g167 ) ) * 1.0 ) ) ) ) + ( _Color_14_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g172 - 1.0 ) / temp_output_7_0_g172 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g172 / temp_output_7_0_g172 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g172 - 1.0 ) / temp_output_8_0_g172 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g172 / temp_output_8_0_g172 ) ) * 1.0 ) ) ) ) + ( _Color_15_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g173 - 1.0 ) / temp_output_7_0_g173 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g173 / temp_output_7_0_g173 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g173 - 1.0 ) / temp_output_8_0_g173 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g173 / temp_output_8_0_g173 ) ) * 1.0 ) ) ) ) + ( _Color_16_Instance * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g171 - 1.0 ) / temp_output_7_0_g171 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g171 / temp_output_7_0_g171 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g171 - 1.0 ) / temp_output_8_0_g171 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g171 / temp_output_8_0_g171 ) ) * 1.0 ) ) ) ) ) ).rgb;
			o.Metallic = _Metallic;
			float4 temp_cast_1 = (_Color1_Instance.a).xxxx;
			float temp_output_3_0_g147 = 1.0;
			float temp_output_7_0_g147 = 4.0;
			float temp_output_9_0_g147 = 4.0;
			float temp_output_8_0_g147 = 4.0;
			float4 temp_cast_2 = (_Color2_Instance.a).xxxx;
			float temp_output_3_0_g150 = 2.0;
			float temp_output_7_0_g150 = 4.0;
			float temp_output_9_0_g150 = 4.0;
			float temp_output_8_0_g150 = 4.0;
			float4 temp_cast_3 = (_Color3_Instance.a).xxxx;
			float temp_output_3_0_g144 = 3.0;
			float temp_output_7_0_g144 = 4.0;
			float temp_output_9_0_g144 = 4.0;
			float temp_output_8_0_g144 = 4.0;
			float4 temp_cast_4 = (_Color4_Instance.a).xxxx;
			float temp_output_3_0_g148 = 4.0;
			float temp_output_7_0_g148 = 4.0;
			float temp_output_9_0_g148 = 4.0;
			float temp_output_8_0_g148 = 4.0;
			float4 temp_cast_5 = (_Color5_Instance.a).xxxx;
			float temp_output_3_0_g145 = 1.0;
			float temp_output_7_0_g145 = 4.0;
			float temp_output_9_0_g145 = 3.0;
			float temp_output_8_0_g145 = 4.0;
			float4 temp_cast_6 = (_Color6_Instance.a).xxxx;
			float temp_output_3_0_g151 = 2.0;
			float temp_output_7_0_g151 = 4.0;
			float temp_output_9_0_g151 = 3.0;
			float temp_output_8_0_g151 = 4.0;
			float4 temp_cast_7 = (_Color7_Instance.a).xxxx;
			float temp_output_3_0_g143 = 3.0;
			float temp_output_7_0_g143 = 4.0;
			float temp_output_9_0_g143 = 3.0;
			float temp_output_8_0_g143 = 4.0;
			float4 temp_cast_8 = (_Color8_Instance.a).xxxx;
			float temp_output_3_0_g153 = 4.0;
			float temp_output_7_0_g153 = 4.0;
			float temp_output_9_0_g153 = 3.0;
			float temp_output_8_0_g153 = 4.0;
			float4 temp_cast_9 = (_Color9_Instance.a).xxxx;
			float temp_output_3_0_g149 = 1.0;
			float temp_output_7_0_g149 = 4.0;
			float temp_output_9_0_g149 = 2.0;
			float temp_output_8_0_g149 = 4.0;
			float4 temp_cast_10 = (_Color10_Instance.a).xxxx;
			float temp_output_3_0_g146 = 2.0;
			float temp_output_7_0_g146 = 4.0;
			float temp_output_9_0_g146 = 2.0;
			float temp_output_8_0_g146 = 4.0;
			float4 temp_cast_11 = (_Color11_Instance.a).xxxx;
			float temp_output_3_0_g142 = 3.0;
			float temp_output_7_0_g142 = 4.0;
			float temp_output_9_0_g142 = 2.0;
			float temp_output_8_0_g142 = 4.0;
			float4 temp_cast_12 = (_Color12_Instance.a).xxxx;
			float temp_output_3_0_g152 = 4.0;
			float temp_output_7_0_g152 = 4.0;
			float temp_output_9_0_g152 = 2.0;
			float temp_output_8_0_g152 = 4.0;
			float4 temp_cast_13 = (_Color_13_Instance.a).xxxx;
			float temp_output_3_0_g166 = 1.0;
			float temp_output_7_0_g166 = 4.0;
			float temp_output_9_0_g166 = 1.0;
			float temp_output_8_0_g166 = 4.0;
			float4 temp_cast_14 = (_Color_14_Instance.a).xxxx;
			float temp_output_3_0_g169 = 2.0;
			float temp_output_7_0_g169 = 4.0;
			float temp_output_9_0_g169 = 1.0;
			float temp_output_8_0_g169 = 4.0;
			float4 temp_cast_15 = (_Color_15_Instance.a).xxxx;
			float temp_output_3_0_g168 = 3.0;
			float temp_output_7_0_g168 = 4.0;
			float temp_output_9_0_g168 = 1.0;
			float temp_output_8_0_g168 = 4.0;
			float4 temp_cast_16 = (_Color_16_Instance.a).xxxx;
			float temp_output_3_0_g170 = 4.0;
			float temp_output_7_0_g170 = 4.0;
			float temp_output_9_0_g170 = 1.0;
			float temp_output_8_0_g170 = 4.0;
			o.Smoothness = ( ( ( ( temp_cast_1 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g147 - 1.0 ) / temp_output_7_0_g147 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g147 / temp_output_7_0_g147 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g147 - 1.0 ) / temp_output_8_0_g147 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g147 / temp_output_8_0_g147 ) ) * 1.0 ) ) ) ) + ( temp_cast_2 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g150 - 1.0 ) / temp_output_7_0_g150 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g150 / temp_output_7_0_g150 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g150 - 1.0 ) / temp_output_8_0_g150 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g150 / temp_output_8_0_g150 ) ) * 1.0 ) ) ) ) + ( temp_cast_3 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g144 - 1.0 ) / temp_output_7_0_g144 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g144 / temp_output_7_0_g144 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g144 - 1.0 ) / temp_output_8_0_g144 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g144 / temp_output_8_0_g144 ) ) * 1.0 ) ) ) ) + ( temp_cast_4 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g148 - 1.0 ) / temp_output_7_0_g148 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g148 / temp_output_7_0_g148 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g148 - 1.0 ) / temp_output_8_0_g148 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g148 / temp_output_8_0_g148 ) ) * 1.0 ) ) ) ) ) + ( ( temp_cast_5 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g145 - 1.0 ) / temp_output_7_0_g145 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g145 / temp_output_7_0_g145 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g145 - 1.0 ) / temp_output_8_0_g145 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g145 / temp_output_8_0_g145 ) ) * 1.0 ) ) ) ) + ( temp_cast_6 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g151 - 1.0 ) / temp_output_7_0_g151 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g151 / temp_output_7_0_g151 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g151 - 1.0 ) / temp_output_8_0_g151 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g151 / temp_output_8_0_g151 ) ) * 1.0 ) ) ) ) + ( temp_cast_7 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g143 - 1.0 ) / temp_output_7_0_g143 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g143 / temp_output_7_0_g143 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g143 - 1.0 ) / temp_output_8_0_g143 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g143 / temp_output_8_0_g143 ) ) * 1.0 ) ) ) ) + ( temp_cast_8 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g153 - 1.0 ) / temp_output_7_0_g153 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g153 / temp_output_7_0_g153 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g153 - 1.0 ) / temp_output_8_0_g153 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g153 / temp_output_8_0_g153 ) ) * 1.0 ) ) ) ) ) + ( ( temp_cast_9 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g149 - 1.0 ) / temp_output_7_0_g149 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g149 / temp_output_7_0_g149 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g149 - 1.0 ) / temp_output_8_0_g149 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g149 / temp_output_8_0_g149 ) ) * 1.0 ) ) ) ) + ( temp_cast_10 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g146 - 1.0 ) / temp_output_7_0_g146 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g146 / temp_output_7_0_g146 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g146 - 1.0 ) / temp_output_8_0_g146 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g146 / temp_output_8_0_g146 ) ) * 1.0 ) ) ) ) + ( temp_cast_11 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g142 - 1.0 ) / temp_output_7_0_g142 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g142 / temp_output_7_0_g142 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g142 - 1.0 ) / temp_output_8_0_g142 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g142 / temp_output_8_0_g142 ) ) * 1.0 ) ) ) ) + ( temp_cast_12 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g152 - 1.0 ) / temp_output_7_0_g152 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g152 / temp_output_7_0_g152 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g152 - 1.0 ) / temp_output_8_0_g152 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g152 / temp_output_8_0_g152 ) ) * 1.0 ) ) ) ) ) + ( ( temp_cast_13 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g166 - 1.0 ) / temp_output_7_0_g166 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g166 / temp_output_7_0_g166 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g166 - 1.0 ) / temp_output_8_0_g166 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g166 / temp_output_8_0_g166 ) ) * 1.0 ) ) ) ) + ( temp_cast_14 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g169 - 1.0 ) / temp_output_7_0_g169 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g169 / temp_output_7_0_g169 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g169 - 1.0 ) / temp_output_8_0_g169 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g169 / temp_output_8_0_g169 ) ) * 1.0 ) ) ) ) + ( temp_cast_15 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g168 - 1.0 ) / temp_output_7_0_g168 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g168 / temp_output_7_0_g168 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g168 - 1.0 ) / temp_output_8_0_g168 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g168 / temp_output_8_0_g168 ) ) * 1.0 ) ) ) ) + ( temp_cast_16 * ( ( ( 1.0 - step( i.uv_texcoord.x , ( ( temp_output_3_0_g170 - 1.0 ) / temp_output_7_0_g170 ) ) ) * ( step( i.uv_texcoord.x , ( temp_output_3_0_g170 / temp_output_7_0_g170 ) ) * 1.0 ) ) * ( ( 1.0 - step( i.uv_texcoord.y , ( ( temp_output_9_0_g170 - 1.0 ) / temp_output_8_0_g170 ) ) ) * ( step( i.uv_texcoord.y , ( temp_output_9_0_g170 / temp_output_8_0_g170 ) ) * 1.0 ) ) ) ) ) ) * _Smoothness ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
7;196;1666;847;1199.881;-513.0625;2.744435;True;False
Node;AmplifyShaderEditor.ColorNode;182;-220.2247,2417.44;Float;False;InstancedProperty;_Color12;Color 12;11;0;Create;True;0;0;False;0;0.5073529,0.1574544,0,0.128;0,0.1460954,0.3161765,0.472;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;181;-218.8154,2174.284;Float;False;InstancedProperty;_Color11;Color 11;10;0;Create;True;0;0;False;0;0.6691177,0.6691177,0.6691177,0.647;0.1985294,0.1664144,0.1664144,0.472;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;183;-224.4024,1681.061;Float;False;InstancedProperty;_Color9;Color 9;8;0;Create;True;0;0;False;0;0.3164301,0,0.7058823,0.134;0.5367647,0.4258277,0.2802228,0.422;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;180;-232.3431,1940.419;Float;False;InstancedProperty;_Color10;Color 10;9;0;Create;True;0;0;False;0;0.362069,0.4411765,0,0.759;0.2647059,0.2534304,0.2413495,0.484;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;217;-264.3738,3419.386;Float;False;InstancedProperty;_Color_16;Color_16;15;0;Create;True;0;0;False;0;0.4080882,0.75,0.4811866,0.134;0,0.1460954,0.3161765,0.472;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;218;-229.103,3176.23;Float;False;InstancedProperty;_Color_15;Color_15;14;0;Create;True;0;0;False;0;1,0,0,0.391;0.1985294,0.1664144,0.1664144,0.472;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;213;-234.6901,2683.007;Float;False;InstancedProperty;_Color_13;Color_13;12;0;Create;True;0;0;False;0;1,0.5586207,0,0.272;1,0.5586207,0,0.272;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;214;-242.6307,2942.365;Float;False;InstancedProperty;_Color_14;Color_14;13;0;Create;True;0;0;False;0;0,0.8025862,0.875,0.047;0.2647059,0.2534304,0.2413495,0.484;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;158;-183.7895,1424.406;Float;False;InstancedProperty;_Color8;Color 8;7;0;Create;True;0;0;False;0;0.4849697,0.5008695,0.5073529,0.078;0,0,0,0.459;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;157;-182.3802,1181.25;Float;False;InstancedProperty;_Color7;Color 7;6;0;Create;True;0;0;False;0;0.1544118,0.6151115,1,0.178;0.2205882,0.2189662,0.2189662,0.491;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;156;-195.9079,947.3851;Float;False;InstancedProperty;_Color6;Color 6;5;0;Create;True;0;0;False;0;0.2720588,0.1294625,0,0.097;0.1911765,0.1883651,0.1883651,0.441;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;159;-187.9672,688.0273;Float;False;InstancedProperty;_Color5;Color 5;4;0;Create;True;0;0;False;0;0.9533468,1,0.1544118,0.553;0.6544118,0.5677984,0.4378785,0.409;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;23;-199.8005,-326.2955;Float;False;InstancedProperty;_Color1;Color 1;0;0;Create;True;0;0;False;0;1,0.1544118,0.1544118,0.291;0.1102941,0.1102941,0.1102941,0.216;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;150;-207.7412,-66.93771;Float;False;InstancedProperty;_Color2;Color 2;1;0;Create;True;0;0;False;0;1,0.1544118,0.8017241,0.253;0.4264706,0.4264706,0.4264706,0.303;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;154;-195.6228,411.2479;Float;False;InstancedProperty;_Color4;Color 4;3;0;Create;True;0;0;False;0;0.1544118,0.5451319,1,0.253;0.4264706,0.4264706,0.4264706,0.422;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;152;-194.2135,166.9271;Float;False;InstancedProperty;_Color3;Color 3;2;0;Create;True;0;0;False;0;0.2535501,0.1544118,1,0.541;0.4264706,0.4264706,0.4264706,0.428;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;220;798.5189,2957.412;Float;True;ColorShartSlot;-1;;169;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;201;822.3342,2189.33;Float;True;ColorShartSlot;-1;;142;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;207;812.8722,2432.486;Float;True;ColorShartSlot;-1;;152;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;215;806.4594,2698.053;Float;True;ColorShartSlot;-1;;166;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;221;802.5844,3434.432;Float;True;ColorShartSlot;-1;;170;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;199;816.7472,1696.107;Float;True;ColorShartSlot;-1;;149;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;195;847.4503,425.1282;Float;True;ColorShartSlot;-1;;148;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;205;859.2836,1439.452;Float;True;ColorShartSlot;-1;;153;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;196;846.9359,181.9717;Float;True;ColorShartSlot;-1;;144;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;194;843.509,-313.4108;Float;True;ColorShartSlot;-1;;147;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;193;833.4083,-51.89295;Float;True;ColorShartSlot;-1;;150;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;202;808.8065,1955.466;Float;True;ColorShartSlot;-1;;146;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;219;812.0465,3191.276;Float;True;ColorShartSlot;-1;;168;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;200;858.7694,1196.295;Float;True;ColorShartSlot;-1;;143;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;204;845.2413,962.4299;Float;True;ColorShartSlot;-1;;151;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;206;853.1823,703.0721;Float;True;ColorShartSlot;-1;;145;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;216;81.02762,2687.848;Float;True;ColorShartSlot;-1;;167;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;145;115.9171,-321.4549;Float;True;ColorShartSlot;-1;;160;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;224;86.61465,3181.071;Float;True;ColorShartSlot;-1;;173;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;223;73.08682,2945.046;Float;True;ColorShartSlot;-1;;172;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;149;107.9764,-62.09709;Float;True;ColorShartSlot;-1;;164;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;151;121.5042,171.7677;Float;True;ColorShartSlot;-1;;163;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;209;1550.481,2137.188;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;153;122.0185,414.924;Float;True;ColorShartSlot;-1;;159;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;4;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;187;83.37437,1945.26;Float;True;ColorShartSlot;-1;;157;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;210;1555.357,2382.548;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;161;133.3375,1186.091;Float;True;ColorShartSlot;-1;;165;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;197;1564.168,1913.812;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;163;127.7504,692.868;Float;True;ColorShartSlot;-1;;161;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;186;96.90227,2179.125;Float;True;ColorShartSlot;-1;;158;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;3;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;188;91.31517,1685.902;Float;True;ColorShartSlot;-1;;156;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;1;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;226;1564.508,2601.695;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;222;87.12894,3424.227;Float;True;ColorShartSlot;-1;;171;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;1;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;162;133.8517,1429.247;Float;True;ColorShartSlot;-1;;155;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;160;119.8096,952.2258;Float;True;ColorShartSlot;-1;;162;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;2;False;9;FLOAT;3;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;185;97.41646,2422.281;Float;True;ColorShartSlot;-1;;154;231fe18505db4a84b9c478d379c9247d;0;5;38;COLOR;0.7843138,0.3137255,0,0;False;3;FLOAT;4;False;9;FLOAT;2;False;7;FLOAT;4;False;8;FLOAT;4;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;146;1539.255,777.6315;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;166;1887.168,1900.592;Float;False;Property;_Smoothness;Smoothness;16;0;Create;True;0;0;False;0;1;0.081;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;184;1537.758,1310.802;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;211;1889.437,2034.777;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;164;1539.944,1043.66;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;225;1534.365,1575.009;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;165;2014.597,1413.642;Float;False;Property;_Metallic;Metallic;17;0;Create;True;0;0;False;0;0;0.053;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;155;1964.993,1140.165;Float;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;212;2203.674,2027.498;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2469.067,1277.475;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Malbers/Color4x4;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;220;38;214;4
WireConnection;201;38;181;4
WireConnection;207;38;182;4
WireConnection;215;38;213;4
WireConnection;221;38;217;4
WireConnection;199;38;183;4
WireConnection;195;38;154;4
WireConnection;205;38;158;4
WireConnection;196;38;152;4
WireConnection;194;38;23;4
WireConnection;193;38;150;4
WireConnection;202;38;180;4
WireConnection;219;38;218;4
WireConnection;200;38;157;4
WireConnection;204;38;156;4
WireConnection;206;38;159;4
WireConnection;216;38;213;0
WireConnection;145;38;23;0
WireConnection;224;38;218;0
WireConnection;223;38;214;0
WireConnection;149;38;150;0
WireConnection;151;38;152;0
WireConnection;209;0;206;0
WireConnection;209;1;204;0
WireConnection;209;2;200;0
WireConnection;209;3;205;0
WireConnection;153;38;154;0
WireConnection;187;38;180;0
WireConnection;210;0;199;0
WireConnection;210;1;202;0
WireConnection;210;2;201;0
WireConnection;210;3;207;0
WireConnection;161;38;157;0
WireConnection;197;0;194;0
WireConnection;197;1;193;0
WireConnection;197;2;196;0
WireConnection;197;3;195;0
WireConnection;163;38;159;0
WireConnection;186;38;181;0
WireConnection;188;38;183;0
WireConnection;226;0;215;0
WireConnection;226;1;220;0
WireConnection;226;2;219;0
WireConnection;226;3;221;0
WireConnection;222;38;217;0
WireConnection;162;38;158;0
WireConnection;160;38;156;0
WireConnection;185;38;182;0
WireConnection;146;0;145;0
WireConnection;146;1;149;0
WireConnection;146;2;151;0
WireConnection;146;3;153;0
WireConnection;184;0;188;0
WireConnection;184;1;187;0
WireConnection;184;2;186;0
WireConnection;184;3;185;0
WireConnection;211;0;197;0
WireConnection;211;1;209;0
WireConnection;211;2;210;0
WireConnection;211;3;226;0
WireConnection;164;0;163;0
WireConnection;164;1;160;0
WireConnection;164;2;161;0
WireConnection;164;3;162;0
WireConnection;225;0;216;0
WireConnection;225;1;223;0
WireConnection;225;2;224;0
WireConnection;225;3;222;0
WireConnection;155;0;146;0
WireConnection;155;1;164;0
WireConnection;155;2;184;0
WireConnection;155;3;225;0
WireConnection;212;0;211;0
WireConnection;212;1;166;0
WireConnection;0;0;155;0
WireConnection;0;3;165;0
WireConnection;0;4;212;0
ASEEND*/
//CHKSM=BD718601C1854516D22C22DC1E6BA584152A285E