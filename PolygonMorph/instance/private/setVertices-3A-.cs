setVertices: newVertices
	| hadHandles |
	hadHandles _ handles ifNil: [false] ifNotNil: [self removeHandles. true].
	vertices _ newVertices.
	hadHandles ifTrue: [self addHandles].
	self computeBounds