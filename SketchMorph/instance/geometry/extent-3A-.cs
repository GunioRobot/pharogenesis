extent: newExtent
	"Change my scale to fit myself into the given extent."

	| radians s c divisor w h origExtent |
	radians _ rotationDegrees degreesToRadians.
	s _ radians sin abs.
	c _ radians cos abs.
	divisor _ (c * c) - (s * s).
	w _ ((c * newExtent x) - (s * newExtent y)) / divisor.
	h _ ((c * newExtent y) - (s * newExtent x)) / divisor.
	origExtent _ originalForm extent.
	scalePoint _
		((w max: 1) / origExtent x) @
		((h max: 1) / origExtent y).
	self layoutChanged.
