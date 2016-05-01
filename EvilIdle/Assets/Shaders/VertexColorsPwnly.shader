Shader "Labertorium/Vertex Colored/Solid" {
    Properties {
        // introduces the base color property which can be used to multiply the vertex colors with (e.g. dim to black or a specific color)
        _Color ("Color", Color) = (1.00, 1.00, 1.00, 1.00) // white
    }
    SubShader {
        // Unity shader lab attributes
        // set the render type to be opaque (not using any transparencies or similar)
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        // actual shader code        
        CGPROGRAM
        // set the 'surf' function to be used by the rendering pipeline as the surface shader function and let it use the lambertion lighting model
        #pragma surface surf Lambert
       
        // map the property to a vector4 of type fixed to use it inside the surf function
        fixed4 _Color;
 
        // declare the input structure we expect unity to pass to the surf-function
        struct Input {
            // add the uv coordinate for the main texture to the input structure
            float2 uv_MainTex;
            // add the vertex color of the rendered mesh to the input structure 
            // remark: the ': COLOR' tells Unity which of the mesh attribute it should but into the field
            float4 color : COLOR;
        };
 
        // actual surface function which does the color calculation
        void surf (Input IN, inout SurfaceOutput o) {
            // get the color value from the input structure and multiply it with the _Color property of the shader
            o.Albedo = IN.color.rgb * _Color.rgb;
            // for compatibility reasons (the shader can be easily made to support transparencies)
            // set the surfaces alpha value to the product of the vertex colors alpha and the _Color properties alpha value
            // it depends on how the alpha should be calculated (set by vertex color, set by the shaders property, a mixture of both or any other way
            o.Alpha = IN.color.a * _Color.a;
        }
        ENDCG
    } 
    // set a fallback for Unity to use when the shader fails to compile/load for rendering 
    // disable this line when you want to test the shaders functionality
    FallBack "Diffuse"
}