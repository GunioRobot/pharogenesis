primitiveAsyncFileOpen: fileName forWrite: writeFlag semaIndex: semaIndex 
	| fileNameSize fOop f |
	self var: #f declareC: 'AsyncFile *f'.
	self primitive: 'primitiveAsyncFileOpen'
		parameters: #(String Boolean SmallInteger ).

	fileNameSize _ interpreterProxy slotSizeOf: (fileName asOop: String).
	fOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray indexableSize: (self cCode: 'sizeof(AsyncFile)').
	f _ self asyncFileValueOf: fOop.
	interpreterProxy failed ifFalse: [self cCode: 'asyncFileOpen(f, (int)fileName, fileNameSize, writeFlag, semaIndex)'].
	^ fOop