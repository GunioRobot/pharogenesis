assignmentCheck: encoder at: location

	(encoder cantStoreInto: self name)
		ifTrue: [^ location]
		ifFalse: [^ -1]
