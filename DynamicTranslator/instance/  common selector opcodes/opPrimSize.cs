opPrimSize
	"See the comment in bytePrimitiveAt"

	| arrayClass |
	(self initOp: PrimSize) ifFalse: [
	self beginOp: PrimSize.

		self skip: 1.
		arrayClass _ self fetchClassOf: (self internalStackValue: 0).
		(self okStreamArrayClass: arrayClass) ifTrue: [
			self externalizeIPandSP.
			self primitiveSize.
			self internalizeIPandSP.
		] ifFalse: [
			self sendSpecialSelector: 18 nArgs: 0.
		].

	self endOp: PrimSize
	]