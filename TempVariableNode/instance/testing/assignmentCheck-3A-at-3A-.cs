assignmentCheck: encoder at: location

	isAnArg ifTrue: [^ location]
			ifFalse: [^ -1]