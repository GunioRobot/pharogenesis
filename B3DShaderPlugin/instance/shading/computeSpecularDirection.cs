computeSpecularDirection
	"Computes
		l2vSpecDir _ l2vSpecDir - vtx position safelyNormalized.
	"
	| scale |
	self var: #scale declareC:'double scale'.
	scale _ self inverseLengthOfFloat: litVertex + PrimVtxPosition.
	l2vSpecDir at: 0 put: (l2vSpecDir at: 0) - ((litVertex at: PrimVtxPositionX) * scale).
	l2vSpecDir at: 1 put: (l2vSpecDir at: 1) - ((litVertex at: PrimVtxPositionY) * scale).
	l2vSpecDir at: 2 put: (l2vSpecDir at: 2) - ((litVertex at: PrimVtxPositionZ) * scale).
