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
	rotationStyle = #normal
		ifTrue: [
			scalePoint _
				((w asFloat / origExtent x) max: 0.001) @
				((h asFloat / origExtent y) max: 0.001).
			divisor abs < 0.5 ifTrue: [  "avoid instability near multiples of 45 degrees"
				s _ newExtent r / (origExtent r * 2 sqrt).
				scalePoint _ s@s]]
		ifFalse: [  "scaling for constraint rotation styles"
			scalePoint _
				((newExtent x max: 1) asFloat / origExtent x) @
				((newExtent y max: 1) asFloat / origExtent y)].
	self layoutChanged.
