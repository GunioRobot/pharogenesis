undo: undoButton with: undoSelector
	| ss |
	(ss _ self focusMorph) 
		ifNotNil: [ss undoPainting: self]
		ifNil: [self notCurrentlyPainting].
	undoButton state: #off.