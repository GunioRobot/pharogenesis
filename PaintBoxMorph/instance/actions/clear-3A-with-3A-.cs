clear: clearButton with: clearSelector

	| ss |
	(ss _ self focusMorph) 
		ifNotNil: [ss clearPainting: self]
		ifNil: [self notCurrentlyPainting].
	clearButton state: #off.