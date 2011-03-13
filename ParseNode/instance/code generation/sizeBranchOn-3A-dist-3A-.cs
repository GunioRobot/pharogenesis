sizeBranchOn: condition dist: dist
	dist = 0 ifTrue: [^1].
	^ condition
		ifTrue: [2]  "Branch on true is always 2 bytes"
		ifFalse: [self sizeShortOrLong: dist]