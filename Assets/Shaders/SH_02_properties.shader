Shader "Holistic/AllProps"
{
	Properties{
		_myColor("Example Color", Color) = (1,1,1,1)
		_myTRange("Example TextureRange", Range(0,5)) = 1
		_myERange("Example EmissionRange", Range(0,1)) = 0
		
		_myTex("Example Texture", 2D) = "white" {}
		_myCube("Example Cube", CUBE) = "" {}
		_myFloat("Example Float", Float) = 0.5
		_myVector("Example Vector", Vector) = (0.5,1,1,1)
		// no boolien support ... some creative solutions: https://forum.unity.com/threads/shader-properties-no-bool-support.157580/
	}
		SubShader{

		  CGPROGRAM
			#pragma surface surf Lambert

			fixed4 _myColor;
			half _myTRange;
			half _myERange;
			sampler2D _myTex;
			samplerCUBE _myCube;
			float _myFloat;
			float4 _myVector;
			int _flag;

			struct Input {
				float2 uv_myTex;
				float3 worldRefl;
			};

			void surf(Input IN, inout SurfaceOutput o) {
				//_flag = 1;
				o.Albedo = (tex2D(_myTex, IN.uv_myTex) * _myTRange).rgb;
				// tex2D -> HLSL function
				// this function grabs all data model from uv_myTex and put image data from _myTex on that.
				// Microsoft: https://docs.microsoft.com/en-us/windows/desktop/direct3dhlsl/dx-graphics-hlsl-tex2d
				// NVidia: http://developer.download.nvidia.com/cg/tex2D.html
				o.Emission = (texCUBE(_myCube, IN.worldRefl) * _myERange).rgb;
				//if (_flag > 0 ) o.Emission = (texCUBE(_myCube, IN.worldRefl) * _myERange).rgb;
				//o.Emission = texCUBE(_myCube, IN.worldRefl).rgb;
			}

		  ENDCG
		}
			Fallback "Diffuse"
}
