primitiveArctan

	| rcvr |
	self var: #rcvr declareC: 'double rcvr'.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushFloat: (self cCode: 'atan(rcvr)')]
		ifFalse: [self unPop: 1]