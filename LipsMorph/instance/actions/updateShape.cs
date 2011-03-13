updateShape
	| center median |
	newVertices isNil ifTrue: [^ self].
	median _ 0 @ 0.
	newVertices do: [ :each | median _ median + each].
	median _ median / newVertices size.
	center _ self center.
	self setVertices: (newVertices collect: [ :each | (each - median) * newScale + median]).
	self position: self position - self center + center.
	newVertices _ nil