bytecodePrimAdd
	| rcvr arg result |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg)
		ifTrue: [result _ (self integerValueOf: rcvr) + (self integerValueOf: arg).
				(self isIntegerValue: result) ifTrue:
					[self internalPop: 2 thenPush: (self integerObjectOf: result).
					^ self fetchNextBytecode "success"]]
		ifFalse: [successFlag _ true.
				self externalizeIPandSP.
				self primitiveFloatAdd: rcvr toArg: arg.
				self internalizeIPandSP.
				successFlag ifTrue: [^ self fetchNextBytecode "success"]].

	messageSelector _ self specialSelector: 0.
	argumentCount _ 1.
	self normalSend