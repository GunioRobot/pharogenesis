primitiveFileRead

	| count startIndex array file byteSize arrayIndex bytesRead |
	self var: 'file' declareC: 'SQFile *file'.
	self var: 'arrayIndex' type:'char *'.
	self var: 'count' type:'size_t'.
	self var: 'startIndex' type:'size_t'.
	self var: 'byteSize' type:'size_t'.
	self export: true.
	count		_ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	startIndex	_ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 1).
	array		_ interpreterProxy stackValue: 2.
	file			_ self fileValueOf: (interpreterProxy stackValue: 3).

	"buffer can be any indexable words or bytes object except CompiledMethod"
	(interpreterProxy isWordsOrBytes: array) 
		ifFalse:[^interpreterProxy primitiveFail].

	(interpreterProxy isWords: array)
		ifTrue: [ byteSize _ 4 ]
		ifFalse: [ byteSize _ 1 ].
	((startIndex >= 1) and:
		[(startIndex + count - 1) <= (interpreterProxy slotSizeOf: array)])
			ifFalse:[^interpreterProxy primitiveFail].

	arrayIndex _ interpreterProxy firstIndexableField: array.
	"Note: adjust startIndex for zero-origin indexing"
	bytesRead _ self sqFile: file Read: (count * byteSize)
					 Into: (self cCoerce: arrayIndex to: 'int')
					   At: ((startIndex - 1) * byteSize).
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 5.  "pop rcvr, file, array, startIndex, count"
		interpreterProxy pushInteger: bytesRead // byteSize.  "push # of elements read"
	].