primitiveTimesTwoPower
	| rcvr arg |
	self var: #rcvr declareC: 'double rcvr'.
	arg _ self popInteger.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [ self pushFloat: (self cCode: 'ldexp(rcvr, arg)') ]
		ifFalse: [ self unPop: 2 ].