Shader "Custom/Cull"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        //SE PUEDE EXCRIBIR AQUI

        //CULL controla que caras del poligono no deben ser mostradas
        //Cull Back  //Elimina los poligonos orientados atras del objeto
        Cull Front
        //Cull oFF


        Pass
        {
            //Todos los Shaders en Unity son programados en un lenguaje declarativo
            //llamado ShadersLab

            //CGPROGRAM
            //
            //ENDCG
            //CG es un lenguaje desarrollado por Nvidia y Microsoft, HLSL (High Level Shader Language)
            //GLSL (OpenGL Shading Language)


            //TAMBIEN SE PUEDE ESCRIBIR AQUI
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex; //Textura
            float4 _MainTex_ST;  //Tiling y Offset

            v2f vert (appdata v)   //Vertex Shader
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target  //FragmenShacer
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
