primitiveFileSetPosition
	| newPosition file |
	self var: 'file' declareC: 'SQFile *file'.
	self export: true.
	newPosition _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	file _ self fileValueOf: (interpreterProxy stackValue: 1).
	interpreterProxy failed ifFalse:[
		self sqFile: file SetPosition: newPosition ].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 2 "pop position, file; leave rcvr on stack" ].