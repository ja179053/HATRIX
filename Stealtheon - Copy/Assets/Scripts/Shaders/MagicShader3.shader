Shader "Custom/MagicShader3" {
Properties{
_Color ("Main Color", Color) = (1,1,1,0)
_SpecColor ("Spec Color", Color) = (1,1,1,1)
_Emission ("Emissive Color", Color) = (0,0,0,0)
_Shininess("Shininess", Range (0.01,1)) = 0.7
_MainTex("Base (RGB)", 2D) = "white" {}
}
SubShader{
 Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
 LOD 100
Pass{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fog
#include "UnityCG.cginc"
struct data{
float4 vertex : POSITION;
float2 uv : TEXCOORD0;
};
struct v2f{
float2 uv : TEXCOORD0;
UNITY_FOG_COORDS(1)
float4 vertex : SV_POSITION;
};
v2f vert (data v){
v2f o;
o.vertex = UnityObjectToClipPos(v.vertex);
//o.uv = TRANSFORM_TEX(v.uv, _MainTex);
UNITY_TRANSFER_FOG(o,o.vertex);
return o;
}

fixed4 frag (v2f i) : SV_Target{
//fixed4 col = tex2D(_MainTex, i.uv);
fixed4 col;
UNITY_APPLY_FOG(i.fogCoord, col);
return col;
}
ENDCG
}
}
}