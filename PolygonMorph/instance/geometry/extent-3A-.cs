extent: newExtent 
	"Not really advisable, but we can preserve most of the geometry if we don't
	shrink things too small."
	| safeExtent center |
	center _ self referencePosition.
	safeExtent _ newExtent max: 20@20.
	self setVertices: (vertices collect:
		[:p | p - center * (safeExtent asFloatPoint / (bounds extent max: 1@1)) + center])