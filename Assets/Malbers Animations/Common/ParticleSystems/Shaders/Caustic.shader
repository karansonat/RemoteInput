// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1372549,fgcg:0.5215687,fgcb:0.8235295,fgca:1,fgde:0.01,fgrn:58.2,fgrf:150,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33213,y:32616,varname:node_4013,prsc:2|diff-6037-OUT,alpha-9668-OUT;n:type:ShaderForge.SFN_Tex2d,id:3709,x:32474,y:32794,varname:node_3709,prsc:2,tex:2317dda727aed1c4e81d2ef4155e98f2,ntxv:0,isnm:False|UVIN-648-UVOUT,TEX-9700-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9700,x:32179,y:32878,ptovrint:False,ptlb:Caustic Texture,ptin:_CausticTexture,varname:node_9700,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2317dda727aed1c4e81d2ef4155e98f2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1484,x:32498,y:33008,varname:node_1484,prsc:2,tex:2317dda727aed1c4e81d2ef4155e98f2,ntxv:0,isnm:False|UVIN-7395-UVOUT,TEX-9700-TEX;n:type:ShaderForge.SFN_Blend,id:9784,x:32680,y:32853,varname:node_9784,prsc:2,blmd:1,clmp:True|SRC-3709-R,DST-1484-R;n:type:ShaderForge.SFN_Panner,id:7395,x:32228,y:33110,varname:node_7395,prsc:2,spu:0,spv:0.01|UVIN-102-UVOUT;n:type:ShaderForge.SFN_Panner,id:648,x:32243,y:32678,varname:node_648,prsc:2,spu:0.01,spv:0|UVIN-8497-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8497,x:31826,y:32852,varname:node_8497,prsc:2,uv:0;n:type:ShaderForge.SFN_Blend,id:9668,x:32797,y:32664,varname:node_9668,prsc:2,blmd:1,clmp:True|SRC-9116-OUT,DST-9784-OUT;n:type:ShaderForge.SFN_Slider,id:9116,x:32502,y:32547,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_9116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Rotator,id:102,x:31954,y:33044,varname:node_102,prsc:2|UVIN-8497-UVOUT,ANG-4060-OUT;n:type:ShaderForge.SFN_Vector1,id:4060,x:31699,y:33114,varname:node_4060,prsc:2,v1:15;n:type:ShaderForge.SFN_Fresnel,id:4005,x:32581,y:32405,varname:node_4005,prsc:2;n:type:ShaderForge.SFN_Vector1,id:6037,x:32996,y:32525,varname:node_6037,prsc:2,v1:1;proporder:9700-9116;pass:END;sub:END;*/

Shader "Malbers/Caustic" {
    Properties {
        _CausticTexture ("Caustic Texture", 2D) = "white" {}
        _Intensity ("Intensity", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _CausticTexture; uniform float4 _CausticTexture_ST;
            uniform float _Intensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_6037 = 1.0;
                float3 diffuseColor = float3(node_6037,node_6037,node_6037);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 node_9831 = _Time + _TimeEditor;
                float2 node_648 = (i.uv0+node_9831.g*float2(0.01,0));
                float4 node_3709 = tex2D(_CausticTexture,TRANSFORM_TEX(node_648, _CausticTexture));
                float node_102_ang = 15.0;
                float node_102_spd = 1.0;
                float node_102_cos = cos(node_102_spd*node_102_ang);
                float node_102_sin = sin(node_102_spd*node_102_ang);
                float2 node_102_piv = float2(0.5,0.5);
                float2 node_102 = (mul(i.uv0-node_102_piv,float2x2( node_102_cos, -node_102_sin, node_102_sin, node_102_cos))+node_102_piv);
                float2 node_7395 = (node_102+node_9831.g*float2(0,0.01));
                float4 node_1484 = tex2D(_CausticTexture,TRANSFORM_TEX(node_7395, _CausticTexture));
                fixed4 finalRGBA = fixed4(finalColor,saturate((_Intensity*saturate((node_3709.r*node_1484.r)))));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
