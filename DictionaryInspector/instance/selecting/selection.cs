selection

	selectionIndex = 0 ifTrue: [^ ''].
	^ object at: (keyArray at: selectionIndex)