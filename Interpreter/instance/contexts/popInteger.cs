popInteger
	| integerPointer |
	integerPointer _ self popStack.
	(self isIntegerObject: integerPointer)
		ifTrue: [^ self integerValueOf: integerPointer]
		ifFalse: [successFlag _ false.
				^ 1  "in case need SOME integer prior to fail"]