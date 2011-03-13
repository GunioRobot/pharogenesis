computeBounds
	vertices ifNil: [^ self].
	self changed.
	self releaseCachedState.
	bounds _ self curveBounds.
	self arrowForms do:
		[:f | bounds _ bounds merge: (f offset extent: f extent)].
	handles ifNotNil: [self updateHandles].
	self layoutChanged.
	self changed