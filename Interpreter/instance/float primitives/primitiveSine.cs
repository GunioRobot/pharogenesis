primitiveSine

	| rcvr |
	self var: #rcvr declareC: 'double rcvr'.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushFloat: (self cCode: 'sin(rcvr)' inSmalltalk: [rcvr sin])]
		ifFalse: [self unPop: 1]