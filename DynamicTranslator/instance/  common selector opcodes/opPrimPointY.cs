opPrimPointY

	(self initOp: PrimPointY) ifFalse: [
	self beginOp: PrimPointY.

		self skip: 1.
		self externalizeIPandSP.
		self primitivePointY.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 31 nArgs: 0].

	self endOp: PrimPointY
	]