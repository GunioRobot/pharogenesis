createSegmentFrom: anObject
	| symbolHolder |
	symbolHolder := Symbol allSymbols.
	 ^ ImageSegment new
		copyFromRoots: (Array with: anObject)
		sizeHint: 1000
		areUnique: true.