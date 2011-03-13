undo: undoButton with: undoSelector evt: evt
	| ss |
	(ss _ self focusMorph) 
		ifNotNil: [ss undoPainting: self evt: evt]
		ifNil: [self notCurrentlyPainting].
	undoButton state: #off.