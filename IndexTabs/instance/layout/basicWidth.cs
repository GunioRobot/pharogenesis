basicWidth
	basicWidth ifNil: [basicWidth _ owner ifNotNil: [owner width] ifNil: [100]].
	^ basicWidth