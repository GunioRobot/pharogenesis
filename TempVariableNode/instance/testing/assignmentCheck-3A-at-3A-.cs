assignmentCheck: encoder at: location

	self isArg ifTrue: [^ location]
			ifFalse: [^ -1]