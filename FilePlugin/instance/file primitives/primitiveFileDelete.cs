primitiveFileDelete

	| namePointer nameIndex nameSize |
	self var: 'nameIndex' type: 'char *'.
	self export: true.
	namePointer _ interpreterProxy stackValue: 0.
	(interpreterProxy isBytes: namePointer) 
		ifFalse:[^interpreterProxy primitiveFail].
	nameIndex _ interpreterProxy firstIndexableField: namePointer.
	nameSize _ interpreterProxy byteSizeOf: namePointer.
	self sqFileDeleteName: (self cCoerce: nameIndex to: 'int') Size: nameSize.
	interpreterProxy failed 
		ifFalse:[interpreterProxy pop: 1. "pop name, leave rcvr on stack" ].
