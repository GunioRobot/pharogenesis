assignmentCheck: encoder at: location

	((encoder cantStoreInto: name) or: [self isArg])
		ifTrue: [^location].
	^-1
