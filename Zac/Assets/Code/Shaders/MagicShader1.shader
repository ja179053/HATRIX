Shader "Custom/MagicShader1" {
    Properties {
        _MainTex ("Texture to blend", 2D) = "black" {}
        _Color("Colour", Color) = (1,1,1,1)
        _Val("Alpha", Float) = 1
    }
    SubShader {
    Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Pass {
 //    Material{
   //  Diffuse [_Color]
     //Ambient [_Color]
 //    }
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
            SetTexture [_MainTex] { combine texture * primary DOUBLE, texture * primary }
        }
    }
}