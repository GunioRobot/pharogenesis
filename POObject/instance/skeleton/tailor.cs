tailor
	| edge |
	self polygon circulation = #left ifTrue: [self polygon reverseCirculation].
	self polygon do: 
		[:point | 
		edge _ self triangulation edgeFrom: point to: (self polygon after: point).
		edge opposite setTag: #border.
		edge face
			ifNotNil: 
				[self triangulation removeTriangle: edge face.
				edge face: nil]]