registerBoundary: boundaryObject transformation: aMatrix
	| external |
	external _ boundaryObject asEdgeRepresentation: (self fullTransformFrom: aMatrix).
	self subdivideExternalEdge: external from: boundaryObject.
