bytecodePrimMultiply
	| rcvr arg result |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg)
		ifTrue: [rcvr _ self integerValueOf: rcvr.
				arg _ self integerValueOf: arg.
				result _ rcvr * arg.
				((arg = 0 or: [(result // arg) = rcvr]) and: [self isIntegerValue: result])
					ifTrue: [self internalPop: 2 thenPush: (self integerObjectOf: result).
							^ self fetchNextBytecode "success"]]
		ifFalse: [successFlag _ true.
				self externalizeIPandSP.
				self primitiveFloatMultiply: rcvr byArg: arg.
				self internalizeIPandSP.
				successFlag ifTrue: [^ self fetchNextBytecode "success"]].

	messageSelector _ self specialSelector: 8.
	argumentCount _ 1.
	self normalSend.
