primitiveEqual
	| integerReceiver integerArgument result |
	integerArgument _ self popStack.
	integerReceiver _ self popStack.
	result _ self compare31or32Bits: integerReceiver equal: integerArgument.
	self checkBooleanResult: result