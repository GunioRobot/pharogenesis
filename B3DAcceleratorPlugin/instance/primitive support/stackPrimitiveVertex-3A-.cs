stackPrimitiveVertex: index
	"Load a primitive vertex from the interpreter stack.
	Return a pointer to the vertex data if successful, nil otherwise."
	| oop |
	self inline: false.
	self returnTypeC:'void*'.
	oop _ interpreterProxy stackObjectValue: index.
	oop = nil ifTrue:[^nil].
	((interpreterProxy isWords: oop) and:[(interpreterProxy slotSizeOf: oop) = PrimVertexSize])
		ifTrue:[^interpreterProxy firstIndexableField: oop].
	^nil