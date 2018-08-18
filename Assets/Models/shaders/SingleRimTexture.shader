Shader "Unlit/Rim1"
{
	Properties{
		_Diffuse("Diffuse", Color) = (1, 1, 1, 1)
		_RimColor("RimColor",Color) = (1,1,1,1)
		_RimWidth("RimWidth",Range(0,1)) = 0.2
	}
		SubShader{
		Pass{
		Tags{ "LightMode" = "ForwardBase" }

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "Lighting.cginc"

		fixed4 _Diffuse;
	struct a2v {
		float4 vert : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : SV_POSITION;
		float3 worldNormal : TEXCOORD0;
	};

	v2f vert(a2v v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vert);
		o.worldNormal = mul((float3x3)unity_ObjectToWorld,v.normal);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target{
		fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
	fixed3 worldNormal = normalize(i.worldNormal);
	fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
	fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLightDir));
	fixed3 color = ambient + diffuse;

	return fixed4(color, 1.0);
	}

		ENDCG
	}
		Pass{
		Cull Front
		CGPROGRAM

#pragma vertex vert
#pragma fragment frag
		fixed4 _RimColor;
	float _RimWidth;
	struct a2v {
		float4 vert:POSITION;
		float3 normal:NORMAL;
	};
	struct v2f {
		float4 pos:SV_POSITION;
	};
	v2f vert(a2v v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vert - v.normal*_RimWidth);
		return o;
	}
	fixed4 frag(v2f i) :SV_Target{
		return _RimColor;
	}
		ENDCG
	}
	}
		FallBack "Diffuse"
}