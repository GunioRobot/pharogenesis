primitiveSubtract
	| integerReceiver integerArgument |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	self checkIntegerResult: integerReceiver - integerArgument from: 2