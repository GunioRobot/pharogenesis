primitiveSquareRoot
	| rcvr |
	self var: #rcvr declareC: 'double rcvr'.
	rcvr _ self popFloat.
	self success: rcvr >= 0.0.
	successFlag
		ifTrue: [self pushFloat: (self cCode: 'sqrt(rcvr)' inSmalltalk: [rcvr sqrt])]
		ifFalse: [self unPop: 1]