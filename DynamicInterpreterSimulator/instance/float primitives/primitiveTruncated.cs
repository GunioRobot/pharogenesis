primitiveTruncated
	"Use host Smalltalk's native function."

	| rcvr |
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushInteger: rcvr truncated]
		ifFalse: [self unPop: 1].