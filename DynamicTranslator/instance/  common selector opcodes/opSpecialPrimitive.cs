opSpecialPrimitive

	| descriptor |
	(self initOp: SpecialPrimitive) ifFalse: [
	self beginOp: SpecialPrimitive.
		descriptor _ self fetchInteger.
		primitiveIndex _ (descriptor >> 16).
		self externalizeIPandSP.
		self primitiveResponse.
		self internalizeIPandSP.
		successFlag ifFalse: [
			self sendSpecialSelector: ((descriptor >> 8) bitAnd: 255) nArgs: (descriptor bitAnd: 255).
		].

	self endOp: SpecialPrimitive
	].