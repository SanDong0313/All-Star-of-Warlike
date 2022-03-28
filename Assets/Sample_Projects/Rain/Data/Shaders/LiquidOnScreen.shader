// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// WILEz Per pixel bumped refraction.


Shader "WILEz/Liquidum" {
Properties {
     _Color ("Main Color", Color) = (1,1,1,1)
	_BumpAmt  ("Distortion", range (0,128)) = 10
	_MainTex ("Tint Color (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	
}

Category {


	Tags { "Queue"="Transparent" "RenderType"="Transparent" }


  
	SubShader {


		GrabPass {							
			Name "BASE"			 
			Tags { "LightMode" = "Always"  "IgnoreProjector"="True"}
 		}
 		

		Pass {
			Name "BASE"
			  Lighting Off
              SeparateSpecular Off
              ZWrite Off
              
              Cull Back
              Colormask RGB
           //   Blend SrcAlpha OneMinusSrcAlpha            
			Tags { "LightMode" = "Always"  "IgnoreProjector"="True"}
			
CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
#pragma vertex vert noambient nolightmap halfasview approxview noforwardadd nodirlightmap novertexlights 
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"


  
struct appdata_t {
	float4 vertex : POSITION;
	float2 texcoord: TEXCOORD0;
};

struct v2f {
	float4 vertex : POSITION;
	float4 uvgrab : TEXCOORD0;
	float2 uvbump : TEXCOORD1;
	float2 uvmain : TEXCOORD2;
};

half _BumpAmt;
float4 _BumpMap_ST;
float4 _MainTex_ST;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	#if UNITY_UV_STARTS_AT_TOP
	float scale = -1.0;
	#else
	float scale = 1.0;
	#endif
	o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
	o.uvgrab.zw = o.vertex.zw;
	o.uvbump = TRANSFORM_TEX( v.texcoord, _BumpMap );
	o.uvmain = TRANSFORM_TEX( v.texcoord, _MainTex );
	return o;
}

sampler2D _GrabTexture;
float4 _GrabTexture_TexelSize;
sampler2D _BumpMap;
sampler2D _MainTex;
fixed4 _Color;

half4 frag( v2f i ) : COLOR
{	half4 tint = tex2D( _MainTex, i.uvmain );	
      tint.rgb *= _Color.rgb;
      tint.a *= _Color.a;
      
      
	// calculate perturbed coordinates
	half2 bump = UnpackNormal(tex2D( _BumpMap, i.uvbump )).rg;
	float2 offset = bump * _BumpAmt*5 *_Color.a* _GrabTexture_TexelSize.xy;
	i.uvgrab.xy = offset * i.uvgrab.z + i.uvgrab.xy;
	
	half4 col = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(i.uvgrab));


    _BumpAmt*=_Color.a/4;
	return lerp( col, tint, tint.a );
}
ENDCG
		}
	}

	// --------------
	

	
	
	SubShader {
		Blend DstColor Zero
		Pass {
		      Name "BASE"
			  Lighting Off
              SeparateSpecular Off
              ZWrite Off
              Cull Back
              Tags { "LightMode" = "Always"  "IgnoreProjector"="True"}
			  SetTexture [_MainTex] {	combine texture alpha * primary }
			
		}

	}
	

	
}

}
