primitiveExp
	"Computes E raised to the receiver power."

	| rcvr |
	self var: #rcvr declareC: 'double rcvr'.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [self pushFloat: (self cCode: 'exp(rcvr)')]
		ifFalse: [self unPop: 1]