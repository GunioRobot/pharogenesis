primitiveDivide
	| integerReceiver integerArgument |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	self success: integerArgument ~= 0.
	successFlag ifFalse: [integerArgument _ 1].  "fall through to fail"
	self success: integerReceiver \\ integerArgument = 0.
	self checkIntegerResult: integerReceiver // integerArgument from: 10