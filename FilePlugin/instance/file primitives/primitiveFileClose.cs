primitiveFileClose

	| file |
	self export: true.
	self var: 'file' declareC: 'SQFile *file'.
	file _ self fileValueOf: (interpreterProxy stackValue: 0).
	interpreterProxy failed ifFalse: [ self sqFileClose: file ].
	interpreterProxy failed ifFalse: [ interpreterProxy pop: 1  "pop file; leave rcvr on stack" ].