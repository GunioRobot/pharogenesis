bytecodePrimNotEqual
	| rcvr arg aBool |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue: [^self booleanCheat: rcvr ~= arg].

	successFlag _ true.
	aBool _ self primitiveFloatEqual: rcvr toArg: arg.
	successFlag ifTrue: [^self booleanCheat: aBool not].

	messageSelector _ self specialSelector: 7.
	argumentCount _ 1.
	self normalSend
