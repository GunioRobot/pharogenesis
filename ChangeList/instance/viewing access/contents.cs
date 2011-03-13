contents
	^ listIndex = 0
		ifTrue: ['']
		ifFalse: [(changeList at: listIndex) string]