doPrimitiveMod: rcvr by: arg
	| integerResult integerRcvr integerArg |
	(self areIntegers: rcvr and: arg)
		ifTrue: [integerRcvr _ self integerValueOf: rcvr.
				integerArg _ self integerValueOf: arg.
				self success: integerArg ~= 0]
		ifFalse: [self primitiveFail].
	successFlag ifFalse: [^ 1 "fail"].

	integerResult _ integerRcvr \\ integerArg.

	"ensure that the result has the same sign as the integerArg"
	integerArg < 0
		ifTrue: [integerResult > 0
			ifTrue: [integerResult _ integerResult + integerArg]]
		ifFalse: [integerResult < 0
			ifTrue: [integerResult _ integerResult + integerArg]].
	self success: (self isIntegerValue: integerResult).
	^ integerResult
