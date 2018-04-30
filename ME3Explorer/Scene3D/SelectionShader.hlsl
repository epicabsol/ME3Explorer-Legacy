// This has to match the data in the vertex buffer.
struct VS_IN {
	float3 pos : POSITION;
	float3 normal : NORMAL;
	float2 uv : TEXCOORD0;
};

struct VS_OUT {
	float4 pos : SV_POSITION;
	float3 worldpos : COLOR0;
	float3 normal : NORMAL;
	float2 uv : TEXCOORD0;
};

struct PS_IN {
	float4 pos : SV_POSITION;
	float3 worldpos : COLOR0;
	float3 normal : NORMAL;
	float2 uv : TEXCOORD0;
};

struct PS_OUT {
	float4 color : SV_TARGET;
};

cbuffer constants {
	float4x4 projection;
	float4x4 view;
	float4x4 model;
};

VS_OUT VSMain(VS_IN input) {
	VS_OUT result = (VS_OUT)0;

	// Transform the input object-space position into a screen-space position
	result.pos = mul(float4(input.pos, 1), model);
	result.worldpos = result.pos;
	result.pos = mul(result.pos, view);
	result.pos = mul(result.pos, projection);

	// Pass through the normal
	result.normal = mul(input.normal, model);

	// Pass through the uv coordinate
	result.uv = input.uv;

	return result;
}

PS_OUT PSMain(PS_IN input) {
	PS_OUT result = (PS_OUT)0;

	// just color everything white
	//result.color = float4(1.0, 1.0, 1.0, 1.0);

	// use the texture
	//result.color = tex2D(sam, input.uv);
	//result.color = tex.Sample(samstate, input.uv);
	float t = fmod((input.worldpos.x + input.worldpos.y + input.worldpos.z) * 0.01f, 1.0f);
	result.color = float4(t, 1.0f, t, 1.0f); //lerp(float4(1.0f, 1.0f, 1.0f, 1.0f), float4(0.3f, 1.0f, 0.6f, 1.0f), t);

	return result;
}
