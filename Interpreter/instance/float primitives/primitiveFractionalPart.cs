primitiveFractionalPart
	| rcvr frac trunc |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #frac declareC: 'double frac'.
	self var: #trunc declareC: 'double trunc'.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [
			self cCode: 'frac = modf(rcvr, &trunc)'.
			self pushFloat: frac]
		ifFalse: [self unPop: 1]