// This has to match the data in the vertex buffer.
struct VS_IN {
	float3 pos : POSITION;
	float3 color : COLOR;
};

struct VS_OUT {
	float4 pos : SV_POSITION;
	float3 color : COLOR;
};

struct PS_IN {
	float4 pos : SV_POSITION;
	float3 color : COLOR;
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
	result.pos = mul(result.pos, view);
	result.pos = mul(result.pos, projection);

	// Pass through the color
	result.color = input.color;

	return result;
}

PS_OUT PSMain(PS_IN input) {
	PS_OUT result = (PS_OUT)0;

	result.color = float4(input.color, 1.0f);

	return result;
}
