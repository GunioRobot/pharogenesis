stackPrimitiveIndexArray: stackIndex ofSize: nItems validate: aBool forVertexSize: maxIndex
	"Load a primitive index array from the interpreter stack.
	If aBool is true then check that all the indexes are in the range (1,maxIndex).
	Return a pointer to the index data if successful, nil otherwise."
	| oop oopSize idxPtr index |
	self inline: false.
	self returnTypeC:'void*'.
	self var: #idxPtr declareC:'int *idxPtr'.

	oop _ interpreterProxy stackObjectValue: stackIndex.
	oop = nil ifTrue:[^nil].
	(interpreterProxy isWords: oop) ifFalse:[^nil].
 	oopSize _ interpreterProxy slotSizeOf: oop.
	oopSize < nItems ifTrue:[^nil].
	idxPtr _ self cCoerce: (interpreterProxy firstIndexableField: oop) to:'int *'.
	aBool ifTrue:[
		0 to: nItems-1 do:[:i|
			index _ idxPtr at: i.
			(index < 0 or:[index > maxIndex]) ifTrue:[^nil]]].
	^idxPtr