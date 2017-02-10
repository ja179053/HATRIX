Shader "Custom/MagicShader4" {
Properties{
_Color ("Main Color", Color) = (1,1,1,0)
_SpecColor ("Spec Color", Color) = (1,1,1,1)
_Emission ("Emissive Color", Color) = (0,0,0,0)
_Shininess("Shininess", Range (0.01,1)) = 0.7
_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader{
 Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="Transparent"}
Pass{
Material{
Diffuse [_Color]
Ambient [_Color]
Shininess [_Shininess]
Specular [_SpecColor]
Emission [_Emission]
} 
AlphaToMask On
Lighting On
SeparateSpecular On
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
SetTexture [_MainTex] { combine texture * primary DOUBLE, texture * primary }
}
}
}