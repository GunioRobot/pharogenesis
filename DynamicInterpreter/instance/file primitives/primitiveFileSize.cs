primitiveFileSize

	| file size |
	self var: 'file' declareC: 'SQFile *file'.
	file _ self fileValueOf: (self stackTop).
	successFlag ifTrue: [ size _ self sqFileSize: file ].
	successFlag ifTrue: [
		self pop: 2.  "rcvr, file"
		self pushInteger: size.
	].