selection
	^ listIndex = 0 
		ifFalse: [list at: listIndex]
		ifTrue: [nil]