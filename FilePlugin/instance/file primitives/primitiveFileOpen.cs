primitiveFileOpen

	| writeFlag namePointer filePointer file nameIndex nameSize |
	self var: 'file' declareC: 'SQFile *file'.
	self var: 'nameIndex' type:'char *'.
	self export: true.
	writeFlag _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	namePointer _ interpreterProxy stackValue: 1.
	(interpreterProxy isBytes: namePointer) 
		ifFalse:[^interpreterProxy primitiveFail].
	filePointer _ interpreterProxy 
					instantiateClass: (interpreterProxy classByteArray)
					indexableSize: self fileRecordSize.
	file _ self fileValueOf: filePointer.
	nameIndex _ interpreterProxy firstIndexableField: namePointer.
	nameSize _ interpreterProxy byteSizeOf: namePointer.
	interpreterProxy failed ifFalse:[
		self cCode: 'sqFileOpen(file, (int)nameIndex, nameSize, writeFlag)'.
	].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 3.  "rcvr, name, writeFlag"
		interpreterProxy push: filePointer.
	].