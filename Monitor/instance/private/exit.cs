exit
	nestingLevel _ nestingLevel - 1.
	nestingLevel < 1 ifTrue: [
		ownerProcess _ nil.
		mutex signal
	].