primitiveFileFlush
	| file |
	self var: 'file' declareC: 'SQFile *file'.
	self export: true.
	file _ self fileValueOf: (interpreterProxy stackValue: 0).
	interpreterProxy failed ifFalse:[self sqFileFlush: file].
	interpreterProxy failed ifFalse: [interpreterProxy pop: 1].