primitiveFractionalPart
	"Use host Smalltalk's native function."

	| rcvr |
	rcvr _ self popFloatOnly.
	successFlag
		ifTrue: [self pushFloat: rcvr fractionPart]
		ifFalse: [self unPop: 1].