bytecodePrimEqual
	| rcvr arg bool |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue:
		[^ self booleanCheat: rcvr = arg].

	successFlag _ true.
	bool _ self primitiveFloatEqual: rcvr toArg: arg.
	successFlag ifTrue:
		[^ self booleanCheat: bool].

	messageSelector _ self specialSelector: 6.
	argumentCount _ 1.
	self normalSend
