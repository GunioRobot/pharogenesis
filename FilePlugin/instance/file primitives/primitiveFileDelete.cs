primitiveFileDelete
	| namePointer nameIndex nameSize  okToDelete |
	self var: 'nameIndex' type: 'char *'.
	self export: true.
	namePointer _ interpreterProxy stackValue: 0.
	(interpreterProxy isBytes: namePointer)
		ifFalse: [^ interpreterProxy primitiveFail].
	nameIndex _ interpreterProxy firstIndexableField: namePointer.
	nameSize _ interpreterProxy byteSizeOf: namePointer.
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCDFfn ~= 0
		ifTrue: [okToDelete _ self cCode: ' ((int (*) (char *, int)) sCDFfn)(nameIndex, nameSize)'.
			okToDelete
				ifFalse: [^ interpreterProxy primitiveFail]].
	self
		sqFileDeleteName: (self cCoerce: nameIndex to: 'int')
		Size: nameSize.
	interpreterProxy failed
		ifFalse: [interpreterProxy pop: 1]