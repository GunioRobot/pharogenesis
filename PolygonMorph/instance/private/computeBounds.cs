computeBounds
	self changed.
	bounds _ self curveBounds.
	self releaseCachedState.
	self arrowForms ifNotNil:
		[self arrowForms do:
		[:f | bounds _ bounds merge: (f offset extent: f extent)]].
	handles ifNotNil: [self updateHandles].
	self layoutChanged.
	self changed