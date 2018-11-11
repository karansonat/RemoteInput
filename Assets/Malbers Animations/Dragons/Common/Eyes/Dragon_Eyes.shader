// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MA/DragonEyes"
{
	Properties
	{
		_Color0("Color 0", Color) = (1,0,0,0)
		_Color1("Color 1", Color) = (1,0.9310346,0,0)
		_Emission("Emission", Range( 0 , 1.5)) = 0
		[NoScaleOffset]_Iris("Iris", 2D) = "white" {}
		[NoScaleOffset]_DragonPupil("Dragon Pupil", 2D) = "white" {}
		[NoScaleOffset]_BloodPupil("Blood Pupil", 2D) = "white" {}
		[NoScaleOffset]_CatPupil("Cat Pupil", 2D) = "white" {}
		[Toggle]_ToggleSwitch0("Cat Eyes", Float) = 1
		[Toggle]_ToggleSwitch1("Blood Eyes", Float) = 0
		_PupilColor("Pupil Color", Color) = (1,1,1,0)
		_Smooth("Smooth", Range( 0 , 1)) = 0
		_Metallic("Metallic", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Iris;
		uniform float4 _PupilColor;
		uniform float _ToggleSwitch1;
		uniform float _ToggleSwitch0;
		uniform sampler2D _DragonPupil;
		uniform sampler2D _CatPupil;
		uniform sampler2D _BloodPupil;
		uniform float4 _Color0;
		uniform float4 _Color1;
		uniform float _Emission;
		uniform float _Metallic;
		uniform float _Smooth;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Iris35 = i.uv_texcoord;
			float2 uv_DragonPupil161 = i.uv_texcoord;
			float2 uv_CatPupil149 = i.uv_texcoord;
			float2 uv_BloodPupil147 = i.uv_texcoord;
			float4 lerpResult37 = lerp( tex2D( _Iris, uv_Iris35 ) , _PupilColor , lerp(lerp(tex2D( _DragonPupil, uv_DragonPupil161 ).a,tex2D( _CatPupil, uv_CatPupil149 ).a,_ToggleSwitch0),tex2D( _BloodPupil, uv_BloodPupil147 ).a,_ToggleSwitch1));
			float temp_output_19_0 = length( (float2( -0.91,-0.96 ) + (i.uv_texcoord - float2( 0.1,0.1 )) * (float2( 1.27,1.2 ) - float2( -0.91,-0.96 )) / (float2( 1,1 ) - float2( 0.1,0.1 ))) );
			float4 lerpResult2 = lerp( _Color0 , _Color1 , (temp_output_19_0*-2.3 + 0.89));
			float4 temp_cast_0 = ((temp_output_19_0*10000.0 + -5598.0)).xxxx;
			float4 blendOpSrc122 = lerpResult2;
			float4 blendOpDest122 = temp_cast_0;
			float4 blendOpSrc62 = lerpResult37;
			float4 blendOpDest62 = ( saturate( 	max( blendOpSrc122, blendOpDest122 ) ));
			float4 temp_output_62_0 = ( saturate( ( blendOpSrc62 * blendOpDest62 ) ));
			o.Albedo = temp_output_62_0.rgb;
			o.Emission = ( temp_output_62_0 * _Emission ).rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smooth;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
7;218;1666;825;339.7748;204.106;1.305222;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-1513.32,289.0191;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;21;-1201.633,502.3371;Float;True;5;0;FLOAT2;0,0;False;1;FLOAT2;0.1,0.1;False;2;FLOAT2;1,1;False;3;FLOAT2;-0.91,-0.96;False;4;FLOAT2;1.27,1.2;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;161;-1278.342,-973.5489;Float;True;Property;_DragonPupil;Dragon Pupil;4;1;[NoScaleOffset];Create;True;0;0;False;0;None;97b733e755bc0a7478f787405f406a78;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;19;-730.5449,583.6178;Float;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;149;-1250.009,-660.561;Float;True;Property;_CatPupil;Cat Pupil;6;1;[NoScaleOffset];Create;True;0;0;False;0;None;039d132d85d391e4393d3675cc9b7815;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;158;-815.1578,-614.6838;Float;False;Property;_ToggleSwitch0;Cat Eyes;7;0;Create;False;0;0;False;0;1;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;147;-979.7119,-426.2217;Float;True;Property;_BloodPupil;Blood Pupil;5;1;[NoScaleOffset];Create;True;0;0;False;0;None;7fd24a4cdfc9d9445b46ce5e87b38825;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;4;-896.2249,-32.30793;Float;False;Property;_Color0;Color 0;0;0;Create;True;0;0;False;0;1,0,0,0;0,0.462069,1,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;5;-906.3721,139.2132;Float;False;Property;_Color1;Color 1;1;0;Create;True;0;0;False;0;1,0.9310346,0,0;1,0.9310346,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScaleAndOffsetNode;48;-517.6025,456.1831;Float;True;3;0;FLOAT;0;False;1;FLOAT;-2.3;False;2;FLOAT;0.89;False;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;159;-511.8494,-488.9924;Float;False;Property;_ToggleSwitch1;Blood Eyes;8;0;Create;False;0;0;False;0;0;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;35;-483.7459,-940.1523;Float;True;Property;_Iris;Iris;3;1;[NoScaleOffset];Create;True;0;0;False;0;None;97b733e755bc0a7478f787405f406a78;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScaleAndOffsetNode;45;-532.7474,766.3651;Float;True;3;0;FLOAT;0;False;1;FLOAT;10000;False;2;FLOAT;-5598;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;153;-297.4925,-276.3829;Float;False;Property;_PupilColor;Pupil Color;9;0;Create;True;0;0;False;0;1,1,1,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;2;-349.5644,159.3667;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;37;6.201534,-389.0968;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.BlendOpsNode;122;33.51579,434.6385;Float;True;Lighten;True;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.BlendOpsNode;62;345.9883,114.0089;Float;True;Multiply;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;68;552.1103,456.3202;Float;False;Property;_Emission;Emission;2;0;Create;True;0;0;False;0;0;0;0;1.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;163;917.1541,616.8787;Float;False;Property;_Smooth;Smooth;10;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;162;908.0172,529.4286;Float;False;Property;_Metallic;Metallic;11;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;67;846.4507,216.6555;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1238.929,100.0278;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;MA/DragonEyes;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;21;0;3;0
WireConnection;19;0;21;0
WireConnection;158;0;161;4
WireConnection;158;1;149;4
WireConnection;48;0;19;0
WireConnection;159;0;158;0
WireConnection;159;1;147;4
WireConnection;45;0;19;0
WireConnection;2;0;4;0
WireConnection;2;1;5;0
WireConnection;2;2;48;0
WireConnection;37;0;35;0
WireConnection;37;1;153;0
WireConnection;37;2;159;0
WireConnection;122;0;2;0
WireConnection;122;1;45;0
WireConnection;62;0;37;0
WireConnection;62;1;122;0
WireConnection;67;0;62;0
WireConnection;67;1;68;0
WireConnection;0;0;62;0
WireConnection;0;2;67;0
WireConnection;0;3;162;0
WireConnection;0;4;163;0
ASEEND*/
//CHKSM=4616FAD580A921E69F0AD3A1127E8103B935F6DD