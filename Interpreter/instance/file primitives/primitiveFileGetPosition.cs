primitiveFileGetPosition

	| file position |
	self var: 'file' declareC: 'SQFile *file'.
	file _ self fileValueOf: (self stackTop).
	successFlag ifTrue: [ position _ self sqFileGetPosition: file ].
	successFlag ifTrue: [
		self pop: 2.  "rcvr, file"
		self pushInteger: position.
	].