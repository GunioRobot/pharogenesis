computeDirectionTo: aB3DPrimitiveVertex
	"A directional light has an explicit direction regardless of the vertex position"

	^ (self getRotationVector).