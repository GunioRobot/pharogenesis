primitiveSize

	| rcvr sz |
	rcvr _ self stackTop.
	(self isIntegerObject: rcvr)
		ifTrue: [sz _ 0]  "integers have no indexable fields"
		ifFalse: [sz _ self stSizeOf: rcvr].
	successFlag
		ifTrue: [self pop: 1. self pushInteger: sz]
		ifFalse: [self failSpecialPrim: 62].