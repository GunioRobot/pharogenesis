opPrimPointX

	(self initOp: PrimPointX) ifFalse: [
	self beginOp: PrimPointX.

		self skip: 1.
		self externalizeIPandSP.
		self primitivePointX.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 30 nArgs: 0].

	self endOp: PrimPointX
	]