primitiveAsyncFileOpen: fileName forWrite: writeFlag semaIndex: semaIndex 
	| fileNameSize fOop f okToOpen |
	self var: #f declareC: 'AsyncFile *f'.
	self primitive: 'primitiveAsyncFileOpen' parameters: #(#String #Boolean #SmallInteger ).
	fileNameSize _ interpreterProxy slotSizeOf: (fileName asOop: String).
	"If the security plugin can be loaded, use it to check for permission.
	If not, assume it's ok"
	sCOAFfn ~= 0
		ifTrue: [okToOpen _ self cCode: ' ((int (*) (char *, int, int)) sCOAFfn)(fileName, fileNameSize, writeFlag)'.
			okToOpen ifFalse: [^ interpreterProxy primitiveFail]].
	fOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray indexableSize: (self cCode: 'sizeof(AsyncFile)').
	f _ self asyncFileValueOf: fOop.
	interpreterProxy failed ifFalse: [self cCode: 'asyncFileOpen(f, (int)fileName, fileNameSize, writeFlag, semaIndex)'].
	^ fOop