bytecodePrimSize
	"See the comment in bytePrimitiveAt"

	| arrayClass |
	self externalizeIPandSP.
	successFlag _ true.
	arrayClass _ self fetchClassOf: (self stackValue: 0).
	(self okStreamArrayClass: arrayClass)
		ifTrue: [self primitiveSize]
		ifFalse: [self failSpecialPrim: 0].
	self internalizeIPandSP.
