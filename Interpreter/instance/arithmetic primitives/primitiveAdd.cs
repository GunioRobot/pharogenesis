primitiveAdd

	| rcvr arg result |
	rcvr _ self stackValue: 1.
	arg _ self stackValue: 0.
	self pop: 2.
	self success: (self areIntegers: rcvr and: arg).
	successFlag ifTrue: [
		result _ (self integerValueOf: rcvr) + (self integerValueOf: arg).
	].
	self checkIntegerResult: result from: 1.
