primitiveFloatGreaterThan
	"Use host Smalltalk's native function."

	| rcvr arg |
	arg _ self popFloat.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushBool: rcvr > arg]
		ifFalse: [self unPop: 2].