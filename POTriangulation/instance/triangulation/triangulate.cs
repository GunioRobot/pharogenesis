triangulate
	| triangle |
	self addBoundingTriangle.
	self points do: 
		[:point | 
		triangle _ toptriangle contains: point.
		self splitTriangle: triangle at: point.
		triangle edges do: [:edge | self legalize: edge with: point]].
	"Remove bounding triangle and incident triangles"
	self faces copy do: [:face | (face sharesCornerWith: toptriangle)
			ifTrue: [self removeTriangle: face]].
	