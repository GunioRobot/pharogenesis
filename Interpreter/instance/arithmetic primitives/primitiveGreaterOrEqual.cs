primitiveGreaterOrEqual
	| integerReceiver integerArgument |
	successFlag _ true.
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	self checkBooleanResult: integerReceiver >= integerArgument from: 6