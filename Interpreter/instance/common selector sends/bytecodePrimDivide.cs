bytecodePrimDivide
	| rcvr arg result |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg)
		ifTrue: [rcvr _ self integerValueOf: rcvr.
			arg _ self integerValueOf: arg.
			(arg ~= 0 and: [rcvr \\ arg = 0])
				ifTrue: [result _ rcvr // arg.
					"generates C / operation"
					(self isIntegerValue: result)
						ifTrue: [self internalPop: 2 thenPush: (self integerObjectOf: result).
							^ self fetchNextBytecode"success"]]]
		ifFalse: [successFlag _ true.
			self externalizeIPandSP.
			self primitiveFloatDivide: rcvr byArg: arg.
			self internalizeIPandSP.
			successFlag ifTrue: [^ self fetchNextBytecode"success"]].

	messageSelector _ self specialSelector: 9.
	argumentCount _ 1.
	self normalSend