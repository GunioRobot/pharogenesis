primitiveFileAtEnd

	| file atEnd |
	self var: 'file' declareC: 'SQFile *file'.
	file _ self fileValueOf: self stackTop.
	successFlag ifTrue: [ atEnd _ self sqFileAtEnd: file ].
	successFlag ifTrue: [
		self pop: 2.  "rcvr, file"
		self pushBool: atEnd.
	].