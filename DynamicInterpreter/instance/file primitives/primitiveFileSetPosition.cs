primitiveFileSetPosition

	| newPosition file |
	self var: 'file' declareC: 'SQFile *file'.
	newPosition _ self stackIntegerValue: 0.
	file _ self fileValueOf: (self stackValue: 1).
	successFlag ifTrue: [ self sqFile: file SetPosition: newPosition ].
	successFlag ifTrue: [ self pop: 2 "pop position, file; leave rcvr on stack" ].