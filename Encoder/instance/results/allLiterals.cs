allLiterals
	(literalStream isKindOf: WriteStream) ifTrue: [
		self litIndex: nil.
		self litIndex: class binding .
	].
	^ literalStream contents