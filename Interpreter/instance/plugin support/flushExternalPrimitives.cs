flushExternalPrimitives
	"Flush the references to external functions from plugin primitives.
	This will force a reload of those primitives when accessed next.
	Note: We must flush the method cache here so that any failed
	primitives are looked up again."
	| oop fmt primIdx |
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue:[
		(self isFreeObject: oop) ifFalse: [
			fmt _ self formatOf: oop.
			fmt >= 12 ifTrue:["This is a compiled method"
				primIdx _ self primitiveIndexOf: oop.
				primIdx = PrimitiveExternalCallIndex ifTrue:["It's primitiveExternalCall"
					self flushExternalPrimitiveOf: oop.
				].
			].
		].
		oop _ self objectAfter: oop.
	].
	self flushMethodCache.
	self flushObsoleteIndexedPrimitives.
	self flushExternalPrimitiveTable.