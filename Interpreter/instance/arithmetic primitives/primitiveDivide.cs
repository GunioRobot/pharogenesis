primitiveDivide
	| integerReceiver integerArgument |
	integerReceiver _ self stackIntegerValue: 1.
	integerArgument _ self stackIntegerValue: 0.
	(integerArgument ~= 0 and: [integerReceiver \\ integerArgument = 0])
		ifTrue: [self pop2AndPushIntegerIfOK: integerReceiver // integerArgument]
		ifFalse: [self primitiveFail]