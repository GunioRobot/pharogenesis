opPrimDivide

	| rcvr arg result |
	(self initOp: PrimDivide) ifFalse: [
	self beginOp: PrimDivide.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			rcvr _ self integerValueOf: rcvr.
			arg _ self integerValueOf: arg.
			((arg ~= 0) and: [(rcvr \\ arg) = 0]) ifTrue: [
				result _ rcvr // arg.  "generates C / operation"
				(self isIntegerValue: result) ifTrue: [
					self longAt: (localSP _ localSP - 4)
							put: (self integerObjectOf: result).
					self skip: 1.
					^self nextOp.
				].
			].
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatDivide.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 9 nArgs: 1].

	self endOp: PrimDivide
	].