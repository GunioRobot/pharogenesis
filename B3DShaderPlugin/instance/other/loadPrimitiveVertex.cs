loadPrimitiveVertex
	"Load the necessary values from the current primitive vertex"
	| rgba |
	self inline: true.
	rgba _ (self cCoerce: litVertex to:'int*') at: PrimVtxColor32.
	vtxInColor at: 2 put: (rgba bitAnd: 255) * (1.0 / 255.0).
	rgba _ rgba >> 8.
	vtxInColor at: 1 put: (rgba bitAnd: 255) * (1.0 / 255.0).
	rgba _ rgba >> 8.
	vtxInColor at: 0 put: (rgba bitAnd: 255) * (1.0 / 255.0).
	rgba _ rgba >> 8.
	vtxInColor at: 3 put: (rgba bitAnd: 255) * (1.0 / 255.0).
