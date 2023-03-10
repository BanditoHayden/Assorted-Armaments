sampler uImage0 : register ( s0 ) ;
float4 PixelShaderFunction ( float2 coords : TEXCOORD0 ) : COLOR0 {
    float4 color = tex2D ( uImage0, coords ) ;
    if ( ! any ( color )) 
        return color;
    float gs = dot ( float3 ( 0.3 , 0.59 , 0.11 ) , color. rgb ) ;
    return float4 ( gs, gs, gs, color. a ) ; 
}
technique Technique1 {
    pass Greyscale {
        PixelShader = compile ps_2_0 PixelShaderFunction () ;
    }
}