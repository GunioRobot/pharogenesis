computeDirectionTo: aB3DPrimitiveVertex
	"Compute the lights direction to the given vertex"

	^ aB3DPrimitiveVertex  position - (self getPositionVector).
