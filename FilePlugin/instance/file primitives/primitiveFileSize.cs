primitiveFileSize
	| file size |
	self var: 'file' declareC: 'SQFile *file'.
	self var: 'size' type: 'squeakFileOffsetType'.
	self export: true.
	file _ self fileValueOf: (interpreterProxy stackValue: 0).
	interpreterProxy failed ifFalse:[size _ self sqFileSize: file].
	interpreterProxy failed ifFalse: [
		interpreterProxy pop: 2.
		interpreterProxy push: (interpreterProxy positive64BitIntegerFor: size)].