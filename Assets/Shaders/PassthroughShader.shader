Shader "Custom/PassthroughShader"
{
    Properties 
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader 
    {
        Tags { "RenderType" = "Opaque" }
        CGPROGRAM
            #pragma surface surf Passthrough noambient alpha

            half4 LightingPassthrough (SurfaceOutput s, half3 lightDir, half atten) 
            {
                half NdotL = dot (s.Normal, lightDir);
                half4 c;
                c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten);
                
                c.a = 0.0;
                if(NdotL * atten > 0.1)
                    c.a = 0.2;
                return c;
            }

        struct Input 
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;

        void surf (Input IN, inout SurfaceOutput o) 
        {
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
