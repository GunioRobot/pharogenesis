colorComponentBlocks: blocks from: oop
	| arrayOop max blockOop |
	self var: #blocks type: 'int **'.
	(interpreterProxy isIntegerObject: oop) ifTrue:[^false].
	(interpreterProxy isPointers: oop) ifFalse:[^false].
	(interpreterProxy slotSizeOf: oop) < MinComponentSize ifTrue:[^false].

	arrayOop _ interpreterProxy fetchPointer: MCUBlockIndex ofObject: oop.
	(interpreterProxy isIntegerObject: arrayOop) ifTrue:[^false].
	(interpreterProxy isPointers: arrayOop) ifFalse:[^false].
	max _ interpreterProxy slotSizeOf: arrayOop.
	max > MaxMCUBlocks ifTrue:[^false].
	0 to: max-1 do:[:i|
		blockOop _ interpreterProxy fetchPointer: i ofObject: arrayOop.
		(interpreterProxy isIntegerObject: blockOop) ifTrue:[^false].
		(interpreterProxy isWords: blockOop) ifFalse:[^false].
		(interpreterProxy slotSizeOf: blockOop) = DCTSize2 ifFalse:[^false].
		blocks at: i put: (interpreterProxy firstIndexableField: blockOop).
	].
	^interpreterProxy failed not