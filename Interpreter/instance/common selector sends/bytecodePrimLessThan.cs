bytecodePrimLessThan
	| rcvr arg bool |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue:
		[self cCode: '' inSmalltalk: 
			[^ self booleanCheat:
				(self integerValueOf: rcvr) < (self integerValueOf: arg)].
		^ self booleanCheat: rcvr < arg].

	successFlag _ true.
	bool _ self primitiveFloatLess: rcvr thanArg: arg.
	successFlag ifTrue:
		[^ self booleanCheat: bool].

	messageSelector _ self specialSelector: 2.
	argumentCount _ 1.
	self normalSend
