primitiveFileOpen
	| namePointer writeFlag fileName |
	writeFlag _ self booleanValueOf: self stackTop.
	namePointer _ self stackValue: 1.
	self success: (self isBytes: namePointer).
	successFlag ifTrue:
		[fileName _ self stringOf: namePointer.
		filesOpen addLast: (writeFlag
			ifTrue: [(FileStream fileNamed: fileName) binary]
			ifFalse: [(StandardFileStream isAFileNamed: fileName)
				ifTrue: [(FileStream oldFileNamed: fileName) readOnly; binary]
				ifFalse: [^ self primitiveFail]]).
		self pop: 3.  "rcvr, name, write"
		self pushInteger: filesOpen size]