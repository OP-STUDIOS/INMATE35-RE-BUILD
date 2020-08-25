Shader "Holistic/FirstShader" {

	//	list of your properties
	Properties{
		
		_myColour("Example Colour", Color) = (1,1,1,1)
		_myEmission("Example Emission", Color) = (1,1,1,1)

		// _Variable name (" name in inspector/editor ", type) = default value 
		// underscore for var name and --------------------------------------- no ; at end 

		_myFloat("Example float variable", Float) = 0.4
		_myInt("Example Int variable", Int) = 0.4

		_mySlider("Example Slider", Range(400, 424)) = 402
		
		_myVector("Example Vector", Vector) = (110, 45, 110, 10)
		//[HideInInspector]_myVector("Example Vector", Vector) = (110, 45, 110, 10)
	}

	SubShader{

	CGPROGRAM
		#pragma surface surf Lambert 
		//	#pragma [shadere type]  [name of shader function (in this code, it called "surf")]  [Lighting model]
		
		//Basics : https://docs.unity3d.com/Manual/SL-SurfaceShaders.html
		//Samples: https://docs.unity3d.com/Manual/SL-SurfaceShaderExamples.html
		//Extra : https://www.alanzucconi.com/2015/06/17/surface-shaders-in-unity3d/

		//	list of your properties
		fixed4 _myColour;
		fixed4 _myEmission;
		fixed4 _myNormal;


		float _myFloat;
		int _myInt;
		float _mySlider;
		float4 _myVector;

		//	input data structure for "surf" function
		struct Input {
			float2 uvMainTex;
		};


		//	shader function
		// void [name]( [input data structure] [output structure from shader`s [Lighting] ])
		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = _myColour.rgb;
			o.Emission = _myEmission.rgb;
		}

	ENDCG
	}

	FallBack "Diffuse"
}