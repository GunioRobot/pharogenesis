doPrimitiveDiv: rcvr by: arg
	"Rounds negative results towards negative infinity, rather than zero."
	| result posArg posRcvr integerRcvr integerArg |
	(self areIntegers: rcvr and: arg)
		ifTrue: [integerRcvr _ self integerValueOf: rcvr.
				integerArg _ self integerValueOf: arg.
				self success: integerArg ~= 0]
		ifFalse: [self primitiveFail].
	successFlag ifFalse: [^ 1 "fail"].

	integerRcvr > 0
		ifTrue: [integerArg > 0
					ifTrue: [result _ integerRcvr // integerArg]
					ifFalse: ["round negative result toward negative infinity"
							posArg _ 0 - integerArg.
							result _ 0 - ((integerRcvr + (posArg - 1)) // posArg)]]
		ifFalse: [posRcvr _ 0 - integerRcvr.
				integerArg > 0
					ifTrue: ["round negative result toward negative infinity"
							result _ 0 - ((posRcvr + (integerArg - 1)) // integerArg)]
					ifFalse: [posArg _ 0 - integerArg.
							result _ posRcvr // posArg]].
	self success: (self isIntegerValue: result).
	^ result