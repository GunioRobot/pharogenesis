primitiveFileClose

	| file |
	self var: 'file' declareC: 'SQFile *file'.
	file _ self fileValueOf: self stackTop.
	successFlag ifTrue: [ self sqFileClose: file ].
	successFlag ifTrue: [ self pop: 1  "pop file; leave rcvr on stack" ].