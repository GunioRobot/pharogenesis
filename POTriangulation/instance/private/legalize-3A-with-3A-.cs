legalize: anEdge with: aPoint 
	| triangle incidentTriangle otherPoint left right |
	triangle _ anEdge face.
	incidentTriangle _ anEdge opposite face.
	incidentTriangle isNil ifTrue: [^ self].
	otherPoint _ incidentTriangle oppositeVertexOf: anEdge opposite.
	(otherPoint
		isInsideCircle: anEdge origin
		with: anEdge destination
		with: aPoint)
		ifTrue: 
			[self removeEdge: anEdge.
			left _ self
						triangle: aPoint
						to: otherPoint
						to: anEdge origin.
			right _ self
						triangle: aPoint
						to: otherPoint
						to: anEdge destination.
			triangle addSubTriangle: left;
			 addSubTriangle: right.
			incidentTriangle addSubTriangle: left;
			 addSubTriangle: right.
			self removeTriangle: triangle;
			 removeTriangle: incidentTriangle.
			self legalize: (left oppositeEdgeOf: aPoint)
				with: aPoint.
			self legalize: (right oppositeEdgeOf: aPoint)
				with: aPoint]