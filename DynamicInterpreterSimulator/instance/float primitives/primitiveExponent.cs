primitiveExponent
	"Use host Smalltalk's native function."

	| rcvr |
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushInteger: rcvr exponent]
		ifFalse: [self unPop: 1].