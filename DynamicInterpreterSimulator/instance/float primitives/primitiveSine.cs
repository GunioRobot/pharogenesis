primitiveSine
	"Use host Smalltalk's native function."

	| rcvr |
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushFloat: rcvr sin]
		ifFalse: [self unPop: 1].