storePrimitiveVertex
	"Store the computed output color back into the current primitive vertex.
	Clamp the r,g,b,a part to be in the range 0-255."
	| r g b a |
	self inline: true.
	r _ ((vtxOutColor at: 0) * 255) asInteger.
	r _ (r min: 255) max: 0.
	g _ ((vtxOutColor at: 1) * 255) asInteger.
	g _ (g min: 255) max: 0.
	b _ ((vtxOutColor at: 2) * 255) asInteger.
	b _ (b min: 255) max: 0.
	a _ ((vtxOutColor at: 3) * 255) asInteger.
	a _ (a min: 255) max: 0.
	"The following is equal to b + (g << 8) + (r << 16) + (a << 24)"
	(self cCoerce: litVertex to:'int*') 
		at: PrimVtxColor32 put: b + (g + (r + (a << 8) << 8) << 8). 
