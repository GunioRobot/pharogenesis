primitiveSize
	| rcvr sz |
	rcvr _ self stackTop.
	(self isIntegerObject: rcvr) ifTrue: [^ self primitiveFail].  "Integers are not indexable"
	(self formatOf: rcvr) < 2 ifTrue: [^ self primitiveFail].  "This is not an indexable object"
	sz _ self stSizeOf: rcvr.
	successFlag ifTrue:
		[self pop: 1 thenPush: (self positive32BitIntegerFor: sz)]
