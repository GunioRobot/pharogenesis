findContext
	| initialProcessIndex initialStackIndex found |
	initialProcessIndex _ self processListIndex.
	initialStackIndex _ self stackListIndex.
	searchString _ FillInTheBlank request: 'Enter a string to search for in the process stack lists' initialAnswer: searchString.
	searchString isEmpty
		ifTrue: [^ false].
	self processListIndex: 1.
	self stackListIndex: 1.
	found _ self nextContext.
	found
		ifFalse: [self processListIndex: initialProcessIndex.
			self stackListIndex: initialStackIndex].
	^ found