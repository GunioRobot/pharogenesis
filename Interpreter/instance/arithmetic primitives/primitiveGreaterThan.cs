primitiveGreaterThan
	| integerReceiver integerArgument |
	integerArgument _ self popInteger.
	integerReceiver _ self popInteger.
	self checkBooleanResult: integerReceiver > integerArgument