opPrimValue

	| block |
	(self initOp: PrimValue) ifFalse: [
	self beginOp: PrimValue.

		self skip: 1.
		block _ self internalStackTop.
		successFlag _ true.
		argumentCount _ 0.
		self successIfClassOf: block is: (self splObj: ClassBlockContext).
		successFlag ifTrue: [
			self externalizeIPandSP.
			self primitiveValue.
			self internalizeIPandSP.
		].
		successFlag ifFalse: [
			self sendSpecialSelector: 25 nArgs: 0
		].

	self endOp: PrimValue
	]