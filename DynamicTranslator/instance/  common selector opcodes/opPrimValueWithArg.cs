opPrimValueWithArg

	| block |
	(self initOp: PrimValueWithArg) ifFalse: [
	self beginOp: PrimValueWithArg.

		self skip: 1.
		block _ self internalStackValue: 1.
		successFlag _ true.
		argumentCount _ 1.
		self successIfClassOf: block is: (self splObj: ClassBlockContext).
		successFlag ifTrue: [
			self externalizeIPandSP.
			self primitiveValue.
			self internalizeIPandSP.
		].
		successFlag ifFalse: [
			self sendSpecialSelector: 26 nArgs: 1
		].

	self endOp: PrimValueWithArg
	]