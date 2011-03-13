assignmentCheck: encoder at: location
	^((self isBlockArg and: [Preferences allowBlockArgumentAssignment not])
	    or: [self isMethodArg])
			ifTrue: [location]
			ifFalse: [-1]