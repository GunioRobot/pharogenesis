primitiveLogN
	"Use host Smalltalk's native function."

	| rcvr |
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushFloat: rcvr ln]
		ifFalse: [self unPop: 1].