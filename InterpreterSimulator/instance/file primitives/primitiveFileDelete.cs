primitiveFileDelete 

	| namePointer |
	namePointer _ self stackTop.
	self success: (self isBytes: namePointer).
	self success: (StandardFileStream isAFileNamed: (self stringOf: namePointer)).
	successFlag ifTrue: [FileDirectory deleteFilePath: (self stringOf: namePointer)].
	successFlag ifTrue: [self pop: 1].  "pop fileName; leave rcvr on stack"
