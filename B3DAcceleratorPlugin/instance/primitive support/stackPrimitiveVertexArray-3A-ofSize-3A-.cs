stackPrimitiveVertexArray: index ofSize: nItems
	"Load a primitive vertex array from the interpreter stack.
	Return a pointer to the vertex data if successful, nil otherwise."
	| oop oopSize |
	self inline: false.
	self returnTypeC:'void*'.
	oop _ interpreterProxy stackObjectValue: index.
	oop = nil ifTrue:[^nil].
	(interpreterProxy isWords: oop) ifTrue:[
 		oopSize _ interpreterProxy slotSizeOf: oop.
		(oopSize >= nItems * PrimVertexSize and:[oopSize \\ PrimVertexSize = 0])
			ifTrue:[^interpreterProxy firstIndexableField: oop]].
	^nil