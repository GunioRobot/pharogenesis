updateShape
	| center median |
	newVertices isNil ifTrue: [^ self].
	median := 0 @ 0.
	newVertices do: [ :each | median := median + each].
	median := median / newVertices size.
	center := self center.
	self setVertices: (newVertices collect: [ :each | (each - median) * newScale + median]).
	self position: self position - self center + center.
	newVertices := nil