primitiveAsFloat
	"Use host Smalltalk's native function."

	| arg |
	arg _ self popInteger.
	successFlag
		ifTrue: [self pushFloat: arg asFloat]
		ifFalse: [self unPop: 1].