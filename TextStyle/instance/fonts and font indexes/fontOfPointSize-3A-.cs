fontOfPointSize: aPointSize
	^ fontArray detect: [:aFont | aFont pointSize = aPointSize] ifNone: [nil]