primitiveFileOpen
	| writeFlag namePointer filePointer nameIndex nameSize |
	self var: 'nameIndex' type: 'char *'.
	self export: true.
	writeFlag _ interpreterProxy
				booleanValueOf: (interpreterProxy stackValue: 0).
	namePointer _ interpreterProxy stackValue: 1.
	(interpreterProxy isBytes: namePointer)
		ifFalse: [^ interpreterProxy primitiveFail].
	nameIndex _ interpreterProxy firstIndexableField: namePointer.
	nameSize _ interpreterProxy byteSizeOf: namePointer.
	filePointer _ self fileOpenName: nameIndex size: nameSize write: writeFlag secure: true.
	interpreterProxy failed
		ifFalse: [interpreterProxy pop: 3.
			"rcvr, name, writeFlag"
			interpreterProxy push: filePointer]
