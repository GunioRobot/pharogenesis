privateMoveBy: delta
	self releaseEditor.
	super privateMoveBy: delta.
	paragraph ifNotNil: [paragraph moveBy: delta].
	container ifNotNil: [container releaseCachedState]