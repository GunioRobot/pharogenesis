splitTriangle: boundingTriangle at: point 
	| triangle |
	boundingTriangle edges do: 
		[:edge | 
		triangle _ self
					triangle: edge origin
					to: edge destination
					to: point.
		boundingTriangle addSubTriangle: triangle].
	self removeTriangle: boundingTriangle