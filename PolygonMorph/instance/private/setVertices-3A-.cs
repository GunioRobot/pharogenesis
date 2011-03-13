setVertices: newVertices
	vertices _ newVertices.
	handles ifNotNil: [self removeHandles; addHandles].
	self computeBounds