extent: newExtent
	"Not really advisable, but we can preserve most of the geometry if we don't
	shrink things too small."
	| safeExtent |
	safeExtent _ newExtent max: 20@20.
	self setVertices: (vertices collect:
		[:p | p - bounds topLeft * (safeExtent asFloatPoint / (bounds extent max: 1@1)) + bounds topLeft])