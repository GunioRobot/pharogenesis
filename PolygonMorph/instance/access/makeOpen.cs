makeOpen
	closed _ false.
	handles ifNotNil: [self removeHandles; addHandles].
	self computeBounds