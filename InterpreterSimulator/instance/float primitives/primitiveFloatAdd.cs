primitiveFloatAdd
	"Use host Smalltalk's native function."

	| rcvr arg |
	arg _ self popFloatOnly.
	rcvr _ self popFloatOnly.
	successFlag
		ifTrue: [self pushFloat: rcvr + arg]
		ifFalse: [self unPop: 2].