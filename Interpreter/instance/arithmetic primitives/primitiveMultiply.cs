primitiveMultiply
	| integerRcvr integerArg integerResult |
	integerRcvr _ self stackIntegerValue: 1.
	integerArg _ self stackIntegerValue: 0.
	successFlag ifTrue:
		[integerResult _ integerRcvr * integerArg.
		"check for C overflow by seeing if computation is reversible"
		((integerArg = 0) or: [(integerResult // integerArg) = integerRcvr])
			ifTrue: [self pop2AndPushIntegerIfOK: integerResult]
			ifFalse: [self primitiveFail]]