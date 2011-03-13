zoomTo: newBounds
	| scale |
	self bounds: newBounds.
	scale _ newBounds extent / toMorph fullBounds extent.
	self setOffset: toMorph position - self position angle: 0.0 scale: scale