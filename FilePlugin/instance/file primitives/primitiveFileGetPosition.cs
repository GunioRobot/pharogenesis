primitiveFileGetPosition
	| file position |
	self var: 'file' declareC: 'SQFile *file'.
	self export: true.
	file _ self fileValueOf: (interpreterProxy stackValue: 0).
	interpreterProxy failed ifFalse: [position _ self sqFileGetPosition: file].
	interpreterProxy failed ifFalse: [
		interpreterProxy pop: 2.
		interpreterProxy push: (interpreterProxy positive32BitIntegerFor: position)].