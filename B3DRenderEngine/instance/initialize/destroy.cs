destroy
	"Utility - destroy all resources associated with any part of the engine"
	transformer ifNotNil:[transformer destroy].
	shader ifNotNil:[shader destroy].
	clipper ifNotNil:[clipper destroy].
	rasterizer ifNotNil:[rasterizer destroy].
	transformer _ shader _ clipper _ rasterizer _ nil.