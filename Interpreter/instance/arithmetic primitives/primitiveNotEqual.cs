primitiveNotEqual
	| integerReceiver integerArgument result |
	successFlag _ true.
	integerArgument _ self popStack.
	integerReceiver _ self popStack.
	result _ (self compare31or32Bits: integerReceiver equal: integerArgument) not.
	self checkBooleanResult: result from: 8