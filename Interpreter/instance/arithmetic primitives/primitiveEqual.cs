primitiveEqual
	| integerReceiver integerArgument result |
	successFlag _ true.
	integerArgument _ self popStack.
	integerReceiver _ self popStack.
	result _ self compare31or32Bits: integerReceiver equal: integerArgument.
	self checkBooleanResult: result from: 7